namespace GitLabClient.Http
{
    using GitLabClient.Interfaces.Http;

    public class ApiResponse<T> : IApiResponse<T>
        where T : class
    {
    }
}
