using System.Collections.Generic;

namespace Shareholders.Domain
{
    public class Shareholder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShareholderCompany> ShareholderCompany { get; set; } = new List<ShareholderCompany>();
    }
}