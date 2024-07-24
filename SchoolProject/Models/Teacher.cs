using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string TeacherName { get; set; }
        [Range(20, 50)]
        public int TeacherAge { get; set; }

    }
}
