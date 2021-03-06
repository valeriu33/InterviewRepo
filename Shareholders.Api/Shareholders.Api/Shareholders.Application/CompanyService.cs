using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shareholders.Domain;

namespace Shareholders.Application
{
    public class CompanyService
    {
        private readonly IShareholdersContext context;

        public CompanyService(IShareholdersContext context)
        {
            this.context = context;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return context.Companies
                .Include(c => c.ShareholderCompany)
                .ThenInclude(sc => sc.Shareholder);
        }
        
        public Company GetCompanyById(int id)
        {
            return context.Companies
                .Include(c => c.ShareholderCompany)
                .ThenInclude(sc => sc.Shareholder)
                .Single(c => c.Id == id);
        } 
    }
}