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
    public class EditModel : PageModel
    {
        private readonly OwnersService _ownersService;

        public EditModel(OwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        [BindProperty]
        public Owner Owner { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            Owner = await _ownersService.GetAsync(id.Value);

            if (Owner == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _ownersService.UpdateAsync(Owner);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
