namespace API.Dtos;

public class YerbaMateDto : ProductDto
{
  public string Composition { get; set; } = "";
  public bool HasAdditives { get; set; }
  public string Weight { get; set; } = "";
  public string Brand { get; set; } = "";
  public string Country { get; set; } = "";
  public string CountryCode { get; set; } = "";
}
