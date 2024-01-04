using System.Runtime.Serialization;

namespace LeetCodeSolutions;

public class GreatestCommonDivisor
{

 public string GcdOfStrings(string str1, string str2) {
    if (str2 == ""){
        return "";

    }
    
    if (str1.Length == str2.Length && str1 != str2){
        return "";
    }

    string compare = "";

    while (compare.Length < str1.Length){
        compare += str2;
    }

    if (compare == str1){
        return str2;
    }
   
    return GcdOfStrings(str1, str2.Substring(0, str2.Length-1));
    }
}