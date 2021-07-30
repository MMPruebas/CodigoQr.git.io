using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPDF.Models;
using Rotativa;
using ZXing;
using ZXing.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;

namespace TestPDF.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormularioLLeno()
        {
            var datos = new Home()
            {
                TimeStart = Request.Form["TimeStart"].ToString(),
                TimeFinish = Request.Form["TimeFinish"].ToString(),
                CriticalOb = Request.Form["CriticalOb"].ToString(),
                BuildBy = Request.Form["BuildBy"].ToString(),
                RevisedBy = Request.Form["RevisedBy"].ToString(),
                PrjPo = Request.Form["PrjPo"].ToString(),
                FolioFolder = Request.Form["FolioFolder"].ToString(),
                PartNum = Request.Form["PartNum"].ToString(),
                Qty = Request.Form["Qty"].ToString(),
                Rev = Request.Form["Rev"].ToString(),
                RevUno = Request.Form["RevUno"].ToString(),
                RevDos = Request.Form["RevDos"].ToString(),
                RevTres = Request.Form["RevTres"].ToString(),
                RevCuatro = Request.Form["RevCuatro"].ToString(),
                RevCinco = Request.Form["RevCinco"].ToString(),
                RevSeis = Request.Form["RevSeis"].ToString(),
                RevSiete = Request.Form["RevSiete"].ToString(),
                RevOcho = Request.Form["RevOcho"].ToString(),
                RevNueve = Request.Form["RevNueve"].ToString(),
                RevDiez = Request.Form["RevDiez"].ToString(),
                RevOnce = Request.Form["RevOnce"].ToString(),
                RevDoce = Request.Form["RevDoce"].ToString(),
                RevTrece = Request.Form["RevTrece"].ToString(),
                Code = Request.Form["Code"].ToString(),
                CodeUno = Request.Form["CodeUno"].ToString(),
                Description = Request.Form["Description"].ToString(),
                SerialNum = Request.Form["SerialNum"].ToString(),
                SerialUno = Request.Form["SerialUno"].ToString(),
                SerialDos = Request.Form["SerialDos"].ToString(),
                SerialTres = Request.Form["SerialTres"].ToString(),
                SerialCuatro = Request.Form["SerialCuatro"].ToString(),
                SerialCinco = Request.Form["SerialCinco"].ToString(),
                SerialSeis = Request.Form["SerialSeis"].ToString(),
                SerialSiete = Request.Form["SerialSiete"].ToString(),
                SerialOcho = Request.Form["SerialOcho"].ToString(),
                SerialNueve = Request.Form["SerialNueve"].ToString(),
                SerialDiez = Request.Form["SerialDiez"].ToString(),
                SerialOnce = Request.Form["SerialOnce"].ToString(),
                SerialDoce = Request.Form["SerialDoce"].ToString(),
                SerialTrece = Request.Form["SerialTrece"].ToString(),
                Ewd = Request.Form["Ewd"].ToString(),
                Dsr = Request.Form["Dsr"].ToString(),
                Inside = Request.Form["Inside"].ToString(),
                Plate = Request.Form["Plate"].ToString(),
                IdFrontal = Request.Form["IdFrontal"].ToString(),
                FinalPacking = Request.Form["FinalPacking"].ToString(),
                TurnTest = Request.Form["TurnTest"].ToString(),
                Ground = Request.Form["Ground"].ToString(),
                DatabaseTest = Request.Form["DatabaseTest"].ToString(),
                Was = Request.Form["Was"].ToString(),
                CutEdges = Request.Form["CutEdges"].ToString(),
                AddedFiles = Request.Form["AddedFiles"].ToString(),
                FrontId=Request.Form["FrontId"].ToString(),
                DoorLabels=Request.Form["DoorLabels"].ToString(),
                WireTags=Request.Form["WireTags"].ToString()
            };

            return new ViewAsPdf("FormularioLLeno",datos) { FileName = "DocumentoLleno.pdf" };
        }
        public ActionResult CodigoQr()
        {
            return View();
        }
        public ActionResult Print()
        {
           return new ActionAsPdf("FormularioLLeno") { FileName = "BuenosDias.pdf" };
        }
        [HttpPost]
        public ActionResult CodigoQr(string DatoQr)
        {
            string ubicacion = ConfigurationManager.AppSettings["Ubicacion"].ToString();
            var write = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions()
                {
                    Height=300,
                    Width=300,
                    Margin=1,
                },
            };

            Bitmap bitmap = write.Write(DatoQr);
            bitmap.Save(String.Format(ubicacion+"CodigoQr.png"),ImageFormat.Png);

            return View();
        }
        

        
    }
}