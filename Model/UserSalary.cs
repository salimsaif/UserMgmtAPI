using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgmt.Model
{
    public class UserSalary
    {
        public int Id { get; set; }

        [Required]
        public string userId { get; set; }
        
        public decimal? Salary { get; set; }
        [Required]
        public string PAN { get; set; }
        [Required]
        public string? AccountNumber { get; set; }
        public  bool? HasMediclaim { get; set; }
      
        public int? MediclaimTypeId { get; set; }

        public  MediclaimType MediclaimTypes { get; set; }
        
        public UsersInfo UsersInfos { get; set; }
    }
}
