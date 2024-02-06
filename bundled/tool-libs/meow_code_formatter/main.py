
import logging
import io
import sys

from .pep8.proc import Procedure as PEP8_Formatter
from .versions import __prog_name__, __description__, __version__

_logger = logging.getLogger('main')

def _raw_input():
    wrapper = io.TextIOWrapper(sys.stdin.buffer, encoding='utf-8')
    return wrapper.buffer.raw.readall().decode('utf-8')

def _removeBOM(source):
    #bom = codecs.BOM_UTF8
    #bom = bom.decode('utf-8')
    #if source.startswith(bom):
    #    return source[len(bom):]
    #return source
    pass

def _out(x):    
    sys.stdout.write(x + '\n')

if '--version' in sys.argv:
    _out('%s %s' % (__prog_name__, __version__))
    sys.exit(0)


def main(argv):    
    _logger.info('Sys.argv: %s', sys.argv)
    # _logger.info('MeowCodeFormatter 2.7.0 (pycodestyle: 2.9.1)')
    if sys.argv[1] != '-':
        return 0       

    if hasattr(sys.stdin, 'closed') and sys.stdin.closed:
        return 0

    try:
        content = _raw_input()
    except EOFError:
        return 0
    except KeyboardInterrupt:
        return 1
    
    # content = _removeBOM(content)
    pep8_proc = PEP8_Formatter(content)
    pep8_proc.format()
    # Output
    sys.stdout.write(pep8_proc.final())
    return 0


def run_main():  # pylint: disable=invalid-name
  try:
    sys.exit(main(sys.argv))
  except Exception as ex:
    _logger.exception(ex)
    sys.exit(1)




