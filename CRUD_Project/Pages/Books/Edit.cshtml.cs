using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Project.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book book { get; set; }

        [TempData]
        public string Message { get; set; }



        public void OnGet(int id)
        {
            book = _db.Books.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = _db.Books.Find(book.Id);
                BookFromDb.Name = book.Name;
                BookFromDb.Description = book.Description;

                await _db.SaveChangesAsync();

                Message = "Se ha realizado correctamente la actualizacion";
                return RedirectToPage("Index");
            }

            return RedirectToPage();

        }
    }
}