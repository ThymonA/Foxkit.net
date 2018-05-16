namespace GitLabClient
{
    public interface IApiResponse<T>
        where T : class
    {
        T Body { get; }

        IResponse HttpResponse { get; }
    }
}
