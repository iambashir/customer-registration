using customer_registration.DTOs;
using customer_registration.Services;
using Microsoft.AspNetCore.Mvc;

namespace customer_registration.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerInfoController : ControllerBase
{
    private readonly CustomerInfoService _service;

    public CustomerInfoController(CustomerInfoService service)
    {
        _service = service;
    }

    // GET all
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET by id
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var customer = await _service.GetByIdAsync(id);
        if (customer == null)
            return NotFound(new { message = "Customer not found" });

        return Ok(customer);
    }

    // POST create
    [HttpPost]
    public async Task<IActionResult> Create(CustomerInfoDto dto)
    {
        var createdCustomer = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = createdCustomer.Id }, createdCustomer);
    }

    // PUT update
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, CustomerInfoDto dto)
    {
        var customer = await _service.GetByIdAsync(id);
        if (customer == null)
            return NotFound(new { message = "Customer not found" });

        await _service.UpdateAsync(id, dto);

        // Return updated customer
        var updatedCustomer = await _service.GetByIdAsync(id);
        return Ok(updatedCustomer);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var customer = await _service.GetByIdAsync(id);
        if (customer == null)
            return NotFound(new { message = "Customer not found" });

        await _service.DeleteAsync(id);

        return Ok(new { message = "Deleted successfully" });
    }
}
