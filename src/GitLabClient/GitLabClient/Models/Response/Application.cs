namespace Foxkit
{
    using System.Diagnostics;
    using System.Globalization;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Application
    {
        public string Name { get; protected set; }

        public string Url { get; protected set; }

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Name: {0}, Url: {1}", Name, Url);
    }
}
