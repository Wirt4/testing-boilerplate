#!/usr/bin/env bas

#takes one argument, the name of the project, no spaces
puzzleName="$(tr '[:lower:]' '[:upper:]' <<< ${1:0:1})${1:1}"

#Creates a directory, empty README and empty CS file based on argument passed in command line
mkdir LeetCodeSolutions/$puzzleName
solutionName="${puzzleName}Solution"
testName="${puzzleName}Tests"
soultionFile="LeetCodeSolutions/$puzzleName/$puzzleName.cs"

#write boilerplate to file
echo "namespace LeetCodeSolutions;" > $soultionFile
echo "public class ${solutionName} {}" >> $soultionFile

#initiate README
touch LeetCodeSolutions/$puzzleName/README.md

#creates a test file for the project
testFile="LeetCodeTests/${testName}.cs"
echo "namespace Tests;" > $testFile
echo "using LeetCodeSolutions;" >> $testFile
echo " public class ${testName} {" >> $testFile
echo "  private ${solutionName} _solution;" >> $testFile
echo "  public ${testName} (){" >> $testFile
echo "      _solution = new();" >> $testFile
echo "  }" >> $testFile
echo "  [Fact]" >> $testFile
echo "  public void Test1(){" >> $testFile
echo "  }" >> $testFile
echo "}" >> $testFile

#builds project so can start testing right away
dotnet build

