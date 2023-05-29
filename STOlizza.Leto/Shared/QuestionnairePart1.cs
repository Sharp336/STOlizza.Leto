using System.ComponentModel.DataAnnotations;

namespace STOlizza.Leto.Shared
{
    public class QuestionnairePart1
    {
        public List<byte> QImage { get; set; } = new ();


        [Required(ErrorMessage = "Необходимо указать имя")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Имя должно быть больше 1 символа и не больше 50")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Необходимо указать фамилию")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Фамилия должна быть больше 1 символа и не больше 50")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Необходимо указать отчество")]
        [StringLength(50, MinimumLength = 4,
        ErrorMessage = "Отчество должно быть больше 3 символов и не больше 50")]
        [DataType(DataType.Text)]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Необходимо указать дату рождения")]
        [DataType(DataType.DateTime)]
        [DateValidation]
        public DateTime? BirthDate { get; set; } = null;

        
        public string Sex { get; set; }


        [Required(ErrorMessage = "Необходимо указать место работы/учёбы")]
        [DataType(DataType.Text)]
        public string WorkingPlace { get; set; }

        [Required(ErrorMessage = "Необходимо указать должность")]
        [StringLength(20, MinimumLength = 4,
        ErrorMessage = "Должность должна быть больше 3 символов и не больше 20")]
        [DataType(DataType.Text)]
        public string? Post { get; set; }

        [Required(ErrorMessage = "Необходимо указать номер")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$", ErrorMessage = "Проверьте правильность введённого номера")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Необходимо указать ссылку на профиль")]
        [DataType(DataType.Url)]
        [RegularExpression("(http:\\/\\/|https:\\/\\/)?(www.)?(vk\\.com|vkontakte\\.ru)\\/(id(\\d{9})|[a-zA-Z0-9_.]+)", ErrorMessage = "Проверьте правильность введённой ссылки")]
        public string? VkLink { get; set; }


        [Required(ErrorMessage = "Необходимо указать телеграм-никнейм")]
        [DataType(DataType.Text)]
        [RegularExpression("\\B@(?=\\w{5,64}\\b)[a-zA-Z0-9]+(?:_[a-zA-Z0-9]+)*", ErrorMessage = "Проверьте правильность введённого никнейма")]
        public string TelegramUsername { get; set; }


        public string? ClothesSize { get; set; }


    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if ((DateTime?)value > DateTime.Today.AddYears(-36) && (DateTime?)value < DateTime.Today.AddYears(-18).AddDays(1))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Для участия вам должно быть от 18 до 35 лет включительно");
        }
    }
}

