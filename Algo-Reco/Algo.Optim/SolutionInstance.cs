using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Optim
{
    public abstract class SolutionInstance
    {
        readonly SolutionSpace _space;
        readonly IReadOnlyList<int> _coordinates;
        readonly IReadOnlyList<SolutionInstance> _neighbors;
        double _cost;

        protected SolutionInstance(SolutionSpace space, IReadOnlyList<int> coordinates )
        {
            _space = space;
            _coordinates = coordinates;
            _cost = -1.0;
            _neighbors = CreateNeighbors();
        }
        public SolutionSpace Space => _space;
        public IReadOnlyList<int> Coordinates => _coordinates;
        public IReadOnlyList<SolutionInstance> Neighbors => _neighbors;
        public double Cost
        {
            get
            {
                if( _cost < 0.0 ) _cost = ComputeCost();
                return _cost;
            }
        }
        protected abstract double ComputeCost();
        protected abstract IReadOnlyList<SolutionInstance> CreateNeighbors();
        public SolutionInstance GetBestNeighbors()
        {
            SolutionInstance best = Neighbors.OrderBy( c => c.Cost ).First();
            if( best.Cost < Cost )
               return best.GetBestNeighbors();
            return this;
        }
    }
}
