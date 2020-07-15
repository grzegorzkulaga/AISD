using System;
using System.Collections.Generic;
using System.Text;

internal static class Program
{
    private static int ReadInt()
    {
        return int.Parse(Console.ReadLine());
    }

    private static int[] ReadInts()
    {
        var input = Console.ReadLine();
        var array = input.Split(' ');

        return Array.ConvertAll(array, int.Parse);
    }

    // Counting Child / DFS
    private static void Main(string[] args)
    {
        var t = ReadInt();
        var sb = new StringBuilder(); // zeby wypisac dopiero wszystko na koniec

        for (var caseNr = 1; caseNr <= t; ++caseNr)
        {
            sb.AppendLine("Case " + caseNr + ":");

            // czytaj dane do odpowiedniego case
            var n = ReadInt();
            var input = ReadInts();

            var stack = new Stack<int>(new[] { input[0] });
            var dict = new Dictionary<int, int>();

            // iteruje po przypadkach
            for (var j = 1; j < 2 * n; ++j)
            {
                var item = input[j];
                var p = stack.Peek();

                if (item == p)
                {
                    stack.Pop();
                    continue;
                }

                if (!dict.ContainsKey(p))
                {
                    dict.Add(p, 1);
                }
                else
                {
                    dict[p]++;
                }

                stack.Push(item);
            }

            // wpisywanie wynikow
            for (var j = 1; j <= n; ++j)
            {
                var result = 0;

                if (dict.ContainsKey(j))
                {
                    result = dict[j];
                }

                sb.AppendLine(j + " -> " + result);
            }

            // pusta linia, moze potrzebna
            sb.AppendLine();
        }

        // wypisz calosc
        Console.Write(sb.ToString());

        // nie zamykaj konsoli
        Console.ReadKey(true);
    }
}