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
    /// ExpressionTreeNode which represents a variable.
    /// </summary>
    public class VariableNode : ExpressionTreeNode
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Dictionary which keeps track of variables and thier values.
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">Variable name.</param>
        /// <param name="variables">Dictionary of variables and thier values.</param>
        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>
        /// Gets the name of the varible.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Evaluates and returns the variable value.
        /// Returns 0 by default if variable is not found.
        /// </summary>
        /// <returns>Node's variable value.</returns>
        public override double Evaluate()
        {
            double value = 0.0;
            if (this.variables.ContainsKey(this.name))
            {
                value = this.variables[this.name];
            }

            return value;
        }
    }
}
