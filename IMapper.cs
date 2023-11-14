using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeNeighborhoodGraph
{
    public interface IMapper<S, D>
    {
        D map(S source);
    }
}
