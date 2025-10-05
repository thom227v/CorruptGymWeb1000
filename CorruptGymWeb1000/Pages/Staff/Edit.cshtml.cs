using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Staff
{
    public class EditModel : PageModel
    {
        private readonly IUserData _userData;

        public EditModel(IUserData userData)
        {
            _userData = userData;
        }

        [BindProperty]
        public CentersStaff CentersStaff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centersStaff = await _userData.GetUser(id.Value);
            if (centersStaff == null)
            {
                return NotFound();
            }
            CentersStaff = centersStaff;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userData.UpdateUser(CentersStaff);

            return RedirectToPage("./Index");
        }
    }
}