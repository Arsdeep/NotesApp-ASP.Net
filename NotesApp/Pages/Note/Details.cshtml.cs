using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Model;

namespace NotesApp.Pages.Note
{
    public class DetailsModel : PageModel
    {
        private readonly NotesApp.Data.NotesAppContext _context;

        public DetailsModel(NotesApp.Data.NotesAppContext context)
        {
            _context = context;
        }

        public Notes Notes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notes = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            if (notes == null)
            {
                return NotFound();
            }
            else
            {
                Notes = notes;
            }
            return Page();
        }
    }
}
