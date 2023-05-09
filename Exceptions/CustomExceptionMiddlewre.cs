using my_books.Data.ViewModels;
using System.Net;

namespace my_books.Exceptions
{
    public class CustomExceptionMiddlewre
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddlewre(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var resoonse = new ErrorVM()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Internal server error from the custom middleware",
                Path = "patho goes here"
            };
            return httpContext.Response.WriteAsync(resoonse.ToString());    
        }
    }
}
