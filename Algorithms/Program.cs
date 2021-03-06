﻿using System;
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

            TestAlgorithm.TestBinaryArrayAdd();

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

        #region Search

        // Lineation Search
        public static int? LineationSearch(int[] array, int val)
        {
            int? key = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == val)
                {
                    key = i;
                }
            }
            return key;
        }
        #endregion

        #region Other

        // 2.1-4
        public static int[] BinaryArrayAdd(int[] A, int[] B)
        {
            if (A.Length != B.Length)
            {
                throw new Exception("The length of A and B must be equal.");
            }
            else
            {
                int[] C = new int[A.Length + 1];
                int add = 0;
                for (int i = A.Length - 1; i >= 0; i--)
                {
                    if (A[i] + B[i] + add == 2)
                    {
                        add = 1;
                        C[i + 1] = 0;
                    }
                    else if (A[i] + B[i] + add == 3)
                    {
                        add = 1;
                        C[i + 1] = 1;
                    }
                    else
                    {                        
                        C[i + 1] = A[i] + B[i] + add;
                        add = 0;
                    }
                }
                C[0] = add;
                return C;
            }
        }

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        #endregion
        
    }

    public class TestAlgorithm
    {
        public static void TestInsertionSort()
        {
            double[] array = { 4, 9, 23, 1, 45, 27, 5, 2, 31, 41, 59, 26, 41, 58, 14.67 };
            Algorithm.InsertionSort(ref array, SortOrder.ASC);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        public static void TestLineationSearch()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 10 };
            int val = 10;
            Console.WriteLine("Search {0}.", val);
            int? result = Algorithm.LineationSearch(array, val);
            if (result != null)
            {
                Console.WriteLine("Searched at {0} index.", result);
            }
            else
            {
                Console.WriteLine("Not Found!");
            }
        }

        public static void TestBinaryArrayAdd()
        {
            int[] A = { 1, 1, 1, 1 };
            int[] B = { 1, 1, 1, 1 };
            int[] C = Algorithm.BinaryArrayAdd(A, B);            
            for (int i = 0; i < C.Length; i++)
            {
                Console.Write(C[i]);
            }
        }
    }

    public enum SortOrder
    {
        ASC = 0,
        DESC = 1,
    }
    
}
