//-----------------------------------------------------------------------
// <copyright file="ProcessInput.cs" company="Nate Gibson">
//     Copyright (c) Nate Gibson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_BSTNumberList
{
    /// <summary>
    /// Contains methods for processing user input data for BST Number List C# console application.
    /// </summary>
    public class ProcessInput
    {
        /// <summary>
        /// Takes an int array and returns an IntBST of ints from the input int array.
        /// </summary>
        /// <param name="ints">Int array for IntBST values.</param>
        /// <returns>IntBST of int items from input int array.</returns>
        public static IntBST BuildIntBSTFromInts(int[] ints)
        {
            IntBST tree = new IntBST();
            foreach (int i in ints)
            {
                tree.Add(i);
            }

            return tree;
        }

        /// <summary>
        /// Takes in Takes in string of ints separated by spaces,
        /// returns an IntBST of int items from the input string.
        /// </summary>
        /// <param name="input">String of ints separated by spaces.</param>
        /// <returns>IntBST of int items from input string.</returns>
        public static IntBST BuildIntBSTFromString(string input)
        {
            return BuildIntBSTFromInts(StringToIntArray(input));
        }

        /// <summary>
        /// Takes in string of ints separated by spaces and returns the ints in an int array.
        /// Input string must contain at least one int.
        /// </summary>
        /// <param name="input">String of ints separated by spaces.</param>
        /// <returns>Int array of ints from input string.</returns>
        public static int[] StringToIntArray(string input)
        {
            string[] ints = input.Split(' ');
            return Array.ConvertAll(ints, int.Parse);
        }
    }
}
