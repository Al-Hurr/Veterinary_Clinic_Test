using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Owners
{
    public class CreateModel : PageModel
    {
        private readonly OwnersService _ownersService;

        public CreateModel(OwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _ownersService.CreateAsync(Owner);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
