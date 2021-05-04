using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab.Models;

namespace OrderingCars.Pages_IssuedCars
{
    public class DetailsModel : PageModel
    {
        private readonly LabContext _context;

        public DetailsModel(LabContext context)
        {
            _context = context;
        }

        public IssuedCar IssuedCar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IssuedCar = await _context.IssuedCar
                .Include(i => i.Car)
                .Include(i => i.Client).FirstOrDefaultAsync(m => m.ID == id);

            if (IssuedCar == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
