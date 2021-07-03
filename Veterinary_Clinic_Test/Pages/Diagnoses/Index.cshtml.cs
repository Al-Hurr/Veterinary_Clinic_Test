using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Diagnoses
{
    public class IndexModel : PageModel
    {
        private readonly DiagnosesService _diagnosesService;

        public IndexModel(DiagnosesService diagnosesService)
        {
            _diagnosesService = diagnosesService;
        }

        public List<Diagnosis> Diagnoses { get; set; }

        public async Task OnGet()
        {
            Diagnoses = await _diagnosesService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _diagnosesService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
