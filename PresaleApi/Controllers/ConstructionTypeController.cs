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

namespace PresaleApi.Controllers
{
    [EnableCors("AllowOrigin")]
    public class ConstructionTypeController : Controller
    {
        private readonly IConstructionTypeRepository _ConstructionTypeRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        private object _constructionTypeRepository;

        public ConstructionTypeController(IConstructionTypeRepository ConstructionTypeRepository, IMapper mapper)
        {
            this._ConstructionTypeRepository = ConstructionTypeRepository;
            this._mapper = mapper;
        }
       
        [HttpPost]
        [Route("api/ConstructionType/upsert")]
        public IActionResult Upsert([FromBody] ConstructionTypeRequest model)
        {
            if (ModelState.IsValid)
            {
                var constructionType = _mapper.Map<ConstructionType>(model);
                constructionType.CreatedBy = userId;
                constructionType.CreatedOn = DateTime.Now;
                constructionType.UpdatedBy = userId;
                constructionType.UpdatedOn = DateTime.Now;
                var response = _ConstructionTypeRepository.Upsert(constructionType);
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
        [Route("api/constructionType/list")]
        public IActionResult List()
        {
            var response = _ConstructionTypeRepository.List();
            var list = _mapper.Map<List<ConstructionTypeResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/ConstructionType/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _ConstructionTypeRepository.Detail(id);
            var ConstructionType = _mapper.Map<ConstructionTypeResponse>(response);
            return Ok(ConstructionType);
        }

        [HttpGet]
        [Route("api/ConstructionType/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _ConstructionTypeRepository.Delete(id);
            return Ok(response);
        }
    }

  
}
