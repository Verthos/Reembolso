#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            try
            {
            IEnumerable<Department> departmentList = _db.GetAll();
            return Ok(departmentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET : api/departments/2
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            try
            {
                Department department = _db.GetFirstOrDefault(d => d.Id == id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST : api/departments
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department department)
        {
            try
            {
            _db.Add(department);
            _db.Save();
            return Created("Departamento criado", department);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
