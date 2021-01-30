using Microsoft.EntityFrameworkCore;
using Shareholders.Domain;

namespace Shareholders.Application
{
    public interface IShareholdersContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Shareholder> Shareholders { get; set; }

        public DbSet<ShareholderCompany> ShareholderCompanies { get; set; }
    }
}