using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccess.Model
{
    public class FullContactModel
    {
        public BasicContactModel BasicInfo { get; set; }
        public List<EmailAddressModel> EmailAddresses { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}
