// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- PurgeException.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    /// Purge exception.
    /// </summary>
    public class PurgeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurgeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PurgeException(string message)
            : base(message)
        {
        }
    }
}