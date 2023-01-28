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
    public class CmsController : Controller
    {
        private readonly ICmsRepository _cmsRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public CmsController(ICmsRepository cmsRepository, IMapper mapper)
        {
            this._cmsRepository = cmsRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/cms/upsert")]
        public IActionResult Upsert([FromBody] CmsRequest model)
        {
            if (ModelState.IsValid)
            {
                var Cms = _mapper.Map<Cms>(model);
                Cms.CreatedBy = userId;
                Cms.CreatedOn = DateTime.Now;
                Cms.UpdatedBy = userId;
                Cms.UpdatedOn = DateTime.Now;
                var response = _cmsRepository.Upsert(Cms);
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
        [Route("api/cms/list")]
        public IActionResult List()
        {
            var response = _cmsRepository.List();
            var list = _mapper.Map<List<CmsResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/cms/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _cmsRepository.Delete(id);
            return Ok(response);
        }
    }
}
