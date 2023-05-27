using System.ComponentModel.DataAnnotations;

namespace STOlizza.Leto.Shared
{
    public class QuestionnaireDTO
    {
        [Required]
        public int Smena { get; set; }

        
        [Required]
        public byte[] QImage { get; set; } = new byte[25000000];


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Father Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string? FatherName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [Required]
        public bool IsMale { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string WorkingPlace { get; set; }


        public string? Post { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }


        [DataType(DataType.Url)]
        [RegularExpression("(http:\\/\\/|https:\\/\\/)?(www.)?(vk\\.com|vkontakte\\.ru)\\/(id(\\d{9})|[a-zA-Z0-9_.]+)")]
        public string? VkLink { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("\\B@(?=\\w{5,64}\\b)[a-zA-Z0-9]+(?:_[a-zA-Z0-9]+)*")]
        public string TelegramUsername { get; set; }


        public string? ClothesSize { get; set; }


        public string? Allergies { get; set; }


        public string? Illneses { get; set; }


        [Required]
        public string KnowledgeSource { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(300, MinimumLength = 20,
        ErrorMessage = "Desired skills should be minimum 20 characters and a maximum of 300 characters")]
        [DataType(DataType.Text)]
        public string DesiredSkills { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(300, MinimumLength = 20,
        ErrorMessage = "Expirience Intentions should be minimum 20 characters and a maximum of 300 characters")]
        [DataType(DataType.Text)]
        public string ExpirienceIntentions { get; set; }


        [Required]
        public byte[] QVideo { get; set; } = new byte[100000000];

    }
}
