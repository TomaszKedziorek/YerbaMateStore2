namespace Core.Entities;

public class Image : BaseEntity
{
  public string PictureUrl { get; set; }
  public Product Product { get; set; }
  public int ProductId { get; set; }
}
