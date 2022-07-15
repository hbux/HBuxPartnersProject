﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBPApi.Library.DataAccess
{
    public interface ISqlDataAccess
    {
        string GetConnectionString(string name);
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}