using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using PresaleApi.DataBaseEntity;
using System.Collections.Generic;

namespace PresaleApi.Controllers
{
    public class ImageDumpController : Controller
    {
        private readonly IImageDumpRepository _ImageDumpRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public ImageDumpController(IImageDumpRepository ImageDumpRepository, IMapper mapper)
        {
            this._ImageDumpRepository = ImageDumpRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/ImageDump/upsert")]
        public IActionResult Upsert([FromBody] ImageDumpRequest model)
        {
            if (ModelState.IsValid)
            {
                var ImageDump = _mapper.Map<ImageDump>(model);
                var response = _ImageDumpRepository.Upsert(ImageDump);
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
        [Route("api/ImageDump/list")]
        public IActionResult List()
        {
            var response = _ImageDumpRepository.List();
            var list = _mapper.Map<List<ImageDumpResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/ImageDump/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _ImageDumpRepository.Delete(id);
            return Ok(response);
        }
    }
}