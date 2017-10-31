using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MtB.Repository.Entities;

namespace MtB.Repository.Providers
{
    public class FriendsProvider : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<CommunicationCapability> CommunicationCapabilities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //optionsBuilder.UseSqlServer(configuration["Configuration:BuddiesProvider"]);
            optionsBuilder.UseSqlite(configuration["Configuration:BuddiesProviderSqlite"]);
        }
    }
}