﻿using STOlizza.Leto.Shared;
using System.Net.Http.Json;
using System.Configuration;

namespace STOlizza.Leto.Client.Shared
{
    public interface ISmenaService
    {
        public List<SmenaDTO> GetLocalSmenas();
        public Task<List<SmenaDTO>> GetSmenas();
    }
    public class SmenaService : ISmenaService
    {
        private readonly HttpClient _http;

        public SmenaService(HttpClient ht)
        {
            _http = ht;
        }

        public async Task<List<SmenaDTO>> GetSmenas()
        {

            var data = await _http.GetAsync(@"api/SmenaDTOes");
            var result = await data.Content.ReadFromJsonAsync<List<SmenaDTO>>();
            return result.OrderBy(sm => sm.number).ToList() ;
        }
        public List<SmenaDTO> GetLocalSmenas()
        {
            var LocalSmenaList = new List<SmenaDTO>(){
                new SmenaDTO(){number = 1, title = "Патриотика", description = "Для тех, кто любит свою Родину.", dates = "20-23 июня", color = "#701487", isAvailable = true},
                new SmenaDTO(){number = 2, title = "Медиа", description = "Научит создавать инфоповоды и развиваться в медиа поле.", dates = "26-29 июня", color = "#701487", isAvailable = true},
                new SmenaDTO(){number = 3, title = "Спорт", description = "Научит побеждать и развивать свою физическую силу.", dates = "1-4 июля", color = "#701487", isAvailable = true},
                new SmenaDTO(){number = 4, title = "Легенды Зарницы", description = "Напомнит об ответственности за себя и своих близких.", dates = "6-9 июля", color = "#FD7D32", isAvailable = true},
                new SmenaDTO(){number = 5, title = "Студенческое самоуправление", description = "Поможет создать команду и развить лидерские качества.", dates = "11-14 июля", color = "#FD7D32", isAvailable = true},
                new SmenaDTO(){number = 6, title = "НКО", description = "Расскажет о деятельности Некоммерческих организаций.", dates = "16-19 июля", color = "#FD7D32", isAvailable = true},
                new SmenaDTO(){number = 7, title = "Карьера", description = "Расскажет о возможностях для молодых соискателей работы.", dates = "21-24 июля", color = "#ABC704", isAvailable = true},
                new SmenaDTO(){number = 8, title = "Волонтерство", description = "Расскажет о культуре добровольчества и волонтерстве.", dates = "26-29 июля", color = "#ABC704", isAvailable = true},
                new SmenaDTO(){number = 9, title = "Служение Отечеству", description = "Для тех, у кого безопасность на первом месте.", dates = "31 июля – 2 августа", color = "#ABC704", isAvailable = true},
                new SmenaDTO(){number = 10, title = "Духовность", description = "Расскажет о традиционных ценностях и важности их сохранения.", dates = "5-8 августа", color = "#01B2E0", isAvailable = true},
                new SmenaDTO(){number = 11, title = "Молодые специалисты", description = "Для молодых и инициативных управленцев.", dates = "10-13 августа", color = "#01B2E0", isAvailable = true},
                };

            return LocalSmenaList;
        }
    }
}