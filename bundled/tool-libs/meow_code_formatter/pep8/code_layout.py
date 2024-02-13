'''
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

'''
import re
import sys
import logging
import tokenize

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
    '//', '+=', '-=', '*=', '/=', '%=', '&=', '|=', '^=',
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

def _ll_string(content, *arg, **kwargs):
    docstr_list = [m for m in _RE_STR_TRIPLE.finditer(content)]
    string_list = [m for m in _RE_STRING.finditer(content)]
    last_pos = len(content)
    ignore_list = []
    if docstr_list:
        if len(docstr_list) == 1:
            ignore_list += [(docstr_list[0].start(), last_pos)]
        else:
            ignore_list += [(docstr_list[0].start(), docstr_list[-1].end())]

    if string_list:
        ignore_list += [(m.start(), m.end()) for m in string_list]

    comment_list = [m for m in _RE_COMMENT.finditer(content)]
    comment_list = [m for m in comment_list if not _within_ignores(m.start(), ignore_list)]
    ignore_list += [(m.start(), last_pos) for m in comment_list]

    for r in ignore_list:
        _logger.error('%02d-%02d: %s' % (r[0], r[1], content[r[0]:r[1]]))

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

def _ll_whitespace_dict(content, *arg, **kwargs):
    prog1 = re.compile('\\"(.*)\\"(\s+)?(:)(\s+)?')
    prog2 = re.compile("\\'(.*)\\'(\s+)?(:)(\s+)?")

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

def _ll_c2(lines, *args, **kwargs):
    new_lines = []

    docstring = False
    for ll in lines:
        if not docstring:
            ll = _ll_whitespace_comma(ll)
            ll = _ll_operator(ll)
            ll = _ll_whitespace_equal(ll)
            ll = _ll_whitespace_dict(ll)
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
    #_pt_cvt_tab_to_space,
    #_pt_whitespace_comma,
    #_pt_operation,
    #_pt_whitespace_equal,
    #_pt_whitespace_dict,
    #_pt_annotations
    ]

