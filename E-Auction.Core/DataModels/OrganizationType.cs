using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.DataModels
{
    public class OrganizationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Organization> Organizations { get; set; }
    }
}
