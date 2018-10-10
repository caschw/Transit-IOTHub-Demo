﻿using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;

namespace Transportation.IoTCore
{
    public static class Helpers
    {
        public static byte[] GetBytes(this string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> enumeration, Func<T, TResult> func)
        {
            //var result = new List<TResult>();
            foreach (T item in enumeration)
            {
                //result.Add(func(item));
                var result = func(item);
                yield return result;
            }
            //return result;
        }
    }
}