def _test_plain_text():
    cont = '''
import builtins
import cv2
import gc
import json
import logging
import os
import copy
import numpy as np
import PIL.Image, PIL.ImageTk, PIL.ImageDraw, PIL.ImageFont
import platform

from binascii import b2a_hex
from datetime import datetime
from time import time, sleep

import tkinter as tk
import tkinter.ttk as ttk
import tkinter.font as tkFont
from tkinter import messagebox, filedialog

from .node_cfg \\
    import switch_theme as tk_node_cfg_theme \\
        , NodeConfigurationDialog
from .pref_pages \\
    import switch_theme as tk_pref_pages_theme \\
        , PreferencePages
from .repair_pages \\
    import switch_theme as tk_repair_pages_theme \\
        , RepairPages
from .theme_mgr import ThemeManager
from .unittest import UnitTest

from ...utils.proc import force_kill_process, kill_all_child_process
from ...locale  \\
    import init as load_language    \\
        , get_supported_languages_with_name \\
        , _DEF_LOCALE as DEF_LOCALE \\
        , _key

from ...utils.web.messenger \\
    import line_notify      \\
        , google_chat       \\
        ,MSG_ENG           \\
        , MSG_CUSTOMER_AREA \\
        , MSG_CUSTOMER      \\
        ,MSG_ENG_SPECIFIC  \\
        , MSG_ENG_ATTEN

from ...versions import __version__, __prog_name__, __copyright__

_TITLE = \\
    '{title} {version} {comment}'.format(
        version = __version__,
        title = __prog_name__,
        comment = ''
        )

filename=os.path.basename(output_file)
output_path=os.path.dirname(output_file)
metadata=None
with GoogleDrive(cred_file=cred_file,channel=channel) as gldrv:
output_path = os.path.dirname(output_file)
metadata = None

abc=func(aa,bbb,cc=['abc', 'ccc'], dd=(1, ), ff=12354)
abc=func(aa,bbb,cc=['abc','ccc'],dd=(1,),ff=12354)
abc=func(aa,bbb,cc=['abc','ccc'] ,dd=(1,) ,ff=12354)
abc=func(aa,bbb,cc=['abc','ccc'] , dd=(1,) , ff=12354)
abc=func(aa,bbb,cc=['abc','ccc']  , dd=(1,) , ff=12354)
abc=func(aa,bbb,cc=['abc','ccc']  ,dd=(1,) ,ff=12354)

text = \'\'\' x<<3 x|3
    prog1=re.compile('#(\S)')
    prog1=re.compile('(\s)?(\s+)?(,)(\S)?')
    However, in a slice the colon acts like a binary operator,
    and should have equal amounts on either side
    (treating it as the operator with the lowest priority).
    In an extended slice, both colons must have the same amount of spacing applied.
    Exception: when a slice parameter is omitted, the space is omitted:

    x=x&3
    x=x|3
    x=x^3
    x=x>>3
    x=x<<3
    \'\'\'

#this is annotations
#-#-- this is annotations --------
output_path= os.path.dirname(output_file)
metadata =None
x = x + 10 - 15
x=x+10-15
y=x-1-1
i=i+1
submitted +=1
x=x*2-1
hypot2=x*x+y*y
c=(a+b)*(a-b)
c=(a+b)* \\
     (a-b)
c=(a+b) \\
    * (a-b)

if not(x<5 or x<10):
    aa=x&c
    aa=x|y
if x<5 or x<10:
    bb=x^y
    bb=~x
if x<5 and x<10:
    cc=x<<2
    dd=x>>2

if not(x < 5 and x < 10):
	x+=10
	x-=10
	x*=10
	x/=10

y=x==y
y=x<y
y=x>y
y=x!=y
y=x<>y
y=x<=y
y=x>=y

x=5
x=x+3 # aaaaa
x=x-3     # cccc
x=x*3   # ssdffs
x=x/3
x=x%3
x=x//3
x=x**3
x=x&3
x=x|3
x=x^3
x=x>>3
x=x<<3

x='x|3'
x='x^3'
x='x>>3'
x='x<<3'

x="x|3"
x="x^3"
x="x>>3"
x="x<<3"

x="x|3"
x="x^3"
x="x>>3"
x=\'\'\' x<<3 prog1=re.compile('#(\S)') x**=3\'\'\'

x=5
x+=3
x-=3
x*=3
x/=3
x%=3
x//=3
x**=3
x&=3
x|=3
x^=3
x>>=3
x<<=3

prog1 = re.compile('#(\S)')
prog1 = re.compile('(\s)?(\s+)?(,)(\S)?')

anno_list += [(tmp_list[idx][0], tmp_list[idx + 1][1]) for idx in range(0, len(tmp_list), 2)]

x=-123
x = -53
dic = {
    'std_order':-1,
    'std_num':-1,
    'std_order10'  :   -1,
    'std_order20':-1,
    'std_order30':123,
    'std_order40':"abcd",
    'std_order50':'adef'
    "std_order1"  :   -1,
    "std_order2":-1,
    "std_order3":123,
    "std_order4":"abcd",
    "std_order5":'adef'
}
12+23
12 + -23
12 + (-23)
12 +(-23)
(12)+(-23)
12 += -23
12 -=(-23)
-123
-12-33
12*56
-12 - 123
-12 + -123
-12 -= -123
-12 += -123

i=i+1
submitted += 1
x=x*2-1
hypot2 = x*x+y*y
c=(a+b)*(a-b)
foo(bar,key='word',*args,**kwargs)
alpha[:-i]
[a,b]
(3,)
a[3,] = 1
a[1:4]
a[:4]
a[1:]
a[1:4:2]

_logger.info('wid_values: %s', wid_values)
node = self.__nodes[node_name]
store_params = self.widgets_apply(node, node.config.components, wid_values)
_logger.info('params: %s', store_params)

if node.config.pub_cfg_apply:
    node_config = NodeConfig()
    node_config.json_data = json.dumps(wid_values, indent = 4, separators = (',', ':'))
    node.config.pub_cfg_apply.publish(node_config)

if x == 'FP':
    pass
if x == "FP":
    pass
(',', ':')

_ROS_INIT = '#ff0d0d'
_ROS_RUNNING = '#33ffff'
_ROS_CLOSED = '#7f7f7f'
x = 'abd' + 'fdsf' + """sfsf
x<<113 x|2223
    prog1=re.compile('#(\S)')
    prog1=re.compile('(\s)?(\s+)?(,)(\S)?')
    However, in a slice the colon acts like a binary operator,
    and should have equal amounts on either side
    (treating it as the operator with the lowest priority).
    In an extended slice, both colons must have the same amount of spacing applied.
    Exception: when a slice parameter is omitted, the space is omitted:

    x=x&3
    x=x|3
    x=x^3
    x=x>>3
    x=x<<3
assa """
'#33ccaa',  # n/a
'''
    return cont

