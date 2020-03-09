// Name: Nate Gibson
// WSU ID: 11697165

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace ExpressionTreeDemo
{
    /// <summary>
    /// Program which demos the ExpressionTree class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method which displays menu for demo and responds based on user input.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            string currentExpression = "A1+B1+C1";
            ExpressionTree et = new ExpressionTree(currentExpression);

            while(true)
            {
                PrintMenu(currentExpression);

                string input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    Console.Write("Enter new expression: ");
                    currentExpression = Console.ReadLine();

                    et = new ExpressionTree(currentExpression);
                }
                else if (input.Equals("2"))
                {
                    Console.Write("Enter variable name: ");
                    string variableName = Console.ReadLine();
                    Console.Write("Enter variable value: ");
                    double variableValue = double.Parse(Console.ReadLine());

                    et.SetVariable(variableName, variableValue);
                }
                else if (input.Equals("3"))
                {
                    Console.WriteLine(et.Evaluate());
                }
                else if (input.Equals("4"))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Prints demo menu with four options.
        /// </summary>
        /// <param name="currentExpression">Current expression.</param>
        public static void PrintMenu(string currentExpression)
        {
            Console.WriteLine("Menu (current expression=\"" + currentExpression + "\")");
            Console.WriteLine("  1 = Enter a new expression");
            Console.WriteLine("  2 = Set a variable value");
            Console.WriteLine("  3 = Evaluate tree");
            Console.WriteLine("  4 = Quit");
        }
    }
}
