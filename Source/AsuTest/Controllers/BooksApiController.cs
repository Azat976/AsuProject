using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsuTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsuTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksApiController : ControllerBase
    {
        UseContext db;
        public BooksApiController(UseContext context)
        {
            db = context;
            if (!db.Books.Any())
            {
                db.Books.Add(new Book { Title = "Властелин колец", Author = "Толкин", Description = "Перед вами трилогия Властелин Колец. Своеобразная Библия от фэнтези", Status = "Прочитан" });
                db.Books.Add(new Book { Title = "Четыре сезона", Author = "Кинг", Description = "«Четыре сезона» — сборник четырёх повестей американского писателя", Status = "Не прочитан" });
                db.Books.Add(new Book { Title = "Как перестать беспокоиться, и начать жить", Author = "Карнеги", Description = "Как потратить свое время впустую", Status = "Прочитан" });
                db.Books.Add(new Book { Title = "Над пропастью во ржи", Author = "Сэлинджер", Description = "«Над пропастью во ржи», также в других переводах — «Ловец на хлебном поле»", Status = "Не прочитан" });
                db.Books.Add(new Book { Title = "Метро 2033", Author = "Глуховский", Description = "«Метро́ 2033» — постапокалиптический роман Дмитрия Глуховского", Status = "Прочитан" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await db.Books.ToListAsync();
        }


        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            //Book book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
            Book book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }



        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        // PUT api/books/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!db.Books.Any(x => x.Id == book.Id))
            {
                return NotFound();
            }

            db.Update(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            Book book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

    }
}