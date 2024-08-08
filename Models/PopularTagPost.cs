namespace AdminApp.Models;

public class PopularTagPost : BaseEntity
{
    public int PostId { get; set; }
    public Post Post { get; set; }
    public int PopularTagId { get; set; }
    public PopularTag PopularTag { get; set; }
}
