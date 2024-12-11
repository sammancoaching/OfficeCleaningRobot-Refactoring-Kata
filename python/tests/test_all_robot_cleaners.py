import pytest

import office_cleaner1
import office_cleaner9
import pytest
import sys
from io import StringIO

testdata = [
    ("Input_empty.txt",  "=> Cleaned: 1"),
    ("Input_one.txt",  "=> Cleaned: 1"),
    ("Input_given_sample.txt",  "=> Cleaned: 4"),
    ("Input_only_west.txt",  "=> Cleaned: 9"),
    ("Input_wiping.txt",  "=> Cleaned: 9"),
    ("Input_large.txt",  "=> Cleaned: 1047"),
]

@pytest.mark.parametrize("filename, expected", testdata)
def test_office_cleaner1(filename, expected):
    do_robot_cleaner_test(filename, expected, office_cleaner1.main)

@pytest.mark.parametrize("filename, expected", testdata)
def test_office_cleaner9(filename, expected):
    do_robot_cleaner_test(filename, expected, office_cleaner9.main)

def do_robot_cleaner_test(filename, expected, sut):
    try:
        sys.stdin = open(filename, 'r')
        old_stdout = sys.stdout
        sys.stdout = StringIO()

        sut()

        output = sys.stdout.getvalue().strip()
        assert output == expected

    finally:
        sys.stdin.close()
        sys.stdout = old_stdout


