// <copyright file="DistinctIntsAnalyzer.cs" company="Nate Gibson">
// Copyright (c) Nate Gibson. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_WinFormsAndDotNet
{
    /// <summary>
    /// Contains 3 different methods to determine the number of unique items in an int list.
    /// </summary>
    public class DistinctIntsAnalyzer
    {
        /// <summary>
        /// Returns the number of distinct items in an int list
        /// using the hash set method to find distinct items.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The number of distinct items in {list}.</returns>
        public int HashMethGetNumDistinct(List<int> list)
        {
            HashSet<int> hSet = new HashSet<int>();
            foreach (int i in list)
            {
                hSet.Add(i);
            }

            return hSet.Count;
        }

        /// <summary>
        /// Returns the number of distinct items in an int list
        /// using the O(1) storage complexity method to find distinct items.
        /// This runs in O(1) time with O(1) space and does not alter the list.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The number of distinct items in {list}.</returns>
        public int BigO1MethGetNumDistinct(List<int> list)
        {
            int numDistinct = 0;
            for (int i = this.GetMin(list); i <= this.GetMax(list); i++)
            {
                if (list.Contains(i))
                {
                    numDistinct++;
                }
            }

            return numDistinct;
        }

        /// <summary>
        /// Returns the number of distinct items in an int list
        /// using the sorted method to find distinct items.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The number of distinct items in {list}.</returns>
        public int SortedMethGetNumDistinct(List<int> list)
        {
            list.Sort();
            int numDistinct = 0;
            int listSize = list.Count();

            for (int i = 0; i < list.Count; i++)
            {
                numDistinct++;

                // Itterates i once per duplicate, effectively skipping them:
                for (int j = i + 1; j < listSize && list[j] == list[i]; j++)
                {
                    i++;
                }
            }

            return numDistinct;
        }

        /// <summary>
        /// Returns the mininum value of an int list.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The int list's minimum value.</returns>
        private int GetMin(List<int> list)
        {
            int min = 0;
            foreach (int i in list)
            {
                if (i < min)
                {
                    min = i;
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the maximum value of an int list.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The int list's maximum value.</returns>
        private int GetMax(List<int> list)
        {
            int max = 0;
            foreach (int i in list)
            {
                if (i > max)
                {
                    max = i;
                }
            }

            return max;
        }
    }
}
