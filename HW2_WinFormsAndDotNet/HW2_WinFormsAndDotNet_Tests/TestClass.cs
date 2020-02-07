// <copyright file="TestClass.cs" company="Nate Gibson">
// Copyright (c) Nate Gibson. All rights reserved.
// </copyright>

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace HW2_WinFormsAndDotNet
{
    /// <summary>
    /// Contains tests for HW2 WinForms Project.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        // ---------------------------------------------------------------------
        //          RANND_INT_LIST_GENERATOR GET_NEW_LIST TESTS:
        // ---------------------------------------------------------------------

        /// <summary>
        /// Tests normal case for RandIntListGenerator GetNewList method.
        /// </summary>
        [Test]
        public void TestGetNewListNormal()
        {
            RandIntListGenerator listGen = new RandIntListGenerator(10);
            List<int> list = listGen.GetNewList();
            Assert.That(list.Count, Is.EqualTo(10), "new list size different from expected");
            Assert.That(this.ListInRange(list, 0, 20000), Is.True, "new list not in correct range");
        }

        /// <summary>
        /// Tests empty case for RandIntListGenerator GetNewList method.
        /// </summary>
        [Test]
        public void TestGetNewListEmpty()
        {
            RandIntListGenerator listGen = new RandIntListGenerator(0);
            List<int> list = listGen.GetNewList();
            Assert.That(list.Count, Is.EqualTo(0), "new list size different from expected");
            Assert.That(this.ListInRange(list, 0, 20000), Is.True, "new list not in correct range");
        }

        /// <summary>
        /// Tests large case for RandIntListGenerator GetNewList method.
        /// </summary>
        [Test]
        public void TestGetNewListLarge()
        {
            RandIntListGenerator listGen = new RandIntListGenerator(); // default size = 10,000
            List<int> list = listGen.GetNewList();
            Assert.That(list.Count, Is.EqualTo(10000), "new list size different from expected");
            Assert.That(this.ListInRange(list, 0, 20000), Is.True, "new list not in correct range");
        }

        /// <summary>
        /// Tests differnt bounds case for RandIntListGenerator GetNewList method.
        /// </summary>
        [Test]
        public void TestGetNewListDiffBounds()
        {
            RandIntListGenerator listGen = new RandIntListGenerator(10, 0, 1);
            List<int> list = listGen.GetNewList();
            Assert.That(list.Count, Is.EqualTo(10), "new list size different from expected");
            Assert.That(this.ListInRange(list, 0, 1), Is.True, "new list not in correct range");
        }

        /// <summary>
        /// Tests negative bounds case for RandIntListGenerator GetNewList method.
        /// </summary>
        [Test]
        public void TestGetNewListNegBounds()
        {
            RandIntListGenerator listGen = new RandIntListGenerator(10, -10, 10);
            List<int> list = listGen.GetNewList();
            Assert.That(list.Count, Is.EqualTo(10), "new list size different from expected");
            Assert.That(this.ListInRange(list, -10, 10), Is.True, "new list not in correct range");
        }

        // ---------------------------------------------------------------------
        //                          NON-TESTS:
        // ---------------------------------------------------------------------

        /// <summary>
        /// Method takes an int list and returns if each list value is
        /// between the lower and upper bounds (inclusive).
        /// </summary>
        /// <param name="list">Int list.</param>
        /// <param name="lowerBound">Smallest value allowed in list.</param>
        /// <param name="upperBound">Greatest value allowed in list.</param>
        /// <returns>If each list value is between the lower and upper bounds (inclusive).</returns>
        private bool ListInRange(List<int> list, int lowerBound, int upperBound)
        {
            foreach (int i in list)
            {
                if (i < lowerBound || i > upperBound)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
