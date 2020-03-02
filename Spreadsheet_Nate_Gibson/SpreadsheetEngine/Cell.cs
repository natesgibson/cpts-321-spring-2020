using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS231
{
    /// <summary>
    /// Spreadsheet cell class.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// The Cell's row index.
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// The Cell's column index.
        /// </summary>
        private int columnIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">Cell row index.</param>
        /// <param name="columnIndex">Cell column index.</param>
        public Cell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the Cell's row index.
        /// </summary>
        public int RowIndex
        {
            get
            {
                return this.rowIndex;
            }
        }

        /// <summary>
        /// Gets the Cell's column index.
        /// </summary>
        public int ColumnIndex
        {
            get
            {
                return this.columnIndex;
            }
        }

        /// <summary>
        /// Gets or sets the Cell's text value.
        /// </summary>
        protected string Text
        {
            get
            {
                return this.Text;
            }

            set
            {
                if (value != this.Text)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(value));
                }
            }
        }

        /// <summary>
        /// Gets the Cell's evaluated text value.
        /// </summary>
        protected string Value
        {
            get
            {
                return this.Value;
            }
        }
    }
}
