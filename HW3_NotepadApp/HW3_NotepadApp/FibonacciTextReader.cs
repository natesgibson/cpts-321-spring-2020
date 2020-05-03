using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HW3_NotepadApp
{
    /// <summary>
    /// Fibonacci text reader class. Inherits System.IO.TextReader class.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private int maxLines;
        private int currLine;
        private BigInteger prevPrevFib;
        private BigInteger prevFib;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLines">Maximum lines to return.</param>
        public FibonacciTextReader(int maxLines)
        {
            this.maxLines = maxLines;
            this.currLine = 1;

            this.prevPrevFib = 0;
            this.prevFib = 1;
        }

        /// <summary>
        /// Returns the next number in the fibonacci sequence up to maxLines numbers.
        /// If maxLines numbers have been read already, returns null.
        /// </summary>
        /// <returns>Result string.</returns>
        public override string ReadLine()
        {
            if (this.currLine <= this.maxLines)
            {
                string result = string.Empty;

                if (this.currLine == 1)
                {
                    result = this.currLine + ": 0";
                }
                else if (this.currLine == 2)
                {
                    result = this.currLine + ": 1";
                }
                else
                {
                    BigInteger nextFib = this.prevPrevFib + this.prevFib;
                    this.prevPrevFib = this.prevFib;
                    this.prevFib = nextFib;

                    result = this.currLine + ": " + nextFib;
                }

                this.currLine++;
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns maxLines of the fibonacci sequence as a string.
        /// </summary>
        /// <returns>Result string.</returns>
        public override string ReadToEnd()
        {
            StringBuilder result = new StringBuilder();

            while(this.currLine <= this.maxLines)
            {
                result.AppendLine(this.ReadLine());
            }

            return result.ToString();
        }
    }
}
