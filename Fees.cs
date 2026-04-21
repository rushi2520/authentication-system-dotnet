using System.ComponentModel.DataAnnotations;

namespace PracticeMVC_DB_Identitty.Models
{ 
    public class Fees
    {
        [Key]
        public int rec_Id { get; set; }

        // 🔗 Foreign Key
        public int stu_Id { get; set; }
        public Student Student { get; set; }

        public DateOnly f_date { get; set; }

        public int amount { get; set; }
    }
}
