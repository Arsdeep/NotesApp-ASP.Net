using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesApp.Model;

namespace NotesApp.Data
{
    public class NotesAppContext : DbContext
    {
        public NotesAppContext (DbContextOptions<NotesAppContext> options)
            : base(options)
        {
        }

        public DbSet<NotesApp.Model.Notes> Notes { get; set; } = default!;
    }
}
