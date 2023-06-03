using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace STOlizza.Leto.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly DatabaseContext _context;

        public ExcelController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult DownloadExcel()
        {
            byte[] reportBytes;
            if (_context.Records == null)
            {
                return NotFound();
            }
            var data = _context.Records.ToList();
            using (var package = ExcelService.CreateReport(data))
            {
                reportBytes = package.GetAsByteArray();
            }
            return File(reportBytes, XlsxContentType, $"Отклики на {DateTime.Now.ToShortDateString}.xlsx");
        }

    }
}
