//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Nate Gibson">
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
    /// Contains the main method for BST Number List C# console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is the main method for the BST Number List C# console application.
        /// Users are asked to input a string of integers, separated by spaces.
        /// Program puts the integers into a BST and outputs certain statistics about the BST.
        /// </summary>
        /// <param name="args">Arguments passed in at start of program.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a collection of numbers in the range [0, 100], separated by spaces:");
            IntBST tree = ProcessInput.BuildIntBSTFromString(Console.ReadLine());
            Console.WriteLine("Tree contents: " + tree.GetOrderedTree());
            Console.WriteLine("  Number of nodes: " + tree.GetSize());
            Console.WriteLine("  Number of levels: " + tree.GetNumLevels());
            Console.WriteLine("  Minimum number of levels that a tree with 7 nodes could have = " +
                                                                                    tree.GetTheoMinLevels());
            Console.WriteLine("Done");
        }
    }
}
