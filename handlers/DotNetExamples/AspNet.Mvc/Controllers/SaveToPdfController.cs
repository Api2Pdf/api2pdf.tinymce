using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Api2PdfLibrary;
using Newtonsoft.Json;


namespace AspNet.Mvc.Controllers
{
    public class SaveToPdfController : Controller
    {
        [HttpPost]
        public ActionResult Handle(PdfModel model)
        {
            //Use NUGET
            //install-package api2pdf

            var a2pClient = new Api2Pdf("YOURAPIKEY");

            var pdfUrl = a2pClient.WkHtmlToPdf.FromHtml(model.Content).Pdf;

            var result = new
            {
                pdfUrl = pdfUrl
            };
           
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        public class PdfModel
        {
            public string Content { get; set; }
        }
    }
}