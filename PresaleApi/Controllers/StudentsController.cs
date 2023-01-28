using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresaleApi.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public StudentsController(IStudentsRepository studentsRepository, IMapper mapper)
        {
            this._studentsRepository = studentsRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/students/upsert")]
        public IActionResult Upsert([FromBody] StudentsRequest model)
        {
            if (ModelState.IsValid)
            {
                var students = _mapper.Map<Students>(model);
                students.CreatedBy = userId;
                students.CreatedOn = DateTime.Now;
                students.UpdateBy = userId;
                students.UpdateOn = DateTime.Now;
                var response = _studentsRepository.Upsert(students);
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
        [Route("api/students/list")]
        public IActionResult List()
        {
            var response = _studentsRepository.List();
            //var list = _mapper.Map<List<StudentsResponse>>(response);
            return Ok(response);
        }
        [HttpGet]
        [Route("api/students/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _studentsRepository.Detail(id);
            var students = _mapper.Map<StudentsResponse>(response);
            return Ok(students);
        }
        [HttpGet]
        [Route("api/students/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _studentsRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/students/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _studentsRepository.DeleteAll(ids);
            return Ok(response);
        }

    }
}