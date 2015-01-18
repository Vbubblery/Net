using System.Data.Entity;

namespace Synchronic_World.Models
{
    public class SynchronicContext : DbContext
    {
        // 您可以向此文件中添加自定义代码。更改不会被覆盖。
        // 
        // 如果您希望只要更改模型架构，Entity Framework
        // 就会自动删除并重新生成数据库，则将以下
        // 代码添加到 Global.asax 文件中的 Application_Start 方法。
        // 注意: 这将在每次更改模型时销毁并重新创建数据库。
        // 
       //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Synchronic_World.Models.PersonContext>());

        public SynchronicContext()
            : base("name=SynchronicContext")
        {

        }

        public DbSet<PersonSystem> PersonSystems { get; set; }
        public DbSet<RoleOfPerson> RoleOfPerson { get; set; }
        public DbSet<EventSystem> EventSystems { get; set; }
        public DbSet<TypeOfEvent> TypeOfEvents { get; set; }
        public DbSet<StatusOfEvent> StatusOfEvents { get; set; }
        public DbSet<ContributionSystem> ContributionSystems { get; set; }
        public DbSet<TypeOfContribution> TypeOfContributions { get; set; }
        public DbSet<FriendSystem> FriendSystems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSystem>().HasRequired<RoleOfPerson>(s => s.RoleOfPerson)
                .WithMany(s => s.Persons).HasForeignKey(s => s.RoleId);
            modelBuilder.Entity<EventSystem>().HasRequired<TypeOfEvent>(s => s.TypeOfEvent)
               .WithMany(s => s.EventSystem).HasForeignKey(s => s.typeId);
            modelBuilder.Entity<EventSystem>().HasRequired<StatusOfEvent>(s => s.StatusOfEvent)
                .WithMany(s => s.EventSystems).HasForeignKey(s => s.StatusId);
            modelBuilder.Entity<FriendSystem>().HasRequired<PersonSystem>(s => s.PersonSystems)
                .WithMany(s => s.FriendSystems).HasForeignKey(s => s.PersonId);
            modelBuilder.Entity<ContributionSystem>().HasRequired<TypeOfContribution>(s => s.TypeOfContributions)
                .WithMany(s => s.ContributionSystems).HasForeignKey(s => s.TypeId);
            modelBuilder.Entity<ContributionSystem>().HasRequired<EventSystem>(s => s.ES)
                .WithMany(s => s.IContributionSystem).HasForeignKey(s => s.EventId);
        }

        
        
    }
}
