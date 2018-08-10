using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Api2PdfLibrary;
using Newtonsoft.Json;

namespace AspNet.Core.Mvc.Controllers
{
    public class SaveToPdfController : Controller
    {
        [HttpPost]
        public IActionResult Handle([FromBody]PdfModel model)
        {
            //Use NUGET
            //install-package api2pdf

            var a2pClient = new Api2Pdf("YOURAPIKEY");

            var pdfUrl = a2pClient.WkHtmlToPdf.FromHtml(model.Content).Pdf;

            var result = new 
            {
                pdfUrl = pdfUrl
            };

            //Uncomment and modify if CORS is required
            //this.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return Content(JsonConvert.SerializeObject(result), "application/json");            
        }

        public class PdfModel
        {
            public string Content { get; set; }
        }
    }
}