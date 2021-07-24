using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using ZXing;
using System.Configuration;
using ZXing.Common;
using System.Drawing;
using System.Drawing.Imaging;

namespace FormularioWeb.Controllers
{
    public class HomeController : Controller
    {
        public string folio = "CodigoQr";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult qr()
        {
            return View();
        }
        [HttpPost]
        public ActionResult qr(string nombreDoc)
        {
            return new ActionAsPdf("qr")
            { FileName = nombreDoc + ".pdf" };
            
        }
        [HttpPost]
        public ActionResult Index(string url)
        {

            string ubicacion = ConfigurationManager.AppSettings["Ubicacion"].ToString();
            var write = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions()
                {
                    Height = 300,
                    Width = 300,
                    Margin = 1,
                },
            };

            Bitmap bitmap = write.Write(url);
            bitmap.Save(String.Format(ubicacion+"{0}.png", folio), ImageFormat.Png);
            return View();
        }
        
    }
}