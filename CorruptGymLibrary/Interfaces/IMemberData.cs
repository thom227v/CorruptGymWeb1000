using CorruptGymLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorruptGymLibrary.Interfaces
{
    public interface IMemberData
    {
        Task<IEnumerable<Members>> GetMembers();
        Task<Members> GetMember(int id);
        Task InsertMember(Members member);
        Task UpdateMember(Members member);
        Task DeleteMember(int id);
    }
}