using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class BogController : Controller
    {
        private static readonly List<Bog> Books = new List<Bog>
        {
            new Bog("bog1", "forfatter1", 123, "12345678910"),
            new Bog("bog1", "forfatter1", 123, "12345678910"),
            new Bog("bog1", "forfatter1", 123, "12345678910")
        };



        // GET Books
        [HttpGet]
        public IEnumerable<Bog> GetBooks()
        {
            return Books;
        }


        //Get Books isbn13
        [HttpGet("{isbn13}", Name = "Get")]
       
        public Bog Get(string isbn13)
        {
            Bog bog = Books.FirstOrDefault(b => b.Isbn13 == isbn13);
            
            return bog;
        }
        // POST api/Post
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            Books.Add(value);
        }

        // PUT api/books/isbn13
        [HttpPut("{isbn13}", Name = "Put")]
        public void Put(string isbn13, [FromBody] Bog value)
        {
            Bog bog = Get(isbn13);
            if (bog != null)
            {
                bog.Isbn13 = value.Isbn13;
                bog.Titel = value.Titel;
                bog.Forfatter = value.Forfatter;
                bog.Sidetal = value.Sidetal;

            }

        }

        // DELETE api/books/isbn13
        [HttpDelete("{isbn}", Name = "Delete")]
        public void Delete(string isbn13)
        {
            Bog bog = Get(isbn13);
            Books.Remove(bog);
        }










    }
}
