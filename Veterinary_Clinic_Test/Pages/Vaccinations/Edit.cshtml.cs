using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Vaccinations
{
    public class EditModel : PageModel
    {
        private readonly VaccinationsService _vaccinationsService;
        private readonly AnimalsService _animalsService;
        private readonly DoctorsService _doctorsService;
        private readonly DiagnosesService _diagnosesService;

        public EditModel(VaccinationsService vaccinationsService,
            AnimalsService animalsService,
            DoctorsService doctorsService,
            DiagnosesService diagnosesService)
        {
            _vaccinationsService = vaccinationsService;
            _animalsService = animalsService;
            _doctorsService = doctorsService;
            _diagnosesService = diagnosesService;
        }

        [BindProperty]
        public Vaccination Vaccination { get; set; }

        public SelectList Animals { get; set; }
        public SelectList Doctors { get; set; }
        public SelectList Diagnoses { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            Vaccination = await _vaccinationsService.GetAsync(id.Value);

            if (Vaccination == null)
                return NotFound();

            var animals = await _animalsService.GetAllAsync();
            Animals = new SelectList(animals, nameof(Animal.Id), nameof(Animal.Name));

            var doctors = await _doctorsService.GetAllAsync();
            Doctors = new SelectList(doctors, nameof(Doctor.Id), nameof(Doctor.FullName));

            var diagnoses = await _diagnosesService.GetAllAsync();
            Diagnoses = new SelectList(diagnoses, nameof(Diagnosis.Id), nameof(Diagnosis.Name));

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _vaccinationsService.UpdateAsync(Vaccination);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
