namespace Foxkit
{
    public interface IRepositoryContent
    {
        string Sha { get; }

        string Name { get; }

        string Type { get; }

        ContentType ContentType { get; }

        string Path { get; }

        int Mode { get; }

        string Branch { get; }

        string GitUrl { get; }

        string HtmlUrl { get; }

        string RawUrl { get; }

        string Content { get; }

        string CommitId { get; }

        string LastCommitId { get; }

        int Size { get; }
    }
}
