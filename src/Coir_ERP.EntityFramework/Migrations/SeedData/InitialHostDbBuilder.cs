using Coir_ERP.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Coir_ERP.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly Coir_ERPDbContext _context;

        public InitialHostDbBuilder(Coir_ERPDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
