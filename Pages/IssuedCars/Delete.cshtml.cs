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
    public class DeleteModel : PageModel
    {
        private readonly LabContext _context;

        public DeleteModel(LabContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IssuedCar = await _context.IssuedCar.FindAsync(id);

            if (IssuedCar != null)
            {
                _context.IssuedCar.Remove(IssuedCar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
