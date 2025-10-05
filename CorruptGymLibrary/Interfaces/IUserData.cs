using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface IUserData
    {
        Task<IEnumerable<CentersStaff>> GetUsers();
        Task<CentersStaff> GetUser(int id);
        Task InsertUser(CentersStaff centersStaff);
        Task UpdateUser(CentersStaff centersStaff);
        Task DeleteUser(int id);
    }
}
