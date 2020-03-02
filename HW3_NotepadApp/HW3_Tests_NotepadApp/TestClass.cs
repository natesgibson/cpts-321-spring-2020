// Name: Nate Gibson
// WSU ID: 11697165

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace HW3_Tests_NotepadApp
{
    /// <summary>
    /// Contains tests for HW3 Notepad Application and Fibonacci reader project.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// Test mehod template.
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
