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

            output.Append("1. HashSet method: ");
            output.Append(intAnal.HashMethGetNumDistinct(list).ToString());
            output.Append(" unique numbers\n");

            this.textBox1.AppendText(output.ToString());
        }
    }
}
