namespace GitLabClient
{
    public interface IProductHeaderValue
    {
        /// <summary>
        /// The name of the product, the GitHub Organization, or the GitHub Username that's using Octokit (in that order of preference)
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The version of the product.
        /// </summary>
        string Version { get; }
    }
}
