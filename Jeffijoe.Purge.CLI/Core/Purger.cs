// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- Purger.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Experimental.IO;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    ///     The purge.
    /// </summary>
    public class Purger : IPurger
    {
        #region Fields

        /// <summary>
        ///     The file system.
        /// </summary>
        private readonly IFileSystem fileSystem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Purger" /> class.
        /// </summary>
        public Purger()
            : this(new LongPathCapableFileSystem())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Purger"/> class.
        /// </summary>
        /// <param name="fileSystem">
        /// The file system.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// fileSystem is null.
        /// </exception>
        internal Purger(IFileSystem fileSystem)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException("fileSystem");
            }

            this.fileSystem = fileSystem;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Deletes the path specified recursively using native Windows functions with unicode support.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void Purge(string path)
        {
            var actions = this.EnumeratePurgeables(path);
            foreach (var purgeAction in actions)
            {
                if (purgeAction.IsFile)
                {
                    if (this.fileSystem.FileExists(purgeAction.Path) == false)
                    {
                        continue;
                    }

                    this.fileSystem.ClearReadOnly(purgeAction.Path);
                    this.fileSystem.DeleteFile(purgeAction.Path);
                }
                else
                {
                    this.fileSystem.DeleteDirectory(purgeAction.Path);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the purge actions.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="result">
        /// The result list, being passed recursively.
        /// </param>
        /// <returns>
        /// The list of purgeable entries.
        /// </returns>
        internal IEnumerable<Purgeable> EnumeratePurgeables(string path, List<Purgeable> result = null)
        {
            bool firstCall = false;
            if (result == null)
            {
                firstCall = true;
                result = new List<Purgeable>();
            }

            var folders = this.fileSystem.EnumerateDirectories(path);
            foreach (var folder in folders)
            {
                this.EnumeratePurgeables(folder, result);
            }

            result.AddRange(folders.Select(f => new Purgeable(false, f)));
            var files = this.fileSystem.EnumerateFiles(path);
            result.AddRange(files.Select(f => new Purgeable(true, f)));
            if (firstCall)
            {
                result.Add(new Purgeable(false, path));
            }

            return result;
        }

        #endregion
    }
}