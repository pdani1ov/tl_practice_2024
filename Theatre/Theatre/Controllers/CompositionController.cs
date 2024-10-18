using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/compositions" )]
public class CompositionController : ControllerBase
{
    private IRepository<Composition> _repository;

    public CompositionController( IRepository<Composition> repository )
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetCompositions()
    {
        List<Composition> compositions = _repository.GetAll();
        return Ok( compositions );
    }

    [HttpPost]
    public IActionResult CreateComposition( [FromBody] CreateComposition composition )
    {
        Composition newComposition = new Composition(
            name: composition.Name,
            description: composition.Description,
            charactersInfo: composition.CharacterInfo,
            authorId: composition.AuthorId );

        try
        {
            _repository.Create( newComposition );
        }
        catch ( DbUpdateException )
        {
            return BadRequest( $"No such author with Id = {composition.AuthorId} exists\"" );
        }
        return Ok( newComposition );
    }

    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteComposition( [FromRoute] int id )
    {
        Composition? composition = _repository.GetAll().FirstOrDefault( c => c.Id == id );
        if ( composition == null )
        {
            return BadRequest( $"No such composition with Id = {id} exists" );
        }
        _repository.Remove( composition );
        return Ok();
    }
}