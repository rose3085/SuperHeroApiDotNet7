namespace SuperHeroApiDotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        //override onc
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = .\\SQLExpress;Database=superherodb;Trusted_Connection=true;TrustedServerCertificate=true;");
        }

        public DbSet<SuperHeroModel> SuperHeroes { get; set; }
    }

}
