namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    /// Entry to be purged.
    /// </summary>
    public class Purgeable
    {
        /// <summary>
        /// Gets a value indicating whether this instance represents a file or a directory.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is file; otherwise, <c>false</c>.
        /// </value>
        public bool IsFile { get; private set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Purgeable"/> class.
        /// </summary>
        /// <param name="isFile">if set to <c>true</c> [is file].</param>
        /// <param name="path">The path.</param>
        public Purgeable(bool isFile, string path)
        {
            this.IsFile = isFile;
            this.Path = path;
        }
    }
}