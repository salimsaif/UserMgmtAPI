using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserMgmt.Model
{
    public class MediclaimType
    {
        public int Id { get; set; }

        [Required]
        public string MType { get; set; }
       
        public ICollection<UserSalary> UserSalary { get; set; }

    }
}
