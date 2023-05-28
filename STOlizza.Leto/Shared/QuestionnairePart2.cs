using System.ComponentModel.DataAnnotations;

namespace STOlizza.Leto.Shared
{
    public class QuestionnairePart2
    {
        

        public string? Allergies { get; set; }


        public string? Illneses { get; set; }


        public string KnowledgeSource { get; set; } = "";


        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [StringLength(300, MinimumLength = 20,
        ErrorMessage = "Минимум 20 символов, максимум - 300")]
        [DataType(DataType.Text)]
        public string DesiredSkills { get; set; }


        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [StringLength(300, MinimumLength = 20,
        ErrorMessage = "Минимум 20 символов, максимум - 300")]
        [DataType(DataType.Text)]
        public string ExpirienceIntentions { get; set; }


    }
}