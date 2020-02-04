//-----------------------------------------------------------------------
// <copyright file="IntBST.cs" company="Nate Gibson">
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
    /// Integer Binary Search Tree for BST Number List C# console application.
    /// </summary>
    public class IntBST
    {
        /// <summary>
        /// Root node of tree.
        /// </summary>
        private IntBSTNode root = null;

        /// <summary>
        /// Number of items in the tree.
        /// </summary>
        private int size = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntBST"/> class.
        /// </summary>
        public IntBST()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntBST"/> class.
        /// </summary>
        /// <param name="newRoot">New root node of tree.</param>
        public IntBST(IntBSTNode newRoot)
        {
            this.root = newRoot;
            this.size++;
        }

        /// <summary>
        /// Adds a new node to the tree in the correct position.
        /// </summary>
        /// <param name="newInt">(Int) value of new node.</param>
        public void Add(int newInt)
        {
            if (this.root == null)
            {
                this.root = new IntBSTNode(newInt);
                this.size++;
            }
            else
            {
                this.AddHelper(this.root, newInt);
            }
        }

        /// <summary>
        /// Recursively navigates down tree and adds node to appropriate spot.
        /// Terminates if new value is found to be a duplicate.
        /// </summary>
        /// <param name="currNode">Current node in tree.</param>
        /// <param name="newInt">New value to be added to tree.</param>
        private void AddHelper(IntBSTNode currNode, int newInt)
        {
            int currValue = currNode.GetValue();
            if (newInt < currValue)
            {
                IntBSTNode left = currNode.GetLeftChild();
                if (left != null)
                {
                    this.AddHelper(left, newInt);
                }
                else
                {
                    currNode.SetLeftChild(new IntBSTNode(newInt));
                    this.size++;
                }
            }
            else if (newInt > currValue)
            {
                IntBSTNode right = currNode.GetRightChild();
                if (right != null)
                {
                    this.AddHelper(right, newInt);
                }
                else
                {
                    currNode.SetRightChild(new IntBSTNode(newInt));
                    this.size++;
                }
            }
        }

        /// <summary>
        /// Returns an ordered (smallest to largest) list of the tree contents.
        /// </summary>
        /// <returns>Ordered list string.</returns>
        public string GetOrderedTree()
        {
            string list = string.Empty;

            if (this.root != null)
            {
                list = this.GetOrderedTreeHelper(this.root, list);
            }

            return list.Trim();
        }

        /// <summary>
        /// Recursively navigates down tree and adds items in sorted order to list string.
        /// </summary>
        /// <param name="currNode">Current node in tree.</param>
        /// <param name="list">Current ordered list of items in tree.</param>
        /// <returns>Updated ordered list of items in tree.</returns>
        private string GetOrderedTreeHelper(IntBSTNode currNode, string list)
        {
            IntBSTNode left = currNode.GetLeftChild();
            IntBSTNode right = currNode.GetRightChild();

            if (left != null)
            {
                list = this.GetOrderedTreeHelper(left, list);
            }

            list += currNode.GetValue() + " ";

            if (right != null)
            {
                list = this.GetOrderedTreeHelper(right, list);
            }

            return list;
        }

        /// <summary>
        /// Returns the number of items in the tree.
        /// </summary>
        /// <returns>Number of items in the tree.</returns>
        public int GetSize()
        {
            return this.size;
        }

        /// <summary>
        /// Returns the number of levels in the tree.
        /// </summary>
        /// <returns>Number of levels in tree.</returns>
        public int GetNumLevels()
        {
            return this.GetNumLevelsHelper(this.root, 0);
        }

        /// <summary>
        /// Recursively navigates down tree to find the lowest level.
        /// Returns the total number of levels in the tree.
        /// </summary>
        /// <param name="currNode">Current node in tree.</param>
        /// <param name="levels">Current number of levels in tree.</param>
        /// <returns>Updated number of levels in tree.</returns>
        private int GetNumLevelsHelper(IntBSTNode currNode, int levels)
        {
            if (currNode != null)
            {
                levels = 1 + Math.Max(
                                    this.GetNumLevelsHelper(currNode.GetLeftChild(), levels),
                                    this.GetNumLevelsHelper(currNode.GetRightChild(), levels));
            }

            return levels;
        }

        /// <summary>
        /// Returns the theoretical minimum number of levels the tree can have
        /// given the number of nodes it contains.
        /// </summary>
        /// <returns>Theoretical minimum number of levels.</returns>
        public int GetTheoMinLevels()
        {
            int theoMinLevels = 0;

            if (this.size > 0)
            {
                // min number of levels where n = number of nodes is: log2(n) + 1 = log10(n)/log10(2) + 1
                theoMinLevels = (int)Math.Floor(Math.Log10(this.size) / Math.Log10(2)) + 1;
            }

            return theoMinLevels;
        }
    }
}
