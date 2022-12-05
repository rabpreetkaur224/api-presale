using AutoMapper;
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
    public class FeatureController : Controller
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public FeatureController(IFeatureRepository featureRepository, IMapper mapper)
        {
            this._featureRepository = featureRepository;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("api/feature/upsert")]
        public IActionResult Upsert([FromBody] FeatureRequest model)
        {
            if (ModelState.IsValid)
            {
                var feature = _mapper.Map<Feature>(model);
                feature.CreatedBy = userId;
                feature.CreatedOn = DateTime.Now;
                feature.UpdatedBy = userId;
                feature.UpdatedOn = DateTime.Now;
                var response = _featureRepository.Upsert(feature);
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
        [Route("api/feature/list")]
        public IActionResult List()
        {
            var response = _featureRepository.List();
            var list = _mapper.Map<List<FeatureResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/feature/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _featureRepository.Detail(id);
            var feature = _mapper.Map<FeatureResponse>(response);
            return Ok(feature);
        }
        [HttpGet]
        [Route("api/feature/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _featureRepository.Delete(id);
            return Ok(response);
        }
    }
}
