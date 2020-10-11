using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContiguousMaxSumAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test array
            int[] myArray = {-1, 2, 2, -5, 0, 5 };

            foreach(var result in ContiguousSubsequenceSumSecondLinearAlgorithm(myArray))
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
        
        //Quadratic Algorithm
        static int[] ContiguousSubsequenceSumQuadraticAlgorithm(int[] inputArray)
        {
            int startIndex = 0;
            int endIndex = 0;
            int maxSum = 0;
            
            int len = inputArray.Length;
            for(var i = 0; i < len; i++)
            {
                int currentSum = inputArray[i];
                for(var j = i+1; j < len; j++)
                {
                    currentSum += inputArray[j];
                    //check max
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startIndex = i;
                        endIndex = j;
                    }
                }
                
            }

            int[] returnArray = { maxSum, startIndex, endIndex };

            return returnArray;

        }


        //Linear algorithm
        static int[] ContiguousSubsequenceSumLinearAlgorithm(int[] inputArray)
        {
            int startIndex = 0;
            int endIndex = 0;
            int maxSum = 0;

            int len = inputArray.Length;

            for(var i = 0; i < len; i++)
            {
                //Remove negative starting value
                if (inputArray[i] >= 0 )
                {
                    int currentSum = inputArray[i];
                    if(currentSum >= 0)
                    {
                        //calculate current sum
                        for (var j = i + 1; j < len; j++)
                        {
                            currentSum += inputArray[j];

                            //check max
                            if (currentSum > maxSum)
                            {
                                maxSum = currentSum;
                                startIndex = i;
                                endIndex = j;
                            }

                            //Don't need to calculate sum of positive next values
                            if(inputArray[j] >= 0)
                            {
                                i++;
                            }
                        }
                    }                 
                }             
            }

            int[] returnArray = { maxSum, startIndex, endIndex };

            return returnArray;
        }

        //Second linear alogorithm
        static int[] ContiguousSubsequenceSumSecondLinearAlgorithm(int[] inputArray)
        {
            int startIndex = 0;
            int endIndex = 0;
            int maxSum = 0;
            int currentSum = 0;
            int len = inputArray.Length;

            for (int i = 0, j = 0; j < len; j++)
            {
                currentSum += inputArray[j];

                //check max
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startIndex = i;
                    endIndex = j;
                }

                else if(currentSum < 0)
                {
                    i = j + 1;
                    currentSum = 0;

                }

            }

            int[] returnArray = { maxSum, startIndex, endIndex };

            return returnArray;

        }
    }
}
