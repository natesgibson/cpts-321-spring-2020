// <copyright file="Form1.cs" company="Nate Gibson">
// Copyright (c) Nate Gibson. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2_WinFormsAndDotNet
{
    /// <summary>
    /// Contains event functions for Form1.
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
        /// Load event function for Form1.
        /// </summary>
        /// <param name="sender">Object which raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            RandIntListGenerator listGen = new RandIntListGenerator();
            List<int> list = listGen.GetNewList();
            DistinctIntsAnalyzer intAnal = new DistinctIntsAnalyzer();
            StringBuilder output = new StringBuilder();

            // Hash set method:
            output.Append("1. HashSet method: ");
            output.Append(intAnal.HashMethGetNumDistinct(list).ToString());
            output.AppendLine(" unique numbers");

            // Hash set Big-O explanation:
            output.AppendLine("    This algorithm runs in O(N) time. I determined this in the following way:");
            output.AppendLine("    There is an O(N) foreach loop over the entire list, out and inside of which " +
                                                                          "there are O(1) hash set operations.");
            output.AppendLine("    Formally, the algorithm's time complexity can be represented as: " +
                                                                            "O(1) + O(N)*(O(1)) + O(1) = O(N).");

            // O(1) storage method:
            output.Append("2. O(1) storage method: ");
            output.Append(intAnal.BigO1MethGetNumDistinct(list).ToString());
            output.AppendLine(" unique numbers");

            // Sorted method:
            output.Append("3. Sorted method: ");
            output.Append(intAnal.SortedMethGetNumDistinct(list).ToString());
            output.AppendLine(" unique numbers");

            this.textBox1.AppendText(output.ToString());
        }
    }
}
