// Name: Nate Gibson
// WSU ID: 11697165

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
        private SpreadsheetCell[,] cells;

        /// <summary>
        /// Undo commands.
        /// </summary>
        private Stack<Command> undos;

        /// <summary>
        /// Redo commands.
        /// </summary>
        private Stack<Command> redos;

        /// <summary>
        /// Alphabet character array for working with cell names.
        /// </summary>
        private char[] alphabet =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Number of spreadsheet cell rows.</param>
        /// <param name="numColumns">Number of spreadsheet cell columns.</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            this.cells = new SpreadsheetCell[numRows, numColumns];
            this.InitializeCells();

            this.undos = new Stack<Command>();
            this.redos = new Stack<Command>();
        }

        /// <summary>
        /// Event when any cell property is changed.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Returns the cell at the given row and column index in the spreadsheet.
        /// Returns null if no cell exists at [rowIndex, colIndex] index.
        /// </summary>
        /// <param name="rowIndex">Spreadsheet row index.</param>
        /// <param name="colIndex">Spreadsheet Column index.</param>
        /// <returns>Spreadsheet Cell.</returns>
        public SpreadsheetCell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex > this.RowCount() - 1 || rowIndex < 0 ||
                colIndex > this.ColumnCount() - 1 || colIndex < 0)
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
        /// Saves a new spreadsheet configuration to a stream.
        /// </summary>
        /// <param name="stream">Save stream.</param>
        public void Save(Stream stream)
        {
            XmlWriter writer = XmlWriter.Create(stream);
            writer.WriteStartDocument();
            writer.WriteStartElement("spreadsheet");

            foreach (SpreadsheetCell cell in this.cells)
            {
                uint bgColor = cell.BGColor;
                string cellText = cell.Text;

                // if cell has any non-default properties:
                if (bgColor != 0xFFFFFFFF || cellText != string.Empty)
                {
                    string cellName = string.Empty + this.alphabet[cell.ColumnIndex] + (cell.RowIndex + 1);

                    writer.WriteStartElement("cell");
                    writer.WriteAttributeString("name", cellName);

                    // if cell has non-default bgcolor:
                    if (bgColor != 0xFFFFFFFF)
                    {
                        writer.WriteStartElement("bgcolor");
                        writer.WriteString(bgColor.ToString("X"));
                        writer.WriteEndElement();
                    }

                    // if cell has non-default text:
                    if (cellText != string.Empty)
                    {
                        writer.WriteStartElement("text");
                        writer.WriteString(cellText);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        /// <summary>
        /// Loads a new spreadsheet configuration from stream.
        /// </summary>
        /// <param name="stream">Spreadsheet configuration stream.</param>
        public void Load(Stream stream)
        {
            XDocument doc = XDocument.Load(stream);

            if (doc.Elements().ToArray()[0].Name == "spreadsheet")
            {
                // The array of elements one level down. Should be cell elements.
                XElement[] elements = doc.Elements().Elements().ToArray();

                for (int i = 0; i < elements.Length; i++)
                {
                    XElement element = elements[i];

                    if (element.Name == "cell")
                    {
                        XAttribute name = element.Attribute(XName.Get("name"));
                        SpreadsheetCell currCell = this.GetCellFromName(name.Value);

                        // Loops over cell elements for text and bg color elements
                        foreach (XElement childElement in element.Elements())
                        {
                            if (childElement.Name == "text")
                            {
                                currCell.Text = childElement.Value;
                            }
                            else if (childElement.Name == "bgcolor")
                            {
                                // Converts hex string to uints
                                currCell.BGColor = Convert.ToUInt32(childElement.Value, 16);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Executes and adds a command to the undos stack.
        /// Resets the redos stack.
        /// </summary>
        /// <param name="undoCommand">Undo command.</param>
        public void AddUndo(Command undoCommand)
        {
            undoCommand.Execute();
            this.undos.Push(undoCommand);

            // reset redos stack.
            while (this.redos.Count > 0)
            {
                this.redos.Pop();
            }
        }

        /// <summary>
        /// Pops and executes a command from the undos stack.
        /// Adds the command to the redos stack.
        /// Does nothing if the undos stack is empty.
        /// </summary>
        public void ExecuteUndo()
        {
            if (!this.UndosIsEmpty())
            {
                Command undoCommand = this.undos.Pop();
                undoCommand.UnExecute();
                this.redos.Push(undoCommand);
            }
        }

        /// <summary>
        /// Pops and executes a command from the redos stack.
        /// Adds the command to the undos stack.
        /// DOes nothing if the redos stack is empty.
        /// </summary>
        public void ExecuteRedo()
        {
            if (!this.RedosIsEmpty())
            {
                Command redoCommand = this.redos.Pop();
                redoCommand.Execute();
                this.undos.Push(redoCommand);
            }
        }

        /// <summary>
        /// Returns if the undos stack is empty.
        /// </summary>
        /// <returns>If the undoes stack is empty.</returns>
        public bool UndosIsEmpty()
        {
            return this.undos.Count <= 0;
        }

        /// <summary>
        /// Returns if the redos stack is empty.
        /// </summary>
        /// <returns>If the redos stack is empty.</returns>
        public bool RedosIsEmpty()
        {
            return this.redos.Count <= 0;
        }

        /// <summary>
        /// Returns the dscription of the undo on the top of the undos stack.
        /// </summary>
        /// <returns>Undo description.</returns>
        public string GetUndoText()
        {
            return this.undos.Peek().Description;
        }

        /// <summary>
        /// Returns the description of the redo on the top of the redos stack.
        /// </summary>
        /// <returns>Redo description.</returns>
        public string GetRedoText()
        {
            return this.redos.Peek().Description;
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
                    newCell.PropertyChanged += this.UpdateOnCellPropertyChanged;
                    newCell.DependentCellValueChanged += this.UpdateOnDependentCellValueChange;
                }
            }
        }

        /// <summary>
        /// Cell property changed event.
        /// If text property changed, update its value.
        /// If bgColor property changed, update its background color.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Arguments.</param>
        private void UpdateOnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Text"))
            {
                this.UpdateCellValue(sender as SpreadsheetCell);
            }
            else if (e.PropertyName.Equals("BGColor"))
            {
                this.CellPropertyChanged?.Invoke(sender as SpreadsheetCell, new PropertyChangedEventArgs("BGColor"));
            }
        }

        /// <summary>
        /// Cell dependent cell value changed event.
        /// If the value of its dependent cell changed, update the sender cell's value.
        /// </summary>
        /// <param name="sender">Dependent cell.</param>
        /// <param name="e">Event arguments.</param>
        private void UpdateOnDependentCellValueChange(object sender, EventArgs e)
        {
            this.UpdateCellValue(sender as SpreadsheetCell);
        }

        /// <summary>
        /// Updates (and possibly evaluates) a cell's value.
        /// </summary>
        /// <param name="cell">Spreadsheet cell.</param>
        private void UpdateCellValue(SpreadsheetCell cell)
        {
            string newValue = cell.Text;

            if (newValue.StartsWith("="))
            {
                newValue = this.EvaluateCellExpression(cell).ToString();
            }

            cell.SetValue(newValue);

            this.CellPropertyChanged?.Invoke(cell, new PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// REQUIREMENT: cell expression text starts with "=".
        /// Evaluates cell's text as an expression and returns its value.
        /// </summary>
        /// <param name="cell">cell who's text is to be evaluated.</param>
        /// <returns>Evaluated expression.</returns>
        private string EvaluateCellExpression(SpreadsheetCell cell)
        {
            // removes the first character (which should be '=') and whitespace.
            string expression = cell.Text.Substring(1).Replace(" ", string.Empty);

            ExpressionTree et = new ExpressionTree(expression);

            bool variableError = this.HandleCellVariables(et, cell);

            if (!variableError)
            {
                return et.Evaluate().ToString();
            }
            else
            {
                return cell.Value;
            }
        }

        /// <summary>
        /// REQUIREMENT: Variable names must be formatted as: "[column letter][row number]"
        /// Defines cell variables in the expression tree and subscribes the
        /// current cell to each variable cell's property changed event.
        /// </summary>
        /// <param name="et">Expression tree.</param>
        /// <param name="currCell">Current spreadsheet cell.</param>\
        /// <returns>If there was an error.</returns>
        private bool HandleCellVariables(ExpressionTree et, SpreadsheetCell currCell)
        {
            bool variableError = false;

            List<string> variableNames = et.GetVariableNames();
            foreach (string name in variableNames)
            {
                SpreadsheetCell varCell = this.GetCellFromName(name);

                if (varCell == null)
                {
                    currCell.SetValue("!(bad reference)");
                    variableError = true;
                }
                else if (varCell == currCell)
                {
                    currCell.SetValue("!(self reference)");
                    variableError = true;
                }
                else if (this.ContainsCircularReference(currCell, varCell))
                {
                    currCell.SetValue("!(circular reference)");
                    variableError = true;
                }
                else
                {
                    // If the cell's value string cannot be parsed as a double, defaults to 0.
                    double value = 0.0;
                    try
                    {
                        value = double.Parse(varCell.Value);
                    }
                    catch (FormatException) { }

                    et.SetVariable(name, value);
                    currCell.SubToCellChange(varCell);
                }
            }

            return variableError;
        }

        /// <summary>
        /// REQUIREMENT: Variable names must be formatted as: "[column letter][row number]"
        /// Throws exception if format is incorrect.
        /// Takes a string which represents a SpreadsheetCell and
        /// returns the appropriate SpreadsheetCell from the spreadsheet.
        /// </summary>
        /// <param name="variableName">String which represents a cell.</param>
        /// <returns>Spreadsheet cell represented by the variable string.</returns>
        private SpreadsheetCell GetCellFromName(string variableName)
        {
            int rowIndex = -1;
            int colIndex = -1;

            try
            {
                char colChar = variableName.ToCharArray()[0];
                rowIndex = int.Parse(variableName.Split(colChar)[1]) - 1;
                colIndex = Array.IndexOf(this.alphabet, colChar);
            }
            catch (FormatException)
            {
                return null;
            }

            return this.GetCell(rowIndex, colIndex);
        }

        /// <summary>
        /// Returns if the refCell has any references to the ogCell.
        /// </summary>
        /// <param name="ogCell">Original cell.</param>
        /// <param name="refCell">Reference cell.</param>
        /// <returns>If there are circular references.</returns>
        private bool ContainsCircularReference(SpreadsheetCell ogCell, SpreadsheetCell refCell)
        {
            if (refCell.Text.StartsWith("="))
            {
                ExpressionTree et = new ExpressionTree(refCell.Text.Substring(1).Replace(" ", string.Empty));
                List<string> names = et.GetVariableNames();

                foreach (string name in names)
                {
                    SpreadsheetCell currCell = this.GetCellFromName(name);
                    if (currCell == ogCell)
                    {
                        return true;
                    }

                    bool containsCircularReference = this.ContainsCircularReference(ogCell, currCell);
                    if (containsCircularReference)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
