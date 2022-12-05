using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresaleApi.Models;
using PresaleApi.Repository;
using System.Linq;
using System;
using PresaleApi.DataBaseEntity;

namespace PresaleApi.Controllers
{
    public class MarketingCompanyController : Controller
    {
        private readonly IMarketingCompanyRepository _MarketingCompanyRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");

        public MarketingCompanyController(IMarketingCompanyRepository MarketingCompanyRepository, IMapper mapper)
        {
            this._MarketingCompanyRepository = MarketingCompanyRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("api/MarketingCompany/upsert")]
        public IActionResult Upsert([FromBody] MarketingCompanyRequest model)
        {
            if (ModelState.IsValid)
            {
                var MarketingCompany = _mapper.Map<MarketingCompany>(model);
                MarketingCompany.CreatedBy = userId;
                MarketingCompany.CreatedOn = DateTime.Now;
                MarketingCompany.UpdatedBy = userId;
                MarketingCompany.UpdatedOn = DateTime.Now;
                var response = _MarketingCompanyRepository.Upsert(MarketingCompany);
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
    }
}
