namespace UserMgmt.Model
{
    public class ViewUserInfo
    {
        public int Id { get; set; }         

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? Location { get; set; }
        public byte[]? UserImage { get; set; }
        public DateTime? DateHired { get; set; }

        public decimal? Salary { get; set; }
        public string MType { get; set; }


    }
}
