using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Coir_ERP.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace Coir_ERP.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Coir_ERP.EntityFramework.Coir_ERPDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Coir_ERP";
        }

        protected override void Seed(Coir_ERP.EntityFramework.Coir_ERPDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
