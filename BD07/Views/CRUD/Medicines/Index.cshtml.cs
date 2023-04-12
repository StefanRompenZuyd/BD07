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
    public class IndexModel : PageModel
    {
        private readonly BD07.Data.MyMedContext _context;

        public IndexModel(BD07.Data.MyMedContext context)
        {
            _context = context;
        }

        public IList<Medicine> Medicine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medicines != null)
            {
                Medicine = await _context.Medicines.ToListAsync();
            }
        }
    }
}
