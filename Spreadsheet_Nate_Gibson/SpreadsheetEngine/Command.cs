using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Command function abstract class for Command design pattern.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Gets a description of the command.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Executes the command function.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Unexecutes or "redo" the command function.
        /// </summary>
        public abstract void UnExecute();
    }
}
