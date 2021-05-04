using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab.Models;

namespace OrderingCars.Pages_IssuedCars
{
    public class CreateModel : PageModel
    {
        private readonly LabContext _context;

        public CreateModel(LabContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Set<Car>(), "ID", "ID");
        ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public IssuedCar IssuedCar { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IssuedCar.Add(IssuedCar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
