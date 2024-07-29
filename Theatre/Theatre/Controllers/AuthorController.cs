using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;

namespace WebAPI.Controllers;

[ApiController]
[Route( "api/author" )]
public class AuthorController : ControllerBase
{
    private IRepository<Author> _repository;

    public AuthorController( IRepository<Author> repository )
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        List<Author> authors = _repository.GetAll();
        return Ok( authors );
    }

    [HttpPost]
    public IActionResult CreateAuthor( [FromBody] CreateAuthor author )
    {
        Author newAuthor = new Author(
            firstName: author.FirstName,
            lastName: author.LastName,
            birthDate: author.BirthDate );
        _repository.Create( newAuthor );
        return Ok( newAuthor );
    }

    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteAuthor( [FromRoute] int id )
    {
        Author? author = _repository.GetAll().FirstOrDefault( a => a.Id == id );

        if ( author == null )
        {
            return BadRequest( $"No such author with Id = {id} exists" );
        }

        _repository.Remove( author );
        return Ok();
    }
}
