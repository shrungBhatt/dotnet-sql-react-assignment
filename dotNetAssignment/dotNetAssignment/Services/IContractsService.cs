using dotNetAssignment.DataEntities;
using dotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetAssignment.Services
{
    public interface IContractsService
    {
        Contracts GetContract(int id);
        IEnumerable<Contracts> GetContracts();
        IEnumerable<ContractsView> GetContractsView();
        void InsertContract(CustomerDto contract);
        void UpdateContract(Contracts contract);
        void DeleteContract(int id);

    }

}
