using STOlizza.Leto.Shared;

namespace STOlizza.Leto.Client.Shared
{
    public interface IQuestionnaireService
    {

        QuestionnaireDTO Get();

        public void SetSmena(int sm);

        public void SetPart1(QuestionnairePart1 qp1);
        public void SetPart2(QuestionnairePart2 qp2);
        public void SetVideo(List<byte> vid);
    }
    public class QuestionnaireService : IQuestionnaireService
    {
        public QuestionnaireDTO QDTO { get; set; } = new();
        public QuestionnaireDTO Get() => QDTO;

        public void SetSmena(int sm)
        {
            QDTO.Smena = sm;
        }
        public void SetPart1(QuestionnairePart1 qp1)
        {
            QDTO.QImage = qp1.QImage;
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
        public void SetPart2(QuestionnairePart2 qp2)
        {
            QDTO.Allergies = qp2.Allergies;
            QDTO.Illneses = qp2.Illneses;
            QDTO.KnowledgeSource = qp2.KnowledgeSource;
            QDTO.DesiredSkills = qp2.DesiredSkills;
            QDTO.ExpirienceIntentions = qp2.ExpirienceIntentions;
        }
        public void SetVideo(List<byte> vid)
        {
            QDTO.QVideo = vid;
        }
    }
}
