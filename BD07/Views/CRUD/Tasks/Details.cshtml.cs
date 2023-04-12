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
    public class DetailsModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public DetailsModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

      public MedEvent MedEvent { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedEvents == null)
            {
                return NotFound();
            }

            var medevent = await _context.MedEvents.FirstOrDefaultAsync(m => m.Id == id);
            if (medevent == null)
            {
                return NotFound();
            }
            else 
            {
                MedEvent = medevent;
            }
            return Page();
        }
    }
}
