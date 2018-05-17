namespace Foxkit
{
    using System.Diagnostics;
    using System.Globalization;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class NewGpgKey
    {
        public NewGpgKey()
        {
        }

        public NewGpgKey(string publicKey)
        {
            publicKey.ArgumentNotNullOrEmptyString(nameof(publicKey));

            Key = publicKey;
        }

        public string Key { get; set; }

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Key: {0}", Key);
    }
}
