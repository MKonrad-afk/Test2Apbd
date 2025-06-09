using Microsoft.AspNetCore.Mvc;
using Test2.services;

namespace Test2.controllers;
[ApiController]
[Route("api/customers")]
public class CustomerController :ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet("{customerId}/purchases")]
    public async Task<IActionResult> GetPurchases(int customerId)
    {
        var result = await _service.GetCustomerPurchasesAsync(customerId);
        return result == null ? NotFound() : Ok(result);
    }
}