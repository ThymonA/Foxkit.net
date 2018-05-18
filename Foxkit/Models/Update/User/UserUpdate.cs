namespace Foxkit
{
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// Represents updatable fields on a user. Values that are null will not be sent in the request.
    /// Use string.empty if you want to clear a value.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class UserUpdate
    {
        public string Name { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public string Skype { get; set; }

        public string LinkedIn { get; set; }

        public string Twitter { get; set; }

        public string WebsiteUrl { get; set; }

        public string Organization { get; set; }

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Name: {0}", Name);
    }
}
