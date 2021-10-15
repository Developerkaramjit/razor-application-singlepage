using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razor_Application.Model;

namespace Razor_Application.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data= _context.Books.ToList() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb =await _context.Books.FindAsync(id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error While delete data!!" });
            }
            _context.Books.Remove(bookFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Data Successfully deleted" });
        }
    }
}
