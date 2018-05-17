namespace Foxkit
{
    using System.Diagnostics;
    using System.Globalization;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class NewSshKey
    {
        public NewSshKey()
        {
        }

        public NewSshKey(string publicKey)
            : this(publicKey, string.Empty)
        {
        }

        public NewSshKey(string publicKey, string title)
        {
            publicKey.ArgumentNotNullOrEmptyString(nameof(publicKey));

            Key = publicKey;
            Title = title;
        }

        public string Key { get; set; }

        public string Title { get; set; }

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Key: {0}, Title: {1}", Key, Title);
    }
}
