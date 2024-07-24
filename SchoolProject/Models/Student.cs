using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string StudentName { get; set; }
        public bool IsActive { get; set; }
        [Range(10, 50)]
        public int StudentAge { get; set; }
        public string PhotonName { get; set; }



    }
}
