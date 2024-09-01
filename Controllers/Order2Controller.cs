using ApiMasterDetailsWithAuthentication.Models;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiMasterDetailsWithAuthentication.Controllers
{
    public class Order2Controller : ApiController
    {
        private MyDbContext _mb = new MyDbContext();
        [HttpGet]
        public IHttpActionResult GetOrder()
        {
            var data = _mb.OrderMasters.ToList();
            var jsonset = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            var serial = JsonConvert.SerializeObject(data, Formatting.None, jsonset);
            var jsonObj = JsonConvert.DeserializeObject(serial);
            return Ok(jsonObj);

        }
        [HttpGet]
        public IHttpActionResult GetOrder2(int id)
        {
            var data = _mb.OrderMasters.FirstOrDefault(o => o.OrderId == id);
            var jsonset = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            var serial = JsonConvert.SerializeObject(data, Formatting.None, jsonset);
            var jsonObj = JsonConvert.DeserializeObject(serial);
            return Ok(jsonObj);

        }
        [HttpPost]

        public IHttpActionResult PostOrder()
        {
            var customerName = HttpContext.Current.Request.Form["CustomerName"];
            var order = new OrderMaster()
            {
                CustomerName = customerName,
            };

            var imageFile = HttpContext.Current.Request.Files["ImageFile"];
            if (imageFile != null)
            {
                var filename = Guid.NewGuid().ToString() + Path.GetFileName(imageFile.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),filename );
                order.ImagePath = path;
            }

            string orderdetailjson = HttpContext.Current.Request.Form["OrderDetail"];
            if (string.IsNullOrEmpty(orderdetailjson))
            {
                List<OrderDetail> orderdeatilList  =JsonConvert.DeserializeObject<List<OrderDetail>>(orderdetailjson);
                order.OrderDetail.AddRange(orderdeatilList);
            }
            _mb.OrderMasters.Add(order);
            _mb.SaveChanges();  
            return Ok();
        }

        [HttpPut]

        public IHttpActionResult PutOrder(int id)
        {
            var order = _mb.OrderMasters.Include(o => o.OrderDetail).FirstOrDefault(o => o.OrderId == id);

            order.CustomerName = HttpContext.Current.Request.Form["CustomerName"];
            var imageFile = HttpContext.Current.Request.Files["ImageFile"];
            if (imageFile != null)
            {
                var filename = Guid.NewGuid().ToString() + Path.GetFileName(imageFile.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), filename);
                order.ImagePath = path;

                string orderDetailJson = HttpContext.Current.Request.Form["OrderDetail"];
                if (!string.IsNullOrEmpty(orderDetailJson))
                {
                    List<OrderDetail> orderDetailList = JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetailJson);

                    foreach (var deatail in order.OrderDetail.ToList())
                    {

                    }
                    order.OrderDetail.AddRange(orderDetailList);
                }
            }
            _mb.Entry(order).State = EntityState.Modified;
            _mb.SaveChanges();
            return Ok();
        }

    }
}
