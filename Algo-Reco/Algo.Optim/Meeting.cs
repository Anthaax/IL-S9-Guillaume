using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algo.Optim
{
    public class Meeting : SolutionSpace
    {
        public Meeting(int randomSeed, FlightDatabase fligthData )
            : base(randomSeed)
        {
            FlightDatabase = fligthData;
            Location = Airport.FindByCode( "LHR" );
            MaxBusTimeOnArrival = new DateTime( 2010, 7, 27, 17, 0, 0 );
            MinBusTimeOnDeparture = new DateTime( 2010, 8, 3, 15, 0, 0 );
            Guests = new[] {
                new Guest( this, "Gunther", Airport.FindByCode("BER")),
                new Guest( this, "Jean", Airport.FindByCode("CDG")),
                new Guest(this, "Michel", Airport.FindByCode("MRS")),
                new Guest(this, "Léo", Airport.FindByCode("LYS")),
                new Guest(this, "Mike", Airport.FindByCode("MAN")),
                new Guest(this, "Miguel", Airport.FindByCode("BIO")),
                new Guest(this, "Ham", Airport.FindByCode("JFK")),
                new Guest(this, "Momo", Airport.FindByCode("TUN")),
                new Guest(this, "Michelangelo", Airport.FindByCode("MXP"))
            };
            int[] spaceDimentions = new int[Guests.Count * 2];
            int i = 0;
            foreach( var g in Guests )
            {
                spaceDimentions[i] = g.ArrivalFlight.Count();
                spaceDimentions[i + Guests.Count] = g.DepartureFlight.Count();
                i++;
            }
        }
        public FlightDatabase FlightDatabase { get; }

        public Airport Location { get; }

        public DateTime MaxBusTimeOnArrival { get; }

        public DateTime MinBusTimeOnDeparture { get; }

        public IReadOnlyList<Guest> Guests { get; }

        public override SolutionInstance CreateInstance( IReadOnlyList<int> coordinates )
        {
            return new MeetingInstance( this, coordinates );
        }
    }
}
