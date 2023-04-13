using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.Book;
using Microsoft.AspNetCore.Mvc;

namespace books_in_the_table.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBook _interfaces;

        public BookController(IBook interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult SaveBook([FromBody] AddBookDto dto)
        {
            var book = _interfaces.Add(dto);

            if (book != null)
            {
                return Ok("Livro salvo com sucesso.");
            }

            return BadRequest("Falha ao salvar livro.");
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            var book = _interfaces.SearchAll();

            if (book != null)
            {
                return Ok(book);
            }

            return BadRequest("Livros não encontrados.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _interfaces.SearchById(id);

            if (book != null)
            {
                return Ok(book);
            }

            return BadRequest("Livro não encontrado.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, UpdateBookDto dto)
        {
            var book = _interfaces.Update(id, dto);

            if (book != null)
            {
                return Ok("Livro atualizado com sucesso.");
            }

            return BadRequest("Falha ao atualizar livro.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = _interfaces.Delete(id);

            if (book == true)
            {
                return Ok("Livro deletado com sucesso.");
            }

            return BadRequest("Falha ao deletar livro.");
        }
    }
}