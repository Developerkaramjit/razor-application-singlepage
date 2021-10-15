using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Application.Model;

namespace Razor_Application.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> Book { get; set; }
        public async Task OnGet()
        {
            Book = await _context.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookInDb = await _context.Books.FindAsync(id);
            if(bookInDb==null)
            return NotFound();
            _context.Books.Remove(bookInDb);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
