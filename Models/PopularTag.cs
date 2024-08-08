namespace AdminApp.Models;

public class PopularTag : BaseEntity
{
    public string Title { get; set; } = null!;
    public ICollection<PopularTagPost>? PopularTagPosts { get; set; }
}