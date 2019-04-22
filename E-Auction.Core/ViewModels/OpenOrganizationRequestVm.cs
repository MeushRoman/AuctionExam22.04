using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.ViewModels
{
    public class OpenOrganizationRequestVm
    {
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string OrganizationType { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkToSite { get; set; }
    }
}
