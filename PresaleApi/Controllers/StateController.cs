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
    public class StateController : Controller
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public StateController(IStateRepository stateRepository, IMapper mapper)
        {
            this._stateRepository = stateRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/state/upsert")]
        public IActionResult Upsert([FromBody] StateRequest model)
        {
            if (ModelState.IsValid)
            {
                var state = _mapper.Map<State>(model);

                var response = _stateRepository.Upsert(state);
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
        [Route("api/State/list")]
        public IActionResult List()
        {
            var response = _stateRepository.List();
            var list = _mapper.Map<List<StateResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/state/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _stateRepository.Detail(id);
            var state = _mapper.Map<StateResponse>(response);
            return Ok(state);
        }
        [HttpGet]
        [Route("api/state/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _stateRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/state/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _stateRepository.DeleteAll(ids);
            return Ok(response);
        }
    }
}
