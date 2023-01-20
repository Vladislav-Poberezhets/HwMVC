namespace HwMVC.Products
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MVCProducts;Trusted_Connection=True;");
        }

    }
}
