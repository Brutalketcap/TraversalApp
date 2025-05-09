using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf" + "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomeReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soydı");
            pdfPTable.AddCell("Misafir Tc");

            pdfPTable.AddCell("Eylül");
            pdfPTable.AddCell("Yücedağ");
            pdfPTable.AddCell("11111111110");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yıldız");
            pdfPTable.AddCell("22222222220");

            pdfPTable.AddCell("Mehmet");
            pdfPTable.AddCell("KaraHanlı");
            pdfPTable.AddCell("33333333330");

            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreports/dosya2.pdf" + "application/pdf", "dosya2.pdf");
        }
    }

}
