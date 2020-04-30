// Name: Nate Gibson
// WSU ID: 11697165

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Class for SpreadsheetCell which inherits Cell class.
    /// </summary>
    public class SpreadsheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="rowIndex">SpreadsheetCell's row index in Spreadsheet.</param>
        /// <param name="colIndex">SpreadsheetCell's column index in Spreadsheet.</param>
        public SpreadsheetCell(int rowIndex, int colIndex) : base(rowIndex, colIndex)
        {
        }

        /// <summary>
        /// Event when a dependent cell's value property changed.
        /// </summary>
        public event EventHandler DependentCellValueChanged;

        /// <summary>
        /// Subscribes this cell to the propertychanged event of another cell.
        /// Used when this cell's expression is dependent on the other cell's value.
        /// </summary>
        /// <param name="cell">Dependee cell.</param>
        public void SubToCellChange(Cell cell)
        {
            cell.PropertyChanged += this.UpdateOnDependentCellValueChange;
        }

        /// <summary>
        /// Updates the value of this cell if the value of another cell has changed.
        /// </summary>
        /// <param name="sender">Sender object (shoudld be dependee cell).</param>
        /// <param name="e">Event arguments.</param>
        private void UpdateOnDependentCellValueChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Value"))
            {
                this.DependentCellValueChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
