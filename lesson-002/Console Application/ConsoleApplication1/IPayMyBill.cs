using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    public interface IPayMyBill
    {
        Decimal AmountDue { get; }
        void Pay();
    }
}
