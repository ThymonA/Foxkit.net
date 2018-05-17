namespace Foxkit
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Authorization
    {
        /// <summary>
        /// The Id of this <see cref="Authorization"/>.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// The API URL for this <see cref="Authorization"/>.
        /// </summary>
        public string Url { get; protected set; }

        /// <summary>
        /// The <see cref="Application"/> that created this <see cref="Authorization"/>.
        /// </summary>
        public Application Application { get; protected set; }

        /// <summary>
        /// The last eight characters of the user's token
        /// </summary>
        public string TokenLastEight { get; protected set; }

        /// <summary>
        /// Base-64 encoded representation of the SHA-256 digest of the token
        /// </summary>
        public string HashedToken { get; protected set; }

        /// <summary>
        /// Optional parameter that allows an OAuth application to create
        /// multiple authorizations for a single user
        /// </summary>
        public string Fingerprint { get; protected set; }

        /// <summary>
        /// Notes about this particular <see cref="Authorization"/>.
        /// </summary>
        public string Note { get; protected set; }

        /// <summary>
        /// A url for more information about notes.
        /// </summary>
        public string NoteUrl { get; protected set; }

        /// <summary>
        /// When this <see cref="Authorization"/> was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; protected set; }

        /// <summary>
        /// When this <see cref="Authorization"/> was last updated.
        /// </summary>
        public DateTimeOffset UpdateAt { get; protected set; }

        /// <summary>
        /// The scopes that this <see cref="Authorization"/> has. This is the kind of access that the token allows.
        /// </summary>
        public string[] Scopes { get; protected set; }

        public string ScopesDelimited => string.Join(",", Scopes);

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Id: {0} CreatedAt: {1}", Id, CreatedAt);
    }
}
