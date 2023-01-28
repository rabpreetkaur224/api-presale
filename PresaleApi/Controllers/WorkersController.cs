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
    public class WorkersController : Controller
    {
        private readonly IWorkersRepository _workersRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        private IWorkersRepository workersRepository;

        public WorkersController(IWorkersRepository workersRepository, IMapper mapper)
        {
            this._workersRepository = workersRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/workers/upsert")]
        public IActionResult Upsert([FromBody] WorkersRequest model)
        {
            if (ModelState.IsValid)
            {
                var workers = _mapper.Map<Workers>(model);
                workers.CreatedBy = userId;
                workers.CreatedOn = DateTime.Now;
                workers.UpdateBy = userId;
                workers.UpdateOn = DateTime.Now;
                var response = _workersRepository.Upsert(workers);
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
        [Route("api/workers/list")]
        public IActionResult List()
        {
            var response = _workersRepository.List();
            var list = _mapper.Map<List<WorkersResponse>>(response);
            return Ok(response);
        }
        [HttpGet]
        [Route("api/workers/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _workersRepository.Detail(id);
            var workers = _mapper.Map<WorkersResponse>(response);
            return Ok(workers);
        }
        [HttpGet]
        [Route("api/workers/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _workersRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/workers/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _workersRepository.DeleteAll(ids);
            return Ok(response);
        }
    }
}
