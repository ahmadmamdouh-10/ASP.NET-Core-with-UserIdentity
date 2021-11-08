using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController
        : ControllerBase
    {
        IGenericRepository<Employee> EmpRepo;
        IUnitOfWork UnitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            EmpRepo = UnitOfWork.GetEmpRepo();
        }


        [HttpGet("")]
        public async Task<List<Employee>>  Get()
        {
            var List  = await EmpRepo.GetAsync();
            return List.ToList();
        }



        [HttpPost("")]
        public async Task<IEnumerable<Employee>> Post(Employee e)
        {
            await EmpRepo.Add(e);
            await UnitOfWork.Save();
            return await EmpRepo.GetAsync();
        }


        [HttpPatch("{id}")]
        public async Task<IEnumerable<Employee>> UpdatePatch([FromRoute]int id, 
            [FromBody]JsonPatchDocument document)
        {
            await EmpRepo.UpdatePatch(id, document);
            await UnitOfWork.Save();
            return await EmpRepo.GetAsync();
        }


    }
}
