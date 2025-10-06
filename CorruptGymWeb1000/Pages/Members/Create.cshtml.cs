using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CorruptGymLibrary.Interfaces;
using CorruptGymLibrary.Models;

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
        public CorruptGymLibrary.Models.Members Member { get; set; } = default!;

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