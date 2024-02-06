
import logging
from time import time

from .code_layout \
    import format_for_list as cl_fmt_list \
        , format_for_plain_text as cl_fmt_pt

_logger = logging.getLogger('pep8')

class Procedure(object):
    
    __for_lines = [
        cl_fmt_list,
        ]
    
    __for_plain_text = [
        cl_fmt_pt
        ]
    
    def __init__(self, content):
        self.__content = content.replace('\r\n', '\n') + '\n'
        _logger.info('Length: %s', len(self.__content))
        assert len(self.__content) > 0, 'Content is empty.'
    
    def final(self):
        return self.__content
        
    def format(self):
        st = time()
        lines = self.__content.splitlines()
        for style_list in self.__for_lines:
            for func in style_list:
                lines = func(lines)
                
        content = '\n'.join(lines)
        for style_list in self.__for_plain_text:
            for func in style_list:
                content = func(content)
        
        self.__content = content
        
        _logger.info('Formatted... %ss', round(time() - st, 2))
                
                
                