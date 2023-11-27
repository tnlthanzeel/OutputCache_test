using OutputCache_test.SharedKernal.Extensions;
using OutputCache_test.SharedKernal.Interfaces;

namespace OutputCache_test.Api.Services;

public sealed class ApplicationContext : IApplicationContext
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationContext(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    public string BaseUrl
    {
        get
        {

            var baseUrl = _webHostEnvironment.IsDevelopment() ? _httpContextAccessor.HttpContext?.Request.BaseUrl() :
                                                           _httpContextAccessor.HttpContext?.Request.BaseUrl();

            return baseUrl!;
        }
    }
}
