import os
import unittest

def main(test_path, test_pattern):
    print(('Discovering tests in : {}'.format(test_path)))
    suite = unittest.TestLoader().discover(test_path, test_pattern)
    unittest.TextTestRunner(verbosity=2).run(suite)

if __name__ == '__main__':
    root_path = os.path.abspath('.')
    test_path = os.path.join(root_path, 'source/hub/tests/')
    test_pattern = 'test_*'
    main(test_path, test_pattern)