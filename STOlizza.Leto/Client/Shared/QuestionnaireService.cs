using STOlizza.Leto.Shared;
using System.Net.Http.Json;

namespace STOlizza.Leto.Client.Shared
{
    public interface IQuestionnaireService
    {

        QuestionnairyDTO Get();
        public int GetStep();

        public void SetSmena(int sm);

        public void SetPart1(QuestionnairePart1 qp1, bool isCompleted);
        public void SetPart2(QuestionnairePart2 qp2, bool isCompleted);
        public void SetVideo(string link);
        public bool isPhotoUploaded();
        public Task<bool> SendQuestionnarry();
        public Task<bool> SendQuestionnarry(QuestionnairyDTO qdto);
    }
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly HttpClient _http;
        public QuestionnairyDTO QDTO { get; set; } = new();
        public QuestionnairyDTO Get() => QDTO;
        public int GetStep() => currentStep;
        public int currentStep = 0;
        public bool isPhotoUploaded() => QDTO.QImage is not null;

        public QuestionnaireService(HttpClient ht)
        {
            _http = ht;
        }

        public void SetSmena(int sm)
        {
            QDTO.Smena = sm;
            currentStep = 1;
        }
        public void SetPart1(QuestionnairePart1 qp1, bool isCompleted = false)
        {
            if (isCompleted) 
            { 
                currentStep = 2;
            }

            QDTO.QImage = qp1.QImage.ToArray();
            QDTO.FirstName = qp1.FirstName;
            QDTO.LastName = qp1.LastName;
            QDTO.FatherName = qp1.FatherName;
            QDTO.Sex = qp1.Sex;
            QDTO.BirthDate = qp1.BirthDate;
            QDTO.WorkingPlace = qp1.WorkingPlace;
            QDTO.Post = qp1.Post;
            QDTO.PhoneNumber = qp1.PhoneNumber;
            QDTO.VkLink = qp1.VkLink;
            QDTO.TelegramUsername = qp1.TelegramUsername;
            QDTO.ClothesSize = qp1.ClothesSize;

        }
        public void SetPart2(QuestionnairePart2 qp2, bool isCompleted)
        {
            if (isCompleted)
            {
                currentStep = 3;
            }

            QDTO.Allergies = qp2.Allergies;
            QDTO.Illneses = qp2.Illneses;
            QDTO.KnowledgeSource = qp2.KnowledgeSource;
            QDTO.DesiredSkills = qp2.DesiredSkills;
            QDTO.ExpirienceIntentions = qp2.ExpirienceIntentions;
        }
        public void SetVideo(string link)
        {
            QDTO.VideoPath = link;
        }

        public async Task<bool> SendQuestionnarry()
        {
            var result = await _http.PostAsJsonAsync("api/QuestionnairyDTOes", QDTO);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> SendQuestionnarry(QuestionnairyDTO qdto)
        {
            var result = await _http.PostAsJsonAsync("api/QuestionnairyDTOes", qdto);
            return result.IsSuccessStatusCode;
        }
    }
}
