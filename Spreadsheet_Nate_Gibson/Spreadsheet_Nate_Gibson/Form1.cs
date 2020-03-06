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

namespace Spreadsheet_Nate_Gibson
{
    /// <summary>
    /// Main form class for spreadsheet.
    /// </summary>
    public partial class Form1 : Form
    {
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
            this.dataGridView1.Columns.Clear();
            this.AddAZColumns();
            this.dataGridView1.Rows.Clear();
            this.AddRows(50);
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
    }
}
