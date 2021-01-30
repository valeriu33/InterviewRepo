namespace Shareholders.Domain
{
    public class ShareholderCompany
    {
        public int ShareholderId { get; set; }
        public Shareholder Shareholder { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public decimal MoneyInvested { get; set; }
    }
}