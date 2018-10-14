using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Domain
{
    public class UserMaster : BaseEntity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName
        {
            get
            {
                return string.Concat(this.FirstName, " ", this.LastName).Trim();
            }
        }

        public string EmailId { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }
    }
}
