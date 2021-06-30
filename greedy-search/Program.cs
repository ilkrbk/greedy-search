using System;
using System.Collections.Generic;
using System.IO;

namespace greedy_search
{
    class Algoritm
    {
        private string path1;
        private string path2;
        private List<string> nameCity = new List<string>();
        private int[,] table1 = new int[15, 15];
        private int[,] table2 = new int[15, 15];
        
        public Algoritm(string _path1)
        {
            path1 = _path1;
            ReadFile(path1, ref table1);
        }
        public Algoritm(string _path1, string _path2)
        {
            path1 = _path1;
            path2 = _path2;
            ReadFile(path1, ref table1);
            ReadFile(path2, ref table2);
        }
        private void ReadFile(string path, ref int[,] table)
        {
            StreamReader read = new StreamReader(path, System.Text.Encoding.Default);
            string temp = read.ReadLine();
            string[] array = temp.Split(' ');
            while (nameCity.Count != 0)
                nameCity.RemoveAt(0);
            for (int i = 0; i < array.Length; i++)
                nameCity.Add(array[i]);
            int count = 0;
            while (temp != null)
            {
                temp = read.ReadLine();
                if (temp != null)
                {
                    array = temp.Split(' ');
                    for (int i = 0; i < array.Length; i++)
                        table[count, i] = Convert.ToInt32(array[i]);
                    count++;
                }
            }
        }
        private bool SearchInList(List<int> list, int n)
        {
            foreach (var item in list)
            {
                if (item == n)
                {
                    return false;
                }
            }
            return true;
        }
        private (int, double) SearchMin(int[,] list, List<int> visited, int index)
        {
            (int, double) min = (1, Double.PositiveInfinity);
            for (int i = 0; i < 15; i++)
                if (min.Item2 > list[index, i] && list[index, i] != 0 && SearchInList(visited, i))
                    min = (i, list[index, i]);
            return min;
        }
        public (double, List<string>) GreedySearch(string start, string finish)
        {
            (double, List<string>) list = (0, new List<string>());
            List<int> visied = new List<int>();
            list.Item2.Add(start);
            while (list.Item2[list.Item2.Count - 1] != finish)
            {
                int index = CalcIndex(list.Item2[list.Item2.Count - 1]);
                visied.Add(index);
                (int, double) min = SearchMin(table1, visied, index);
                list.Item2.Add(nameCity[min.Item1]);
                list = ((list.Item1 += min.Item2), list.Item2);
            }
            return list;
        }
        private int SearchMinFuncF(List<string> list)
        {
            int index = 0;
            int min = 0;
            for (int i = 1; i < list.Count; i++)
            {
                
            }

            return index;
        }
        private int CalcIndex(string name)
        {
            int index = 0;
            for (int i = 0; i < 15; i++)
            {
                if (nameCity[i] == name)
                {
                    index = i;
                }
            }
            return index;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Жадный поиск");
            Algoritm mainAlgo1 = new Algoritm("test1.txt");
            (double, List<string>) result = mainAlgo1.GreedySearch("Ереван", "Раздан");
            Console.WriteLine($"Растояние: {result.Item1}км\nПуть:");
            foreach (var item in result.Item2)
                Console.Write($"{item,3} ");
        }
    }
}