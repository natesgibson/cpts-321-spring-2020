using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Command object for changing a list of spreadsheet cells' background colors.
    /// </summary>
    public class BGColorCommand : Command
    {
        /// <summary>
        /// Receiver cells.
        /// </summary>
        private List<SpreadsheetCell> cells;

        /// <summary>
        /// New background color.
        /// </summary>
        private uint newColor;

        /// <summary>
        /// Dictionary of cells and their old background color.
        /// </summary>
        private Dictionary<SpreadsheetCell, uint> oldColors;

        /// <summary>
        /// Initializes a new instance of the <see cref="BGColorCommand"/> class.
        /// </summary>
        /// <param name="cells">Receiver cells.</param>
        /// <param name="newColor">New background color.</param>
        public BGColorCommand(List<SpreadsheetCell> cells, uint newColor)
        {
            this.cells = cells;
            this.newColor = newColor;
            this.oldColors = this.GetOldColors();

            this.Description = "background color change";
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
            foreach (SpreadsheetCell cell in this.cells)
            {
                cell.BGColor = this.newColor;
            }
        }

        /// <summary>
        /// Unexecutes or redo each cell in cells to their old background color.
        /// </summary>
        public override void UnExecute()
        {
            foreach (SpreadsheetCell cell in this.cells)
            {
                cell.BGColor = this.oldColors[cell];
            }
        }

        /// <summary>
        /// Returns a dictonary of all spreadsheet cells in cells and
        /// their old (original) background color.
        /// </summary>
        /// <returns>Dictionary of spreadsheet cells and their old bg colors.</returns>
        private Dictionary<SpreadsheetCell, uint> GetOldColors()
        {
            Dictionary<SpreadsheetCell, uint> oldColors = new Dictionary<SpreadsheetCell, uint>();
            foreach (SpreadsheetCell cell in this.cells)
            {
                oldColors.Add(cell, cell.BGColor);
            }

            return oldColors;
        }
    }
}
