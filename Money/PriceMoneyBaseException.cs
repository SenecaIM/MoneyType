using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTypes
{
    public class PriceMoneyBaseExceptionDirectUseNotAllowed : Exception
    {
        public PriceMoneyBaseExceptionDirectUseNotAllowed() : base("Direct Use of class not allowed") { }
    }
}
