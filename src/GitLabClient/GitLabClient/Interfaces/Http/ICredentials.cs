namespace GitLabClient.Interfaces.Http
{
    using GitLabClient.Helpers.Enums;

    public interface ICredentials
    {
        string Login { get; }

        string Password { get; }

        AuthenticationType AuthenticationType { get; }
    }
}
