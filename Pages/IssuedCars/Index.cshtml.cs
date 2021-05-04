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
    public class IndexModel : PageModel
    {
        private readonly LabContext _context;

        public IndexModel(LabContext context)
        {
            _context = context;
        }

        public IList<IssuedCar> IssuedCar { get;set; }

        public async Task OnGetAsync()
        {
            IssuedCar = await _context.IssuedCar
                .Include(i => i.Car)
                .Include(i => i.Client).ToListAsync();
        }
    }
}
