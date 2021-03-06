using System.Linq;
using Coir_ERP.EntityFramework;
using Coir_ERP.MultiTenancy;

namespace Coir_ERP.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly Coir_ERPDbContext _context;

        public DefaultTenantCreator(Coir_ERPDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
