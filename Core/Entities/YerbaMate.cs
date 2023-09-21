namespace Core.Entities;
public class YerbaMate : Product
{
  public string Composition { get; set; }
  public bool HasAdditives { get; set; }
  public string Weight { get; set; }
  public ProductBrand ProductBrand { get; set; }
  public int ProductBrandId { get; set; }
  public Country Country { get; set; }
  public int CountryId { get; set; }
}
