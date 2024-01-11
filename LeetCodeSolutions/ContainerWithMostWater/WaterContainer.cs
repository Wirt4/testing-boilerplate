using System.Runtime.InteropServices;

namespace LeetCodeSolutions;

public class WaterContainer{
    public int MaxArea(int[] height){
        int maxArea = 0;
        int leftIndex = 0;
        int rightIndex =  height.Length -1;

        while (leftIndex < rightIndex){
            int leftHeight = height[leftIndex];
            int rightHeight = height[rightIndex];
            int currentHeight = leftHeight;

            bool rightHeightIsLower = rightHeight < leftHeight;

            if (rightHeightIsLower){
                currentHeight = rightHeight;
            }

            int currentArea =  currentHeight * (rightIndex-leftIndex);
            
            if (currentArea > maxArea){
                maxArea = currentArea;
            }

           if (leftHeight == rightHeight){
            leftIndex++;
            rightIndex--;
            continue;
           }
           
            if (rightHeightIsLower){
                rightIndex--;
                continue;
           }

           leftIndex++;

        }
    
        return maxArea;
    }
}