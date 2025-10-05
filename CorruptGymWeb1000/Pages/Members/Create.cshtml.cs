using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly IMemberData _memberData;

        public CreateModel(IMemberData memberData)
        {
            _memberData = memberData;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClassLibrary1.Models.Members Member { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _memberData.InsertMember(Member);

            return RedirectToPage("./Index");
        }
    }
}