using System;
using System.Linq;
using System.Collections.Generic;

internal static class RKSorting
{
    private class Element
    {
        public int Index, Value, N;
    }

    private class Comparer : IComparer<Element>
    {
        public int Compare(Element x, Element y)
        {
            if (x.Value != y.Value)
                return y.Value - x.Value;
            else
                return x.Index - y.Index;
        }
    }

    private static IEnumerable<Element> ParseElements()
    {
        Console.ReadLine();

        var line = Console.ReadLine();
        var numerki = line.Split(' ');

        var array = new Element[numerki.Length];

        for (int i = 0; i < numerki.Length; i++)
        {
            var element = new Element();

            element.Index = i;
            element.Value = 1;
            element.N = int.Parse(numerki[i]);

            array[i] = element;
        }

        return array;
    }

    private static void Main(string[] args)
    {
        var list = ParseElements().OrderBy(element => element.N).ToList();

        for (var i = 1; i < list.Count; i++)
        {
            if (list[i - 1].N == list[i].N)
            {
                list[i].Value = list[i - 1].Value + 1;
                list[i].Index = Math.Min(list[i].Index, list[i - 1].Index);
            }
        }

        if (list[list.Count - 1].N == list[list.Count - 2].N)
        {
            list[list.Count - 1].Index = Math.Min(list[list.Count - 1].Index, list[list.Count - 2].Index);
        }

        for (var i = list.Count - 2; i >= 0; i--)
        {
            if (list[i].N == list[i + 1].N)
            {
                list[i].Value = list[i + 1].Value;
                list[i].Index = Math.Min(list[i].Index, list[i + 1].Index);
            }
        }

        list.Sort(new Comparer());

        var output = string.Join(' ', list.Select(element => element.N));
        Console.WriteLine(output);
    }
}