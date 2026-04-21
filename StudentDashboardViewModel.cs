namespace PracticeMVC_DB_Identitty.ViewModels
{
    public class StudentDashboardViewModel
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseContent { get; set; } // Full content
        public decimal TotalPrice { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RemainingBalance => TotalPrice - AmountPaid;

        // To calculate remaining content, we'll split the content string
        public List<string> ContentList { get; set; }
    }
}
