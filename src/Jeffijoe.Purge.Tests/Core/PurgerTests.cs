// Jeffijoe.Purge
// - Jeffijoe.Purge.Tests
// -- PurgeTests.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System;
using System.IO;
using System.Linq;

using Jeffijoe.Purge.CLI;

using Should;

using Xunit;

namespace Jeffijoe.Purge.Tests
{
    /// <summary>
    /// The purge tests.
    /// </summary>
    public class PurgerTests
    {
        #region Fields

        /// <summary>
        /// The content path.
        /// </summary>
        protected readonly string ContentPath;

        /// <summary>
        /// The subject.
        /// </summary>
        private readonly Purger subject;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PurgerTests"/> class.
        /// </summary>
        public PurgerTests()
        {
            this.ContentPath =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\TestContent"));

            // using the File system implementation on purpose,
            // as I already set up the test fixture before the refactor.
            this.subject = new Purger();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The verify get purge actions returns the correct actions.
        /// </summary>
        [Fact]
        public void VerifyEnumeratePurgeablesReturnsTheCorrectDirectories()
        {
            var actual = this.subject.EnumeratePurgeables(this.GetPath("d1")).ToArray();
            actual.Count().ShouldEqual(7);
            actual.Count(x => x.IsFile == false).ShouldEqual(4);
            actual.Count(x => x.IsFile).ShouldEqual(3);

            string[] expected =
            {
                @"d1\d1-1\d1-1-f1.txt",
                @"d1\d1-1",
                @"d1\d1-2",
                @"d1\d1-3",
                @"d1\d1-f1.txt",
                @"d1\d1-f2.js",
                @"d1"
            };

            for (int i = 0; i < actual.Length; i++)
            {
                var action = actual[i];
                Console.WriteLine(action.Path);
                var substring = action.Path.Substring(this.ContentPath.Length + 1);
                substring.ShouldEqual(expected[i]);
            }
        }

        /// <summary>
        /// Gets the path relative to the content path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private string GetPath(string path)
        {
            return Path.Combine(this.ContentPath, path);
        }

        #endregion
    }
}