using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int[] array = { 31, 41, 59, 26, 41, 58 };
            Algorithm.InsertionSort(ref array, SortOrder.ASC);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }

            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Time: {0} ms.", sw.ElapsedMilliseconds);
        }
        
    }

    public class Algorithm
    {
        #region Sort
        
        // Insertion Sort       

        public static void InsertionSort(ref int[] array, SortOrder order)
        {           
            int key = 0,
                i = 0;
            for (int j = 1; j < array.Length; j++)
            {
                key = array[j];
                i = j - 1;
                while (i >= 0 && (order == 0 ? array[i] > key : array[i] < key))
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = key;
            }            
        }

        #endregion

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }

    public enum SortOrder
    {
        ASC = 0,
        DESC = 1,
    }
    
}
