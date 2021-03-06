using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using Coir_ERP.Authorization.Roles;
using Coir_ERP.Authorization.Users;
using Coir_ERP.MultiTenancy;
using Coir_ERP.Vehicles;
using Coir_ERP.VehicleTypes;

namespace Coir_ERP.EntityFramework
{
    public class Coir_ERPDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public Coir_ERPDbContext()
            : base("Default")
        {
            
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in Coir_ERPDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of Coir_ERPDbContext since ABP automatically handles it.
         */
        public Coir_ERPDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        
        //This constructor is used in tests
        public Coir_ERPDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public Coir_ERPDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }

       

    }
}
