using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PresaleApi.Controllers
{
    public class NearByController : Controller
    {
        private readonly INearByRepository _NearByRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public NearByController(INearByRepository NearByRepository, IMapper mapper)
        {
            this._NearByRepository = NearByRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/NearBy/upsert")]
        public IActionResult Upsert([FromBody] NearByRequest model)
        {
            if (ModelState.IsValid)
            {
                var NearBy = _mapper.Map<NearBy>(model);
                NearBy.CreatedBy = userId;
                NearBy.CreatedOn = DateTime.Now;
                NearBy.UpdatedBy = userId;
                NearBy.UpdatedOn = DateTime.Now;
                var response = _NearByRepository.Upsert(NearBy);
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
        [Route("api/NearBy/list")]
        public IActionResult List()
        {
            var response = _NearByRepository.List();
            var list = _mapper.Map<List<NearByResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/NearBy/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _NearByRepository.Detail(id);
            var NearBy = _mapper.Map<NearByResponse>(response);
            return Ok(NearBy);
        }
        [HttpGet]
        [Route("api/NearBy/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _NearByRepository.Delete(id);
            return Ok(response);
        }

    }
}
