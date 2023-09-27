using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgmt.Model
{
    public class UsersInfoUpdate
    {
        public int Id { get; set; }
        [Required]
       //public string UserName { get; set; }
      
        public string FirstName { get; set; }
       
        public string? LastName { get; set; }
        public string? Location { get; set; }
        //public byte[]? UserImage { get; set; }
        //public DateTime? DateHired { get; set; }
        public decimal? salary { get; set; }


        //public virtual ICollection<UserSalary> UserSalarys { get; set; }

    }
}
