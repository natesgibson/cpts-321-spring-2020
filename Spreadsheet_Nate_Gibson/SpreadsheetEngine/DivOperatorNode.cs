using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Operator node which represents the division operator.
    /// </summary>
    public class DivOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivOperatorNode"/> class.
        /// </summary>
        public DivOperatorNode()
        {
        }

        /// <summary>
        /// Evaluates and returns the quotient of the evaluated values
        /// of the node's left and right children.
        /// </summary>
        /// <returns>Evaluated node value.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}
