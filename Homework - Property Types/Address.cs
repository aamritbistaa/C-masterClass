using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Property_Types
{
    public class Address
    {
        public string StreetAddress {private get;  set; }
        public string City {private get; set; }
        public string State {private get; set; }
        public int ZipCode {private get; set; }

        public string FullAddress
        {
            get {
                
                return $"{ZipCode},{StreetAddress},{City},{State}"; }
            
        }

    }
}
