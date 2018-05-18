namespace Foxkit
{
    public interface IServiceContainer
    {
        TService GetService<TService>()
            where TService : class;
    }
}
