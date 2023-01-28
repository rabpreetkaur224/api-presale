using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/employee/upsert")]
        public IActionResult Upsert([FromBody] EmployeeRequest model)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(model);
                employee.CreatedBy = userId;
                employee.CreatedOn = DateTime.Now;
                employee.UpdateBy = userId;
                employee.UpdateOn = DateTime.Now;
                var response = _employeeRepository.Upsert(employee);
                return Ok(response);
            }
            else
            {
                ApplicationResponse res = new ApplicationResponse();
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                res.Message = message;
                return StatusCode(StatusCodes.Status500InternalServerError, res);
            }

        }
        [HttpGet]
        [Route("api/employee/list")]
        public IActionResult List()
        {
            var response = _employeeRepository.List();
            var list = _mapper.Map<List<EmployeeResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/employee/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _employeeRepository.Detail(id);
            var employee = _mapper.Map<EmployeeResponse>(response);
            return Ok(employee);
        }
        [HttpGet]
        [Route("api/employee/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _employeeRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/employee/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _employeeRepository.DeleteAll(ids);
            return Ok(response);
        }
    }
}
