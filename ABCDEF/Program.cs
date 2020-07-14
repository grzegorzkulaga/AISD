using System;
using System.Collections.Generic;

namespace abcdef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] S = new int[100];
            int output = 0;
            int N = int.Parse(Console.ReadLine());
            int i, j, k;

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (i = -30000; i <= 30000; i++)
            {
                dic[i] = 0;
            }

            for (i = 0; i != N; i++)
            {
                S[i] = int.Parse(Console.ReadLine());
            }

            for (i = 0; i != N; i++)
            {
                for (j = 0; j != N; j++)
                {
                    for (k = 0; k != N; k++)
                    {
                        dic[S[i] * S[j] + S[k]]++;
                    }
                }
            }

            for (i = 0; i != N; i++)
            {
                if (S[i] == 0)
                    continue;
                else
                {
                    for (j = 0; j != N; j++)
                    {
                        for (k = 0; k != N; k++)
                        {
                            output += dic[(S[j] + S[k]) * S[i]];
                        }
                    }
                }
            }
            Console.Write(output);
        }
    }
}