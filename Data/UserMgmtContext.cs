using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserMgmt.Model;

namespace UserMgmt.Data
{
    public class UserMgmtContext : DbContext
    {
        public UserMgmtContext (DbContextOptions<UserMgmtContext> options)
            : base(options)
        {
        }

        public DbSet<UserMgmt.Model.UsersInfo> UsersInfo { get; set; } = default!;

        public DbSet<UserMgmt.Model.UserSalary> UserSalary { get; set; } = default!;

        public DbSet<UserMgmt.Model.MediclaimType> MediclaimType { get; set; } = default!;
    }
}
