namespace BMDb.AccessCode.Models;

public class ResponseModel
{
    public string Message { get; set; } = string.Empty;
    public bool IsSucceeded { get; set; }
    public int StatusCode { get; set; }
    public List<string>? Errors { get; set; }
}
