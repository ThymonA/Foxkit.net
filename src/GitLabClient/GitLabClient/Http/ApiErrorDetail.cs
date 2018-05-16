namespace GitLabClient
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    #if !NO_SERIALIZABLE
    [Serializable]
    #endif
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class ApiErrorDetail
    {
        public ApiErrorDetail()
        {
        }

        public ApiErrorDetail(string message, string code, string field, string resource)
        {
            Message = message;
            Code = code;
            Field = field;
            Resource = resource;
        }

        public string Message { get; protected set; }

        public string Code { get; protected set; }

        public string Field { get; protected set; }

        public string Resource { get; protected set; }

        internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Message: {0}, Code: {1}, Field: {2}", Message, Code, Field);
    }
}
