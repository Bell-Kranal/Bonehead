using System;
using System.Collections.Generic;

namespace Data
{
    public static class DataExtensions
    {
        public static List<TResult> ToList<TResult, TSource>(this TSource[] source, Func<TSource, TResult> operation)
        {
            List<TResult> list = new List<TResult>();

            int sourceLenght = source.Length;
            for (int i = 0; i < sourceLenght; i++)
            {
                list.Add(operation.Invoke(source[i]));
            }

            return list;
        }
    }
}