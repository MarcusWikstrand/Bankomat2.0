using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat2._0
{
    public interface iEvent
    {
        string Client { get; set; }
        string Description { get; set; }
        DateTime Time { get; set; }
        bool Outcome { get; set; }
    }
}
