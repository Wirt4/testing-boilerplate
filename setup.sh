#!/usr/bin/env bas
#takes one argument, the name of the project, no spaces
puzzleName="$(tr '[:lower:]' '[:upper:]' <<< ${1:0:1})${1:1}"
#Creates a directory, empty README and empty CS file based on argument passed in command line
mkdir LeetCodeSolutions/$puzzleName
touch LeetCodeSolutions/$puzzleName/$puzzleName.cs
touch LeetCodeSolutions/$puzzleName/README.md
#creates a test file for the project
touch LeetCodeTests/$puzzleName-tests.cs

