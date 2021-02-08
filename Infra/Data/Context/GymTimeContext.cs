using Domain.Entities;
using Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Data.Context
{
    public class BaseApiContext : DbContext
    {
        public BaseApiContext() : base("name=Default")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserAffiliation> UserAffiliation { get; set; }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PartnerAddress> PartnerAddress { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Rule> Rule { get; set; }
        public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GymTimeContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Mappings
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new CollaboratorMapping());
            modelBuilder.Configurations.Add(new EmployeeMapping());
            modelBuilder.Configurations.Add(new LogMapping());
            modelBuilder.Configurations.Add(new PartnerMapping());
            modelBuilder.Configurations.Add(new PartnerAddressMapping());
            modelBuilder.Configurations.Add(new RuleMapping());
            modelBuilder.Configurations.Add(new UserAffiliationMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
