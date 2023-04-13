using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.Author;
using Microsoft.AspNetCore.Mvc;

namespace books_in_the_table.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _interfaces;

        public AuthorController(IAuthor interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult SaveAuthor([FromBody] AddAuthorDto dto)
        {
            var author = _interfaces.Add(dto);

            if (author != null)
            {
                return Ok("Autor salvo com sucesso.");
            }

            return BadRequest("Falha ao salvar autor.");
        }

        [HttpGet("/Authors")]
        public IActionResult GetAuthor()
        {
            var author = _interfaces.SearchAll();

            if (author != null)
            {
                return Ok(author);
            }

            return BadRequest("Autores não encontrados.");
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            var author = _interfaces.SearchById(id);

            if (author != null)
            {
                return Ok(author);
            }

            return BadRequest("Autor não encontrado.");
        }

        [HttpGet("/AuthorName/{name}")]
        public IActionResult GetAuthorByName(string name)
        {
            var author = _interfaces.SearchByName(name);

            if (author != null)
            {
                return Ok(author);
            }

            return BadRequest("Autor não encontrado.");

        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, UpdateAuthorDto dto)
        {
            var author = _interfaces.Update(id, dto);

            if (author != null)
            {
                return Ok("Autor atualizado com sucesso.");
            }

            return BadRequest("Falha ao atualizar autor.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var author = _interfaces.Delete(id);

            if (author == true)
            {
                return Ok("Autor deletado com sucesso.");
            }

            return BadRequest("Falha ao deletar Autor.");
        }
    }
}