//-----------------------------------------------------------------------
// <copyright file="TestClass.cs" company="Nate Gibson">
//     Copyright (c) Nate Gibson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace HW1_BSTNumberList
{
    /// <summary>
    /// Contains tests for HW1_BSTNumberList Program.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        // ----------------------------------
        // BST ADD TESTS:
        // ----------------------------------

        /// <summary>
        /// Tests normal case for IntBST Add method.
        /// </summary>
        [Test]
        public void TestBSTAddNormal()
        {
            IntBST tree = new IntBST();
            tree.Add(1);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1"), "IntBST did not add new item correctly");
            tree.Add(1000);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 1000"), "IntBST did not add new item correctly");
            tree.Add(8);
            tree.Add(420);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 8 420 1000"), "IntBST did not add new item correctly");
            tree.Add(51);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 8 51 420 1000"), "IntBST did not add new item correctly");
        }

        /// <summary>
        /// Tests duplicate input case for IntBST Add method.
        /// </summary>
        [Test]
        public void TestBSTAddDuplicate()
        {
            IntBST tree = new IntBST();
            tree.Add(1);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1"), "IntBST did not add new item correctly");
            tree.Add(1);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1"), "IntBST did not add duplicate item correctly");
            tree.Add(8);
            tree.Add(420);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 8 420"), "IntBST did not add new item correctly");
            tree.Add(8);
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 8 51 420"), "IntBST did not add duplicate item correctly");
        }

        // ----------------------------------
        // BST GETORDEREDTREE TESTS:
        // ----------------------------------

        /// <summary>
        /// Tests normal case for IntBST GetOrderedTree method.
        /// </summary>
        [Test]
        public void TestBSTGetOrderedNormal()
        {
            IntBST tree = BuildIntBST(new int[] { 1, 2, 3, 7, 5 });
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 2 3 5 7"), "IntBST returned wrong ordered list");
        }

        /// <summary>
        /// Tests empty case for IntBST GetOrderedTree method.
        /// </summary>
        [Test]
        public void TestBSTGetOrderedEmpty()
        {
            IntBST tree = new IntBST();
            Assert.That(tree.GetOrderedTree(), Is.EqualTo(string.Empty), "IntBST returned wrong ordered list");
        }

        /// <summary>
        /// Tests duplicate input case for IntBST GetOrderedTree method.
        /// </summary>
        [Test]
        public void TestBSTGetOrderedDuplicate()
        {
            IntBST tree = BuildIntBST(new int[] { 1, 1, 3, 7, 5, 7, 2, 2 });
            Assert.That(tree.GetOrderedTree(), Is.EqualTo("1 2 3 5 7"), "IntBST returned wrong ordered list");
        }

        // ----------------------------------
        // BST GETSIZE TESTS:
        // ----------------------------------

        /// <summary>
        /// Tests normal case for IntBST GetSize method.
        /// </summary>
        [Test]
        public void TestBSTGetSizeNormal()
        {
            IntBST tree = BuildIntBST(new int[] { 1, 2, 3, 7, 5 });
            Assert.That(tree.GetSize(), Is.EqualTo(5), "IntBST returned wrong size");
        }

        /// <summary>
        /// Tests empty case for IntBST GetSize method.
        /// </summary>
        [Test]
        public void TestBSTGetSizeEmpty()
        {
            IntBST tree = new IntBST();
            Assert.That(tree.GetSize(), Is.EqualTo(0), "IntBST returned wrong size");
        }

        /// <summary>
        /// Tests duplicate input case for IntBST GetSize method.
        /// </summary>
        [Test]
        public void TestBSTGetSizeDuplicate()
        {
            IntBST tree = BuildIntBST(new int[] { 1, 1, 3, 7, 5, 7 });
            Assert.That(tree.GetSize(), Is.EqualTo(4), "IntBST returned wrong size");
        }

        // ----------------------------------
        // BST NUMLEVELS TESTS:
        // ----------------------------------

        /// <summary>
        /// Tests normal case for IntBST GetNumLevels method.
        /// </summary>
        [Test]
        public void TestBSTGetNumLevelsNormal()
        {
            IntBST tree = BuildIntBST(new int[] { 1, 2, 3 });
            Assert.That(tree.GetNumLevels(), Is.EqualTo(2), "IntBST returned wrong number of levels");
        }

        /// <summary>
        /// Tests empty case for IntBST GetNumLevels method.
        /// </summary>
        [Test]
        public void TestBSTGetNumLevelsEmpty()
        {
            IntBST tree = new IntBST();
            Assert.That(tree.GetNumLevels(), Is.EqualTo(0), "IntBST returned wrong number of levels");
        }

        /// <summary>
        /// Tests duplicate input case for IntBST GetNumLevels method.
        /// </summary>
        [Test]
        public void TestBSTGetNumLevelsDuplicate()
        {
            IntBST tree = BuildIntBST(new int[] { 1, 1, 2, 3, 1, 2 });
            Assert.That(tree.GetNumLevels(), Is.EqualTo(2), "IntBST returned wrong number of levels");
        }

        // ----------------------------------
        // NOT TESTS:
        // ----------------------------------

        /// <summary>
        /// Returns a new IntBST from passed-in int array values.
        /// </summary>
        /// <param name="ints">Int array of IntBST inputs.</param>
        /// <returns>New IntBST.</returns>
        private static IntBST BuildIntBST(int[] ints)
        {
            IntBST tree = new IntBST();
            foreach (int i in ints)
            {
                tree.Add(i);
            }

            return tree;
        }
    }
}
