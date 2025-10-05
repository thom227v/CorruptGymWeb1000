using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly IUserData _userData;

        public CreateModel(IUserData userData)
        {
            _userData = userData;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CentersStaff CentersStaff { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userData.InsertUser(CentersStaff);

            return RedirectToPage("./Index");
        }
    }
}