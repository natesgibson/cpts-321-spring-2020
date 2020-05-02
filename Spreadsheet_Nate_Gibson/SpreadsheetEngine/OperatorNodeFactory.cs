// Name: Nate Gibson
// WSU ID: 11697165

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// Holds valid operators char and type.
        /// </summary>
        private Dictionary<char, Type> operators;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// </summary>
        public OperatorNodeFactory()
        {
            this.operators = new Dictionary<char, Type>();
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        /// <summary>
        /// Delegate for operator char and type.
        /// </summary>
        /// <param name="op">Operater character.</param>
        /// <param name="type">Operator type.</param>
        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// Takes an operator char and returns coresponding operator node.
        /// Accepts all operators that are defined which inherit the OperatorNode class.
        /// </summary>
        /// <param name="op">Operator.</param>
        /// <returns>Operator node.</returns>
        public OperatorNode CreateOperatorNode(char op)
        {
            if (!this.operators.ContainsKey(op))
            {
                throw new NotSupportedException("Operator " + op.ToString() + " not supported.");
            }

            return (OperatorNode)Activator.CreateInstance(this.operators[op]);
        }

        /// <summary>
        /// Returns if a char is a valid operator.
        /// </summary>
        /// <param name="op">Operator char.</param>
        /// <returns>Boolean.</returns>
        internal bool IsValidOperator(char op)
        {
            return this.operators.ContainsKey(op);
        }

        /// <summary>
        /// Traverses all assemblies for subclasses of OperatorNode
        /// and adds their Operator property and type to operators dictionary.
        /// </summary>
        /// <param name="onOperator">Delegate.</param>
        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            Type operatorNodeType = typeof(OperatorNode);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));

                foreach (var type in operatorTypes)
                {
                    PropertyInfo operatorField = type.GetProperty("Operator");

                    if (operatorField != null)
                    {
                        var value = operatorField.GetValue(type);

                        if (value is char)
                        {
                            char operatorSymbol = (char)value;
                            onOperator(operatorSymbol, type);
                        }
                    }
                }
            }
        }
    }
}