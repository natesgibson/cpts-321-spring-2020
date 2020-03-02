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
    /// Spreadsheet class which creates and manages spreadsheet Cells.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// A 2D row x column array of cells.
        /// </summary>
        private Cell[,] cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Number of spreadsheet cell rows.</param>
        /// <param name="numColumns">Number of spreadsheet cell columns.</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            this.cells = new Cell[numRows, numColumns];
            this.InitializeCells();
        }

        /// <summary>
        /// Cell property changed event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Arguments.</param>
        public void CellPropertyChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Returns the cell at the given row and column index in the spreadsheet.
        /// </summary>
        /// <param name="rowIndex">Spreadsheet row index.</param>
        /// <param name="colIndex">Spreadsheet Column index.</param>
        /// <returns>Spreadsheet Cell.</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex > this.RowCount() - 1 || colIndex > this.ColumnCount() - 1)
            {
                return null;
            }

            return this.cells[rowIndex, colIndex];
        }

        /// <summary>
        /// Returns the number of columns in the spreadsheet.
        /// </summary>
        /// <returns>Number of columns in spreadsheet.</returns>
        public int ColumnCount()
        {
            return this.cells.GetLength(1);
        }

        /// <summary>
        /// Returns the number of rows in the spreadsheet.
        /// </summary>
        /// <returns>Number of rows in spreadsheet.</returns>
        public int RowCount()
        {
            return this.cells.GetLength(0);
        }

        /// <summary>
        /// Initializes each cell in cells as a SpreadsheetCell.
        /// </summary>
        private void InitializeCells()
        {
            for (int rowIndex = 0; rowIndex < this.cells.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.cells.GetLength(1); colIndex++)
                {
                    SpreadsheetCell newCell = new SpreadsheetCell(rowIndex, colIndex);
                    this.cells[rowIndex, colIndex] = newCell;
                    newCell.PropertyChanged += this.CellPropertyChanged;
                }
            }
        }
    }
}
