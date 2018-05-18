namespace Foxkit
{
    using System.ComponentModel;

    /// <summary>
    /// Repository content types
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// Content Type: Unknown
        /// </summary>
        [Description("unknown")]
        Unknown = 0,

        /// <summary>
        /// Content Type: File
        /// </summary>
        [Description("blob")]
        File = 1,

        /// <summary>
        /// Content Type: Directory
        /// </summary>
        [Description("tree")]
        Directory = 2
    }
}
