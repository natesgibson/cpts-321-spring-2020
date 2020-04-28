using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Exception class for undefined variables.
    /// </summary>
    public class UndefinedVariableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedVariableException"/> class.
        /// </summary>
        public UndefinedVariableException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedVariableException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public UndefinedVariableException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedVariableException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Previous exception.</param>
        public UndefinedVariableException(string message, Exception inner) : base(message, inner) { }
    }
}
