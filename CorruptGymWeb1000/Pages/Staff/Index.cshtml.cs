using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace CorruptGymWeb1000.Pages.Staff
{
    public class IndexModel : PageModel
    {
        private readonly IUserData _userData;

        public IndexModel(IUserData userData)
        {
            _userData = userData;
        }

        public IEnumerable<CentersStaff> Staff { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Staff = await _userData.GetUsers();
        }
    }
}