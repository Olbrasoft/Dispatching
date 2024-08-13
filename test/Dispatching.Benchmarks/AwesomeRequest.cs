using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatching.Benchmarks;
public class AwesomeRequest : IRequest<string> , Olbrasoft.Dispatching.IRequest<string>
{
}
