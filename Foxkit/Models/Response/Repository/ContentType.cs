namespace Foxkit
{
    /// <summary>
    /// Repository content types
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// Unknown (type)
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// File (blob)
        /// </summary>
        File = 100644,

        /// <summary>
        /// Executable (blob)
        /// </summary>
        Executable = 100755,

        /// <summary>
        /// Subdirectory (tree)
        /// </summary>
        Subdirectory = 040000,

        /// <summary>
        /// Reference to another file or directory (blob)
        /// </summary>
        Symlink = 120000,

        /// <summary>
        /// Submodule (commit)
        /// </summary>
        Submodule = 160000
    }
}
