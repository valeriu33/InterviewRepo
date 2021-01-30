using System.Collections.Generic;
using Shareholders.Domain;

namespace Shareholders.Api.ViewModel
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ShareholderPerCompanyViewModel> Shareholders { get; set; } =
            new List<ShareholderPerCompanyViewModel>();

        public CompanyViewModel(Company company)
        {
            Id = company.Id;
            Name = company.Name;

            foreach (var shareholderCompany in company.ShareholderCompany)
            {
                Shareholders.Add(new ShareholderPerCompanyViewModel
                {
                    Name = shareholderCompany.Shareholder.Name,
                    AmountOfMoney = shareholderCompany.MoneyInvested
                });
            }
        }
    }

    public class ShareholderPerCompanyViewModel
    {
        public string Name { get; set; }

        public decimal AmountOfMoney { get; set; }
    }
}