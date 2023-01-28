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
    public class ProductInquiryController : Controller
    {
        private readonly IProductInquiryRepository _ProductInquiryRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public ProductInquiryController(IProductInquiryRepository ProductInquiryRepository, IMapper mapper)
        {
            this._ProductInquiryRepository = ProductInquiryRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/SaveProductInquiry/upsert")]
        public IActionResult Upsert([FromBody] ProductInquiryRequest model)
        {
            if (ModelState.IsValid)
            {
                var ProductInquiry = _mapper.Map<ProductInquiry>(model);
                ProductInquiry.CreatedOn = DateTime.Now;
                var response = _ProductInquiryRepository.Upsert(ProductInquiry);
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
        [Route("api/ProductInquiry/list")]
        public IActionResult List()
        {
            var response = _ProductInquiryRepository.List();
            var list = _mapper.Map<List<ProductInquiryResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/ProductInquiry/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _ProductInquiryRepository.Delete(id);
            return Ok(response);
        }
    }
}