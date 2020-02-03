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
            return string.Empty;
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
            return 0;
        }
    }
}
