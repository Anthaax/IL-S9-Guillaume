using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Optim
{
    public class Guest
    {
        public Guest( Meeting meeting, string name, Airport location, bool noStop = false )
        {
            Meeting = meeting;
            Name = name;
            Location = location;
            NoStop = noStop;
            ArrivalFlight = Meeting.FlightDatabase.GetFlights( Meeting.MaxBusTimeOnArrival, Location, Meeting.Location )
                                                  .Concat( Meeting.FlightDatabase.GetFlights( Meeting.MaxBusTimeOnArrival.AddDays( -1 ), Location, Meeting.Location ) )
                                                  .Where( c => c.ArrivalTime <= Meeting.MaxBusTimeOnArrival )
                                                  .Where( c => c.Stops == 0 || !NoStop )
                                                  .OrderBy( c => c.ArrivalTime )
                                                  .ToArray();
            DepartureFlight = Meeting.FlightDatabase.GetFlights( Meeting.MinBusTimeOnDeparture, Meeting.Location, Location )
                                                  .Concat( Meeting.FlightDatabase.GetFlights( Meeting.MinBusTimeOnDeparture.AddDays( 1 ), Location, Meeting.Location ) )
                                                  .Where( c => c.DepartureTime >= Meeting.MinBusTimeOnDeparture )
                                                  .Where( c => c.Stops == 0 || !NoStop )
                                                  .OrderBy( c => c.DepartureTime )
                                                  .ToArray();
        }
        public string Name { get; }

        public Airport Location { get; }

        public Meeting Meeting { get; }

        public bool NoStop { get; }

        public IReadOnlyList<SimpleFlight> ArrivalFlight { get; }

        public IReadOnlyList<SimpleFlight> DepartureFlight { get; }
        public bool isVIP { get; internal set; }
    }
}
