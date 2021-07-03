using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Animals
{
    public class EditModel : PageModel
    {
        private readonly AnimalsService _animalsService;
        private readonly OwnersService _ownersService;
        private readonly DoctorsService _doctorsService;
        private readonly DiagnosesService _diagnosesService;

        public EditModel(AnimalsService animalsService,
            OwnersService ownersService,
            DoctorsService doctorsService,
            DiagnosesService diagnosesService)
        {
            _animalsService = animalsService;
            _ownersService = ownersService;
            _doctorsService = doctorsService;
            _diagnosesService = diagnosesService;
        }

        [BindProperty]
        public Animal Animal { get; set; }

        public SelectList Owners { get; set; }
        public SelectList Doctors { get; set; }
        public SelectList Diagnoses { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            Animal = await _animalsService.GetAsync(id.Value);

            if (Animal == null)
                return NotFound();

            var owners = await _ownersService.GetAllAsync();
            Owners = new SelectList(owners, nameof(Owner.Id), nameof(Owner.FullName));

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
                await _animalsService.UpdateAsync(Animal);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
