using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Application.Model;

namespace Razor_Application.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
         public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost(Book book)
        {
            var BookInDb = await _context.Books.FindAsync(book.Id);
            if (BookInDb == null)
                return NotFound();
            BookInDb.Name = book.Name;
            BookInDb.Author = book.Author;
            BookInDb.ISBN = book.ISBN;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
