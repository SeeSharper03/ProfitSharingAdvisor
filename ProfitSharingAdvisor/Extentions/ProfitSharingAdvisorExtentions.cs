
using System;
using System.Collections.Generic;

namespace ProfitSharingAdvisor.Extentions
{
    public static class ProfitSharingAdvisorExtentions
    {
        #region Sorting
        /// <summary>Bubble Sort in Ascending Order
        /// <para>Sorts collection in ascending order based on a property as long as the property implements IComparable</para>
        /// </summary>
        public static IList<T> BubbleSort<T,TKey>(this IList<T> source, Func<T, TKey> keySelector) where TKey : System.IComparable
        {
            return BubbleSortCore(source, keySelector, true);
        }

        /// <summary>Bubble Sort in Descending Order
        /// <para>Sorts collection in descending order based on a property as long as the property implements IComparable</para>
        /// </summary>
        public static IList<T> BubbleSortDesc<T,TKey>(this IList<T> source, Func<T, TKey> keySelector) where TKey : System.IComparable
        {
            return BubbleSortCore(source, keySelector, false);
        }

        /// <summary>Bubble Sort Core Algorithm
        /// <para>Provide single, private implementation for bubble sort regardless of sort order</para>
        /// </summary>
        private static IList<T> BubbleSortCore<T,TKey>(IList<T> source, Func<T, TKey> keySelector, bool ascending) where TKey : IComparable
        {
            for (int i = 0; i < source.Count - 1; i++)
            {
                for (int j = 0; j < source.Count - 1; j++)
                {
                    var item1 = keySelector.Invoke(source[j]);
                    var item2 = keySelector.Invoke(source[j + 1]);
                    var compareResult = item1.CompareTo(item2);
                    if (ascending ? compareResult > 0 : compareResult < 0)
                    {
                        var temp = source[j];
                        source[j] = source[j + 1];
                        source[j + 1] = temp;
                    }
                }
            }
            return source;
        }
        #endregion

    }
}
