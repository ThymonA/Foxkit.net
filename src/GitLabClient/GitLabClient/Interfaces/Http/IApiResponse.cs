namespace GitLabClient
{
    public interface IApiResponse<out T>
        where T : class
    {
        T Body { get; }

        IResponse HttpResponse { get; }
    }
}
