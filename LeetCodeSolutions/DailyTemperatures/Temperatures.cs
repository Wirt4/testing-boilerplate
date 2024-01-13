using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;

namespace LeetCodeSolutions;
public class Temperatures{
    public int [] DailyTemperatures(int[] temperatures){
    Stack <int> left = new Stack<int>();
    Stack <int> right = new Stack<int>();
    //build stacks 
    for (int i=0; i< temperatures.Length; i++){
        int cur = temperatures[i];

        while (left.Count > 0 && cur < temperatures[left.Peek()]){
            right.Push(left.Pop());
        }

        while (right.Count > 0 && cur >= temperatures[right.Peek()] ){
            left.Push(right.Pop());
        }

        left.Push(i);
    }

    int [] counts = new int[temperatures.Length];

    //query them
    for (int j=0; j < temperatures.Length; j ++){
        int cur = temperatures[j];

        while (left.Count > 0 && cur < temperatures[left.Peek()]){
            right.Push(left.Pop());
        }

        while (right.Count > 0 && cur >= temperatures[right.Peek()]){
            left.Push(right.Pop());
        }

        left.Pop();

        bool indexFound =  false;
        int searchIndex = j;

        while(!indexFound && searchIndex < temperatures.Length){
            searchIndex++;
            indexFound =  right.Contains(searchIndex);
        }

        counts[j] = indexFound ? searchIndex - j: 0;
    }

    return counts;
    }
}