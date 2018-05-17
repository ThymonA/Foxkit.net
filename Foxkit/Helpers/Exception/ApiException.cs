namespace Foxkit
{
    using System;
    using System.Net;

    public class ApiException : Exception
    {
        public static readonly IJsonSerializer JsonSerializer = new SimpleJsonSerializer();

        public ApiException()
            : this(new Response())
        {
        }

        public ApiException(string message, HttpStatusCode httpStatusCode)
            : this(GetApiErrorFromExceptionMessage(message), httpStatusCode, null)
        {
        }

        public ApiException(string message, Exception innerException)
            : this(GetApiErrorFromExceptionMessage(message), 0, innerException)
        {
        }

        public ApiException(IResponse response)
            : this(response, null)
        {
        }

        public ApiException(IResponse response, Exception innerException)
            : base(null, innerException)
        {
            response.ArgumentNotNull(nameof(response));

            StatusCode = response.StatusCode;
            ApiError = GetApiErrorFromExceptionMessage(response);
            HttpResponse = response;
        }

        protected ApiException(ApiException innerException)
        {
            innerException.ArgumentNotNull(nameof(innerException));

            StatusCode = innerException.StatusCode;
            ApiError = innerException.ApiError;
        }

        protected ApiException(HttpStatusCode statusCode, Exception innerException)
            : base(null, innerException)
        {
            ApiError = new ApiError();
            StatusCode = statusCode;
        }

        protected ApiException(ApiError apiError, HttpStatusCode statusCode, Exception innerException)
            : base(null, innerException)
        {
            apiError.ArgumentNotNull(nameof(apiError));

            ApiError = apiError;
            StatusCode = statusCode;
        }

        /// <summary>
        /// The HTTP status code associated with the repsonse
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The HTTP response associated with the repsonse
        /// </summary>
        public IResponse HttpResponse { get; }

        /// <summary>
        /// The raw exception payload from the response
        /// </summary>
        public ApiError ApiError { get; }

        public static ApiError GetApiErrorFromExceptionMessage(string responseContent)
        {
            try
            {
                if (!string.IsNullOrEmpty(responseContent))
                {
                    return JsonSerializer.Deserialize<ApiError>(responseContent) ?? new ApiError(responseContent);
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return new ApiError(responseContent);
        }

        public static ApiError GetApiErrorFromExceptionMessage(IResponse response)
        {
            var responseBody = response?.Body as string;

            return GetApiErrorFromExceptionMessage(responseBody);
        }

        /// <summary>
        /// Get the inner error message from the API response
        /// </summary>
        /// <remarks>
        /// Returns null if ApiError is not populated
        /// </remarks>
        protected string ApiErrorMessageSafe
        {
            get
            {
                if (ApiError != null && !string.IsNullOrWhiteSpace(ApiError.Message))
                {
                    return ApiError.Message;
                }

                return null;
            }
        }

        /// <summary>
        /// Get the inner http response body from the API response
        /// </summary>
        /// <remarks>
        /// Returns empty string if HttpResponse is not populated or if
        /// response body is not a string
        /// </remarks>
        protected string HttpResponseBodySafe =>
            HttpResponse != null
            && !HttpResponse.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)
            && HttpResponse.Body is string
                ? (string)HttpResponse.Body : string.Empty;

        public override string ToString()
        {
            var original = base.ToString();
            return original + Environment.NewLine + HttpResponseBodySafe;
        }
    }
}
