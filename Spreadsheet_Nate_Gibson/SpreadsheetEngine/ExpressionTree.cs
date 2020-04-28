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
                if (this.IsConstantNode(currNode) || this.IsVariableNode(currNode))
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
        /// Takes a valid string expression and returns a postfix ordered list of expression tree nodes.
        /// Uses Dijkstra's Shunting Yard algorithm.
        /// </summary>
        /// <param name="expression">Valid expression string.</param>
        /// <returns>Postfix ordered expression tree node list.</returns>
        private List<ExpressionTreeNode> GetPostfixList(string expression)
        {
            Stack<char> stack = new Stack<char>();
            List<ExpressionTreeNode> postfixList = new List<ExpressionTreeNode>();
            OperatorNodeFactory opFact = new OperatorNodeFactory();

            char[] expressionArray = expression.ToArray<char>();

            // loops over each char in expression string
            for (int i = 0; i < expressionArray.Length; i++)
            {
                char currChar = expressionArray[i];

                // if the current char is a left parenthesis, push to stack
                if (currChar.Equals('('))
                {
                    stack.Push(currChar);
                }

                // if the current char is a right parenthesis
                else if (currChar.Equals(')'))
                {
                    // while the top of the stack is not a left parenthesis, pop and add to list
                    while (!stack.Peek().Equals('('))
                    {
                        OperatorNode newOpNode = opFact.CreateOperatorNode(stack.Pop());
                        postfixList.Add(newOpNode);
                    }

                    stack.Pop(); // pop the left parenthesis from the top of the stack
                }

                // If the current char is a valid operator
                else if (this.IsValidOperator(currChar))
                {
                    // if the stack is empty or the next char is a left parenthesis
                    if (stack.Count <= 0 || stack.Peek().Equals('('))
                    {
                        stack.Push(currChar);
                    }

                    // otherwise the next char on the stack is an operator
                    else
                    {
                        OperatorNode currOpNode = opFact.CreateOperatorNode(currChar);
                        OperatorNode nextOpNode = opFact.CreateOperatorNode(stack.Peek());

                        // if curr operator has > precedence than the next operator, or equal precedence and right associativity
                        if (currOpNode.Precedence > nextOpNode.Precedence ||
                           (currOpNode.Precedence == nextOpNode.Precedence && currOpNode.Associativity == OperatorNode.Associative.Right))
                        {
                            stack.Push(currChar); // push the current operator on the stack
                        }

                        // if curr operator has < precedence than the next operator, or equal precedence and left associativity
                        else
                        {
                            // add the next operator to the list
                            stack.Pop();
                            postfixList.Add(nextOpNode);
                            i--;
                        }
                    }
                }

                // if the current char is a digit (0-9)
                else if (char.IsDigit(currChar))
                {
                    string constantString = currChar.ToString();
                    for (int j = i + 1; j < expressionArray.Length; j++)
                    {
                        currChar = expressionArray[j];

                        // if the next char is a digit, append to constant string
                        if (char.IsDigit(currChar))
                        {
                            constantString += currChar.ToString();
                            i++;
                        }

                        // otherwise the next char is not part of this number
                        else
                        {
                            break;
                        }
                    }

                    postfixList.Add(new ConstantNode(double.Parse(constantString))); // add the complete number to the list
                }

                // if the current char is a variable
                else
                {
                    string variable = currChar.ToString();
                    for (int j = i + 1; j < expressionArray.Length; j++)
                    {
                        currChar = expressionArray[j];

                        // if the next char is not an operator
                        if (!this.IsValidOperator(currChar))
                        {
                            variable += expressionArray[j].ToString();
                            i++;
                        }

                        // otherwise the next char is not part of this variable
                        else
                        {
                            break;
                        }
                    }

                    // add the complete variable to the list
                    postfixList.Add(new VariableNode(variable, ref this.variables));
                }
            }

            // pop and add the rest of the stack to the list
            while (stack.Count > 0)
            {
                OperatorNode newOpNode = opFact.CreateOperatorNode(stack.Pop());
                postfixList.Add(newOpNode);
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
        /// Takes an expression tree node and returns if the node is a constant node type.
        /// </summary>
        /// <param name="node">Expression tree node.</param>
        /// <returns>Bool that represents is the node is a constant or variable node type.</returns>
        private bool IsConstantNode(ExpressionTreeNode node)
        {
            Type nodeType = node.GetType();
            return nodeType.Equals(typeof(ConstantNode));
        }

        /// <summary>
        /// Takes an expression tree node and returns if the node is a variable node type.
        /// </summary>
        /// <param name="node">Expression tree node.</param>
        /// <returns>Bool that represents is the node is a constant or variable node type.</returns>
        private bool IsVariableNode(ExpressionTreeNode node)
        {
            Type nodeType = node.GetType();
            return nodeType.Equals(typeof(VariableNode));
        }
    }
}
