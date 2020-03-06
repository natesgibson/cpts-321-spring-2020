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
    }
}
