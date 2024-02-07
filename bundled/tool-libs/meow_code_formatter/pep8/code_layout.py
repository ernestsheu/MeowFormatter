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

_logger = logging.getLogger('code_layout')

def _within_string(pos, string_list):
    for anno in string_list:
        if anno[0] <= pos < anno[1]:
            return True
    return False

def search_string_position(content):
    string_list = []

    tmp_list = []
    for m in re.finditer("'''", content):
        # print('%02d-%02d: %s' % (m.start(), m.end(), m.group(0)))
        tmp_list.append((m.start(), m.end()))
    assert len(tmp_list) % 2 == 0, 'The declared annotation is illegal.'
    string_list += [(tmp_list[idx][0], tmp_list[idx + 1][1]) for idx in range(0, len(tmp_list), 2)]

    for pattern in ['"', "'"]:
        tmp_list = []
        for m in re.finditer(pattern, content):
            if m.start() > 0 and content[m.start() - 1] == '\\':
                continue
            if _within_string(m.start(), string_list):
                continue
            tmp_list.append((m.start(), m.end()))
        assert len(tmp_list) % 2 == 0, 'The declared annotation is illegal.'
        string_list += [(tmp_list[idx][0], tmp_list[idx + 1][1]) for idx in range(0, len(tmp_list), 2)]

    # print(string_list)
    #for r in string_list:
    #    print('%02d-%02d: %s' % (r[0], r[1], content[r[0]:r[1]]))
    return string_list

def _ll_c1(lines, *args, **kwargs):
    new_lines = []
    blank_count = 0

    # Remove line-end whitespace
    # Remove more blank lines
    # Special: Check the keyword "#-#--" and fix its length
    # Convert tabs to spaces
    for ll in lines:
        ll = ll.rstrip()
        # ll = re.sub("\t", "    ", ll)
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

def _pt_cvt_tab_to_space(content, *args, **kwargs):
    return re.sub("\t", "    ", content)

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

# 1 letter, skip '%', '~'
_1L_OPERATOR_SIGN = ('+', '-', '*', '/', '=', '>', '<', '&', '|', '^')
# 2 letters
_2L_OPERATOR_SIGN = (
    '**', '//', '+=', '-=', '*=', '/=', '%=', '&=', '|=', '^=',
    '==', '!=', '<>', '<=', '>=', '<<', '>>'
    )
# 3 letters
_3L_OPERATOR_SIGN = (
    '//=', '**=', '>>=', '<<='
    )
_LOG_OPERATOR_SIGN = ('and', 'or', 'not')

_1L_IGNORES = tuple(list(_2L_OPERATOR_SIGN) + list(_3L_OPERATOR_SIGN) \
                        + ['--', '#-', '-#'])
_2L_IGNORES = _3L_OPERATOR_SIGN

def repl_op(m, **kwargs):
    matched = m.group()

    ignores = kwargs.get('ignores', None)
    string_positions = kwargs.get('string_positions', None)

    if ignores and any(operator in matched for operator in ignores):
        return matched

    if string_positions and _within_string(m.start(), string_positions):
        print('%s, pos: %s' % (matched, m.start()))
        return matched

    rep = m.groups()
    if rep[0] and rep[2]:
        return '{} {} {}'.format(*rep)
    elif rep[0] and rep[2] is None:
        return '{} {}'.format(*rep[:2])
    elif rep[0] is None and rep[2]:
        return '{} {}'.format(*rep[1:])
    else:
        return '{}'.format(rep[1])

