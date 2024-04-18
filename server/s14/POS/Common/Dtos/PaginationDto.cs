namespace S14.POS.Common.Dtos;
public class PaginationDTO
{
    public int PageNumber { get; set; }

    private readonly int MaxNumberOfRecordsPerPage = 50;

    public int PageSize
    {
        get => PageSize;
        set => PageSize = (value > MaxNumberOfRecordsPerPage) ? MaxNumberOfRecordsPerPage : value;
    }
}