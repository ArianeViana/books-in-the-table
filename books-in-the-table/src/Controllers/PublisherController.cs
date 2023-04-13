using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace books_in_the_table.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisher _interfaces;

        public PublisherController(IPublisher interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult SavePublisher([FromBody] AddPublisherDto dto)
        {
            var publisher = _interfaces.Add(dto);

            if (publisher != null)
            {
                return Ok("Editora salva com sucesso.");
            }

            return BadRequest("Falha ao salvar editora.");
        }

        [HttpGet]
        public IActionResult GetPublisher()
        {
            var publisher = _interfaces.SearchAll();

            if (publisher != null)
            {
                return Ok(publisher);
            }

            return BadRequest("Editoras não encontradas.");
        }

        [HttpGet("{id}")]
        public IActionResult GetPubisherById(Guid id)
        {
            var publisher = _interfaces.SearchById(id);

            if (publisher != null)
            {
                return Ok(publisher);
            }

            return BadRequest("Editora não encontrada.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(Guid id, UpdatePublisherDto dto)
        {
            var publisher = _interfaces.Update(id, dto);

            if (publisher != null)
            {
                return Ok("Editora atualizada com sucesso.");
            }

            return BadRequest("Falha ao atualizar editora.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(Guid id)
        {
            var publisher = _interfaces.Delete(id);

            if (publisher == true)
            {
                return Ok("Editora deletada com sucesso.");
            }

            return BadRequest("Falha ao deletar editora.");
        }
    }
}