using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgmt.Model
{
    public class UserSalary
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("UsersInfo")]
        public int userId { get; set; }
        
        public decimal? Salary { get; set; }
        [Required]
        public string PAN { get; set; }
        [Required]
        public string? AccountNumber { get; set; }
        public  bool? HasMediclaim { get; set; }

        [ForeignKey("MediclaimType")]
        public int MediclaimTypeId { get; set; }

        public  MediclaimType MediclaimType { get; set; }
       
        public  UsersInfo UsersInfo { get; set; }
    }
}
