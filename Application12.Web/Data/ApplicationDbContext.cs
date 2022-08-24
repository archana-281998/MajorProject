
using Application12.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Application12.Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OnlinePayment> OnlinePayments { get; set; }
        public DbSet<CashOnDelivery> CashOnDeliveries { get; set; }

        public DbSet<Product> Products { get; set; }    

        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
    }
}
