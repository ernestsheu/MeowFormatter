'''
Key: MeowFormater
Code Lay-out
https://peps.python.org/pep-0008/#code-lay-out
https://peps.python.org/pep-0008/#whitespace-in-expressions-and-statements

Already implemented
  - Blank Lines
     + Only one blank line is allowed
  - Convert tabs to spaces
  - Remove line-end whitespace

  Whitespace in Expressions and Statements
    - Operators
    - Comma
    - Annotation

Special Cases: (Custom rules)
  - Special: Check the keyword "#-#--" and fix its length

Python typing
https://docs.python.org/3/library/typing.html

'''
import os
import re
import sys
import logging
import tokenize

from time import time

_logger = logging.getLogger('code_layout')

# ref: https://www.w3schools.com/python/python_operators.asp
# Arithmetic Operators
#   '+', '-', '*', '/', '%', '**', '//'
# Assignment Operators
#   '=', '+=', '-=', '*=', '/=', '%=', '//=', '**=', '&=', '|=',
#   '^=', '>>=', '<<='
# Comparison Operators
#   '==', '!=', '<', '>', '<>', '<=', '>='
# Logical Operators
#   'and', 'or', 'not'
# Bitwise Operators
#   '&', '|', '^', '~', '<<', '>>'

# 1 letter, skip '%', '~', '+', '-', '*', '='
_1L_OPERATOR_SIGN = ('/', '>', '<', '&', '|', '^')

# 2 letters, skip '**'
_2L_OPERATOR_SIGN = (
    '//', '+=', '-=', '*=', '/=', '%=', '&=', '|=', '^=', '@=',
    '==', '!=', '<>', '<=', '>=', '<<', '>>'
    )

# 3 letters
_3L_OPERATOR_SIGN = (
    '//=', '**=', '>>=', '<<='
    )
_LOG_OPERATOR_SIGN = ('and', 'or', 'not')

_1L_IGNORES = tuple(list(_2L_OPERATOR_SIGN) + list(_3L_OPERATOR_SIGN) \
                        + ['--', '#-', '-#'])
_2L_IGNORES = tuple(list(_3L_OPERATOR_SIGN) + [])

_RE_STRING = re.compile(tokenize.String)
_RE_STR_TRIPLE = re.compile(tokenize.Triple)
_RE_COMMENT = re.compile('(\'|")?' + tokenize.Comment)
_RE_TYPING_RETURN = re.compile('->')

ignore_comments = [
    # '#-- coding:',
    # '#-*-',
    '#!',    
]

def _within_ignores(pos, ignore_list):
    for anno in ignore_list:
        if anno[0] <= pos < anno[1]:
            return True
    return False

def _ll_c1(lines, *args, **kwargs):
    new_lines = []
    blank_count = 0

    # Remove line-end whitespace
    # Remove more blank lines
    # Special: Check the keyword "#-#--" and fix its length
    # Convert tabs to spaces
    for ll in lines:
        ll = ll.rstrip()
        
        if any(ll.startswith(ign_str) for ign_str in ignore_comments):
            new_lines.append(ll)
            continue
        
        ll = re.sub("\t", "    ", ll)
        if '#-#--' in ll:
            while len(ll) > 80: ll = ll[:-1]
            while len(ll) < 80: ll += '-'
        if not ll:
            blank_count += 1
        else:
            blank_count = 0

        if blank_count < 2:
            new_lines.append(ll)

    return new_lines

