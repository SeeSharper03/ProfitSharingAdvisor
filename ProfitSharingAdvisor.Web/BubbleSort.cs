using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfitSharingAdvisor.Extentions;
using System.Collections.Generic;
using System.Linq;

namespace ProfitSharingAdvisor.Web
{
    [TestClass]
    public class BubbleSort
    {
        [TestMethod]
        public void Bubble_Sort_Integers_Returns_Sorted_Ascending_Order()
        {
            var expected = new List<int>() { 1, 3, 10, 6, 12, 30, -1, 6 };
            var actual = new List<int>() { 1, 3, 10, 6, 12, 30, -1, 6 };

            expected = expected.OrderBy(x => x).ToList();
            actual = actual.BubbleSort(x => x).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Bubble_Sort_Desc_Integers_Returns_Sorted_Descending_Order()
        {
            var expected = new List<int>() { 1, 3, 10, 6, 12, 30, -1, 6 };
            var actual = new List<int>() { 1, 3, 10, 6, 12, 30, -1, 6 };

            expected = expected.OrderByDescending(x => x).ToList();
            actual = actual.BubbleSortDesc(x => x).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Bubble_Sort_Decimals_Returns_Sorted_Ascending_Order()
        {
            var expected = new List<decimal>() { 1.2M, 3, 10, 0.0006M, 12.00048M, 30, -1, -6.03M };
            var actual = new List<decimal>() { 1.2M, 3, 10, 0.0006M, 12.00048M, 30, -1, -6.03M };

            expected = expected.OrderBy(x => x).ToList();
            actual = actual.BubbleSort(x => x).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Bubble_Sort_Desc_Decimals_Returns_Sorted_Descending_Order()
        {
            var expected = new List<decimal>() { 1.2M, 3, 10, 0.0006M, 12.00048M, 30, -1, -6.03M };
            var actual = new List<decimal>() { 1.2M, 3, 10, 0.0006M, 12.00048M, 30, -1, -6.03M };

            expected = expected.OrderByDescending(x => x).ToList();
            actual = actual.BubbleSortDesc(x => x).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Bubble_Sort_Strings_Returns_Sorted_Ascending_Order()
        {
            var expected = new List<string>() { "one", "two", "three", "four", "five" };
            var actual = new List<string>() { "one", "two", "three", "four", "five" };

            expected = expected.OrderBy(x => x).ToList();
            actual = actual.BubbleSort(x => x).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Bubble_Sort_Desc_Strings_Returns_Sorted_Descending_Order()
        {
            var expected = new List<string>() { "one", "two", "three", "four", "five" };
            var actual = new List<string>() { "one", "two", "three", "four", "five" };

            expected = expected.OrderByDescending(x => x).ToList();
            actual = actual.BubbleSortDesc(x => x).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
