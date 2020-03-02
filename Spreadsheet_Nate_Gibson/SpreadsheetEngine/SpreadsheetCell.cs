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
    /// a.
    /// </summary>
    public class SpreadsheetCell : Cell
    {
        /// <summary>
        /// SpreadsheetCell's row index in Spreadsheet.
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// SpreadsheetCell's column index in Spreadsheet.
        /// </summary>
        private int colIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="rowIndex">SpreadsheetCell's row index in Spreadsheet.</param>
        /// <param name="colIndex">SpreadsheetCell's column index in Spreadsheet.</param>
        public SpreadsheetCell(int rowIndex, int colIndex) : base(rowIndex, colIndex)
        {
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
        }

        /// <summary>
        /// Gets or sets the Cell's evaluated text value.
        /// </summary>
        private protected new string Value
        {
            get
            {
                return this.Value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
