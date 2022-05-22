#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgDataAPI.Data;
using Reembolso.Models;
using Reembolso.Repository.IRepository;

namespace Reembolso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _db;

        public DepartmentsController(IDepartmentRepository db)
        {
            _db = db;
        }

        // GET : api/departments
        [HttpGet]
        public ActionResult<Department> GetDepartments()
        {
            IEnumerable<Department> departmentList = _db.GetAll();
            return Ok(departmentList);
        }

        // GET : api/departments/2
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            Department department = _db.GetFirstOrDefault(d=> d.Id == id);
            return Ok(department);
        }

        // POST : api/departments
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department department)
        {
            _db.Add(department);
            _db.Save();
            return Created("Departamento criado", department);
        }

    }
}
