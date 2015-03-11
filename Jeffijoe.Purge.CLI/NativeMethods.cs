// Jeffijoe.Purge
// - Jeffijoe.Purge.CLI
// -- NativeMethods.cs
// -------------------------------------------
// Author: Jeff Hansen <jeff@jeffijoe.com>
// Copyright (C) Jeff Hansen 2015. All rights reserved.

using System.IO;
using System.Runtime.InteropServices;

namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    /// Purge's native methods - these were not available from Microsoft.Experimental.IO.
    /// </summary>
    public class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetFileAttributes(string lpFileName, [MarshalAs(UnmanagedType.U4)] FileAttributes dwFileAttributes); 
    }
}