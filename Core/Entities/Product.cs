namespace Core.Entities;

public class Product : BaseEntity
{
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }
  public int Quantity { get; set; }
  public IEnumerable<Image> Images { get; set; } = new List<Image>();
  public ProductType ProductType { get; set; }
  public int ProductTypeId { get; set; }
}
