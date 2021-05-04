using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab.Models;

namespace OrderingCars.Pages_IssuedCars
{
    public class EditModel : PageModel
    {
        private readonly LabContext _context;

        public EditModel(LabContext context)
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
           ViewData["CarId"] = new SelectList(_context.Set<Car>(), "ID", "ID");
           ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ID", "ID");
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

            _context.Attach(IssuedCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuedCarExists(IssuedCar.ID))
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

        private bool IssuedCarExists(int id)
        {
            return _context.IssuedCar.Any(e => e.ID == id);
        }
    }
}
