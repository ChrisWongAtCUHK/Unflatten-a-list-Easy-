using System;
using System.Collections.Generic;
public class Kata
{
    public static object[] Unflatten(int[] flatArray)
    {
        List<object> result = new List<object>();

        // You start at the first number.
        for (int i = 0; i < flatArray.Length; i++)
        {
            if (flatArray[i] < 3)
            {
                // If this number x is smaller than 3, take this number x direct for the new array and continue with the next number.
                result.Add(flatArray[i]);
            } 
            else
            {
                // If this number x is greater than 2, take the next x numbers (inclusive this number) as a sub-array in the new array. Continue with the next number AFTER this taken numbers.
                // If there are too few numbers to take by number, take the last available numbers.
                int arrayLength = flatArray[i];
                if (arrayLength > (flatArray.Length - i - 1))
                {
                    arrayLength = flatArray.Length - i;
                }
                int[] array = new int[arrayLength];
                Array.Copy(flatArray, i, array, 0, arrayLength);

                result.Add(array);

                i += arrayLength - 1;
            }
        }

        return result.ToArray();
    }
}

