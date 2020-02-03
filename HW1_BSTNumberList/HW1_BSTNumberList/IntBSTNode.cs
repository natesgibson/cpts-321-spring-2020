//-----------------------------------------------------------------------
// <copyright file="IntBSTNode.cs" company="Nate Gibson">
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
    /// Node for 'IntBST' Tree. Contains left and right child nodes, and int value.
    /// </summary>
    public class IntBSTNode
    {
        /// <summary>
        /// Int value of the node.
        /// </summary>
        private int value;

        /// <summary>
        /// Left child of the node.
        /// </summary>
        private IntBSTNode left = null;

        /// <summary>
        /// Right child of the node.
        /// </summary>
        private IntBSTNode right = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntBSTNode"/> class.
        /// </summary>
        public IntBSTNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntBSTNode"/> class.
        /// </summary>
        /// <param name="newValue">Int value of node.</param>
        public IntBSTNode(int newValue)
        {
            this.value = newValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntBSTNode"/> class.
        /// </summary>
        /// <param name="newValue">Int value of node.</param>
        /// /// <param name="newLeft">Right child of node.</param>
        /// /// <param name="newRight">Left child of node.</param>
        public IntBSTNode(int newValue, IntBSTNode newLeft, IntBSTNode newRight)
        {
            this.value = newValue;
            this.left = newLeft;
            this.right = newRight;
        }

        /// <summary>
        /// Returns node int value.
        /// </summary>
        /// <returns>Node int value.</returns>
        public int GetValue()
        {
            return this.value;
        }

        /// <summary>
        /// Returns node left child.
        /// </summary>
        /// <returns>Node left child.</returns>
        public IntBSTNode GetLeftChild()
        {
            return this.left;
        }

        /// <summary>
        /// Returns node right child.
        /// </summary>
        /// <returns>Node right child.</returns>
        public IntBSTNode GetRightChild()
        {
            return this.right;
        }

        /// <summary>
        /// Changes node int value to new value.
        /// </summary>
        /// <param name="value">New int node value.</param>
        public void SetValue(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Changes node left child to new left child.
        /// </summary>
        /// <param name="newLeft">New node left child.</param>
        public void SetLeftChild(IntBSTNode newLeft)
        {
            this.left = newLeft;
        }

        /// <summary>
        /// Changes node right child to new right child.
        /// </summary>
        /// <param name="newRight">New node right child.</param>
        public void SetRightChild(IntBSTNode newRight)
        {
            this.right = newRight;
        }
    }
}
