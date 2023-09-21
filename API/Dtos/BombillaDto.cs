namespace API.Dtos;

public class BombillaDto : ProductDto
{
  public string Material { get; set; } = "";
  public string Length { get; set; } = "";
  public bool IsUnscrewed { get; set; }
}
