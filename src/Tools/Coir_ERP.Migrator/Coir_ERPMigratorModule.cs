using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Coir_ERP.EntityFramework;

namespace Coir_ERP.Migrator
{
    [DependsOn(typeof(Coir_ERPDataModule))]
    public class Coir_ERPMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<Coir_ERPDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}