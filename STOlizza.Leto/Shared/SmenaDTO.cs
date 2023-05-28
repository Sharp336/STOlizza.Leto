using System.ComponentModel.DataAnnotations;

namespace STOlizza.Leto.Shared
{
    public class SmenaDTO
    {
        public int number;
        public string title;
        public string description;
        public string dates;
        public string color;
        public bool isAvailable;

        public SmenaDTO(int _number, string _title, string _description, string _dates, string _colour, bool _isavailable)
        {
            number = _number;
            title = _title;
            description = _description;
            dates = _dates;
            color = _colour;
            isAvailable = _isavailable;
        }
    }
}