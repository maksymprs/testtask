namespace DataService
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TestDbContext : DbContext
    {
      
        public TestDbContext()
            : base("name=TestDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TestDbContext>());

        }


        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}