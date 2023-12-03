using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models
{
    public class DetailsModel
    {
        public int Age { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }    
        public string Message { get; set; }
    }
}
