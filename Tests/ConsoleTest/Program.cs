using ConsoleTest.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.IO;
using ConsoleTest.Service;

namespace ConsoleTest
{
   
    class Program
    {
        static void Main(string[] args)
        {
            int number_count = 100;
            Random rnd = new Random();
            List<int> numbers = new List<int>();
            for(int i = 0; i < number_count; i++)
            {
                numbers.Add(rnd.Next(0, 51));
            }

            Dictionary<int, int> numbers_count = new Dictionary<int, int>();

            for(int i = 0; i < number_count; i++)
            {
                var n = numbers[i];
                if (numbers_count.ContainsKey(n))
                    numbers_count[n]++;
                else
                    numbers_count.Add(n, 1);
            }

            var counts3 = GetItemCounts(numbers);

            var counts4 = numbers.GroupBy(n => n)
                .Select(group => new { value = group.Key, count = group.Count() })
                .OrderBy(v => v.value).ToArray();

            var counts5 = numbers.GroupBy(n => n)
                .ToDictionary(group => group.Key, group => group.Count());

            Console.ReadLine();
        }

        private static Dictionary<T, int> GetItemCounts<T>(IEnumerable<T> items)
        {
            var result = new Dictionary<T, int>();
            foreach(var item in items)
            {
                if (result.ContainsKey(item))
                    result[item]++;
                else
                    result.Add(item, 1);
            }
            return result;
        }
    }
}
