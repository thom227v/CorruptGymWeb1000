using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly IMemberData _memberData;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IMemberData memberData, ILogger<EditModel> logger)
        {
            _memberData = memberData;
            _logger = logger;
        }

        [BindProperty]
        public ClassLibrary1.Models.Members Member { get; set; } = default!;

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

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
            Member = member;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = "Please correct the errors below.";
                return Page();
            }

            try
            {
                _logger.LogInformation("Attempting to update member with ID: {MemberId}", Member.Id);
                await _memberData.UpdateMember(Member);
                _logger.LogInformation("Successfully updated member with ID: {MemberId}", Member.Id);
                
                StatusMessage = "Member updated successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating member with ID: {MemberId}", Member.Id);
                StatusMessage = $"Error updating member: {ex.Message}";
                return Page();
            }
        }
    }
}