def _check_plain_text(content):
    answer = '''import builtins
import cv2
import gc
import json
import logging
import os
import copy
import numpy as np
import PIL.Image, PIL.ImageTk, PIL.ImageDraw, PIL.ImageFont
import platform

from binascii import b2a_hex
from datetime import datetime
from time import time, sleep

import tkinter as tk
import tkinter.ttk as ttk
import tkinter.font as tkFont
from tkinter import messagebox, filedialog

from .node_cfg \\
    import switch_theme as tk_node_cfg_theme \\
        , NodeConfigurationDialog
from .pref_pages \\
    import switch_theme as tk_pref_pages_theme \\
        , PreferencePages
from .repair_pages \\
    import switch_theme as tk_repair_pages_theme \\
        , RepairPages
from .theme_mgr import ThemeManager
from .unittest import UnitTest

from ...utils.proc import force_kill_process, kill_all_child_process
from ...locale  \\
    import init as load_language    \\
        , get_supported_languages_with_name \\
        , _DEF_LOCALE as DEF_LOCALE \\
        , _key

from ...utils.web.messenger \\
    import line_notify      \\
        , google_chat       \\
        , MSG_ENG           \\
        , MSG_CUSTOMER_AREA \\
        , MSG_CUSTOMER      \\
        , MSG_ENG_SPECIFIC  \\
        , MSG_ENG_ATTEN

from ...versions import __version__, __prog_name__, __copyright__

_TITLE = \\
    '{title} {version} {comment}'.format(
        version = __version__,
        title = __prog_name__,
        comment = ''
        )

filename = os.path.basename(output_file)
output_path = os.path.dirname(output_file)
metadata = None
with GoogleDrive(cred_file = cred_file, channel = channel) as gldrv:
output_path = os.path.dirname(output_file)
metadata = None

abc = func(aa, bbb, cc = ['abc', 'ccc'], dd = (1,), ff = 12354)
abc = func(aa, bbb, cc = ['abc', 'ccc'], dd = (1,), ff = 12354)
abc = func(aa, bbb, cc = ['abc', 'ccc'], dd = (1,), ff = 12354)
abc = func(aa, bbb, cc = ['abc', 'ccc'], dd = (1,), ff = 12354)
abc = func(aa, bbb, cc = ['abc', 'ccc'], dd = (1,), ff = 12354)
abc = func(aa, bbb, cc = ['abc', 'ccc'], dd = (1,), ff = 12354)

text = \'\'\' x<<3 x|3
    prog1=re.compile('#(\S)')
    prog1=re.compile('(\s)?(\s+)?(,)(\S)?')
    However, in a slice the colon acts like a binary operator,
    and should have equal amounts on either side
    (treating it as the operator with the lowest priority).
    In an extended slice, both colons must have the same amount of spacing applied.
    Exception: when a slice parameter is omitted, the space is omitted:

    x=x&3
    x=x|3
    x=x^3
    x=x>>3
    x=x<<3
    \'\'\'

#this is annotations
#-#-- this is annotations ------------------------------------------------------
output_path = os.path.dirname(output_file)
metadata = None
x = x + 10 - 15
x = x + 10 - 15
y = x - 1 - 1
i = i + 1
submitted += 1
x = x * 2 - 1
hypot2 = x * x + y * y
c = (a + b) * (a - b)
c = (a + b) * \\
     (a - b)
c = (a + b) \\
    * (a - b)

if not(x < 5 or x < 10):
    aa = x & c
    aa = x | y
if x < 5 or x < 10:
    bb = x ^ y
    bb = ~x
if x < 5 and x < 10:
    cc = x << 2
    dd = x >> 2

if not(x < 5 and x < 10):
    x += 10
    x -= 10
    x *= 10
    x /= 10

y = x == y
y = x < y
y = x > y
y = x != y
y = x <> y
y = x <= y
y = x >= y

x = 5
x = x + 3 # aaaaa
x = x - 3     # cccc
x = x * 3   # ssdffs
x = x / 3
x = x%3
x = x // 3
x = x ** 3
x = x & 3
x = x | 3
x = x ^ 3
x = x >> 3
x = x << 3

x = 'x|3'
x = 'x^3'
x = 'x>>3'
x = 'x<<3'

x = "x|3"
x = "x^3"
x = "x>>3"
x = "x<<3"

x = "x|3"
x = "x^3"
x = "x>>3"
x = \'\'\' x<<3 prog1=re.compile('#(\S)') x**=3\'\'\'

x = 5
x += 3
x -= 3
x *= 3
x /= 3
x %= 3
x //= 3
x **= 3
x &= 3
x |= 3
x ^= 3
x >>= 3
x <<= 3

prog1 = re.compile('#(\S)')
prog1 = re.compile('(\s)?(\s+)?(,)(\S)?')

anno_list += [(tmp_list[idx][0], tmp_list[idx + 1][1]) for idx in range(0, len(tmp_list), 2)]

x = -123
x = -53
dic = {
    'std_order': -1,
    'std_num': -1,
    'std_order10': -1,
    'std_order20': -1,
    'std_order30': 123,
    'std_order40': "abcd",
    'std_order50': 'adef'
    'std_order1': -1,
    'std_order2': -1,
    'std_order3': 123,
    'std_order4': "abcd",
    'std_order5': 'adef'
}
12 + 23
12 + -23
12 + (-23)
12 + (-23)
(12) + (-23)
12 += -23
12 -= (-23)
-123
-12 - 33
12 * 56
-12 - 123
-12 + -123
-12 -= -123
-12 += -123

i = i + 1
submitted += 1
x = x * 2 - 1
hypot2 = x * x + y * y
c = (a + b) * (a - b)
foo(bar, key = 'word', *args, **kwargs)
alpha[:-i]
[a, b]
(3,)
a[3,] = 1
a[1:4]
a[:4]
a[1:]
a[1:4:2]

_logger.info('wid_values: %s', wid_values)
node = self.__nodes[node_name]
store_params = self.widgets_apply(node, node.config.components, wid_values)
_logger.info('params: %s', store_params)

if node.config.pub_cfg_apply:
    node_config = NodeConfig()
    node_config.json_data = json.dumps(wid_values, indent = 4, separators = (',', ':'))
    node.config.pub_cfg_apply.publish(node_config)

if x == 'FP':
    pass
if x == 'FP':
    pass
(',', ':')

_ROS_INIT = '#ff0d0d'
_ROS_RUNNING = '#33ffff'
_ROS_CLOSED = '#7f7f7f'
x = 'abd' + 'fdsf' + """sfsf
x<<113 x|2223
    prog1=re.compile('#(\S)')
    prog1=re.compile('(\s)?(\s+)?(,)(\S)?')
    However, in a slice the colon acts like a binary operator,
    and should have equal amounts on either side
    (treating it as the operator with the lowest priority).
    In an extended slice, both colons must have the same amount of spacing applied.
    Exception: when a slice parameter is omitted, the space is omitted:

    x=x&3
    x=x|3
    x=x^3
    x=x>>3
    x=x<<3
assa """
'#33ccaa',  # n/a
'''

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
            print('Test   : "%s"' % sl)
            print('Correct: "%s"' % dl)
            break
    else:
        print('Lines compare all pass')
        return False

    print('Error')

    return False

def test1():
    from time import time
    st = time()
    print('\n\n========================================================\n\n')
    cont = _test_plain_text()
    lines = cont.splitlines()
    for func in format_for_list:
        lines = func(lines)

    cont = '\n'.join(lines)
    if False:
        cont = _pt_cvt_tab_to_space(cont)
        cont = _pt_whitespace_comma(cont)
        cont = _pt_operation(cont)
        cont = _pt_whitespace_equal(cont)
        cont = _pt_whitespace_dict(cont)
        #cont = _pt_annotations(cont)

    cont = cont.rstrip()
    cont = cont.strip()
    print('ret:', cont)
    print('...')

    print('\n\nDone (%ss)\n' % (round(time() - st, 3)))
    _check_plain_text(cont)
    print(' ')
    print('String Pattern: %s' % tokenize.String)
    print('Triple: %s' % tokenize.Triple)
    print('Ignore: %s' % tokenize.Ignore)

if __name__ == '__main__':
   test1()