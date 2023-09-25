using Core.Entities;

namespace API.Dtos;
public class ProductDto
{
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public string Description { get; set; } = "";
  public decimal Price { get; set; }
  public int Quantity { get; set; }
  public IEnumerable<ImageDto> Images { get; set; } = new List<ImageDto>();
  public string ProductType { get; set; } = "";
}
