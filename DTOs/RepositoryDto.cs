namespace GitHubRepoSearchApi.DTOs
{
    public class RepositoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerLogin { get; set; }
        public string AvatarUrl { get; set; }
        public string HtmlUrl { get; set; }
    }
}