def _ll_string(content, ignore_comment = False, *arg, **kwargs):
    docstr_list = [m for m in _RE_STR_TRIPLE.finditer(content)]
    string_list = [m for m in _RE_STRING.finditer(content)]
    typing_list = [m for m in _RE_TYPING_RETURN.finditer(content)]

    last_pos = len(content)
    ignore_list = []
    if docstr_list:
        if len(docstr_list) == 1:
            ignore_list += [(docstr_list[0].start(), last_pos)]
        else:
            ignore_list += [(docstr_list[0].start(), docstr_list[-1].end())]

    if string_list:
        ignore_list += [(m.start(), m.end()) for m in string_list]

    if typing_list:
        ignore_list += [(m.start(), m.end()) for m in typing_list]

    if ignore_comment:
        return ignore_list

    comment_list = [m for m in _RE_COMMENT.finditer(content)]
    comment_list = [m for m in comment_list if not _within_ignores(m.start(), ignore_list)]
    ignore_list += [(m.start(), last_pos) for m in comment_list]

    if not comment_list and content.count('#') > 1:        
        last_comment_pos = content.rindex('#')
        if not _within_ignores(last_comment_pos, ignore_list):
            ignore_list.append((last_comment_pos, last_pos))

    # for r in ignore_list:
    #    _logger.error('%02d-%02d: %s' % (r[0], r[1], content[r[0]:r[1]]))

    # tmp_ignores = ignore_list[:]
    # _logger.info('xxxxxxxxx - xxxxxxxxxxxxxx')
    # for pattern in ["(\d+.)?\d+E-\d+"]:
    #     tmp_list = []
    #     for m in re.finditer(pattern, content):
    #         if _within_ignores(m.start(), tmp_ignores):
    #             continue
    #         tmp_list.append((m.start(), m.end()))
    #         _logger.info('xxx - %s', m)
    #     ignore_list += tmp_list
        
    return ignore_list

