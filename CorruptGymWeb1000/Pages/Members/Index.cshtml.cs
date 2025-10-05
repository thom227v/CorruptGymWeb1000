using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly IMemberData _memberData;

        public IndexModel(IMemberData memberData)
        {
            _memberData = memberData;
        }

        public IEnumerable<ClassLibrary1.Models.Members> Members { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Members = await _memberData.GetMembers();
        }
    }
}