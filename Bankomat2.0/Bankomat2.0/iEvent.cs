using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat2._0
{
    public interface iEvent
    {
        int Client { get; }
        string Description { get; }
        DateTime Time { get; }
        bool Outcome { get; }
    }
}
