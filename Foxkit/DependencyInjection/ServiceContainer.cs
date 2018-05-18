namespace Foxkit
{
    public sealed class ServiceContainer : IServiceContainer
    {
        private readonly Container container;

        public ServiceContainer(Container container)
        {
            this.container = container;
        }

        public TService GetService<TService>()
            where TService : class
        {
            return container.GetService<TService>();
        }
    }
}
