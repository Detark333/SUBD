using Microsoft.EntityFrameworkCore;
using SUBD.Model;

namespace SUBD
{
    public class AutoServiceDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AIVAGGI\SQLEXPRESS;Initial Catalog=SUBD5Lab;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Information> Informations { set; get; }
        public virtual DbSet<Auto> Autos { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Contract> Contracts { set; get; }
        public virtual DbSet<SalePeople> SalePeoples { get; set; }
    }
}
