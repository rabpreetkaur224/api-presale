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
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public SubjectController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            this._subjectRepository = subjectRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/subject/upsert")]
        public IActionResult Upsert([FromBody] SubjectRequest model)
        {
            if (ModelState.IsValid)
            {
                var state = _mapper.Map<Subject>(model);

                var response = _subjectRepository.Upsert(state);
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
        [Route("api/subject/list")]
        public IActionResult List()
        {
            var response = _subjectRepository.List();
            var list = _mapper.Map<List<SubjectResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/subject/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _subjectRepository.Detail(id);
            var state = _mapper.Map<StateResponse>(response);
            return Ok(state);
        }
        [HttpGet]
        [Route("api/subject/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _subjectRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/subject/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _subjectRepository.DeleteAll(ids);
            return Ok(response);
        }
    }
}
