using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PresaleApi.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeachersRepository _teachersRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        private ITeachersRepository teachersRepository;

        public TeachersController(ITeachersRepository teachersRepository, IMapper mapper)
        {
            this._teachersRepository = teachersRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/teachers/upsert")]
        public IActionResult Upsert([FromBody] TeachersRequest model)
        {
            if (ModelState.IsValid)
            {
                var teachers = _mapper.Map<Teachers>(model);
                teachers.CreatedBy = userId;
                teachers.CreatedOn = DateTime.Now;
                teachers.UpdateBy = userId;
                teachers.UpdateOn = DateTime.Now;
                var response = _teachersRepository.Upsert(teachers);
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
        [Route("api/teachers/list")]
        public IActionResult List()
        {
            var response = _teachersRepository.List();
            var list = _mapper.Map<List<TeachersResponse>>(response);
            return Ok(response);
        }
        [HttpGet]
        [Route("api/teachers/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _teachersRepository.Detail(id);
            var teachers = _mapper.Map<TeachersResponse>(response);
            return Ok(teachers);
        }
        [HttpGet]
        [Route("api/teachers/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _teachersRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/teachers/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _teachersRepository.DeleteAll(ids);
            return Ok(response);
        }
    }
}