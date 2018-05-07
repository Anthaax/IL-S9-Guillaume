using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Optim
{
    public abstract class SolutionSpace
    {
        readonly Random _random;
        SolutionInstance _bestResult;

        public SolutionSpace(int randomSeed )
        {
            _random = new Random( randomSeed );
        }
        public IReadOnlyList<int> Dimensions { get; private set; }

        public double Cardinality => Dimensions.Aggregate( 1, ( acc, value ) => acc * value );

        public SolutionInstance BestResult => _bestResult;

        public SolutionInstance GetRandomInstance()
        {
            SolutionInstance s = CreateInstance( Dimensions.Select( c => _random.Next( c ) ).ToArray()).GetBestNeighbors();
            if( _bestResult == null || s.Cost < _bestResult.Cost ) _bestResult = s;
            return s;
        }

        public abstract SolutionInstance CreateInstance( IReadOnlyList<int> enumerable );

        protected void Initialize (IReadOnlyList<int> spaceDimention )
        {
            if( spaceDimention == null ) throw new ArgumentNullException();
            Dimensions = spaceDimention;
        }

    }
}
