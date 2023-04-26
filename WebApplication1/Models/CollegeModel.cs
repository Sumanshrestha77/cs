using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CollegeModel
    {
        public int CollegeId { set; get; }
        public string CollegeName { get; set; }
        public string Address { get; set; }
        public string University { get; set; }

        
    }
}
