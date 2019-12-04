using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Pages_ProductPages
{
    public class DetailsModel : PageModel
    {
        private readonly ProductApp.Data.ProductContext _context;

        public DetailsModel(ProductApp.Data.ProductContext context)
        {
            _context = context;
        }

        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _context.Products.FirstOrDefaultAsync(m => m.id == id);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
