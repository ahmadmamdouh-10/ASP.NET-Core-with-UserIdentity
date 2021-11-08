using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        DbContext Context;
        IGenericRepository<Employee> EmpRepo;
        public UnitOfWork(ITIDBContext context, IGenericRepository<Employee> empRepo)
        {
            Context = context;
            EmpRepo = empRepo;
        }
        public IGenericRepository<Employee> GetEmpRepo()
        {
            return EmpRepo;
        }
        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
