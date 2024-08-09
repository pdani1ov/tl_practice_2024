using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/woking_hours" )]
public class WorkingHoursController : ControllerBase
{
    private IRepository<WorkingHours> _repository;

    public WorkingHoursController( IRepository<WorkingHours> repository )
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllWorkingHours()
    {
        List<WorkingHours> allWorkingHours = _repository.GetAll();
        return Ok( allWorkingHours );
    }

    [HttpPost]
    public IActionResult CreateWorkingHours( [FromBody] CreateWorkingHours workingHours )
    {
        WorkingHours newWorkingHours = new WorkingHours(
            day: workingHours.Day,
            start: workingHours.Start,
            end: workingHours.End,
            theatreId: workingHours.TheatreId );

        try
        {
            _repository.Create( newWorkingHours );
        }
        catch ( DbUpdateException )
        {
            return BadRequest( $"No such theatre with Id = {workingHours.TheatreId} exists." );
        }

        return Ok( newWorkingHours );
    }

    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteWorkingHours( [FromRoute] int id )
    {
        WorkingHours? workingHours = _repository.GetAll().FirstOrDefault( wh => wh.Id == id );
        if ( workingHours == null )
        {
            return BadRequest( $"No such working hours with Id = {id} exist." );
        }
        _repository.Remove( workingHours );
        return Ok( workingHours );
    }
}
