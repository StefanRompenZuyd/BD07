using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BD07.Data;
using BD07.Models;

namespace BD07.Views.CRUD.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public CreateModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MedEvent MedEvent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MedEvents == null || MedEvent == null)
            {
                return Page();
            }

            _context.MedEvents.Add(MedEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
