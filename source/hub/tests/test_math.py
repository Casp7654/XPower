# Python code to demonstrate working of unittest
from threading import activeCount
import unittest
  
class TestStringMethods(unittest.TestCase):
      
    def setUp(self):
        pass
  
    # Returns True if the string contains 4 a.
    def test_plus(self):
        expected = 10
        actual = 5 + 5
        self.assertEqual(expected, actual)