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
    public class DetailsModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public DetailsModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

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
    }
}
