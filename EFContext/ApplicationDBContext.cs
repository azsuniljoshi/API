using Microsoft.EntityFrameworkCore;

namespace API.EFContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<API.Models.StudentRegistration> StudentRegistrations { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //        modelBuilder.Entity<API.Models.StudentRegistration>(entity =>
        //        {
        //            entity.HasKey(e => e.Id);
        //            entity.Property(e => e.Name).IsRequired();
        //            entity.Property(e => e.Email).IsRequired();
        //            entity.Property(e => e.Course).IsRequired();
        //        });
        //}   
    }
}
