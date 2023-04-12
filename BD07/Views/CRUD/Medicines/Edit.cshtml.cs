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

namespace BD07.Views.CRUD.Medicines
{
    public class EditModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public EditModel(BD07.Data.MyMedContext context)
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

            var medicine =  await _context.Medicines.FirstOrDefaultAsync(m => m.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }
            Medicine = medicine;
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

            _context.Attach(Medicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(Medicine.Id))
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

        private bool MedicineExists(int id)
        {
          return (_context.Medicines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
