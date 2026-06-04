using Microsoft.AspNetCore.Mvc;
using RESTWebApiDatabaseFirst2.Data;
using RESTWebApiDatabaseFirst2.DTOs;
using RESTWebApiDatabaseFirst2.Exceptions;
using RESTWebApiDatabaseFirst2.Models;
using RESTWebApiDatabaseFirst2.Services;

namespace RESTWebApiDatabaseFirst2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
 
    private readonly IDBService _service;
    public PatientsController(IDBService service)
    {
        _service = service;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetPatients([FromQuery] string? search)
    {
        try
        {
            var patients = await _service.GetPatients(search);
            return Ok(patients);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Route("{pesel}/bedassignments")]
    [HttpPost]
    public async Task<IActionResult> PostBedAssignment(string pesel, BedAssignmentsPostDTO bedAssignments)
    {
        try
        {
            await _service.BedAssignments(pesel, bedAssignments);
            return Created();
        }
        catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

}