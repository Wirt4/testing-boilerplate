using System.Reflection.Emit;
using System.Runtime.Serialization;

namespace LeetCodeSolutions;

public class GreatestCommonDivisor
{

private Boolean isDenominator( ref string shortString, int shortLen, ref string longString, int longLen){

    if (longLen%shortLen !=0){
        return false;
    }

    for (int i=0; i<longLen; i++){
        if (shortString[i%shortLen] != longString[i]){
            return false;
        }
    }

    return true;
}
 public string GcdOfStrings(string str1, string str2) {

    if (str2 == ""){
        return "";
    }

    int str1Len = str1.Length;
    int str2Len = str2.Length;

    if (str1Len == str2Len){
        return str1 == str2 ? str2: "";
    }

    if (str1Len < str2Len){
        string tempStr = str1;
        int tempInt = str1Len;

        str1 = str2;
        str2 = tempStr;

        str1Len = str2Len;
        str2Len = tempInt;
    }

    for (int endIndex = str2Len; endIndex >0; endIndex--){
        if (str1Len%endIndex !=0 || str2Len%endIndex !=0){
            continue;
        }

        string cur = str2.Substring(0, endIndex);
        if (isDenominator(ref cur, endIndex, ref str1, str1Len) && isDenominator(ref cur, endIndex, ref str2, str2Len)){
            return cur;
        }
    }

    return "";
    }
    
}