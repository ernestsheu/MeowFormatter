'''
Code Lay-out
https://peps.python.org/pep-0008/#code-lay-out

Already implemented
  - Blank Lines
     + Only one blank line is allowed
  - Convert tabs to spaces
  - Remove line-end whitespace


Special Cases: (Custom rules)
  - Special: Check the keyword "#-#--" and fix its length


'''
import re

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

def _pt_operation_test():
    cont = '''filename=os.path.basename(output_file)
output_path=os.path.dirname(output_file)
metadata=None
with GoogleDrive(cred_file=cred_file, channel=channel) as gldrv:
output_path = os.path.dirname(output_file)
metadata = None

output_path= os.path.dirname(output_file)
metadata =None
x=x+1-1
y=x-1-1
i=i+1
submitted +=1
x = x * 2 - 1
hypot2 = x * x + y * y
c = (a + b) * (a - b)

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

'''
    return cont

def _pt_operation(content, *args, **kwargs):
    ops = ('+', '-', '*', '/')
    aug_ops = ('+=', '-=', '*=', '/=') # augmented 
    
    # comparisons
    # comps = ('==', '<', '>', '!=', '<>', '<=', '>=', 'in', 'not in', 'is', 'is not')
    comps = ('==', '<', '>', '!=', '<>', '<=', '>=')
    pattern1 = '(\S)?([]=\+\-\*\/])(\S)?'

    def _repl1(m):        
        matched = m.group()
        if any(comp in matched for comp in comps):
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
    
    tmp_cont = content
    while True:
        ret_cont = re.sub(pattern1, _repl1, tmp_cont)
        ret_cont = re.sub(pattern1, _repl1, ret_cont)
        if ret_cont == tmp_cont:
            break
        tmp_cont = ret_cont
    return ret_cont



format_for_list = [
    _ll_c1,    
    ]

format_for_plain_text = [
    _pt_operation,     
    ]


def test_operation():
    print('\n\n========================================================\n\n')
    cont = _pt_operation_test()
    print(_pt_operation(cont))

if __name__ == '__main__':
  test_operation()