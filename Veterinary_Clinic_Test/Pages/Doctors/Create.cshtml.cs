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
    public class CreateModel : PageModel
    {
        private readonly DoctorsService _doctorsService;

        public CreateModel(DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _doctorsService.CreateAsync(Doctor);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
