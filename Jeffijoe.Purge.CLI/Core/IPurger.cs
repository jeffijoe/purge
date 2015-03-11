namespace Jeffijoe.Purge.CLI
{
    /// <summary>
    /// Purger interface.
    /// </summary>
    public interface IPurger
    {
        /// <summary>
        /// Deletes the path specified recursively using native Windows functions with unicode support.
        /// </summary>
        /// <param name="path">The path.</param>
        void Purge(string path);
    }
}