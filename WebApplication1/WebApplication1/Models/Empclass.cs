using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Empclass
    {
        [Key] 
        public int EId { get; set; }
        public string EName { get; set; }
       
        public string EDesignation { get; set; }
        public DateTime EDoj { get; set; }

    }
}
