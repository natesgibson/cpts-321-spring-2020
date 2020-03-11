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
    /// Tests for Expression Tree project.
    /// </summary>
    [TestFixture]
    public class ExpressionTreeTests
    {
        //---------------------------------------------------------------
        //                      SetVariable Tests:
        //---------------------------------------------------------------

        /// <summary>
        /// CONDITION: Expression Tree Evaluate method works.
        /// Tests a normal case for expression tree set variable method.
        /// </summary>
        [Test]
        public void TestSetVariableNormal()
        {
            string expression = "A+1";
            ExpressionTree tree = new ExpressionTree(expression);
            tree.SetVariable("A", 3);

            Assert.That(tree.Evaluate(), Is.EqualTo(4.0), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// CONDITION: Expression Tree Evaluate method works.
        /// Tests a multiple variables case for expression tree set variable method.
        /// </summary>
        [Test]
        public void TestSetVariableMultiple()
        {
            string expression = "A+1+B";
            ExpressionTree tree = new ExpressionTree(expression);
            tree.SetVariable("A", 3);
            tree.SetVariable("B", 5);

            Assert.That(tree.Evaluate(), Is.EqualTo(9.0), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// CONDITION: Expression Tree Evaluate method works.
        /// Tests a long variable name case for expression tree set variable method.
        /// </summary>
        [Test]
        public void TestSetVariableLongName()
        {
            string expression = "IAmThree+1";
            ExpressionTree tree = new ExpressionTree(expression);
            tree.SetVariable("IAmThree", 3);

            Assert.That(tree.Evaluate(), Is.EqualTo(4.0), "Evaluate retuned unexpected value.");
        }

        //---------------------------------------------------------------
        //                      Evaluate Tests:
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

        /// <summary>
        /// Tests a normal case for expression tree evaluate method with parenthesis that effect the result.
        /// </summary>
        [Test]
        public void TestEvaluateParensNormal()
        {
            string expression = "(1+1)*2";
            double expectedValue = (1.0 + 1.0) * 2.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a multiple parentheses case for expression tree evaluate method with parenthesis that effect the result.
        /// </summary>
        [Test]
        public void TestEvaluateParensMultiple()
        {
            string expression = "((1+(1))*2)";
            double expectedValue = (1.0 + 1.0) * 2.0;
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a normal case for expression tree evaluate method in which associativity is relevant to the answer.
        /// </summary>
        [Test]
        public void TestEvaluateAssociativeNormal()
        {
            string expression = "1+3*5";
            double expectedValue = 1.0 + (3.0 * 5.0);
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }

        /// <summary>
        /// Tests a case for expression tree evaluate method where all recognized operators are used.
        /// </summary>
        [Test]
        public void TestEvaluateAllOperators()
        {
            string expression = "1+7*100/10-2/1";
            double expectedValue = 1.0 + ((7.0 * 100.0) / 10.0) - (2.0 / 1.0);
            ExpressionTree tree = new ExpressionTree(expression);

            Assert.That(tree.Evaluate(), Is.EqualTo(expectedValue), "Evaluate retuned unexpected value.");
        }
    }
}