def _ll_operator(content, *arg, **kwargs):
    op1_prog = re.compile('(\S)?([{}])(\S)?'.format('\\'.join(_1L_OPERATOR_SIGN)))

    op2_operators = ['\\' + '\\'.join(list(sign)) for sign in _2L_OPERATOR_SIGN]
    op2_prog = re.compile('(\S)?({})(\S)?'.format('|'.join(op2_operators)))

    op3_operators = ['\\' + '\\'.join(list(sign)) for sign in _3L_OPERATOR_SIGN]
    op3_prog = re.compile('(\S)?({})(\S)?'.format('|'.join(op3_operators)))

    tmp_cont = content
    while True:
        ignore_list = _ll_string(tmp_cont)
        m_list = [(m, _1L_IGNORES) for m in op1_prog.finditer(tmp_cont)]
        m_list += [(m, _2L_IGNORES) for m in op2_prog.finditer(tmp_cont)]
        m_list += [(m, None) for m in op3_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_op(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    op4_prog = re.compile('(\w+)(\+|\-|\*|\*\*)(\w+)')
    while True:
        ignore_list = _ll_string(tmp_cont)
        m_list = [(m, None) for m in op4_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]

        ret_cont = tmp_cont
        for m in m_list:
            # check float
            if re.search('(\d+.)?\d+E-\d+', m[0].group()):
                continue            
            keys = repl_op(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    op5_prog = re.compile('(\))?(\+|\-|\*|\*\*)(\()?')
    tmp_cont = tmp_cont
    while True:
        ignore_list = _ll_string(tmp_cont)
        m_list = [(m, None) for m in op5_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_op2(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    return ret_cont

def repl_comma2(m, *arg, **kwargs):
    rep = m.groups()

    if m.start() == 0 and rep[3] is None:
        return '{}{}{}'.format(rep[0], rep[1], rep[2])
    elif m.start() == 0 and rep[3]:
        return '{}{}{} {}'.format(rep[0], rep[1], rep[2], rep[3])
    elif rep[0] is None and rep[3]:
        return '{} {}'.format(rep[2], rep[3])
    elif rep[0] == ' ' and rep[1] is None and rep[3]:
        return '{} {}'.format(rep[2], rep[3])
    elif rep[0] == ' ' and rep[1] and rep[3]:
        return '{}{}{} {}'.format(rep[0], rep[1], rep[2], rep[3])
    else:
        return rep[2]

def _ll_whitespace_comma(content, *arg, **kwargs):
    prog1 = re.compile('(\s)?(\s+)?(,)(\S)?')
    tmp_cont = content
    while True:
        ignore_list = _ll_string(tmp_cont)
        m_list = [(m, None) for m in prog1.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        # m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]
        tmp_list = m_list
        m_list = []
        for m in tmp_list:
            pos = m[0].start()
            rel = m[0].groups()
            if rel[0]:
                pos += len(rel[0])
            if rel[1]:
                pos += len(rel[1])
            if _within_ignores(pos, ignore_list):
                continue
            m_list.append(m)

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_comma2(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    ret_cont = ret_cont.replace(', )', ',)')
    ret_cont = ret_cont.replace(', ]', ',]')

    return ret_cont

def _ll_whitespace_equal(content, *arg, **kwargs):
    prog1 = re.compile('(\S)?(=)(\S)?')
    tmp_cont = content
    while True:
        ignore_list = _ll_string(tmp_cont)
        m_list = [(m, _1L_IGNORES) for m in prog1.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        # m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]
        tmp_list = m_list
        m_list = []
        for m in tmp_list:
            pos = m[0].start()
            rel = m[0].groups()
            if rel[0]:
                pos += len(rel[0])
            if _within_ignores(pos, ignore_list):
                continue
            m_list.append(m)

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_equal(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break

        tmp_cont = ret_cont
    return ret_cont

def repl_dict2(m, **kwargs):
    matched = m.group()
    rep = m.groups()
    ignores = kwargs.get('ignores', None)
    if ignores and any(operator in matched for operator in ignores):
        return matched
    #if any(p in rep[0] for p in ['\'', '"']):
    #    return matched
    return '{}{} '.format(rep[0], rep[2])

def _ll_whitespace_dict(content, *arg, **kwargs):
    # prog1 = re.compile('\\"(.*)\\"(\s+)?(:)(\s+)?')
    # prog2 = re.compile("\\'(.*)\\'(\s+)?(:)(\s+)?")
    prog1 = re.compile(r"('[^\n'\\]*(?:\\.[^\n'\\]*)*')(\s+)?(:)(\s+)?")
    prog2 = re.compile(r'("[^\n"\\]*(?:\\.[^\n"\\]*)*")(\s+)?(:)(\s+)?')

    tmp_cont = content
    ignores = tuple('\n')
    ignore_list = _ll_string(tmp_cont)
    m_list = [(m, ignores) for m in prog1.finditer(tmp_cont)]
    m_list += [(m, ignores) for m in prog2.finditer(tmp_cont)]

    m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
    # m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]
    tmp_list = m_list
    m_list = []
    for m in tmp_list:
        pos = m[0].start()
        rel = m[0].groups()
        if rel[0]:
            pos += len(rel[0])
        if rel[1]:
            pos += len(rel[1])
        if _within_ignores(pos, ignore_list):
           continue
        m_list.append(m)
        #_logger.error('%02d-%02d: %s',
        #                m[0].start(), m[0].end(), m[0].groups())

    ret_cont = tmp_cont
    for m in m_list:
        keys = repl_dict2(m[0], ignores = m[1])
        if keys == m[0].group():
            continue
        ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        tmp_cont = ret_cont
    return ret_cont

def _ll_whitespace_comment(content, *arg, **kwargs):
    if '#-#--' in content:
        return content
    if '#!/' in content:
        return content

    prog = re.compile(r"([ ]*)?(#)([ ])?")

    tmp_cont = content
    ignore_list = _ll_string(tmp_cont, ignore_comment = True)

    m = prog.search(content)
    if m is None:
        return content

    pos = m.start()
    if _within_ignores(pos, ignore_list):
        return content
    old_str = m.group()    
    new_str = ''.join(m.groups()[:2]) + ' '
    content = content.replace(old_str, new_str, 1)

    return content

def _ll_c2(lines, *args, **kwargs):
    new_lines = []

    docstring = False
    for ll in lines:
        if not docstring:
            ll = _ll_whitespace_comma(ll)
            ll = _ll_operator(ll)
            ll = _ll_whitespace_equal(ll)
            ll = _ll_whitespace_dict(ll)
            ll = _ll_whitespace_comment(ll)
        docstr_list = [m for m in _RE_STR_TRIPLE.finditer(ll)]
        if len(docstr_list) == 1:
            docstring = not docstring
        ll = ll.rstrip()
        new_lines.append(ll)

    return new_lines

def _pt_cvt_tab_to_space(content, *args, **kwargs):
    return re.sub("\t", "    ", content)

def search_comment_position(content):
    prog1 = re.compile('(\'|")?#(\s+)?([^\r\n]*)')
    ignore_list = []

    for m in prog1.finditer(content):
        rel = m.groups()
        if rel[0] and re.search('(\'|")#([0-9A-Fa-f]{6})(\'|")', m.group()):
            continue
        if any(s in m.group() for s in ignore_comments):
            continue
        ignore_list.append((m.start(), m.end()))

    # print(ignore_list)
    #for r in ignore_list:
    #    _logger.error('%02d-%02d: %s' % (r[0], r[1], content[r[0]:r[1]]))
    return ignore_list

def search_string_position(content):
    ignore_list = []

    # ignore_list += search_comment_position(content)

    for pattern in ["'''", '"""']:
        tmp_list = []
        for m in re.finditer(pattern, content):
            tmp_list.append((m.start(), m.end()))
        assert len(tmp_list) % 2 == 0, 'The declared annotation is illegal.'
        ignore_list += [(tmp_list[idx][0], tmp_list[idx + 1][1])
                            for idx in range(0, len(tmp_list), 2)]

    tmp_ignores = ignore_list[:]
    for pattern in ["'([\s\S]*?)'", '"([\s\S]*?)"']:
        tmp_list = []
        for m in re.finditer(pattern, content):
            if _within_ignores(m.start(), tmp_ignores):
                continue
            if '\n' in m.group():
                continue
            tmp_list.append((m.start(), m.end()))
        ignore_list += tmp_list    

    # print(ignore_list)
    #for r in ignore_list:
    #    _logger.error('%02d-%02d: %s' % (r[0], r[1], content[r[0]:r[1]]))
    return ignore_list

def repl_op(m, **kwargs):
    matched = m.group()
    ignores = kwargs.get('ignores', None)

    if ignores and any(operator in matched for operator in ignores):
        return matched

    rep = m.groups()
    if rep[0] and rep[2]:
        return '{} {} {}'.format(*rep)
    elif rep[0] and rep[2] is None:
        return '{} {}'.format(*rep[:2])
    elif rep[0] is None and rep[2]:
        return '{} {}'.format(*rep[1:])
    else:
        return matched

def repl_op2(m, **kwargs):
    matched = m.group()
    ignores = kwargs.get('ignores', None)

    if ignores and any(operator in matched for operator in ignores):
        return matched

    rep = m.groups()
    if rep[0] and rep[2]:
        return '{} {} {}'.format(rep[0], rep[1], rep[2])
    elif rep[0]:
        return '{} {}'.format(rep[0], rep[1])
    elif rep[2]:
        return '{} {}'.format(rep[1], rep[2])
    else:
        return '{}'.format(rep[1])

def _pt_operation(content, *args, **kwargs):
    op1_prog = re.compile('(\S)?([{}])(\S)?'.format('\\'.join(_1L_OPERATOR_SIGN)))

    op2_operators = ['\\' + '\\'.join(list(sign)) for sign in _2L_OPERATOR_SIGN]
    op2_prog = re.compile('(\S)?({})(\S)?'.format('|'.join(op2_operators)))

    op3_operators = ['\\' + '\\'.join(list(sign)) for sign in _3L_OPERATOR_SIGN]
    op3_prog = re.compile('(\S)?({})(\S)?'.format('|'.join(op3_operators)))

    tmp_cont = content
    while True:
        ignore_list = search_string_position(tmp_cont)
        # ignore_list += search_negative_number_position(tmp_cont)
        m_list = [(m, _1L_IGNORES) for m in op1_prog.finditer(tmp_cont)]
        m_list += [(m, _2L_IGNORES) for m in op2_prog.finditer(tmp_cont)]
        m_list += [(m, None) for m in op3_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_op(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    op4_prog = re.compile('(\w+)(\+|\-|\*|\*\*)(\w+)')
    while True:
        ignore_list = search_string_position(tmp_cont)
        m_list = [(m, None) for m in op4_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_op(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    op5_prog = re.compile('(\))?(\+|\-|\*|\*\*)(\()?')
    tmp_cont = tmp_cont
    while True:
        ignore_list = search_string_position(tmp_cont)
        m_list = [(m, None) for m in op5_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_op2(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

    return ret_cont

def repl_comma(m, **kwargs):
    rep = m.groups()

    if rep[0] == '\n' and rep[3] is None:
        return m.group()
    elif rep[0] == '\n' and rep[3]:
        return '{}{}{} {}'.format(rep[0], rep[1], rep[2], rep[3])
    elif rep[0] is None and rep[3]:
        return '{} {}'.format(rep[2], rep[3])
    elif rep[0] == ' ' and rep[1] is None and rep[3]:
        return '{} {}'.format(rep[2], rep[3])
    elif rep[0] == ' ' and rep[1] and rep[3]:
        return '{}{}{} {}'.format(rep[0], rep[1], rep[2], rep[3])
    else:
        return rep[2]

def _pt_whitespace_comma(content, *args, **kwargs):
    prog1 = re.compile('(\s)?(\s+)?(,)(\S)?')
    tmp_cont = content
    while True:
        ignore_list = search_string_position(tmp_cont)
        m_list = [(m, None) for m in prog1.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        # m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]
        tmp_list = m_list
        m_list = []
        for m in tmp_list:
            pos = m[0].start()
            rel = m[0].groups()
            if rel[0]:
                pos += len(rel[0])
            if rel[1]:
                pos += len(rel[1])
            if _within_ignores(pos, ignore_list):
                continue
            m_list.append(m)
            #_logger.error('%02d-%02d: %s',
            #              m[0].start(), m[0].end(), m[0].groups())

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_comma(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break

        tmp_cont = ret_cont
    ret_cont = ret_cont.replace(', )', ',)')
    ret_cont = ret_cont.replace(', ]', ',]')
    return ret_cont

def repl_equal(m, **kwargs):
    matched = m.group()
    rep = m.groups()
    ignores = kwargs.get('ignores', None)

    if ignores and any(operator in matched for operator in ignores):
        return matched

    if rep[0] and rep[2]:
        return '{} {} {}'.format(rep[0], rep[1], rep[2])
    elif rep[0]:
        return '{} {}'.format(rep[0], rep[1])
    elif rep[2]:
        return '{} {}'.format(rep[1], rep[2])
    else:
        return matched

def _pt_whitespace_equal(content, *args, **kwargs):
    prog1 = re.compile('(\S)?(=)(\S)?')
    tmp_cont = content
    while True:
        ignore_list = search_string_position(tmp_cont)
        m_list = [(m, _1L_IGNORES) for m in prog1.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        # m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]
        tmp_list = m_list
        m_list = []
        for m in tmp_list:
            pos = m[0].start()
            rel = m[0].groups()
            if rel[0]:
                pos += len(rel[0])
            if _within_ignores(pos, ignore_list):
                continue
            m_list.append(m)

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_equal(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break

        tmp_cont = ret_cont
    return ret_cont

def repl_dict(m, **kwargs):
    matched = m.group()
    rep = m.groups()
    ignores = kwargs.get('ignores', None)
    if ignores and any(operator in matched for operator in ignores):
        return matched
    if any(p in rep[0] for p in ['\'', '"']):
        return matched
    return '\'{}\'{} '.format(rep[0], rep[2])

def _pt_whitespace_dict(content, *args, **kwargs):
    prog1 = re.compile('\\"(.*)\\"(\s+)?(:)(\s+)?')
    prog2 = re.compile("\\'(.*)\\'(\s+)?(:)(\s+)?")

    tmp_cont = content
    ignores = tuple('\n')
    ignore_list = search_string_position(tmp_cont)
    m_list = [(m, ignores) for m in prog1.finditer(tmp_cont)]
    m_list += [(m, ignores) for m in prog2.finditer(tmp_cont)]

    m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
    # m_list = [m for m in m_list if not _within_ignores(m[0].start(), ignore_list)]
    tmp_list = m_list
    m_list = []
    for m in tmp_list:
        pos = m[0].start() + 2
        rel = m[0].groups()
        if rel[0]:
            pos += len(rel[0])
        if rel[1]:
            pos += len(rel[1])
        if _within_ignores(pos, ignore_list):
           continue
        m_list.append(m)
        #_logger.error('%02d-%02d: %s',
        #                m[0].start(), m[0].end(), m[0].groups())

    ret_cont = tmp_cont
    for m in m_list:
        keys = repl_dict(m[0], ignores = m[1])
        if keys == m[0].group():
            continue
        ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        tmp_cont = ret_cont
    return ret_cont

def repl_anno(m, **kwargs):
    rep = m.groups()
    if rep[0] != '-':
        return '# {}'.format(rep[0])
    return '#-'

def _pt_annotations_xxx(content, *args, **kwargs):
    prog1 = re.compile('#(\S)')
    tmp_cont = content
    while True:
        ret_cont = prog1.sub(lambda x: repl_anno(x), tmp_cont)
        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont
    return ret_cont

def _pt_annotations(content, *args, **kwargs):
    prog1 = re.compile('#([^\r\n]*)')
    tmp_cont = content

    string_list = search_string_position(tmp_cont)
    m_list = [(m, None) for m in prog1.finditer(tmp_cont)]

    m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
    m_list = [m for m in m_list if not _within_ignores(m[0].start(), string_list)]

    ret_cont = tmp_cont
    for m in m_list:
        keys = repl_anno(m[0])
        if keys == m[0].group():
            continue
        ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

    return ret_cont

format_for_list = [
    _ll_c1,
    _ll_c2,
    ]

format_for_plain_text = [
    # _pt_cvt_tab_to_space,
    # _pt_whitespace_comma,
    # _pt_operation,
    # _pt_whitespace_equal,
    # _pt_whitespace_dict,
    # _pt_annotations
    ]

def _check_plain_text(content, answer):

    if answer.rstrip() == content:
        print('Same.')
        return True

    # print('Not Same\n')

    src_lines = [ll.rstrip() for ll in content.splitlines()]
    dst_lines = [ll.rstrip() for ll in answer.splitlines()]

    src_len = len(src_lines)
    dst_len = len(dst_lines)
    max_len = max(src_len, dst_len)

    for idx in range(max_len):
        if idx >= src_len:
            print('Source content to end. %s/%s' % (src_len, dst_len))
            break

        if idx >= dst_len:
            print('Target content to end. %s/%s' % (src_len, dst_len))
            break

        sl = src_lines[idx]
        dl = dst_lines[idx]
        if sl != dl:
            print(f'Line   : "{idx}"')
            print(f'Test   : "{sl}"')
            print(f'Correct: "{dl}"')
            break
    else:
        print('Lines compare all pass')
        return False

    print('Error')

    return False

location = os.path.abspath(os.path.dirname(__file__))
 
def test1():
    print('\n\n========================================================\n\n')
    input_file = os.path.join(location, 'tests', 'sample1.err')
    with open(input_file) as fp:
        lines = fp.readlines()

    check_file = os.path.join(location, 'tests', 'sample1.ans')
    with open(check_file) as fp:
        answers = fp.read()

    st = time()
    for func in format_for_list:
        lines = func(lines)

    print('...')

    cont = '\n'.join(lines)
    cont = cont.rstrip()
    cont = cont.strip()
    # print('ret:', cont)
    print('...')
    print('\n\nDone (%ss)\n' % (round(time() - st, 3)))

    _check_plain_text(cont, answers)
    print(' ')
    # print('String Pattern: %s' % tokenize.String)
    # print('Triple: %s' % tokenize.Triple)
    # print('Ignore: %s' % tokenize.Ignore)

if __name__ == '__main__':
   test1()