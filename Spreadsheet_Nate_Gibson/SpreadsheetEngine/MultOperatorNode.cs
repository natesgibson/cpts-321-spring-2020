// Name: Nate Gibson
// WSU ID: 11697165

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Operator node which represents the multiplication operator.
    /// </summary>
    public class MultOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultOperatorNode"/> class.
        /// </summary>
        public MultOperatorNode()
        {
        }

        /// <summary>
        /// Gets associativity of operator.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluates and returns the product of the evaluated values
        /// of the node's left and right children.
        /// </summary>
        /// <returns>Evaluated node value.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}
