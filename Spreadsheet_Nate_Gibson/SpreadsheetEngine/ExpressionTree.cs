// Name: Nate Gibson
// WSU ID: 11697165

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
        /// dictionary of variables.
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">A valid string expression.</param>
        public ExpressionTree(string expression)
        {
            this.variables = new Dictionary<string, double>();
            this.root = this.BuildExpressionTree(expression);
        }

        /// <summary>
        /// Sets variable variableName to double variableValue.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="variableValue">The value to set the variable to.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
        }

        /// <summary>
        /// Evaluates the expression tree and returns double value.
        /// </summary>
        /// <returns>Evaluated expression tree value.</returns>
        public double Evaluate()
        {
            return this.root.Evaluate();
        }

        /// <summary>
        /// Builds an expression tree from expression string.
        /// Returns the root node of the expression tree.
        /// </summary>
        /// <param name="expression">Expression string.</param>
        /// <returns>Root of built expression tree.</returns>
        private ExpressionTreeNode BuildExpressionTree(string expression)
        {
            List<ExpressionTreeNode> postfixList = this.GetPostfixList(expression);
            Stack<ExpressionTreeNode> stack = new Stack<ExpressionTreeNode>();

            foreach (ExpressionTreeNode currNode in postfixList)
            {
                Type nodeType = currNode.GetType();
                if (this.IsVariableOrConstantNode(currNode))
                {
                    stack.Push(currNode);
                }
                else
                {
                    OperatorNode currOpNode = currNode as OperatorNode;
                    currOpNode.Right = stack.Pop();
                    currOpNode.Left = stack.Pop();
                    stack.Push(currOpNode);
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// Takes a valid string expression and returns a
        /// postfix ordered list of expression tree nodes.
        /// </summary>
        /// <param name="expression">Valid expression string.</param>
        /// <returns>Postfix ordered expression tree node list.</returns>
        private List<ExpressionTreeNode> GetPostfixList(string expression)
        {
            Stack<OperatorNode> stack = new Stack<OperatorNode>();
            List<ExpressionTreeNode> postfixList = new List<ExpressionTreeNode>();
            OperatorNodeFactory opFact = new OperatorNodeFactory();

            char[] expressionArray = expression.ToArray<char>();
            for (int i = 0; i < expressionArray.Length; i++)
            {
                char currChar = expressionArray[i];
                if (this.IsValidOperator(currChar))
                {
                    OperatorNode currOpNode = opFact.CreateOperatorNode(currChar);
                    if (stack.Count <= 0)
                    {
                        stack.Push(currOpNode);
                    }
                    else
                    {
                        postfixList.Add(stack.Pop());
                        i--;
                    }
                }
                else if (char.IsDigit(currChar))
                {
                    string constantString = currChar.ToString();
                    for (int j = i + 1; j < expressionArray.Length; j++)
                    {
                        currChar = expressionArray[j];
                        if (char.IsDigit(currChar))
                        {
                            constantString += currChar.ToString();
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    postfixList.Add(new ConstantNode(double.Parse(constantString)));
                }
                else
                {
                    string variable = currChar.ToString();
                    for (int j = i + 1; j < expressionArray.Length; j++)
                    {
                        currChar = expressionArray[j];
                        if (!this.IsValidOperator(currChar))
                        {
                            variable += expressionArray[j].ToString();
                            this.variables[variable] = 0.0;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    postfixList.Add(new VariableNode(variable, ref this.variables));
                }
            }

            while (stack.Count > 0)
            {
                postfixList.Add(stack.Pop());
            }

            return postfixList;
        }

        /// <summary>
        /// Returns if char input is a valid operator.
        /// Current valid operators: + - * /.
        /// </summary>
        /// <param name="input">Input character.</param>
        /// <returns>Bool respresenting if input is a valid operator.</returns>
        private bool IsValidOperator(char input)
        {
            return input == '+' || input == '-' || input == '*' || input == '/';
        }

        /// <summary>
        /// Takes an expression tree node and returns if the node is a constant or variable node type.
        /// </summary>
        /// <param name="node">Expression tree node.</param>
        /// <returns>Bool that represents is the node is a constant or variable node type.</returns>
        private bool IsVariableOrConstantNode(ExpressionTreeNode node)
        {
            Type nodeType = node.GetType();
            return nodeType.Equals(typeof(ConstantNode)) || nodeType.Equals(typeof(VariableNode));
        }
    }
}
