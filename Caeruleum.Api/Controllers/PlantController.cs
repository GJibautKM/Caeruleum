using Caeruleum.Model;
using Caeruleum.Model.Service;
using Microsoft.AspNetCore.Mvc;

namespace Caeruleum.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantController(
    ILogger<PlantController> logger,
    IPlantService plantService
) : ControllerBase
{
    [HttpGet]
    [Route($"{nameof(All)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IAsyncEnumerable<Plant> All()
    {
        logger.LogDebug("Get all plants");
        return plantService.GetAllAsync();
    }

    [HttpGet]
    [Route($"{{{nameof(plantId)}:int:min(1)}}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Plant>> GetOne([FromRoute] int plantId)
    {
        logger.LogDebug("Try get plant with id = {plantId}", plantId);

        return await plantService.GetByIdAsync(plantId) is Plant plant
            ? Ok(plant)
            : NotFound();
    }
}
