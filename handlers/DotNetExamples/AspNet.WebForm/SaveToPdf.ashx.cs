using Api2PdfLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.WebForm
{
    /// <summary>
    /// Summary description for SaveToPdf
    /// </summary>
    public class SaveToPdf : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
            {
                var data = sr.ReadToEnd();
                var model = JsonConvert.DeserializeObject<PdfModel>(data);

                context.Response.ContentType = "application/json";

                var a2pClient = new Api2Pdf("YOURAPIKEY");

                var pdfUrl = a2pClient.WkHtmlToPdf.FromHtml(model.Content).Pdf;

                var result = new
                {
                    pdfUrl = pdfUrl
                };

                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        public class PdfModel
        {
            public string Content { get; set; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}