using System.Net;

namespace Xpense.Api.Models;

public class CustomResponse
{
    public HttpStatusCode Code { get; set; }
    public string Phrase { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}