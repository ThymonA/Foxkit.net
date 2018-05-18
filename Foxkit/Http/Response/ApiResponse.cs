namespace Foxkit
{
    public class ApiResponse<T> : IApiResponse<T>
        where T : class
    {
        public ApiResponse(IResponse response)
            : this(response, GetBodyAsObject(response))
        {
        }

        public ApiResponse(IResponse response, T bodyAsObject)
        {
            response.ArgumentNotNull(nameof(response));

            HttpResponse = response;
            Body = bodyAsObject;
        }

        public T Body { get; }

        public IResponse HttpResponse { get; }

        private static T GetBodyAsObject(IResponse response)
        {
            var body = response.Body;

            if (body is T variable)
            {
                return variable;
            };

            return default(T);
        }
    }
}
