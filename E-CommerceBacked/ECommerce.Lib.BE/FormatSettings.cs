using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Lib.BE
{
    public class FormatSettings:BaseBE
    {
        public bool Localize { get; set; }

        public NumberSettings? Number { get; set; }
    }
}
