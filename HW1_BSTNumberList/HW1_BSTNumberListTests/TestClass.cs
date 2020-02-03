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

namespace HW1_BSTNumberListTests
{
    /// <summary>
    /// Contains tests for HW1_BSTNumberList Program.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// Example test.
        /// </summary>
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
