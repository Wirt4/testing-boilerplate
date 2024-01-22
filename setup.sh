#!/usr/bin/env bas
#capitilize the argument, just in case
puzzleName="$(tr '[:lower:]' '[:upper:]' <<< ${1:0:1})${1:1}"
mkdir LeetCodeSolutions/$puzzleName
touch LeetCodeSolutions/$puzzleName/$puzzleName.cs
touch LeetCodeSolutions/$puzzleName/README.md

touch LeetCodeTests/$puzzleName-tests.cs

