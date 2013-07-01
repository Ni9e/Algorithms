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

            double[] array = { 4, 9, 23, 1, 45, 27, 5, 2, 31, 41, 59, 26, 41, 58, 14.67 };
            Algorithm.InsertionSort(ref array, SortOrder.ASC);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
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

        public static void InsertionSort(ref double[] array, SortOrder order)
        {
            double key = 0;
            int  i = 0;
            for (int j = 1; j < array.Length; j++)
            {
                key = array[j];
                i = j - 1;
                while (i >= 0 && (order == SortOrder.ASC ? array[i] > key : array[i] < key))
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
