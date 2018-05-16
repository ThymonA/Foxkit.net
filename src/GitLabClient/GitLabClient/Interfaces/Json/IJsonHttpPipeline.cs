namespace GitLabClient
{
    public interface IJsonHttpPipeline
    {
        void SerializeRequest(IRequest request);

        IApiResponse<T> DeserializeResponse<T>(IResponse response)
            where T : class;
    }
}
