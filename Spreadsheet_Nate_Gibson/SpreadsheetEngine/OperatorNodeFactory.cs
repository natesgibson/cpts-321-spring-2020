using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Class which creates operator nodes based on a given oprator.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// </summary>
        public OperatorNodeFactory()
        {
        }

        /// <summary>
        /// Takes an operator char and returns coresponding operator node.
        /// Current valid operators: + - * /.
        /// </summary>
        /// <param name="op">Operator.</param>
        /// <returns>Operator node.</returns>
        public OperatorNode CreateOperatorNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new AddOperatorNode();
                case '-':
                    return new SubOperatorNode();
                case '*':
                    return new MultOperatorNode();
                case '/':
                    return new DivOperatorNode();
                default:
                    throw new NotSupportedException(
                        "Operator " + op.ToString() + " not supported.");
            }
        }
    }
}
