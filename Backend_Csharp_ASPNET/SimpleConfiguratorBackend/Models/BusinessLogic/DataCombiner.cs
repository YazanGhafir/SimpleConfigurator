using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleConfiguratorBackend.Models.BusinessLogic
{
    public class DataCombiner
    {

        static void combinationUtil(int[] arr, int n, int r, int index, int[] data, int i)
        {
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                    System.Diagnostics.Debug.Write(data[j] + " ");
                System.Diagnostics.Debug.WriteLine("");
                return;
            }

            if (i >= n)
                return;

            data[index] = arr[i];
            combinationUtil(arr, n, r, index + 1, data, i + 1);
            combinationUtil(arr, n, r, index, data, i + 1);
        }

        static void printCombination(int[] arr, int n, int r)
        {
            int[] data = new int[r];
            combinationUtil(arr, n, r, 0, data, 0);
        }

        public void Main()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            int r = 3;
            int n = arr.Length;

            printCombination(arr, n, r);
        }
    }

    // This code is contributed by vt_m. 


}