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
            Purge(path);
        }

        /// <summary>
        /// Purges the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        private static void Purge(string path)
        {
#if !DEBUG
            try
            {
#endif
                var purger = new Purger();
                purger.Purge(path);    
#if !DEBUG
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
#endif
        }

        #endregion
    }
}