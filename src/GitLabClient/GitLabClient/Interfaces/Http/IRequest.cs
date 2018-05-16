namespace GitLabClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public interface IRequest
    {
        object Body { get; set; }

        IDictionary<string, string> Headers { get; }

        HttpMethod Method { get; }

        IDictionary<string, string> Parameters { get; }

        Uri BaseAddress { get; }

        TimeSpan Timeout { get; }

        string ContentType { get; }
    }
}
