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
    public class StatesController : Controller
    {
        private readonly IStatesRepository _statesRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public StatesController(IStatesRepository statesRepository, IMapper mapper)
        {
            this._statesRepository = statesRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/states/upsert")]
        public IActionResult Upsert([FromBody] StatesRequest model)
        {
            if (ModelState.IsValid)
            {
                var state = _mapper.Map<States>(model);

                var response = _statesRepository.Upsert(state);
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
        [Route("api/states/list")]
        public IActionResult List()
        {
            var response = _statesRepository.List();
            var list = _mapper.Map<List<StatesResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/states/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _statesRepository.Detail(id);
            var state = _mapper.Map<StateResponse>(response);
            return Ok(state);
        }
        [HttpGet]
        [Route("api/states/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _statesRepository.Delete(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/states/Deleteall")]
        public IActionResult DeleteAll([FromBody] List<int> ids)
        {
            var response = _statesRepository.DeleteAll(ids);
            return Ok(response);
        }
    }
}
