using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ClassLibrary1.MemberData
{
    public class MemberData : IMemberData
    {
        private readonly ISqlDataAccess _db;
        private readonly ILogger<MemberData> _logger;

        public MemberData(ISqlDataAccess db, ILogger<MemberData> logger)
        {
            _db = db;
            _logger = logger;
        }

        public Task<IEnumerable<Members>> GetMembers() => _db.LoadData<Members, dynamic>(storedProcedure: "Client.MembersSelect", new { });

        public async Task<Members> GetMember(int id)
        {
            // Since there's no specific stored procedure for selecting by ID, 
            // we'll get all members and filter by ID
            var results = await GetMembers();
            return results.FirstOrDefault(m => m.Id == id);
        }

        public Task InsertMember(Members member) => _db.SaveData(storedProcedure: "Client.MembersInsert", 
            new { 
                FirstName = member.First_Name,
                LastName = member.Last_Name,
                Email = member.Email,
                MembershipTypeId = member.Membership_Type_Id,
                CenterId = member.Center_Id,
                Birthday = member.Birthday
            });

        public async Task UpdateMember(Members member)
        {
            try
            {
                _logger.LogInformation("Updating member: {@Member}", member);
                
                var parameters = new {
                    Id = member.Id,
                    FirstName = member.First_Name,
                    LastName = member.Last_Name,
                    Email = member.Email,
                    Active = member.Active,
                    MembershipTypeId = member.Membership_Type_Id,
                    CenterId = member.Center_Id,
                    Birthday = member.Birthday
                };
                
                _logger.LogInformation("Update parameters: {@Parameters}", parameters);
                
                await _db.SaveData(storedProcedure: "Client.MembersUpdate", parameters);
                
                _logger.LogInformation("Member update completed for ID: {MemberId}", member.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating member with ID: {MemberId}", member.Id);
                throw;
            }
        }

        public Task DeleteMember(int id) => _db.SaveData(storedProcedure: "Client.MembersDelete", new { Id = id });
    }
}