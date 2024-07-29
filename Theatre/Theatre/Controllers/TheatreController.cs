using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using Domain.Entities;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/theatres" )]
public class TheatreController : ControllerBase
{
    private IRepository<Theatre> _repository;

    public TheatreController( IRepository<Theatre> repository )
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetTheatres()
    {
        List<Theatre> theatres = _repository.GetAll();
        return Ok( theatres );
    }

    [HttpPost]
    public IActionResult CreateTheatre( [FromBody] CreateTheatre theatre )
    {
        Theatre newTheatre = new Theatre(
            name: theatre.Name,
            address: theatre.Address,
            openingDate: theatre.OpeningDate,
            phoneNumber: theatre.PhoneNumber,
            description: theatre.Description
        );
        _repository.Create( newTheatre );
        return Ok( newTheatre );
    }

    [HttpPut, Route( "{id:int}" )]
    public IActionResult UpdateTheatre( [FromRoute] int id, [FromBody] UpdateTheatre updatedInfo )
    {
        Theatre? theatre = _repository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( theatre == null )
        {
            return BadRequest( $"No such theatre with Id = {id} exists" );
        }
        theatre.Update(
            name: updatedInfo.Name,
            phoneNumber: updatedInfo.PhoneNumber,
            description: updatedInfo.Description );
        _repository.Save();
        return Ok( theatre );
    }

    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteTheatre( [FromRoute] int id )
    {
        Theatre? theatre = _repository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( theatre == null )
        {
            return BadRequest( $"No such theatre with Id = {id} exists" );
        }
        _repository.Remove( theatre );
        return Ok();
    }
}
