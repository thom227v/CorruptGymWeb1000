using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.UserData
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<CentersStaff>> GetUsers() => _db.LoadData<CentersStaff, dynamic>(storedProcedure: "Organization.uspCentersStaff_Select", new { });

        public async Task<CentersStaff> GetUser(int id)
        {
            var results = await _db.LoadData<CentersStaff, dynamic>
                (storedProcedure: "Organization.uspCentersStaff",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(CentersStaff centersStaff) => _db.SaveData(storedProcedure: "Organization.uspCentersStaff_Insert", centersStaff);


        public Task UpdateUser(CentersStaff centersStaff) => _db.SaveData(storedProcedure: "Organization.uspCentersStaff_Update", centersStaff);


        public Task DeleteUser(int id) => _db.SaveData(storedProcedure: "Organization.uspCentersStaff_Delete", new { Id = id });

    }
}
