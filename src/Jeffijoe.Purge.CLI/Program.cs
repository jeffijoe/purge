// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- Program.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    ///     The program.
    /// </summary>
    internal class Program
    {
        #region Constants

        /// <summary>
        ///     The welcome message.
        /// </summary>
        private const string Welcome = @"
purge, slayer of files and folders with long paths
- by Jeff Hansen

Usage:
  
  purge <path>
  
Path can be a file or a folder, 
and can be relative to the current
working dir, or an absolute path
";

        #endregion

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
                Console.WriteLine(Welcome);
                return;
            }

            string path = args[0];
            Purge(path);
        }

        /// <summary>
        /// Purges the specified path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
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