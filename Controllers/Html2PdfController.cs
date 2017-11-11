using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using convertizzle.Models;
using DinkToPdf;
using Microsoft.AspNetCore.Mvc;

namespace DockerHello.Controllers
{
    /// <summary>
    /// Controller for html2pdf related methods
    /// </summary>
    [Route("api/html2pdf")]
    public class Html2PdfController : Controller
    {
        
        /// <summary>
        /// Returns a sample pdf document
        /// </summary>
        /// <returns>A sample pdf document</returns>
        [HttpGet("test")]
        public IActionResult TestConvert()
        {
            var converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur mauris eget ultrices  iaculis. Ut                               odio viverra, molestie lectus nec, venenatis turpis.",
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            byte[] pdf = converter.Convert(doc);
            
            var response = File(pdf, "application/octet-stream", "File.pdf"); // FileStreamResult
       
            return response;
        }

        /// <summary>
        /// Returns a sample pdf document
        /// </summary>
        /// <params name="url">Url</params>
        /// <returns>A sample pdf document</returns>
        [HttpGet("url")]
        public IActionResult ConvertFromUrl([FromQuery]string url, [FromBody]ConvertOptions options)
        {
            var webClient = new System.Net.WebClient();
            var downloadedHtml = webClient.DownloadString(url);

            var converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = downloadedHtml,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            byte[] pdf = converter.Convert(doc);
            
            var response = File(pdf, "application/octet-stream", "File.pdf"); // FileStreamResult
       
            return response;
        }

    }
}
