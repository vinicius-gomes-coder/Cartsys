using Microsoft.EntityFrameworkCore;

namespace CartSysAPI.Model.Context
{
    public class CartsysContext : DbContext
    {        

        public CartsysContext(DbContextOptions<CartsysContext> options) : base(options)
        {

        }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cartsys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        public DbSet<PersonModel> Persons { get; set; }
    }
}
