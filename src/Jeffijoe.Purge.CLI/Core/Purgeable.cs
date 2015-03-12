// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- Purgeable.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.
namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    ///     Entry to be purged.
    /// </summary>
    public class Purgeable
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Purgeable"/> class.
        /// </summary>
        /// <param name="isFile">
        /// if set to <c>true</c> [is file].
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        public Purgeable(bool isFile, string path)
        {
            this.IsFile = isFile;
            this.Path = path;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets a value indicating whether this instance represents a file or a directory.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is file; otherwise, <c>false</c>.
        /// </value>
        public bool IsFile { get; private set; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <value>
        ///     The path.
        /// </value>
        public string Path { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", this.IsFile ? "File" : "Directory", this.Path);
        }

        #endregion
    }
}