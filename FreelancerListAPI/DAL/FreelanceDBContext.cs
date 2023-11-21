using FreelancerListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancerListAPI.DAL
{
    public class FreelanceDBContext : DbContext
    {
        public FreelanceDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserFreelance> UsersFreelances { get; set; }
        
        public DbSet<UsersSkills> UsersSkills { get; set; }

        public DbSet<ConfigSkill> ConfigSkill { get; set; }
        

    }
}
