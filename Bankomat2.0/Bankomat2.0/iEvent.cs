using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat2._0
{
    public interface iEvent
    {
        string client { get; set; }
        string description { get; set; }
        DateTime datum { get; set; }
        bool outcome { get; set; }
    }
}
