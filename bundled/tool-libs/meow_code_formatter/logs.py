import os
import logging
import sys

from logging import *
from logging import Manager, root

DEF_BASIC_FORMAT = '%(asctime)s P({}) %(name)-10s : %(levelname)-9s : %(message)s'.format('%05d' % os.getpid())
DEF_CONSOLE_FORMAT = '%(asctime)s P({}) %(name)-10s : %(levelname)-9s : %(message)s'.format('%05d' % os.getpid())

log_level = INFO
console = StreamHandler(stream = sys.stderr)
console.setLevel(log_level)
formatter = Formatter(DEF_CONSOLE_FORMAT)
console.setFormatter(formatter)

# basic
basicConfig(
    level = log_level,
    format = DEF_BASIC_FORMAT,
    handlers = [console]
    )