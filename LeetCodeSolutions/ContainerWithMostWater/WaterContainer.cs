using System.Runtime.InteropServices;

namespace LeetCodeSolutions;

public class WaterContainer{
    public int MaxArea(int[] height){
        int maxArea = 0;
        int i =0;
        int j =  height.Length -1;
        while (i<j){
            //TODO: reduce duplicated work
            int h = height[i] < height[j]? height[i] : height[j];
            int currentArea =  h * (j-i);
            if (currentArea > maxArea){
                maxArea = currentArea;
            }

           if (height[i]== height[j]){
            i++;
            j--;
           }else if (
            height[i] < height[j]
           ){
            i++;
           }else{
            j--;
           }

        }
    
        return maxArea;
    }
}