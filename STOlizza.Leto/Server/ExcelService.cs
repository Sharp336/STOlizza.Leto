using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OfficeOpenXml;
using STOlizza.Leto.Shared;
using System.Configuration;

namespace STOlizza.Leto.Server
{
    public class ExcelService
    {
        public static ExcelPackage CreateReport(List<QuestionnairyDTO> QDTOES)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            package.Workbook.Properties.Title =  $"Отклики на {DateTime.Now.ToShortDateString}";
            package.Workbook.Properties.Author = "Stolizza.Leto";
            package.Workbook.Properties.Subject = "Отклики по форме";

            var worksheet = package.Workbook.Worksheets.Add("Отклики");

            worksheet.Cells[1, 1].Value = "Номер смены";
            worksheet.Cells[1, 2].Value = "ФИО";
            worksheet.Cells[1, 3].Value = "Дата рождения";
            worksheet.Cells[1, 4].Value = "Пол";
            worksheet.Cells[1, 5].Value = "Место работы/учёбы";
            worksheet.Cells[1, 6].Value = "Должность";
            worksheet.Cells[1, 7].Value = "Номер телефона";
            worksheet.Cells[1, 8].Value = "VK";
            worksheet.Cells[1, 9].Value = "Telegram";
            worksheet.Cells[1, 10].Value = "Ссылка на видео";
            worksheet.Cells[1, 11].Value = "Размер одежды";
            worksheet.Cells[1, 12].Value = "Аллергии";
            worksheet.Cells[1, 13].Value = "Заболевания";
            worksheet.Cells[1, 14].Value = "Узнал от";
            worksheet.Cells[1, 15].Value = "Какие навыки хочет получить";
            worksheet.Cells[1, 16].Value = "Как собирается применять опыт";

            for(int i = 0; i < QDTOES.Count;  i++ )
            {
                worksheet.Cells[i + 2, 1].Value = QDTOES[i].Smena;
                worksheet.Cells[i + 2, 2].Value = string.Join(' ', QDTOES[i].LastName, QDTOES[i].FirstName, QDTOES[i].FatherName);
                worksheet.Cells[i + 2, 3].Value = (QDTOES[i].BirthDate ?? DateTime.Today).ToShortDateString();
                worksheet.Cells[i + 2, 4].Value = QDTOES[i].Sex;
                worksheet.Cells[i + 2, 5].Value = QDTOES[i].WorkingPlace;
                worksheet.Cells[i + 2, 6].Value = QDTOES[i].Post;
                worksheet.Cells[i + 2, 7].Value = QDTOES[i].PhoneNumber;
                worksheet.Cells[i + 2, 8].Value = QDTOES[i].VkLink;
                worksheet.Cells[i + 2, 9].Value = QDTOES[i].TelegramUsername;
                worksheet.Cells[i + 2, 10].Value = QDTOES[i].VideoPath;
                worksheet.Cells[i + 2, 11].Value = QDTOES[i].ClothesSize;
                worksheet.Cells[i + 2, 12].Value = QDTOES[i].Allergies;
                worksheet.Cells[i + 2, 13].Value = QDTOES[i].Illneses;
                worksheet.Cells[i + 2, 14].Value = QDTOES[i].KnowledgeSource;
                worksheet.Cells[i + 2, 15].Value = QDTOES[i].DesiredSkills;
                worksheet.Cells[i + 2, 16].Value = QDTOES[i].ExpirienceIntentions;
            }

            var tbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: QDTOES.Count + 1, toColumn: 16), "Отклики");

            tbl.ShowHeader = true;



            return package;
        }
    }
}
