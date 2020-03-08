using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetEngine;

namespace CptS321
{
    /// <summary>
    /// Class which contains and evaluates an expression tree.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Expression tree root node.
        /// </summary>
        private ExpressionTreeNode root;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">A valid string expression.</param>
        public ExpressionTree(string expression)
        {
            this.root = this.BuildExpressionTree(expression);
        }

        /// <summary>
        /// Sets variable variableName to double variableValue.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="variableValue">The value to set the variable to.</param>
        public void SetVariable(string variableName, double variableValue)
        {
        }

        /// <summary>
        /// Evaluates the expression tree and returns double value.
        /// </summary>
        /// <returns>Evaluated expression tree value.</returns>
        public double Evaluate()
        {
            return 0.0;
        }

        /// <summary>
        /// Builds the expression tree from provided expression string.
        /// Returns the root of the expression tree.
        /// </summary>
        /// <param name="expression">Expression string.</param>
        /// <returns>Root of built expression tree.</returns>
        private ExpressionTreeNode BuildExpressionTree(string expression)
        {
            return new ConstantNode(0);
        }
    }
}
