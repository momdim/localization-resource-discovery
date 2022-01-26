using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ResxDiscovery.Shared.Resources;

namespace ResxDiscovery.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocalizedResponseController : Controller
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public LocalizedResponseController(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    [HttpGet]
    [Produces(typeof(LocalizedResponse))]
    [ProducesResponseType(typeof(LocalizedResponse), (int)HttpStatusCode.OK)]
    public IActionResult Get()
    {
        return Ok(new LocalizedResponse()
        {
            CurrentCulture = CultureInfo.CurrentCulture.Name,
            CurrentUiCulture = CultureInfo.CurrentUICulture.Name,
            RandomKeyValue = _localizer["randomKey"]
        });
    }
}