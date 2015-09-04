using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentC
{
    public class SearchEngine
    {
        public List<Itinerary> Process(List<Itinerary> discounted)
        {
            List<Itinerary> SearchResults=new List<Itinerary>();

            foreach (Itinerary searches in discounted)
            {
                searches.bookingDate = DateTime.UtcNow;
                if (searches.OriginAirportCode == "Dallas" && (searches.RoundTripArrivalDate.Day - searches.RoundtripDepatureDate.Day < 5 && searches.RoundTripArrivalDate.Month != 12 && searches.RoundtripDepatureDate.Month != 12))
                {
                    SortEngine result = new SortEngine();
                    SearchResults = result.Dallas(discounted);
                    break;
                }
                else if(searches.RoundTripArrivalDate.Day - searches.RoundtripDepatureDate.Day > 5 && searches.RoundTripArrivalDate.Month == 12 && searches.RoundtripDepatureDate.Month != 12)
                {
                    SortEngine result = new SortEngine();
                    SearchResults = result.HolidayPackage(discounted);
                    break;
                }

            }
            return SearchResults;
        }
    }
}
