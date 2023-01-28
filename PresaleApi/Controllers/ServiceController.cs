using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PresaleApi.Models;
using PresaleApi.Models.Request;
using PresaleApi.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;
using System.Xml;

namespace PresaleApi.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        private Guid userId = new System.Guid("5F099914-63A7-458A-A29F-FC0EF9FC3311");
        public ServiceController(ICommonRepository commonRepository, IMapper mapper)
        {
            this._commonRepository = commonRepository;
            this._mapper = mapper;
        }
        // TypedProductList

        [HttpPost]
        [Route("api/service/getTypedProductList")]
        public IActionResult GetTypedProductList([FromBody] TypedProductListRequest model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsFeaturedProduct", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                Value = model.IsFeaturedProduct, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsShowOnHomePage", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                Value = model.IsShowOnHomePage, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsArrival", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                Value = model.IsArrival, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsUpComing", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                Value = model.IsUpComing, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            var data = _commonRepository.GetData("Product_TypedProductList", parameters);
            return Ok(data);
        }
        //ProductInquiryRequest
        [HttpPost]
        [Route("api/service/SaveProductInquiry")]
        public IActionResult SaveProductInquiry([FromBody] ProductInquiryRequest model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@FirstName", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.FirstName, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@LastName", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.LastName, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Email", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Email, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Phone", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Phone, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@PriceRange", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.PriceRange, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Bedrooms", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Bedrooms, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsRealtor", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                Value = model.IsRealtor, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsAgent", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                Value = model.IsAgent, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductId", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = model.ProductId, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Message", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Message, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            var data = _commonRepository.GetData("ProductInquiry_Insert", parameters);
            return Ok(data);
        }
        //SubLocation_SelectAll
        [HttpGet]
        [Route("api/service/getAllSubLocationList")]
        public IActionResult getAllSubLocationList()
        {
            var data = _commonRepository.GetData("SubLocation_SelectAll", null);
            return Ok(data);
        }

        //SubLocation_SelectAll
        [HttpPost]
        [Route("api/service/getAllProductList")]
        public IActionResult getAllProductList([FromBody] List<ProductSearchRequest> model)
        {
            if (model != null && model.Any())
            {
                XmlDocument doc = new XmlDocument();
                XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("root"));
                //el.AppendChild("Search");
                model.ForEach(x =>
                {
                    el.SetAttribute(x.Key, x.Value);
                });
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter
                {
                    ParameterName = "@SearchXml", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Xml, //Data Type of Parameter
                    Value = doc.InnerXml, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                });
                var data = _commonRepository.GetData("Product_Search", parameters);
                return Ok(data);
            }
            return Ok();

        }
        //Location_SelectAll
        [HttpGet]
        [Route("api/service/getAllLocationList")]
        public IActionResult getAllLocationList()
        {
            var data = _commonRepository.GetData("Location_SelectAll", null);
            return Ok(data);
        }
        //ContactUs_Insert
        [HttpPost]
        [Route("api/service/ContactUs")]
        public IActionResult ContactUs([FromBody] ContactUsRequest model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Name", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Name, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Email", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Email, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Phone", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Phone, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@IsRealtor", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.IsRealtor, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Message", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.Message, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("ContactUs_Insert", parameters);
            return Ok(data);
        }
        // ContactUs_SelectAll
        [HttpGet]
        [Route("api/service/ContactUs")]
        public IActionResult ContactUs()
        {
            var data = _commonRepository.GetData("ContactUs_SelectAll", null);
            return Ok(data);
        }
        //ContactUs_Delete
        [HttpPost]
        [Route("api/service/ContactUs_Delete")]
        public IActionResult ContactUs_Delete([FromBody] ContactUsDeleteRequest model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ContactUsId", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = model.ContactUsId, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });


            var data = _commonRepository.GetData("ContactUs_Delete", parameters);
            return Ok(data);
        }
        //ViewURL_SEARCH
        [HttpGet]
        [Route("api/service/ViewURL/{id}")]
        public IActionResult ViewURL(string url)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@Url", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = url, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });


            var data = _commonRepository.GetData("ViewURL_SEARCH", parameters);
            return Ok(data);
        }

        //Category_MappedByProductId
        [HttpPost]
        [Route("api/service/Category_MappedByProductId")]
        public IActionResult Category_MappedByProductId([FromBody] Category_MappedByProductIdRequest model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = model.ProductID, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Category_MappedByProductId", parameters);
            return Ok(data);
        }

        //Product_Select
        [HttpGet]
        [Route("api/service/detail/{id}")]
        public IActionResult Product_Select(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Category_MappedByProductId", parameters);
            return Ok(data);
        }

        //Image_Dump_SelectByMaterId
        [HttpGet]
        [Route("api/service/listByMaterId/{id}")]
        public IActionResult listByMaterId(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@MaterID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Image_Dump_SelectByMaterId", parameters);
            return Ok(data);
        }
        //Feature_MappedByProductId
        [HttpGet]
        [Route("api/service/mappedfeatures/{id}")]
        public IActionResult mappedfeatures(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Feature_MappedByProductId", parameters);
            return Ok(data);
        }
        //ConstructionType_MappedByProductId

        [HttpGet]
        [Route("api/service/mappedConstructionTypes/{id}")]
        public IActionResult mappedConstructionTypes(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("ConstructionType_MappedByProductId", parameters);
            return Ok(data);
        }
        //MarketingCompany_MappedByProductId
        [HttpGet]
        [Route("api/service/mappedMarketingCompanies/{id}")]
        public IActionResult mappedMarketingCompanies(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("MarketingCompany_MappedByProductId", parameters);
            return Ok(data);
        }
        //PropertyType_MappedByProductId
        [HttpGet]
        [Route("api/service/mappedPropertyTypes/{id}")]
        public IActionResult mappedPropertyTypes(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("PropertyType_MappedByProductId", parameters);
            return Ok(data);
        }
        //Bedroom_MappedByProductId
        [HttpGet]
        [Route("api/service/mappedBedrooms/{id}")]
        public IActionResult mappedBedrooms(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Bedroom_MappedByProductId", parameters);
            return Ok(data);
        }
        //Developer_MappedByProductId
        [HttpGet]
        [Route("api/service/mappedDevelopers/{id}")]
        public IActionResult mappedDevelopers(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Developer_MappedByProductId", parameters);
            return Ok(data);
        }
        //Product_RelatedProductList
        [HttpGet]
        [Route("api/service/mappedRelatedProducts/{id}")]
        public IActionResult mappedRelatedProducts(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Product_RelatedProductList", parameters);
            return Ok(data);
        }

        //Cms_Select
        [HttpGet]
        [Route("api/service/cmsDetail/{id}")]
        public IActionResult cmsDetail(int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "@cmsId", //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = id, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            });

            var data = _commonRepository.GetData("Cms_Select", parameters);
            return Ok(data);
        }
        //featureList
        [HttpGet]
        [Route("api/service/featureList")]
        public IActionResult featureList()
        {
            var data = _commonRepository.GetData("Feature_SelectAll", null);
            return Ok(data);
        }
        //Developer_SelectAll
        [HttpGet]
        [Route("api/service/developerList")]
        public IActionResult developerList()
        {
            var data = _commonRepository.GetData("Developer_SelectAll", null);
            return Ok(data);
        }
        //MarketingCompany_SelectAll

        [HttpGet]
        [Route("api/service/marketingcompanyList")]
        public IActionResult marketingcompanyList()
        {
            var data = _commonRepository.GetData("MarketingCompany_SelectAll", null);
            return Ok(data);
        }
        //PropertyType_SelectAll

        [HttpGet]
        [Route("api/service/propertytypeList")]
        public IActionResult propertytypeList()
        {
            var data = _commonRepository.GetData("PropertyType_SelectAll", null);
            return Ok(data);
        }

        //ConstructionType_SelectAll
        [HttpGet]
        [Route("api/service/constructiontypeList")]
        public IActionResult constructiontypeList()
        {
            var data = _commonRepository.GetData("ConstructionType_SelectAll", null);
            return Ok(data);
        }

        //Banner_SelectAll
        [HttpGet]
        [Route("api/service/bannerList")]
        public IActionResult bannerList()
        {
            var data = _commonRepository.GetData("Banner_SelectAll", null);
            return Ok(data);
        }

        //NearBy_SelectAll
        [HttpGet]
        [Route("api/service/nearBylist")]
        public IActionResult nearBylist()
        {
            var data = _commonRepository.GetData("NearBy_SelectAll", null);
            return Ok(data);
        }
        //Testimonial_SelectAll
        [HttpGet]
        [Route("api/service/testimonialList")]
        public IActionResult testimonialList()
        {
            var data = _commonRepository.GetData("Testimonial_SelectAll", null);
            return Ok(data);
        }




        [HttpPost]
        [Route("api/service/TypedProductList2")]
        public IActionResult TypedProductList2([FromBody] TypedProductListRequest model)
        {
            string ConnectionString = @"data source=DESKTOP-VF6GA3A; database=Presale; User ID=sa;Password=123456;Trusted_Connection=True;MultipleActiveResultSets=True;";
            List<Dictionary<string, object>> returnObjects = new List<Dictionary<string, object>>();
            DataTable dt = new DataTable();
            //Create the SqlConnection object
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "Product_TypedProductList", //Specify the Stored procedure name
                    Connection = connection, //Specify the connection object where the stored procedure is going to execute
                    CommandType = CommandType.StoredProcedure //Specify the command type as Stored Procedure
                };
                //Create an instance of SqlParameter
                SqlParameter param1 = new SqlParameter
                {
                    ParameterName = "@IsFeaturedProduct", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                    Value = model.IsFeaturedProduct, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };


                SqlParameter param2 = new SqlParameter
                {
                    ParameterName = "@IsShowOnHomePage", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                    Value = model.IsShowOnHomePage, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };



                SqlParameter param3 = new SqlParameter
                {
                    ParameterName = "@IsArrival", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                    Value = model.IsArrival, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                SqlParameter param4 = new SqlParameter
                {
                    ParameterName = "@IsUpComing", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                    Value = model.IsUpComing, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                //Add the parameter to the Parameters property of SqlCommand object
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var list = new List<Dictionary<string, object>>();
                foreach (DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        dict[col.ColumnName] = (Convert.ToString(row[col]));
                    }
                    list.Add(dict);
                }
                var dd = JsonConvert.SerializeObject(list);
                return Ok(dd);
            }
        }
    }
}