def _pt_operation(content, *args, **kwargs):
    op1_prog = re.compile('(\S)?([{}])(\S)?'.format('\\'.join(_1L_OPERATOR_SIGN)))

    op2_operators = ['\\' + '\\'.join(list(sign)) for sign in _2L_OPERATOR_SIGN]
    op2_prog = re.compile('(\S)?({})(\S)?'.format('|'.join(op2_operators)))

    op3_operators = ['\\' + '\\'.join(list(sign)) for sign in _3L_OPERATOR_SIGN]
    # op3_operators += list(_LOG_OPERATOR_SIGN)
    op3_prog = re.compile('(\S)?({})(\S)?'.format('|'.join(op3_operators)))

    tmp_cont = content
    while True:
        string_list = search_string_position(tmp_cont)
        m_list = [(m, _1L_IGNORES) for m in op1_prog.finditer(tmp_cont)]
        m_list += [(m, _2L_IGNORES) for m in op2_prog.finditer(tmp_cont)]
        m_list += [(m, None) for m in op3_prog.finditer(tmp_cont)]

        m_list = sorted(m_list, key = lambda m: m[0].start(), reverse = True)
        m_list = [m for m in m_list if not _within_string(m[0].start(), string_list)]

        ret_cont = tmp_cont
        for m in m_list:
            keys = repl_op(m[0], ignores = m[1])
            if keys == m[0].group():
                continue
            ret_cont = ret_cont[:m[0].start()] + keys + ret_cont[m[0].end():]

        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont

        if False:
            ret_cont = op1_prog.sub(
                            lambda x: repl_op(x, ignores = _1L_IGNORES,
                                            string_positions = string_list),
                            tmp_cont)
            string_list = search_string_position(ret_cont)
            ret_cont = op2_prog.sub(
                            lambda x: repl_op(x, ignores = _2L_IGNORES,
                                            string_positions = string_list),
                            ret_cont)
            string_list = search_string_position(ret_cont)
            ret_cont = op3_prog.sub(
                            lambda x: repl_op(x, string_positions = string_list),
                            ret_cont)
        #if ret_cont == tmp_cont:
        #    break
        #tmp_cont = ret_cont
    return ret_cont


def repl_comma(m, **kwargs):
    rep = m.groups()
    within_string = kwargs.get('within_string', None)

    if within_string and within_string(m.start()):
        return m.group()

    if rep[0] == '\n' and rep[3] is None:
        return m.group()
    elif rep[0] == '\n' and rep[3]:
        return '{}{}{} {}'.format(*rep)

    elif rep[0] is None and rep[3]:
        return ', {}'.format(rep[3])
    elif rep[0] == ' ' and rep[1] is None and rep[3]:
        return ', {}'.format(rep[3])
    elif rep[0] == ' ' and rep[1] and rep[3]:
        return '{}{}, {}'.format(rep[0], rep[1], rep[3])
    else:
        return ','

def _pt_comma(content, *args, **kwargs):
    prog1 = re.compile('(\s)?(\s+)?(,)(\S)?')
    tmp_cont = content
    while True:
        ret_cont = prog1.sub(lambda x: repl_comma(x, **kwargs), tmp_cont)
        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont
    return ret_cont

def repl_anno(m, **kwargs):
    rep = m.groups()
    if rep[0] != '-':
        return '# {}'.format(rep[0])
    return '#-'

def _pt_annotations(content, *args, **kwargs):
    prog1 = re.compile('#(\S)')
    tmp_cont = content
    while True:
        ret_cont = prog1.sub(lambda x: repl_anno(x), tmp_cont)
        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont
    return ret_cont

format_for_list = [
    _ll_c1,
    ]

format_for_plain_text = [
    _pt_cvt_tab_to_space,
    _pt_operation,
    _pt_comma,
    _pt_annotations
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
        , _DEF_LOCALE as DEF_LOCALE, _key

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
    prog1 = re.compile('#(\S)')
    prog1 = re.compile('(\s)?(\s+)?(,)(\S)?')
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

'''
    return cont

def test1():
    from time import time
    st = time()
    print('\n\n========================================================\n\n')
    cont = _test_plain_text()

    cont = _pt_cvt_tab_to_space(cont)
    cont = _pt_operation(cont)
    #cont = _pt_comma(cont)
    #cont = _pt_annotations(cont)
    print(cont)

    print('\n\nDone (%ss)' % (round(time() - st, 3)))



if __name__ == '__main__':
  test1()