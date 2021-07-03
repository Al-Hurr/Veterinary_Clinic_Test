using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly DoctorsService _doctorsService;

        public EditModel(DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            Doctor = await _doctorsService.GetAsync(id.Value);

            if (Doctor == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _doctorsService.UpdateAsync(Doctor);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
