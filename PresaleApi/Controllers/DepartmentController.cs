using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PresaleApi.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this._departmentRepository = departmentRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/department/upsert")]
        public IActionResult Upsert([FromBody] DepartmentRequest model)
        {
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(model);
              
                var response = _departmentRepository.Upsert(department);
                return Ok(response);
            }
            else
            {
                ApplicationResponse res = new ApplicationResponse();
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                res.Message = message;
                return StatusCode(StatusCodes.Status400BadRequest, res);
            }

        }

        [HttpGet]
        [Route("api/department/list")]
        public IActionResult List()
        {
            var response = _departmentRepository.List();
            var list = _mapper.Map<List<DepartmantResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/department/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _departmentRepository.Detail(id);
            var department = _mapper.Map<DepartmantResponse>(response);
            return Ok(department);
        }
        [HttpGet]
        [Route("api/department/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _departmentRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/department/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _departmentRepository.DeleteAll(ids);
            return Ok(response);
        }

    }
}
