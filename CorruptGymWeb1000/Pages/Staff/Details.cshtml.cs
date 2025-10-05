using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Staff
{
    public class DetailsModel : PageModel
    {
        private readonly IUserData _userData;

        public DetailsModel(IUserData userData)
        {
            _userData = userData;
        }

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
            else
            {
                CentersStaff = centersStaff;
            }
            return Page();
        }
    }
}