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
        /// Color dialog menu.
        /// </summary>
        private ColorDialog colorDialog;

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
            this.InitializeDGCells();

            this.DataGridView1.CellBeginEdit += this.DataGridView1_CellBeginEdit;
            this.DataGridView1.CellEndEdit += this.DataGridView1_CellEndEdit;

            this.colorDialog = new ColorDialog();

            this.UpdateUndoRedoButtons();
        }

        /// <summary>
        /// When a dataGridView1 cell begins to be edited, set its value to equal
        /// its corresponding spreadsheet cell's text value.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell dgCell = this.DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            SpreadsheetCell ssCell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex);

            dgCell.Value = ssCell.Text;
        }

        /// <summary>
        /// When a dataGridView1 cell ends being edited,
        /// set the ss cell's text value to equal the cc cell's value,
        /// and reset the dg cell to the ss cell's value.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dgCell = this.DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            SpreadsheetCell ssCell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex);

            string newText = dgCell.Value.ToString();
            CellTextCommand cmd = new CellTextCommand(ssCell, newText);
            this.spreadsheet.AddUndo(cmd);

            this.UpdateUndoRedoButtons();

            dgCell.Value = ssCell.Value;
        }

        /// <summary>
        /// Initializes each DG cell's value to equal its spreadsheet cell counterpart's value.
        /// </summary>
        private void InitializeDGCells()
        {
            for (int i = 0; i < this.DataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < this.DataGridView1.Columns.Count; j++)
                {
                    DataGridViewCell dgCell = this.DataGridView1.Rows[i].Cells[j];
                    SpreadsheetCell ssCell = this.spreadsheet.GetCell(i, j);

                    dgCell.Value = ssCell.Value;
                }
            }
        }

        /// <summary>
        /// Resets dataGridView 1 with clear A-Z columns and 1-50 rows.
        /// </summary>
        private void ResetDataGrid()
        {
            this.DataGridView1.Columns.Clear();
            this.AddAZColumns();
            this.DataGridView1.Rows.Clear();
            this.AddRows(50);

            this.spreadsheet = new Spreadsheet(50, 26);
            this.spreadsheet.CellPropertyChanged += this.UpdateCellProperty;
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
                this.DataGridView1.Columns.Add(letter.ToString(), letter.ToString());
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
                this.DataGridView1.Rows.Add();
                this.DataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }

        /// <summary>
        /// Cell Property Changed Spreadsheet event.
        /// If the value of the SpreadsheetCell changed, updates dataGridView1 cell value.
        /// If the bgColor of the SpreadsheetCell changed, updates its background color.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Arguments.</param>
        private void UpdateCellProperty(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell ssCell = sender as SpreadsheetCell;
            DataGridViewCell dgCell = this.DataGridView1.Rows[ssCell.RowIndex].Cells[ssCell.ColumnIndex];

            if (e.PropertyName.Equals("Value"))
            {
                dgCell.Value = ssCell.Value;
            }
            else if (e.PropertyName.Equals("BGColor"))
            {
                Color newColor = Color.FromArgb((int)ssCell.BGColor);
                dgCell.Style.BackColor = newColor;
            }
        }

        /// <summary>
        /// Updates the background color of currently selected cells in the spreadsheet.
        /// Users select a color with a color dialog window.
        /// Updates the undo/redo menu buttons.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                uint newColor = (uint)this.colorDialog.Color.ToArgb();
                List<SpreadsheetCell> changingCells = new List<SpreadsheetCell>();

                foreach (DataGridViewCell dgCell in this.DataGridView1.SelectedCells)
                {
                    SpreadsheetCell ssCell = this.spreadsheet.GetCell(dgCell.RowIndex, dgCell.ColumnIndex);
                    changingCells.Add(ssCell);
                }

                BGColorCommand cmd = new BGColorCommand(changingCells, newColor);
                this.spreadsheet.AddUndo(cmd);

                this.UpdateUndoRedoButtons();
            }
        }

        /// <summary>
        /// Executes spreadsheet undo command.
        /// Updates undo/redo buttons.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.ExecuteUndo();
            this.UpdateUndoRedoButtons();
        }

        /// <summary>
        /// Executes spreadsheet redo command.
        /// Updates undo/redo buttons.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.ExecuteRedo();
            this.UpdateUndoRedoButtons();
        }

        /// <summary>
        /// Updated the text and enabled properties of the undo redo buttons
        /// based on the spreadsheet.
        /// </summary>
        private void UpdateUndoRedoButtons()
        {
            if (this.spreadsheet.UndosIsEmpty())
            {
                this.UndoToolStripMenuItem.Enabled = false;
                this.UndoToolStripMenuItem.Text = "Undo";
            }
            else
            {
                this.UndoToolStripMenuItem.Enabled = true;
                this.UndoToolStripMenuItem.Text = "Undo " + this.spreadsheet.GetUndoText();
            }

            if (this.spreadsheet.RedosIsEmpty())
            {
                this.RedoToolStripMenuItem.Enabled = false;
                this.RedoToolStripMenuItem.Text = "Redo";
            }
            else
            {
                this.RedoToolStripMenuItem.Enabled = true;
                this.RedoToolStripMenuItem.Text = "Redo " + this.spreadsheet.GetRedoText();
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
