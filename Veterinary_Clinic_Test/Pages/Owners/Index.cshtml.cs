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
    public class IndexModel : PageModel
    {
        private readonly OwnersService _ownersService;

        public IndexModel(OwnersService ownersService)
        {
            _ownersService = ownersService;
        }

        public List<Owner> Owners { get; set; }

        public async Task OnGet()
        {
            Owners = await _ownersService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _ownersService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
