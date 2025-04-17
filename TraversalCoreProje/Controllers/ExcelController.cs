using BusinessLayer.Abstract;
using BussinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using OfficeOpenXml;
using TraversalCoreProje.Models;
namespace TraversalCoreProje.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }

            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet", "YeniExcel.xlsx");
            
            /*
            (ExcelPackage.License.SetLicense(LicenseType.NonCommercial);

            using var excel = new ExcelPackage();

            var workShet = excel.Workbook.Worksheets.Add("Sayfa1");
            workShet.Cells[1, 1].Value = "Rota";
            workShet.Cells[1, 2].Value = "Rehber";
            workShet.Cells[1, 3].Value = "Kontenjan ";

            workShet.Cells[2, 1].Value = "Gürcistan";
            workShet.Cells[2, 2].Value = "Kadir Yıldız";
            workShet.Cells[2, 3].Value = "50";

            workShet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            workShet.Cells[3, 2].Value = "Zeynep Öztürk";
            workShet.Cells[3, 3].Value = "35";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet", "dosya1.xlsx");




            ---------------------------------------------------------------//





            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;



            using var excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Rota";
            workSheet.Cells[1, 2].Value = "Rehber";
            workSheet.Cells[1, 3].Value = "Kontenjan ";

            workSheet.Cells[2, 1].Value = "Gürcistan";
            workSheet.Cells[2, 2].Value = "Kadir Yıldız";
            workSheet.Cells[2, 3].Value = "50";

            workSheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            workSheet.Cells[3, 2].Value = "Zeynep Öztürk";
            workSheet.Cells[3, 3].Value = "35";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet", "dosya1.xlsx");
            */
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Sayfa1");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;

                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }

            }

            return View();

        }

    }
}
