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
            return 0;
        }

        /// <summary>
        /// Returns the number of distinct items in an int list
        /// using the O(1) storage complexity method to find distinct items.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The number of distinct items in {list}.</returns>
        public int BigO1MethGetNumDistinct(List<int> list)
        {
            return 0;
        }

        /// <summary>
        /// Returns the number of distinct items in an int list
        /// using the sorted method to find distinct items.
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <returns>The number of distinct items in {list}.</returns>
        public int SortedMethGetNumDistinct(List<int> list)
        {
            return 0;
        }
    }
}
