using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Command object for changing a spreadsheet cell's text.
    /// </summary>
    public class CellTextCommand : Command
    {
        /// <summary>
        /// Receiver cell.
        /// </summary>
        private SpreadsheetCell cell;

        /// <summary>
        /// New cell text.
        /// </summary>
        private string newText;

        /// <summary>
        /// Old (original) cell text.
        /// </summary>
        private string oldText;

        /// <summary>
        /// Initializes a new instance of the <see cref="CellTextCommand"/> class.
        /// </summary>
        /// <param name="cell">Spreadsheet cell.</param>
        /// <param name="newText">Cell text.</param>
        public CellTextCommand(SpreadsheetCell cell, string newText)
        {
            this.cell = cell;
            this.newText = newText;
            this.oldText = cell.Text;

            this.Description = "text change";
        }

        /// <summary>
        /// Gets the description of the command.
        /// </summary>
        public override string Description { get; }

        /// <summary>
        /// Changes each cell in cells to the new background color.
        /// Stores each cell's background color in oldColors dictionary.
        /// </summary>
        public override void Execute()
        {
            this.cell.Text = this.newText;
        }

        /// <summary>
        /// Unexecutes or redo each cell in cells to their old background color.
        /// </summary>
        public override void UnExecute()
        {
            this.cell.Text = this.oldText;
        }
    }
}
