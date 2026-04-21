using PracticeMVC_DB_Identitty.Models;
using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.Models
{
    public class Courses
    {
        [Key]
        public int Cour_Id { get; set; }

        public string Cour_Name { get; set; }

        public string Cour_Desc { get; set; }

        public string Cour_Cont { get; set; }

        public double Cour_price { get; set; }

        // 🔗 One Course → Many Students
        public List<Student> Students { get; set; }
    }
}
