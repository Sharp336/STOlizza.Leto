using System.ComponentModel.DataAnnotations;

namespace STOlizza.Leto.Shared
{
    public class SmenaDTO
    {
        [Key]
        public int Id { get; set; }
        public int number { get; set; }
        public string slogan { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string dates { get; set; }
        public string color { get; set; }
        public string availableTill { get; set; }
        public bool isAvailable { get; set; }

        //public SmenaDTO(int _number, string _title, string _description, string _dates, string _colour, bool _isavailable)
        //{
        //    number = _number;
        //    title = _title;
        //    description = _description;
        //    dates = _dates;
        //    color = _colour;
        //    isAvailable = _isavailable;
        //}
    }

    public class IntDto
    {
        public int Id { get; set; }
    }
}