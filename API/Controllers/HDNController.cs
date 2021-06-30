using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HDNController : ControllerBase
    {
        private IHDNBLL _OrderBusiness;
        public HDNController(IHDNBLL OrderBusiness)
        {
            _OrderBusiness = OrderBusiness;
        }

        [Route("create")]
        [HttpPost]
        public HDN CreateItem([FromBody] HDN model)
        {
            var kq = _OrderBusiness.Create(model);

            return kq;
        }


        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HDN> GetDatabAll()
        {
            return _OrderBusiness.GetDataAll();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public HDN GetDatabyID(string id)
        {
            return _OrderBusiness.GetDatabyID(id);
        }

        [Route("get-chi-tiet-by-hoa-don/{id}")]
        [HttpGet]
        public List<CTHDN> getbyhdn(string id)
        {
            return _OrderBusiness.GetChiTietByhdn(id);
        }
        //public HDN GetCHitietByHoaDon(string id)
        //{
        //    var kq = _OrderBusiness.GetChiTietByhdn(id);
        //    return kq;
        //}
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenNV = "";
                if (formData.Keys.Contains("tenNV") && !string.IsNullOrEmpty(Convert.ToString(formData["tenNV"]))) { tenNV = Convert.ToString(formData["tenNV"]); }

                long total = 0;
                var data = _OrderBusiness.Search(page, pageSize, out total,tenNV);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}

