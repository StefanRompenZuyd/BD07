using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BD07.Data;
using BD07.Models;

namespace BD07.Views.CRUD.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public IndexModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

        public IList<MedEvent> MedEvent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MedEvents != null)
            {
                MedEvent = await _context.MedEvents.ToListAsync();
            }
        }
    }
}
