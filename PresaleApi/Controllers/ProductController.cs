using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace PresaleApi.Controllers
{
    [EnableCors("AllowOrigin")]

    public class ProductController : Controller
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public ProductController(IProductRepository ProductRepository, IMapper mapper)
        {
            this._ProductRepository = ProductRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/Product/upsert")]
        public IActionResult Upsert([FromBody] ProductRequest model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                product.CreatedBy = userId;
                product.CreatedOn = DateTime.Now;
                product.UpdatedBy = userId;
                product.UpdatedOn = DateTime.Now;
                var response = _ProductRepository.Upsert(product);
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
        [Route("api/Product/list")]
        public IActionResult List()
        {
            var response = _ProductRepository.List();
            var list = _mapper.Map<List<ProductResponse>>(response);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/Product/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _ProductRepository.Detail(id);
            var Product = _mapper.Map<ProductResponse>(response);
            return Ok(Product);
        }
        [HttpGet]
        [Route("api/Product/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _ProductRepository.Delete(id);
            return Ok(response);
        }

    }
}
