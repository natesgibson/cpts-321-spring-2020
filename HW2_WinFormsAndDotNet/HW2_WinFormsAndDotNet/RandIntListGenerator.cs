// <copyright file="RandIntListGenerator.cs" company="Nate Gibson">
// Copyright (c) Nate Gibson. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_WinFormsAndDotNet
{
    /// <summary>
    /// Generates a random list of ints of a certain size and in a certain range.
    /// </summary>
    public class RandIntListGenerator
    {
        /// <summary>
        /// Number of ints in list. Default value is 10,000.
        /// </summary>
        private int size = 10000;

        /// <summary>
        /// Lower bound of the range (inclusive). Default value is 0.
        /// </summary>
        private int lowerBound = 0;

        /// <summary>
        /// Upper bound of the range (inclusive). Default value is 20,000.
        /// </summary>
        private int upperBound = 20000;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandIntListGenerator"/> class.
        /// </summary>
        public RandIntListGenerator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandIntListGenerator"/> class.
        /// </summary>
        /// <param name="size">Number of ints in list.</param>
        public RandIntListGenerator(int size)
        {
            this.size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandIntListGenerator"/> class.
        /// </summary>
        /// <param name="size">Number of ints in list.</param>
        /// <param name="lowerBound">Lower bound of list range.</param>
        /// <param name="upperBound">Upper bond of list range.</param>
        public RandIntListGenerator(int size, int lowerBound, int upperBound)
        {
            this.size = size;
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }

        /// <summary>
        /// Generates and returns a list of {size} number of random ints,
        /// in the range between the lower and upper bounds (inclusive).
        /// </summary>
        /// <returns>A newly generated random list of ints.</returns>
        public List<int> GetNewList()
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < this.size; i++)
            {
                list.Add(rand.Next(this.lowerBound, this.upperBound));
            }

            return list;
        }
    }
}