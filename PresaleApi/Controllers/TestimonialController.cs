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

namespace PresaleApi.Controllers
{
    public class TestimonialController : Controller
    {
        
            private readonly ITestimonialRepository _TestimonialRepository;
            private readonly IMapper _mapper;
            private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

            public TestimonialController(ITestimonialRepository TestimonialRepository, IMapper mapper)
            {
                this._TestimonialRepository = TestimonialRepository;
                this._mapper = mapper;
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


        [HttpPost("api/Testimonial/uploadImage")]
        public ActionResult Student([FromForm] StudentRequest std)
        {
            // Getting Name
            string name = std.Name;

            // Getting Image
            var image = std.Image;

            // Saving Image on Server
            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(image.FileName, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            return Ok(new { status = true, message = "Student Posted Successfully" });
        }
    }
    }
