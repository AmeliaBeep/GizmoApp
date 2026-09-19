using GizmoApp.Models;
using GizmoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GizmoApp.Controllers;

[ApiController]
[Route("api/opinions")]
public class OpinionsController(IOpinionService opinionService) : ControllerBase
{
    [HttpGet("random")]
    public async Task<ActionResult<Opinion?>> GetRandom()
    {
        var opinion = await opinionService.GetRandomOpinionAsync();

        return opinion is null
            ? NotFound()
            : Ok(opinion);
    }
}