﻿using System.Collections.Generic;
using System.IO;

using Microsoft.Experimental.IO;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    ///     File system implementation that supports long paths.
    /// </summary>
    public class LongPathCapableFileSystem : IFileSystem
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current working directory.
        /// </summary>
        /// <value>
        /// The current working directory.
        /// </value>
        public string CurrentWorkingDirectory
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }

        /// <summary>
        /// The clear read only.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void ClearReadOnly(string filePath)
        {
            FileAttributes attributes = Microsoft.Experimental.IO.Interop.NativeMethods.GetFileAttributes(filePath);

            // Do nothing if the attributes are invalid.
            if (attributes <= 0 || !attributes.HasFlag(FileAttributes.ReadOnly))
            {
                return;
            }

            // Removes the ReadOnly flag.
            attributes &= ~FileAttributes.ReadOnly;
            if (!NativeMethods.SetFileAttributes(filePath, attributes))
            {
                throw LongPathCommon.GetExceptionFromLastWin32Error();
            }
        }

        /// <summary>
        /// The delete directory.
        /// </summary>
        /// <param name="directoryPath">
        /// The directory path.
        /// </param>
        public void DeleteDirectory(string directoryPath)
        {
            LongPathDirectory.Delete(directoryPath);
        }

        /// <summary>
        /// The delete file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void DeleteFile(string filePath)
        {
            LongPathFile.Delete(filePath);
        }

        /// <summary>
        /// Determines if the directory exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// The <see cref="bool" />.
        /// </returns>
        public bool DirectoryExists(string path)
        {
            return LongPathDirectory.Exists(path);
        }

        /// <summary>
        /// Check if the specified file exists.
        /// </summary>
        /// <param name="filePath">The path.</param>
        /// <returns>
        /// The <see cref="bool" />.
        /// </returns>
        public bool FileExists(string filePath)
        {
            return LongPathFile.Exists(filePath);
        }

        /// <summary>
        /// Sanitizes the path, ensuring it is rooted.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public string SanitizePath(string path)
        {
            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), path);
            }

            return path;
        }

        /// <summary>
        /// Enumerates the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public IEnumerable<string> EnumerateFiles(string path)
        {
            return LongPathDirectory.EnumerateFiles(path);
        }

        /// <summary>
        /// Enumerates the directories.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public IEnumerable<string> EnumerateDirectories(string path)
        {
            return LongPathDirectory.EnumerateDirectories(path);
        }

        #endregion
    }
}