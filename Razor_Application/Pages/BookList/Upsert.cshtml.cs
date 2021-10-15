using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Application.Model;

namespace Razor_Application.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id ==0)
             return Page();
            else
            {
                var bookInDb = await _context.Books.FindAsync(id);
                if (bookInDb == null)
                    return NotFound();
                Book = bookInDb;
                return Page();
            }
        }
        public async Task<IActionResult> OnPost(Book book)
        {
            if(book.Id==0)
            {
                await _context.Books.AddAsync(book);
            }
            else
            {
                var bookInDb = await _context.Books.FindAsync(Book.Id);
                if (bookInDb == null)
                    return NotFound();
                bookInDb.Name = Book.Name;
                bookInDb.Author = Book.Author;
                bookInDb.ISBN = Book.ISBN;
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
