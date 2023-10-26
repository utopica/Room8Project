using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room8Project.Domain.Common;

namespace Room8Project.Domain.Common
{
    public class BankAccount : EntityBase<Guid>
    {
        public Person? Owner { get; set; }
        public decimal Balance { get; set; }
    }
}
