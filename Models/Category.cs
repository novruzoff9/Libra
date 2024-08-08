namespace AdminApp.Models;

public class Category : BaseEntity
{
    public string Title { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category>? SubCategories { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
