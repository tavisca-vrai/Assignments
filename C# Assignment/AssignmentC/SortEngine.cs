using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC
{
    class SortEngine
    {
        Itinerary flight = new Itinerary();
        public IEnumerable<Itinerary> Sort(IEnumerable<Itinerary> inputList)
        {
            IEnumerable<Itinerary> SortedList = inputList.OrderBy(fare => fare.TotalFareInUSD)
                .ThenBy(markup => markup.MarkupInUSD)
                .ThenBy(noOfStops => noOfStops.NumberOfStops);
            return SortedList;
        }


        public List<Itinerary> Dallas(List<Itinerary> inputList)
        {
            IEnumerable<Itinerary> List2;
            IEnumerable<Itinerary> List1 = from flights in inputList
                                           where flights.Airline == "SouthWest Airlines"
                                           select flights;
            List1 = Sort(List1);
            if (flight.bookingDate.Day - DateTime.UtcNow.Day > 3)
            {
                List2 = from flights in inputList
                        where flights.Airline != "SouthWest Airlines"
                        select flights;
            }
            else
            {
                List2 = from flights in inputList
                        where flights.Airline != "SouthWest Airlines" && flights.Airline != "Spirit Airlines"
                        select flights;

            }
            List2 = Sort(List2);
            IEnumerable<Itinerary> results = List1.Concat(List2);
            return results.ToList();
        }


        public List<Itinerary> HolidayPackage(List<Itinerary> inputList)
        {
            IEnumerable<Itinerary> List2;
            IEnumerable<Itinerary> List1 = from flights in inputList
                                           where flights.Airline == "American Airlines" || flights.Airline == "Delta Airlines" || flights.Airline == "SouthWest Airlines"
                                           select flights;
            List1 = Sort(List1);
            if (flight.bookingDate.Day - DateTime.UtcNow.Day > 3)
            {

                List2 = from flights in inputList
                        where flights.Airline != "American Airlines" || flights.Airline != "Delta Airlines" || flights.Airline != "SouthWest Airlines"
                        select flights;
            }
            else
            {
                List2 = from flights in inputList
                        where flights.Airline != "American Airlines" || flights.Airline != "Delta Airlines" || flights.Airline != "SouthWest Airlines" || flights.Airline != "Spirit Airlines"
                        select flights;

            }
            List2 = Sort(List2);
            IEnumerable<Itinerary> results = List1.Concat(List2);
            return results.ToList();
        }
    }
}
