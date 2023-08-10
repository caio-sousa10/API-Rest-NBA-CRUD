using API_Tranca_Curso.Entities;
using API_Tranca_Curso.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace API_Tranca_Curso.Controllers;

[Route("api/[controller]")]
[ApiController]
public class APIExternaController : ControllerBase
{
    public readonly APIDBContext _context;

    public APIExternaController(APIDBContext context)

    {
        _context = context;
    }
    [HttpPost("EscolheId/{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        string urlApi = "https://www.balldontlie.io/api/v1/teams/" + id;
        var client = new HttpClient();
        var retorno = client.GetFromJsonAsync<Root>(urlApi).Result;
        _context.data.Add(retorno);
        return Ok(retorno);
    }

    [HttpGet("BuscarId/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetExternal(int id)
    {
        var pesquisa = _context.data.FirstOrDefault(x => x.id == id);
        if (pesquisa == null)
        {
            return NotFound();
        }

        return Ok(pesquisa);
    }

    [HttpGet("BuscarTodos/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        
        var usuarios = _context.data.ToList();
        return Ok(usuarios);
        
    }

    [HttpPut("Update/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put(int id_Atualiza, Datum input)
    {
        foreach (var item in _context.data)
        {
            var atualizaTime = _context.data.SingleOrDefault(x => x.id == id_Atualiza);

            if (atualizaTime == null)
            {
                return NotFound();

            }
            atualizaTime.Atualiza(input.abbreviation, input.city, input.conference, input.division, input.full_name, input.name);
            return Ok();
        }
        return BadRequest();
    }


    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult Delete(int id)
    {
        var record = _context.data.FirstOrDefault(d => d.id == id);

        if (record == null)
        {
            return NotFound();
        }
        record.Deletar(id);

        return NoContent();
    }
}
