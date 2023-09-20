using System.ComponentModel.DataAnnotations;

namespace UserMgmt.Model
{
    public class UsersInfo
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Location { get; set; }
        public byte[]? UserImage  { get; set; }
        public DateTime? DateHired { get; set; }

        public ICollection<UserSalary> UserSalary { get; set; }
    
    }
}
