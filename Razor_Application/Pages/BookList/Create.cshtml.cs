using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Application.Model;

namespace Razor_Application.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
         public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Book book)
        {
            if (ModelState.IsValid)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
                return Page(); 
        }
    }
}
