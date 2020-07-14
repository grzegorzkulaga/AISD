using System;
using System.Collections.Generic;
using System.Linq;

namespace sbankk
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = int.Parse(Console.ReadLine());

            for (var i = 0; i < r; i++)
            {
                var dict = new SortedDictionary<BankNumber, int>(new BankNumberComparer());
                var n = int.Parse(Console.ReadLine());

                for (var j = 0; j < n; j++)
                {
                    var nr = BankNumber.Parse();

                    if (!dict.TryAdd(nr, 1))
                    {
                        dict[nr]++;
                    }
                }

                foreach (var pair in dict)
                {
                    Console.WriteLine($"{pair.Key}, {pair.Value}");
                }
            }
        }

        private class BankNumber
        {
            private static readonly string[] Formats = { "00", "00000000", "0000" };

            public readonly int[] Id;

            private BankNumber(int[] ids)
            {
                this.Id = ids;
            }

            public static BankNumber Parse()
            {
                var line = Console.ReadLine();

                return new BankNumber(Array.ConvertAll(line.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse));
            }

            public override string ToString()
            {
                return string.Join(' ', this.Id.Select((el, i) => el.ToString(Formats[Math.Min(i, 2)])));
            }
        }

        private class BankNumberComparer : IComparer<BankNumber>
        {
            public int Compare(BankNumber x, BankNumber y)
            {
                return x.Id.Select((t, i) => t.CompareTo(y.Id[i])).FirstOrDefault(comp => comp != 0);
            }
        }
    }
}