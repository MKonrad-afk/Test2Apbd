using Microsoft.AspNetCore.Mvc;
using Test2.Dtos;
using Test2.services;

namespace Test2.controllers;


[ApiController]
[Route("/washing-machines")]
public class WashingMachineController : ControllerBase
{
    private readonly IWashingMachineService _service;

    public WashingMachineController(IWashingMachineService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddMachine([FromBody] AddWashingMachineRequest request)
    {
        try
        {
            await _service.AddWashingMachineAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}