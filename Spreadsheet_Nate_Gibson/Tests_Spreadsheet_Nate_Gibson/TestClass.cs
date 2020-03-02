// Name: Nate Gibson
// WSU ID: 11697165

// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SpreadsheetEngine;

namespace Tests_Spreadsheet_Nate_Gibson
{
    /// <summary>
    /// Tests for spreadsheet.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// Normal case for Spreadsheet GetCell method.
        /// </summary>
        [Test]
        public void TestSpreadsheetGetCellNormal()
        {
            Spreadsheet s = new Spreadsheet(5, 5);
            SpreadsheetCell newCell = new SpreadsheetCell(0, 0);
            Assert.That(s.GetCell(4, 0).Value, Is.EqualTo(newCell.Value), "Spreadsheet returned undexpected cell at index.");
        }

        /// <summary>
        /// Nonexistent case for Spreadsheet GetCell method.
        /// </summary>
        [Test]
        public void TestSpreadsheetGetCellNonexistent()
        {
            Spreadsheet s = new Spreadsheet(5, 5);
            Assert.That(s.GetCell(6, 0), Is.EqualTo(null), "Spreadsheet returned undexpected cell at index.");
        }

        /// <summary>
        /// Normal case for Spreadsheet ColumnCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetColumnCountNormal()
        {
            Spreadsheet s = new Spreadsheet(6, 5);
            Assert.That(s.ColumnCount(), Is.EqualTo(5), "Spreadsheet returned unexpected column count.");
        }

        /// <summary>
        /// Zero case for Spreadsheet ColumnCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetColumnCountZero()
        {
            Spreadsheet s = new Spreadsheet(5, 0);
            Assert.That(s.ColumnCount(), Is.EqualTo(0), "Spreadsheet returned unexpected column count.");
        }

        /// <summary>
        /// Normal case for Spreadsheet RowCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetRowCountNormal()
        {
            Spreadsheet s = new Spreadsheet(5, 6);
            Assert.That(s.RowCount(), Is.EqualTo(5), "Spreadsheet returned unexpected row count.");
        }

        /// <summary>
        /// Zero case for Spreadsheet RowCount method.
        /// </summary>
        [Test]
        public void TestSpreadsheetRowCountZero()
        {
            Spreadsheet s = new Spreadsheet(0, 5);
            Assert.That(s.RowCount(), Is.EqualTo(0), "Spreadsheet returned unexpected row count.");
        }
    }
}