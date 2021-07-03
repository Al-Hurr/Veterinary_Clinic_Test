using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Diagnoses
{
    public class EditModel : PageModel
    {
        private readonly DoctorsService _doctorsService;
        private readonly DiagnosesService _diagnosesService;

        public EditModel(DoctorsService doctorsService,
            DiagnosesService diagnosesService)
        {
            _doctorsService = doctorsService;
            _diagnosesService = diagnosesService;
        }

        [BindProperty]
        public Diagnosis Diagnosis { get; set; }

        public SelectList Doctors { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            Diagnosis = await _diagnosesService.GetAsync(id.Value);

            if (Diagnosis == null)
                return NotFound();

            var doctors = await _doctorsService.GetAllAsync();
            Doctors = new SelectList(doctors, nameof(Doctor.Id), nameof(Doctor.FullName));

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _diagnosesService.UpdateAsync(Diagnosis);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
