using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinary_Clinic_Test.Models;
using Veterinary_Clinic_Test.Services;

namespace Veterinary_Clinic_Test.Pages.Vaccinations
{
    public class IndexModel : PageModel
    {
        private readonly VaccinationsService _vaccinationsService;

        public IndexModel(VaccinationsService vaccinationsService)
        {
            _vaccinationsService = vaccinationsService;
        }

        public List<Vaccination> Vaccinations { get; set; }

        public async Task OnGet()
        {
            Vaccinations = await _vaccinationsService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _vaccinationsService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
