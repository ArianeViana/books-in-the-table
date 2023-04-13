
using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.AuthorPublisher;
using Microsoft.AspNetCore.Mvc;

namespace books_in_the_table.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthorPublisherController : ControllerBase
    {
        private readonly IAuthorPublisher _interfaces;

        public AuthorPublisherController(IAuthorPublisher interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult SaveAuthorPublisher([FromBody] AddAuthorPublisherDto dto)
        {
            var authorPublisher = _interfaces.Add(dto);

            if (authorPublisher != null)
            {
                return Ok("Salvo com sucesso.");
            }

            return BadRequest("Falha ao salvar.");
        }

        [HttpGet]
        public IActionResult GetAuthorPublisher()
        {
            var authorPublisher = _interfaces.SearchAll();

            if (authorPublisher != null)
            {
                return Ok(authorPublisher);
            }

            return BadRequest("Registros não encontrados.");
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorPublisherById(Guid id)
        {
            var authorPublisher = _interfaces.SearchById(id);

            if (authorPublisher != null)
            {
                return Ok(authorPublisher);
            }

            return BadRequest("Registro não encontrado.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthorPublisher(Guid id, UpdateAuthorPublisherDto dto)
        {
            var authorPublisher = _interfaces.Update(id, dto);

            if (authorPublisher != null)
            {
                return Ok("Registro atualizado com sucesso.");
            }

            return BadRequest("Falha ao atualizar registro.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorPublisher(Guid id)
        {
            var authorPublisher = _interfaces.Delete(id);

            if (authorPublisher == true)
            {
                return Ok("Registro deletado com sucesso.");
            }

            return BadRequest("Falha ao deletar registro.");
        }
    }
}