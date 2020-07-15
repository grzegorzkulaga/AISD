using System;

internal static class Program
{
    private static int GetTreeDepth(string tree, int depth, ref int i)
    {
        if (tree[i] == 'l')
        {
            return depth;
        }

        depth++;

        i++;
        var left = GetTreeDepth(tree, depth, ref i);

        i++;
        var right = GetTreeDepth(tree, depth, ref i);

        return Math.Max(left, right);
    }

    private static void Main(string[] args)
    {
        var cases = int.Parse(Console.ReadLine());
        var results = new int[cases];

        for (var n = 0; n < cases; n++)
        {
            var line = Console.ReadLine();
            var i = 0;

            results[n] = GetTreeDepth(line, 0, ref i);
        }

        Array.ForEach(results, Console.WriteLine);

        Console.ReadKey(true);
    }
}