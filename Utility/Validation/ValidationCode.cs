using System.Net;

namespace PC.Utility.Validation;

public class ValidationCode
{
    public const HttpStatusCode Success = HttpStatusCode.OK;
    public const HttpStatusCode NotFound = HttpStatusCode.NotFound;
    public const HttpStatusCode BadRequest = HttpStatusCode.BadRequest;
}