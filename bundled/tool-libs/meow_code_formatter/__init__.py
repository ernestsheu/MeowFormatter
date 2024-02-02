

import sys


def main(argv):
  
  sys.stdout.write('main()\n')
  return 1


def run_main():  # pylint: disable=invalid-name
  try:
    sys.exit(main(sys.argv))
  except errors.YapfError as e:
    sys.stderr.write('yapf: ' + str(e) + '\n')
    sys.exit(1)


if __name__ == '__main__':
  run_main()
