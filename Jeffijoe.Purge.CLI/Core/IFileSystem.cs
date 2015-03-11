// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- IFileSystem.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System.Collections.Generic;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    ///     Interface for accessing the file system.
    /// </summary>
    public interface IFileSystem
    {
        #region Public Methods and Operators

        /// <summary>
        /// Disabled "readonly" for the specified file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        void ClearReadOnly(string filePath);

        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <param name="directoryPath">
        /// The directory path.
        /// </param>
        void DeleteDirectory(string directoryPath);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        void DeleteFile(string filePath);

        /// <summary>
        /// Check if the specified file exists.
        /// </summary>
        /// <param name="filePath">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool FileExists(string filePath);

        /// <summary>
        /// Enumerates the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        IEnumerable<string> EnumerateFiles(string path);

        /// <summary>
        /// Enumerates the directories.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        IEnumerable<string> EnumerateDirectories(string path);

        #endregion
    }
}