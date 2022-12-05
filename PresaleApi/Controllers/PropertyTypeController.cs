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
    public class PropertyTypeController : Controller
    {
        private readonly IPropertyTypeRepository _PropertyTypeRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public PropertyTypeController(IPropertyTypeRepository PropertyTypeRepository, IMapper mapper)
        {
            this._PropertyTypeRepository = PropertyTypeRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/PropertyType/upsert")]
        public IActionResult Upsert([FromBody] PropertyTypeRequest model)
        {
            if (ModelState.IsValid)
            {
                var PropertyType = _mapper.Map<PropertyType>(model);
                PropertyType.CreatedBy = userId;
                PropertyType.CreatedOn = DateTime.Now;
                PropertyType.UpdatedBy = userId;
                PropertyType.UpdatedOn = DateTime.Now;
                var response = _PropertyTypeRepository.Upsert(PropertyType);
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
        [Route("api/PropertyType/list")]
        public IActionResult List()
        {
            var response = _PropertyTypeRepository.List();
            var list = _mapper.Map<List<PropertyTypeResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/PropertyType/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _PropertyTypeRepository.Detail(id);
            var PropertyType = _mapper.Map<PropertyTypeResponse>(response);
            return Ok(PropertyType);
        }
        [HttpGet]
        [Route("api/PropertyType/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _PropertyTypeRepository.Delete(id);
            return Ok(response);
        }

    }
}
