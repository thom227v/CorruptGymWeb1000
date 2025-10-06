using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CorruptGymLibrary.Interfaces;
using CorruptGymLibrary.Models;

namespace CorruptGymWeb1000.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly IMemberData _memberData;

        public DetailsModel(IMemberData memberData)
        {
            _memberData = memberData;
        }

        public CorruptGymLibrary.Models.Members Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _memberData.GetMember(id.Value);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}