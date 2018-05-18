namespace Foxkit
{
    public static class DependencyContainer
    {
        public static IServiceContainer Current { get; private set; }

        /// <summary>
        /// Register all library dependencies
        /// </summary>
        /// <param name="connection"></param>
        public static void Register(IConnection connection)
        {
            var container = new Container();
            var serviceContainer = new ServiceContainer(container);

            container.RegisterSingleton<IServiceContainer>(() => serviceContainer);

            Current = serviceContainer;

            container.RegisterSingleton(() => connection);
            container.RegisterSingleton(() => connection.Credentials);
            container.RegisterSingleton(() => connection.CredentialStore);
            container.RegisterSingleton<IGitLabClient>(() => new GitLabClient(connection));
            container.Register<IApiPagination, ApiPagination>();
            container.Register<IApiConnection, ApiConnection>();
            container.Register<IUserClient, UserClient>();
            container.Register<IUserSshKeysClient, UserSshKeysClient>();
            container.Register<IUserGpgKeysClient, UserGpgKeysClient>();
            container.Register<IProjectClient, ProjectClient>();
            container.Register<IRepositoryClient, RepositoryClient>();
            container.Register<IRepositoryContentClient, RepositoryContentClient>();
        }

        /// <summary>
        /// Get a instance of <see cref="TService"/>
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns>A <see cref="TService"/> instance</returns>
        public static TService GetService<TService>()
            where TService : class
        {
            return Current.GetService<TService>();
        }
    }
}
