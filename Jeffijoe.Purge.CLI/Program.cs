// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- Program.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System;
using System.IO;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: purge <folder>");
                return;
            }

            string path = args[0];
            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, args[0]);
            }

            if (Directory.Exists(path) == false)
            {
                Console.WriteLine("Directory \"{0}\" not found.", path);
                return;
            }
            
            var purger = new Purger();
            purger.Purge(path);
        }

        #endregion
    }
}