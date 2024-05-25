using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookClassLibrary.Models
{
    public class GuestModel
    {
        public string FirstName {private get; set; }
        public string LastName {private get; set; }
        public string MessageToHost {private get; set; }
        public string GuestInfo
        {
            get
            {
                return $"{FirstName} {LastName}: {MessageToHost}";
            }
        }

    }
}
