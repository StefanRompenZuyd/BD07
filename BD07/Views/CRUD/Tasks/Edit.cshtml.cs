using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD07.Data;
using BD07.Models;

namespace BD07.Views.CRUD.Tasks
{
    public class EditModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public EditModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedEvent MedEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedEvents == null)
            {
                return NotFound();
            }

            var medevent =  await _context.MedEvents.FirstOrDefaultAsync(m => m.Id == id);
            if (medevent == null)
            {
                return NotFound();
            }
            MedEvent = medevent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MedEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedEventExists(MedEvent.Id))
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

        private bool MedEventExists(int id)
        {
          return (_context.MedEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
