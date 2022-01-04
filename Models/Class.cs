using System.ComponentModel.DataAnnotations;

namespace rihal_challenge.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }
        public string? ClassName { get; set; }
        public virtual List<Student>? StudentList { get; set; }
        public Class()
        {

        }
    }
}
