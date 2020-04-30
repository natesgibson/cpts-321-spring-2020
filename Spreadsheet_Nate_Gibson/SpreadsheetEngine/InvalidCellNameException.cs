using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Exception class for invalid cell names.
    /// </summary>
    public class InvalidCellNameException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellNameException"/> class.
        /// </summary>
        public InvalidCellNameException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellNameException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidCellNameException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellNameException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Previous exception.</param>
        public InvalidCellNameException(string message, Exception inner) : base(message, inner) { }
    }
}
