using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Model;

namespace NotesApp.Pages.Note
{
    public class EditModel : PageModel
    {
        private readonly NotesApp.Data.NotesAppContext _context;

        public EditModel(NotesApp.Data.NotesAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notes Notes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notes =  await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            if (notes == null)
            {
                return NotFound();
            }
            Notes = notes;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(Notes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
