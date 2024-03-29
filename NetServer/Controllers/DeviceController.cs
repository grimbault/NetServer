﻿using NetServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace NetServer.Controllers
{
    public class DeviceController : ApiController
    {
        // GET api/<controller>
        public HttpError Get()
        {
            return new HttpError("401");
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(string metric, int size)
        {
            string device = Request.GetQueryNameValuePairs().Where(x => x.Key == "device").FirstOrDefault().Value;
            ResultAdapter resultAdapter = new ResultAdapter();
            resultAdapter.device = device;
            resultAdapter.generateTable(metric, size);

            var json = JsonConvert.SerializeObject(resultAdapter);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        public HttpResponseMessage Get(string metric, int size, int frequence)
        {
            string device = Request.GetQueryNameValuePairs().Where(x => x.Key == "device").FirstOrDefault().Value;
            ResultAdapter resultAdapter = new ResultAdapter();
            resultAdapter.device = device;
            resultAdapter.generateTable(metric, size, frequence);

            var json = JsonConvert.SerializeObject(resultAdapter);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}