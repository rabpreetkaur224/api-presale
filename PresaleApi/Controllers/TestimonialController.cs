using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using PresaleApi.Models.Request;
using System.IO;
using PresaleApi.DataBaseEntity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;

namespace PresaleApi.Controllers
{
    [EnableCors("AllowOrigin")]
    public class TestimonialController : Controller
    {
        private ITestimonialRepository _environment;
        private readonly ITestimonialRepository _TestimonialRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public TestimonialController(ITestimonialRepository TestimonialRepository, IMapper mapper, ITestimonialRepository environment)
        {
            this._TestimonialRepository = TestimonialRepository;
            this._mapper = mapper;
            this._environment = environment;
        }

        [HttpPost]
        [Route("api/Testimonial/upsert")]
        public IActionResult Upsert([FromBody] TestimonialRequest model)
        {
            if (ModelState.IsValid)
            {
                var testimonial = _mapper.Map<Testimonial>(model);
                testimonial.CreatedBy = userId;
                testimonial.CreatedOn = DateTime.Now;
                testimonial.UpdatedBy = userId;
                testimonial.UpdatedOn = DateTime.Now;
                var response = _TestimonialRepository.Upsert(testimonial);
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


        //[HttpPost("api/Testimonial/uploadImage")]
        //public ActionResult Student([FromForm] StudentRequest std)
        //{
        //    string path = Path.Combine(this._environment.ContentRootPath, "Images");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    var objName = Guid.NewGuid().ToString();
        //    string fileExtension = Path.GetExtension(std.Image.FileName);
        //    string newFileName = objName + fileExtension;
        //    using (FileStream stream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
        //    {
        //        std.Image.CopyTo(stream);
        //    }
        //    return Ok(new { status = true, message = "Student Posted Successfully" });
        //}
    }
}
