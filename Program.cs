using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// Author: Yanzhi Wang
    /// Purpose: Sorts an array of integers using a recursive function
    /// Restrictions: None
    /// </summary>
    class NumberSorter
    {
        static void Main(string[] args)
        {
            // get user input
            Console.Write("Enter a list of comma-separated numbers: ");
            string input = Console.ReadLine();
            // split the input into an array of strings
            string[] stringArray = input.Split(',');

            // convert the array of strings to an array of integers
            int[] intArray = Array.ConvertAll(stringArray, int.Parse);

            // call the recursive function to sort the array
            SortArray(intArray, 0, intArray.Length - 1);

            // print the sorted array
            Console.WriteLine("Sorted Array: " + string.Join(", ", intArray));
        }

        /// <summary>
        /// Recursively sorts an array of integers using the QuickSort algorithm
        /// </summary>
        /// <param name="arr">The array to be sorted</param>
        /// <param name="left">The leftmost index of the subarray to be sorted</param>
        /// <param name="right">The rightmost index of the subarray to be sorted</param>
        /// <returns></returns>
        static void SortArray(int[] arr, int left, int right)
        {
            // base case
            if (left >= right) return;

            // partition the array
            int pivotIndex = Partition(arr, left, right);

            // recursively sort the left and right subarrays
            SortArray(arr, left, pivotIndex - 1);
            SortArray(arr, pivotIndex + 1, right);
        }

        /// <summary>
        /// Partitions an array of integers using the last element as the pivot
        /// </summary>
        /// <param name="arr">The array to be partitioned</param>
        /// <param name="left">The leftmost index of the subarray to be partitioned</param>
        /// <param name="right">The rightmost index of the subarray to be partitioned</param>
        /// <returns>The index of the pivot element</returns>
        static int Partition(int[] arr, int left, int right)
        {
            // choose the last element as the pivot
            int pivot = arr[right];

            // initialize the pivot index to the leftmost index
            int pivotIndex = left;

            // iterate through the subarray
            for (int i = left; i < right; i++)
            {
                // if the current element is less than or equal to the pivot, swap it with the element at the pivot index
                if (arr[i] <= pivot)
                {
                    int temp = arr[i];
                    arr[i] = arr[pivotIndex];
                    arr[pivotIndex] = temp;

                    // increment the pivot index
                    pivotIndex++;
                }
            }

            // swap the pivot element with the element at the pivot index
            int temp2 = arr[right];
            arr[right] = arr[pivotIndex];
            arr[pivotIndex] = temp2;

            // return the pivot index
            return pivotIndex;
        }
    }
}