using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Animals
{
    public class IndexModel : PageModel
    {
        private readonly AnimalsService _animalsService;

        public IndexModel(AnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        public List<Animal> Animals { get; set; }

        public async Task OnGet()
        {
            Animals = await _animalsService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _animalsService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
