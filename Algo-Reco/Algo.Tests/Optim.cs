using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Algo.Optim;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.IO;

namespace Algo.Tests
{
    [TestFixture]
    public class Optim
    {
        static string GetFlightDataPath( [CallerFilePath]string thisFilePath = null )
        {
            string algoPath = Path.GetDirectoryName( Path.GetDirectoryName( thisFilePath ) );
            return Path.Combine( algoPath, "ThirdParty", "FlightData" );
        }


        [Test]
        public void opening_database_from_ThirdParty_FlightData()
        {
            FlightDatabase db = new FlightDatabase( GetFlightDataPath() );

            {
                var f0 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "BER" ), Airport.FindByCode( "LHR" ) );
                var f1 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "CDG" ), Airport.FindByCode( "LHR" ) );
                var f2 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "MRS" ), Airport.FindByCode( "LHR" ) );
                var f3 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "LYS" ), Airport.FindByCode( "LHR" ) );
                var f4 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "MAN" ), Airport.FindByCode( "LHR" ) );
                var f5 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "BIO" ), Airport.FindByCode( "LHR" ) );
                var f6 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "JFK" ), Airport.FindByCode( "LHR" ) );
                var f7 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "TUN" ), Airport.FindByCode( "LHR" ) );
                var f8 = db.GetFlights( new DateTime( 2010, 7, 26 ), Airport.FindByCode( "MXP" ), Airport.FindByCode( "LHR" ) );
            }
            {
                var f0 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "BER" ), Airport.FindByCode( "LHR" ) );
                var f1 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "CDG" ), Airport.FindByCode( "LHR" ) );
                var f2 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "MRS" ), Airport.FindByCode( "LHR" ) );
                var f3 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "LYS" ), Airport.FindByCode( "LHR" ) );
                var f4 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "MAN" ), Airport.FindByCode( "LHR" ) );
                var f5 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "BIO" ), Airport.FindByCode( "LHR" ) );
                var f6 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "JFK" ), Airport.FindByCode( "LHR" ) );
                var f7 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "TUN" ), Airport.FindByCode( "LHR" ) );
                var f8 = db.GetFlights( new DateTime( 2010, 7, 27 ), Airport.FindByCode( "MXP" ), Airport.FindByCode( "LHR" ) );
            }

            {
                var f0 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "BER" ) );
                var f1 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "CDG" ) );
                var f2 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "MRS" ) );
                var f3 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "LYS" ) );
                var f4 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "MAN" ) );
                var f5 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "BIO" ) );
                var f6 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "JFK" ) );
                var f7 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "TUN" ) );
                var f8 = db.GetFlights( new DateTime( 2010, 8, 3 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "MXP" ) );
            }
            {
                var f0 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "BER" ) );
                var f1 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "CDG" ) );
                var f2 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "MRS" ) );
                var f3 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "LYS" ) );
                var f4 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "MAN" ) );
                var f5 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "BIO" ) );
                var f6 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "JFK" ) );
                var f7 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "TUN" ) );
                var f8 = db.GetFlights( new DateTime( 2010, 8, 4 ), Airport.FindByCode( "LHR" ), Airport.FindByCode( "MXP" ) );
            }


        }

        [Test]
        public void dump_guest_flight_count()
        {
            FlightDatabase db = new FlightDatabase( GetFlightDataPath() );
            Meeting m = new Meeting(3712, db );
            foreach( var g in m.Guests )
            {
                Console.WriteLine( $"{g.Name} ({g.Location}) => {g.ArrivalFlight.Count}, {g.DepartureFlight}" );
            }
        }
        [Test]
        public void run_algo()
        {
            FlightDatabase db = new FlightDatabase( GetFlightDataPath() );
            Meeting m = new Meeting( 3712, db );
            for( int i = 0; i < 1000; i++ )
            {
                m.GetRandomInstance();
            }
            Console.WriteLine( m.BestResult );
        }
    }
}
