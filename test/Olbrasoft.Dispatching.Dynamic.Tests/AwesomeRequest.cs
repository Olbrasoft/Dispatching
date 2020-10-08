using Olbrasoft.Dispatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Dispatching.Dynamic
{
    public class AwesomeRequest : Request<AwesomeResponse>
    {
        public AwesomeRequest(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}