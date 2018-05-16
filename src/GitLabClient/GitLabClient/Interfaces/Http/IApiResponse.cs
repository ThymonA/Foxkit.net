namespace GitLabClient.Interfaces.Http
{
    public interface IApiResponse<T>
        where T : class
    {
        T Body { get; }

        IResponse HttpResponse { get; }
    }
}
