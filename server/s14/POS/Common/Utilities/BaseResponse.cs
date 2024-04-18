namespace S14.POS.Common.Utilities;

public class BaseResponse<T>
{
    public BaseResponse() { }

    public BaseResponse(T data, string? message)
    {
        Message = message;
        Data = data;
    }

    public BaseResponse(string message)
    {
        Message = message;
    }

    public string? Message { get; set; }

    public T? Data { get; set; }

    public List<string>? Errors { get; set; }

    public bool Success { get; set; }

    public bool IsFound { get; set; }

    // public int? TotalRecords { get; set; }
    // public int? StatusCode { get; set; }
    // public List<T>? Items { get; set; }
}
