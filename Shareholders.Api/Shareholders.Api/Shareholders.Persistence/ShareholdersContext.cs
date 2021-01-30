using System;
using Microsoft.EntityFrameworkCore;
using Shareholders.Application;
using Shareholders.Domain;

namespace Shareholders.Persistence
{
    public class ShareholdersContext: DbContext, IShareholdersContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Shareholder> Shareholders { get; set; }

        public DbSet<ShareholderCompany> ShareholderCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShareholderCompany>()
                .HasKey(sc => new {sc.CompanyId, sc.ShareholderId});

            builder.Entity<ShareholderCompany>()
                .HasOne<Shareholder>(sc => sc.Shareholder)
                .WithMany(s => s.ShareholderCompany)
                .HasForeignKey(sc => sc.ShareholderId);

            builder.Entity<ShareholderCompany>()
                .HasOne<Company>(sc => sc.Company)
                .WithMany(c => c.ShareholderCompany)
                .HasForeignKey(sc => sc.CompanyId);
        }
    }
}