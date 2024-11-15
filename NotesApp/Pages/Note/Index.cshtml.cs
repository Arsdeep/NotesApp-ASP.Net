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
    public class IndexModel : PageModel
    {
        private readonly NotesApp.Data.NotesAppContext _context;

        public IndexModel(NotesApp.Data.NotesAppContext context)
        {
            _context = context;
        }

        public IList<Notes> Notes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Notes = await _context.Notes.ToListAsync();
        }
    }
}
