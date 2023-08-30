using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Models
{
    public class AppDbContext :IdentityDbContext

    {
        public AppDbContext()
        {}
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Student>    Student { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Attandance> Attandance { get; set; }
        


    
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //     base.OnConfiguring(optionsBuilder);

        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    var conectionstring = config.GetSection("constr").Value;
        //    optionsBuilder.UseSqlServer(conectionstring); 
        //}
    }
}
