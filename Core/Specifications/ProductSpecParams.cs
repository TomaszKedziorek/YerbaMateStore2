namespace Core.Specifications;
public class ProductSpecParams
{
  private const int MaxPageSize = 50;
  private int _pageIndex = 1;
  public int PageIndex
  {
    get => _pageIndex;
    set => _pageIndex = (value <= 0) ? _pageIndex : value;
  }

  private int _pageSize = 5;
  public int PageSize
  {
    get => _pageSize;
    set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
  }
  public int? TypeId { get; set; }
  public string Sort { get; set; }

  private string _search;
  public string Search
  {
    get => _search;
    set => _search = value.ToLower();
  }
}