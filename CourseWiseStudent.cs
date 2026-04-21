using PracticeMVC_DB_Identitty.Models;

namespace PracticeMVC_DB_Identitty.ViewModels
{
    public class CourseWiseStudent
    {
        public Courses creDetails { get; set; }
        public List<Student> stuDetails { get; set;}
    }
}
