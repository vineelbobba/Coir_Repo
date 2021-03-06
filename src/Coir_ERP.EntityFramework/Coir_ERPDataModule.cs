using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Coir_ERP.EntityFramework;

namespace Coir_ERP
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(Coir_ERPCoreModule))]
    public class Coir_ERPDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Coir_ERPDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
