﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
    }
}
