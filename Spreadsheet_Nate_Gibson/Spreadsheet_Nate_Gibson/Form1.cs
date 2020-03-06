// Name: Nate Gibson
// WSU ID: 11697165

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CptS321;
using SpreadsheetEngine;

namespace Spreadsheet_Nate_Gibson
{
    /// <summary>
    /// Main form class for spreadsheet.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Spreadsheet object.
        /// </summary>
        private Spreadsheet spreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Form1 Load event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Arguments.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ResetDataGrid();
        }

        /// <summary>
        /// Resets dataGridView 1 with clear A-Z columns and 1-50 rows.
        /// </summary>
        private void ResetDataGrid()
        {
            this.dataGridView1.Columns.Clear();
            this.AddAZColumns();
            this.dataGridView1.Rows.Clear();
            this.AddRows(50);

            this.spreadsheet = new Spreadsheet(50, 26);
            this.spreadsheet.CellPropertyChanged += this.UpdateCellValue;
        }

        /// <summary>
        /// Adds A-Z columns to the form's DataGridView.
        /// </summary>
        private void AddAZColumns()
        {
            char[] alphabet =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            };

            foreach (char letter in alphabet)
            {
                this.dataGridView1.Columns.Add(letter.ToString(), letter.ToString());
            }
        }

        /// <summary>
        /// Adds numRows rows to the form's DatGridView.
        /// </summary>
        /// <param name="numRows">Number of rows to add.</param>
        private void AddRows(int numRows)
        {
            for (int i = 1; i <= numRows; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }

        /// <summary>
        /// Cell Property Changed Spreadsheet event.
        /// If the value of the SpreadsheetCell changed, updates dataGridView1 cell value.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Arguments.</param>
        private void UpdateCellValue(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Value"))
            {
                SpreadsheetCell currCell = sender as SpreadsheetCell;
                this.dataGridView1.Rows[currCell.RowIndex].Cells[currCell.ColumnIndex].Value = currCell.Value;
            }
        }

        /// <summary>
        /// Event when demoButton is clicked.
        /// Performs a demo which showcases dataGridView1 being updated by the Spreadsheet class.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void DemoButton_Click(object sender, EventArgs e)
        {
            this.ResetDataGrid();
            this.SetRandomCells(50, "demo text");
            this.SetColumnBCells();
            this.SetColumnACellsToB();
        }

        /// <summary>
        /// Sets random spreadsheet cells to display value numCells times.
        /// Note that the same random cell can be changed multiple times.
        /// </summary>
        /// <param name="numCells">The number of affected cells.</param>
        /// <param name="value">Value for cells to display.</param>
        private void SetRandomCells(int numCells, string value)
        {
            Random rand = new Random();

            for (int i = 0; i < numCells; i++)
            {
                int rowIndex = rand.Next(this.spreadsheet.RowCount());
                int colIndex = rand.Next(this.spreadsheet.ColumnCount());

                this.spreadsheet.GetCell(rowIndex, colIndex).Text = value;
            }
        }

        /// <summary>
        /// Sets all column B spreadsheet cells to display their name.
        /// </summary>
        private void SetColumnBCells()
        {
            for (int rowIndex = 0; rowIndex < this.spreadsheet.RowCount(); rowIndex++)
            {
                this.spreadsheet.GetCell(rowIndex, 1).Text = "This is cell B" + (rowIndex + 1);
            }
        }

        /// <summary>
        /// Sets all column A spreadsheet cells to the same value as column B.
        /// </summary>
        private void SetColumnACellsToB()
        {
            for (int rowIndex = 0; rowIndex < this.spreadsheet.RowCount(); rowIndex++)
            {
                this.spreadsheet.GetCell(rowIndex, 0).Text = "=B" + (rowIndex + 1);
            }
        }
    }
}
