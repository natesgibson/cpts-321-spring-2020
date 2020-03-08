// Name: Nate Gibson
// WSU ID: 11697165

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using CptS321;
using NUnit.Framework;
using SpreadsheetEngine;

namespace Tests_Spreadsheet_Nate_Gibson
{
    /// <summary>
    /// Tests for spreadsheet project.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        //---------------------------------------------------------------
        //                     Spreadsheet  Tests:
        //---------------------------------------------------------------

        /// <summary>
        /// Normal case for Spreadsheet GetCell method.
        /// </summary>
        [Test]
        public void TestSpreadsheetGetCellNormal()
        {
            Spreadsheet s = new Spreadsheet(5, 5);
            SpreadsheetCell newCell = new SpreadsheetCell(0, 0);
            Assert.That(s.GetCell(4, 0).Value, Is.EqualTo(newCell.Value), "Spreadsheet returned undexpected cell at index.");
        }

        /// <summary>
        /// Nonexistent case for Spreadsheet GetCell method.
        /// </summary>
        [Test]
        public void TestSpreadsheetGetCellNonexistent()
        {
            Spreadsheet s = new Spreadsheet(5, 5);
            Assert.That(s.GetCell(6, 0), Is.EqualTo(null), "Spreadsheet returned undexpected cell at index.");
        }

        /// <summary>
        /// Normal case for Spreadsheet ColumnCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetColumnCountNormal()
        {
            Spreadsheet s = new Spreadsheet(6, 5);
            Assert.That(s.ColumnCount(), Is.EqualTo(5), "Spreadsheet returned unexpected column count.");
        }

        /// <summary>
        /// Zero case for Spreadsheet ColumnCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetColumnCountZero()
        {
            Spreadsheet s = new Spreadsheet(5, 0);
            Assert.That(s.ColumnCount(), Is.EqualTo(0), "Spreadsheet returned unexpected column count.");
        }

        /// <summary>
        /// Normal case for Spreadsheet RowCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetRowCountNormal()
        {
            Spreadsheet s = new Spreadsheet(5, 6);
            Assert.That(s.RowCount(), Is.EqualTo(5), "Spreadsheet returned unexpected row count.");
        }

        /// <summary>
        /// Zero case for Spreadsheet RowCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetRowCountZero()
        {
            Spreadsheet s = new Spreadsheet(0, 5);
            Assert.That(s.RowCount(), Is.EqualTo(0), "Spreadsheet returned unexpected row count.");
        }

        //---------------------------------------------------------------
        //              Expression Tree Evaluate Tests:
        //---------------------------------------------------------------

        /// <summary>
        /// Tests a normal case for expression tree evaluate method with an add expression.
        /// </summary>
        [Test]
        public void TestEvaluateAddNormal()
        {
            string expression = "2+2";
            double expectedValue = 2.0 + 2.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a multiple operands case for expression tree evaluate method with an add expression.
        /// </summary>
        [Test]
        public void TestEvaluateAddMultiple()
        {
            string expression = "2+2+3";
            double expectedValue = 2.0 + 2.0 + 3.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a normal case for expression tree evaluate method with an subtraction expression.
        /// </summary>
        [Test]
        public void TestEvaluateSubNormal()
        {
            string expression = "2-1";
            double expectedValue = 2.0 - 1.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a multiple operands case for expression tree evaluate method with an subtraction expression.
        /// </summary>
        [Test]
        public void TestEvaluateSubMultiple()
        {
            string expression = "10-2-3";
            double expectedValue = 10.0 - 2.0 - 3.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a negative result case for expression tree evaluate method with an subtraction expression.
        /// </summary>
        [Test]
        public void TestEvaluateSubNegativeResult()
        {
            string expression = "10-11";
            double expectedValue = 10.0 - 11.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a normal case for expression tree evaluate method with a multiplication expression.
        /// </summary>
        [Test]
        public void TestEvaluateMultNormal()
        {
            string expression = "2*1";
            double expectedValue = 2.0 * 1.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a multiple operands case for expression tree evaluate method with a multiplication expression.
        /// </summary>
        [Test]
        public void TestEvaluateMultMultiple()
        {
            string expression = "2*2*3";
            double expectedValue = 2.0 * 2.0 * 3.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a normal case for expression tree evaluate method with a division expression.
        /// </summary>
        [Test]
        public void TestEvaluateDivNormal()
        {
            string expression = "2/1";
            double expectedValue = 2.0 / 1.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a multiple operands case for expression tree evaluate method with a division expression.
        /// </summary>
        [Test]
        public void TestEvaluateDivMultiple()
        {
            string expression = "2/2/3";
            double expectedValue = 2.0 / 2.0 / 3.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a divide by zero case for expression tree evaluate method with a division expression.
        /// </summary>
        [Test]
        public void TestEvaluateDivByZero()
        {
            string expression = "1/0";
            double expectedValue = 1.0 / 0.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }
    }
}