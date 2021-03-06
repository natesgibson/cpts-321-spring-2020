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
    /// Expression tree node which represents an operator.
    /// </summary>
    public abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Associativity of the operator.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// Rigth associativity.
            /// </summary>
            Right,

            /// <summary>
            /// Left associativity.
            /// </summary>
            Left,
        }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public static char Operator { get; }

        /// <summary>
        /// Gets the associativity of the operator.
        /// </summary>
        public abstract Associative Associativity { get; }

        /// <summary>
        /// Gets the precedence of the operator.
        /// </summary>
        public abstract int Precedence { get; }

        /// <summary>
        /// Gets or sets left child expression tree node.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Gets or sets right child expression tree node.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }
    }
}
