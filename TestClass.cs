using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDll
{
    public class TestClass
    {
        public List<List<byte>> Data { get; set; }

        public TestClass()
        {
            Data = new List<List<byte>>(); 
        }
        
        public List<int> Calculation()
        {
            var result = new List<int>();

            foreach (var item in Data)
            {
                int type = item[0];
                item.RemoveAt(0);
                int R = 0;

                switch (type)
                {
                    case 1: // R = сумма параметров % 255
                        for (int i = 0; i < item.Count; i++)
                        {
                            R += item[i];
                        }
                        R %= 255;
                        break;
                    case 2: // R = произведение параметров % 255
                        R = 1;
                        for (int i = 0; i < item.Count; i++)
                        {
                            R *= item[i];
                        }
                        R %= 255;
                        break;
                    case 3: // R = максимум значений параметров
                        R = item.Max();
                        break;
                    case 4: // R = минимум значений параметров
                        R = item.Min();
                        break;
                }

                result.Add(R);
            }
            return result;
        }

        public List<int> MedianFiltering(List<int> signal, int windowSize)
        {
            int startpoint = windowSize / 2;
            signal = AddingStartEndData(signal, startpoint);
            int endPoint = signal.Count - windowSize;
            var medians = new List<int>();

            for (int i = 0; i <= endPoint; i++)
            {
                int[] selectDataFromWindow = signal.GetRange(i, windowSize).ToArray();
                Array.Sort(selectDataFromWindow);
                int median = selectDataFromWindow[selectDataFromWindow.Length / 2];
                medians.Add(median);
            }

            return medians;
        }

        private List<int> AddingStartEndData(List<int> data, int count)
        {
            int startItem = data[0];
            int endItem = data[data.Count-1];

            for (int i = 0; i < count; i++)
                data.Insert(0, startItem);

            for (int i = 0; i < count; i++)
                data.Add( endItem);

            return data;
        }
    }
}