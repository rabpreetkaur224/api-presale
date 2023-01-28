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
    public class ContactUsController : Controller
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public ContactUsController(IContactUsRepository contactUsRepository, IMapper mapper)
        {
            this._contactUsRepository = contactUsRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/ContactUs/upsert")]
        public IActionResult Upsert([FromBody] ContactUsRequest model)
        {
            if (ModelState.IsValid)
            {
                var ContactUs = _mapper.Map<ContactUs>(model);
                ContactUs.CreatedOn = DateTime.Now;
                var response = _contactUsRepository.Upsert(ContactUs);
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
        [Route("api/ContactUs/list")]
        public IActionResult List()
        {
            var response = _contactUsRepository.List();
            var list = _mapper.Map<List<ContactUsResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/Product/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _contactUsRepository.Delete(id);
            return Ok(response);
        }
    }
}