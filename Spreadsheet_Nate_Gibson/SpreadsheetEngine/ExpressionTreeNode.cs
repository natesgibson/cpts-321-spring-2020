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
    /// Abstract class for expression tree nodes.
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// Evaluates and returns the expression tree node.
        /// </summary>
        /// <returns>Evaluated expression tree node value.</returns>
        public abstract double Evaluate();
    }
}
