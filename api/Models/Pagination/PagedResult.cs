namespace api.Utilities;

public class PagedResult<T> : List<T>
{
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public int TotalNumberOfPages { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalNumberOfPages;
    
    public PagedResult(List<T> items, int count, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalCount = count;
        TotalNumberOfPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }
}