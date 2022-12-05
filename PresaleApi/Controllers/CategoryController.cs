using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models.Request;
using System.Collections.Generic;
using PresaleApi.Models.Response;

namespace PresaleApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");


        public CategoryController(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            this._CategoryRepository = CategoryRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/Category/upsert")]
        public IActionResult Upsert([FromBody] CategoryRequest model)
        {
            //var id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                var Category = _mapper.Map<Category>(model);
                Category.CreatedBy = userId;
                Category.CreatedOn = DateTime.Now;
                Category.UpdatedBy = userId;
                Category.UpdatedOn = DateTime.Now;
                var response = _CategoryRepository.Upsert(Category);
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
        [Route("api/Category/list")]
        public IActionResult List()
        {
            var response = _CategoryRepository.List();
            var list = _mapper.Map<List<CategoryResponse>>(response);
            return Ok(list);


        }
        [HttpGet]
        [Route("api/Category/detail/{id}")]
        public IActionResult detail(int id)
        {
            var response = _CategoryRepository.Detail(id);
            var Category = _mapper.Map<CategoryResponse>(response);
            return Ok(Category);
        }
        [HttpGet]
        [Route("api/Category/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _CategoryRepository.Delete(id);
            return Ok(response);
        }

    }
}