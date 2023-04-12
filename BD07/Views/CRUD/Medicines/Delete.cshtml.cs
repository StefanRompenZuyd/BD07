using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BD07.Data;
using BD07.Models;

namespace BD07.Views.CRUD.Medicines
{
    public class DeleteModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public DeleteModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Medicine Medicine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines.FirstOrDefaultAsync(m => m.Id == id);

            if (medicine == null)
            {
                return NotFound();
            }
            else 
            {
                Medicine = medicine;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine != null)
            {
                Medicine = medicine;
                _context.Medicines.Remove(Medicine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
