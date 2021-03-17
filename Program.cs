using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestDll;

namespace TestDllConsoleApp
{
    class Program
    {
        static string path = @"1.txt";
        static TestClass testClass = new TestClass();
        static List<int> result = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine($"Reading file {path}...");
            testClass.Data = ReadTxt(path);
            result = testClass.Calculation();
            ShowResults("Results of calculations: ");
  
            //result = testClass.MedianFiltering(result, 3);
            //ShowResults($"Results of medians with window={window}: ");

            var oddNumbers = OddNumbers(3, 70).ToArray();
            MedianFilteringWithWindow(oddNumbers);
        }
        public static List<List<byte>> ReadTxt(string path)
        {
            var data = new List<List<byte>>();

            try
            {
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var arrOsStrings = line.Split(' ');
                        var listOfBytes = new List<byte>();

                        foreach (var item in arrOsStrings)
                        {
                            listOfBytes.Add(byte.Parse(item));
                        }

                        data.Add(listOfBytes);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

        public static void ShowResults(string text)
        {
            Console.WriteLine(text);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public static void MedianFilteringWithWindow(int[] windows)
        {
            for (int i = 0; i < windows.Length; i ++)
            {
                result = testClass.MedianFiltering(result, windows[i]);
                ShowResults($"Results of medians with window = {windows[i]}: ");
            }
        }
        public static List<int> OddNumbers(int start, int end)
        {
            var oddNummbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                {
                    oddNummbers.Add(i);
                }
            }

            return oddNummbers;
        }
    }
}