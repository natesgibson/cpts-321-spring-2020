using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Class which contains and evaluates an expression tree.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">A valid string expression.</param>
        public ExpressionTree(string expression)
        {
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
    }
}
