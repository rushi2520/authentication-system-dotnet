using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.Models
{
    public class Student
    {
        [Key]
        public int stu_Id { get; set; }

        [Required]
        public string stu_Name { get; set; }

        [Required]
        public string stu_mail { get; set; }

        public string stu_Contact { get; set; }

        public DateOnly age { get; set; }

        // 🔗 Relationship
        public int? CourseId { get; set; }
        public Courses Course { get; set; }

        // 🔗 One Student → Many Fees
        public List<Fees> Fees { get; set; }
    }
}

