using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterRandomizer.Common
{
    public static class EnumerableRandomizerExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElement<T>(new Random());
        }

        public static T RandomElement<T>(this IEnumerable<T> enumerable, Random rand)
        {
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }
    }
}