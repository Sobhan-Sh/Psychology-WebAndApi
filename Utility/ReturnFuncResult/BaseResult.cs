using System.Net;

namespace PC.Utility.ReturnFuncResult;

public class BaseResult
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}

public class BaseResult<TData>
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public TData Data { get; set; }
}