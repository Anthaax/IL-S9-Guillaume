using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Optim
{
    public class MeetingInstance : SolutionInstance
    {
        public MeetingInstance(Meeting m, IReadOnlyList<int> coordinates )
            :base( m, coordinates)
        {
        }
        public new Meeting Space => (Meeting)base.Space;
        protected override double ComputeCost()
        {
            List<KeyValuePair<Guest, SimpleFlight>> flights = new List<KeyValuePair<Guest, SimpleFlight>>();
            for( int i = 0; i < Space.Guests.Count; i++ )
            {
                flights.Add(new KeyValuePair<Guest, SimpleFlight>( Space.Guests[i], Space.Guests[i].ArrivalFlight[Coordinates[i]]));
                flights.Add(new KeyValuePair<Guest, SimpleFlight>( Space.Guests[i], Space.Guests[i].DepartureFlight[Coordinates[i + Space.Guests.Count]]));
            }
            DateTime lastFlightArrival = flights.Where( c => c.Value.Destination == Space.Location ).Max( c => c.Value.ArrivalTime );
            DateTime firstFligthDeparture = flights.Where( c => c.Value.Origin == Space.Location ).Max( c => c.Value.DepartureTime );
            double totalCost = flights.Sum( c => c.Value.Price );
            totalCost += flights.Where(c => c.Value.Destination == Space.Location)
                                .Select(c => (c.Value.ArrivalTime - lastFlightArrival).Minutes * (c.Key.isVIP ? 4 :2))
                                .Sum(c => c);
            totalCost += flights.Where( c => c.Value.Origin == Space.Location )
                                .Select( c => (c.Value.DepartureTime - firstFligthDeparture).Minutes * (c.Key.isVIP ? 4 : 2) )
                                .Sum( c => c);
            return totalCost;
        }

        protected override IReadOnlyList<SolutionInstance> CreateNeighbors()
        {
            List<MeetingInstance> neighbors = new List<MeetingInstance>();
            for( int i = 0; i < Space.Guests.Count; i++ )
            {
                if( Coordinates[i] < Space.Guests[i].ArrivalFlight.Count )
                {
                    int[] next = Coordinates.ToArray();
                    next[i] = Coordinates[i] + 1;
                    neighbors.Add( new MeetingInstance( Space, next ) );
                }
                if(Coordinates[i] > 0 )
                {
                    int[] next = Coordinates.ToArray();
                    next[i] = Coordinates[i] - 1;
                    neighbors.Add( new MeetingInstance( Space, next ) );
                }
                if( Coordinates[i + Space.Guests.Count] < Space.Guests[i].DepartureFlight.Count )
                {
                    int[] next = Coordinates.ToArray();
                    next[i + Space.Guests.Count] = Coordinates[i + Space.Guests.Count] + 1;
                    neighbors.Add( new MeetingInstance( Space, next ) );
                }
                if( Coordinates[i + Space.Guests.Count] > 0 )
                {
                    int[] next = Coordinates.ToArray();
                    next[i + Space.Guests.Count] = Coordinates[i + Space.Guests.Count] - 1;
                    neighbors.Add( new MeetingInstance( Space, next ) );
                }
            }
            return neighbors;
        }
    }
}
