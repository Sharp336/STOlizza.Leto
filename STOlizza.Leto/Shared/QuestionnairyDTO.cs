using System.ComponentModel.DataAnnotations;

namespace STOlizza.Leto.Shared
{
    public class QuestionnairyDTO
    {
        [Key]
        public int Id { get; set; }
        public int Smena { get; set; } = 0;

        public byte[] QImage { get; set; }

        //public string? ImagePath { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string? FatherName { get; set; }

        public DateTime? BirthDate { get; set; } = null;

        public string Sex { get; set; }

        public string WorkingPlace { get; set; }


        public string? Post { get; set; }

        public string PhoneNumber { get; set; }


        public string VkLink { get; set; }

        public string TelegramUsername { get; set; }


        public string? ClothesSize { get; set; }

        public string Passport { get; set; }


        public string? Allergies { get; set; }


        public string? Illneses { get; set; }

        public string KnowledgeSource { get; set; } = "";

        public string DesiredSkills { get; set; }

        public string ExpirienceIntentions { get; set; }

        public string VideoPath { get; set; } = "";


        public static implicit operator QuestionnairePart1(QuestionnairyDTO qdto)
        {
            var result = new QuestionnairePart1();
            result.QImage = qdto.QImage is null ? new List<byte>() : qdto.QImage.ToList();
            result.FirstName = qdto.FirstName;
            result.LastName = qdto.LastName;
            result.FatherName = qdto.FatherName;
            result.BirthDate = qdto.BirthDate;
            //result.IsMale = qdto.IsMale;
            result.Sex = qdto.Sex;
            result.WorkingPlace = qdto.WorkingPlace;
            result.Post = qdto.Post;
            result.PhoneNumber = qdto.PhoneNumber;
            result.VkLink = qdto.VkLink;
            result.TelegramUsername = qdto.TelegramUsername;
            result.ClothesSize = qdto.ClothesSize;
            result.Passport = qdto.Passport;
            return result;
        }

        public static implicit operator QuestionnairePart2(QuestionnairyDTO qdto)
        {
            var result = new QuestionnairePart2();
            result.Allergies = qdto.Allergies;
            result.Illneses = qdto.Illneses;
            result.KnowledgeSource = qdto.KnowledgeSource;
            result.DesiredSkills = qdto.DesiredSkills;
            result.ExpirienceIntentions = qdto.ExpirienceIntentions;
            return result;
        }
    }
}