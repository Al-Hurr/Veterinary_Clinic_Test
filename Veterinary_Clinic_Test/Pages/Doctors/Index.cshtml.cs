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
    public class IndexModel : PageModel
    {
        private readonly DoctorsService _doctorsService;

        public IndexModel(DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        public List<Doctor> Doctors { get; set; }

        public async Task OnGet()
        {
            Doctors = await _doctorsService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
    await _doctorsService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
