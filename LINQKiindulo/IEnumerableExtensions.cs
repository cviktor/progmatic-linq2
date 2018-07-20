using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQKiindulo
{
    static class IEnumerableExtensions
    {
        public static void WriteAll<T>(this IEnumerable<T> enumerable, string title = null)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title ?? "--------Start--------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
