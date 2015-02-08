using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class AllTripsPage
    {
        Model1Container context;
        IQueryable<City> cities;
        public AllTripsPage()
        {
            Console.Clear();
            context = new Model1Container();
            try
            {
                run();
            }
            catch (Exception)
            {
                Console.WriteLine("You have error input.");
                run();
            }
        }
        public void run() 
        {
            IQueryable<Trip> trips = (from s in context.TripSet
                                      select s);
            foreach (Trip item in trips)
            {
                Console.WriteLine("Id: " + item.Id + "  Departure: " + item.Departure + "  Departure time: " + item.DepartureTime + "  Arrival: " + item.Arrival + "  Arrival time: " + item.ArrivalTime + "  Client's name: " + item.ClientFirstName + " " + item.ClientLastName);
            }
            Console.WriteLine("Choose one trip's id or 'N' to exit");
            string str = Console.ReadLine().ToLower();
            if (str.Equals("n"))
            {

            }
            else
            {
                int num = Convert.ToInt32(str);
                operation(num);
            }

        }
        public void operation(int id) 
        {
            Console.WriteLine("OPeration: 1.Edit trip   2.Delete trip");
            Trip trip = context.TripSet.Find(id);
            string str = Console.ReadLine();
            if (str == "1")
            {
                editTrip(trip);
            }
            else if(str=="2")
            {
                deleteTrip(trip);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("error input, try again: ");
                run();
            }
        }
        public void editTrip(Trip trip)
        {
            Console.Clear();
            getCity();
            trip.Departure = setDeparture();
            trip.DepartureTime = setDepartureArrivalTime();
            trip.Arrival = setArrival();
            trip.ArrivalTime = setDepartureArrivalTime();
            trip.ClientFirstName = setFirstName();
            trip.ClientLastName = setLastName();
            context.SaveChanges();
        }
        public void deleteTrip(Trip trip)
        {
            context.TripSet.Remove(trip);
            context.SaveChanges();
        }
        public void getCity()
        {
            cities = (from s in context.CitySet
                      select s);
        }
        public string setLastName()
        {
            Console.WriteLine("Client's Last name:");
            string str = Console.ReadLine();
            return str.ToLower();
        }
        public string setFirstName()
        {
            Console.WriteLine("Client's first name:");
            string str = Console.ReadLine();
            return str.ToLower();
        }
        public string setDeparture()
        {
            int num = 65;
            foreach (City item in cities)
            {
                Console.Write((char)num++ + " " + item.CityName + "\t");
            }
            Console.Write("\nGo to: ");
            char str = Convert.ToChar(Console.ReadLine());
            int ch = Convert.ToInt32(str);
            return cities.ToArray()[ch - 65].CityName;
        }
        public string setArrival()
        {
            int num = 65;
            foreach (City item in cities)
            {
                Console.Write((char)num++ + " " + item.CityName + "\t");
            }
            Console.Write("\nArrival: ");
            char str = Convert.ToChar(Console.ReadLine());
            int ch = Convert.ToInt32(str);
            return cities.ToArray()[ch - 65].CityName;
        }
        public DateTime setDepartureArrivalTime()
        {
            int year, month, day;
            string str;
            Console.WriteLine("The year:");
            str = Console.ReadLine();
            year = Convert.ToInt32(str);
            Console.Write("The month: ");
            str = Console.ReadLine();
            month = Convert.ToInt32(str);
            Console.Write("The day: ");
            str = Console.ReadLine();
            day = Convert.ToInt32(str);
            return new DateTime(year, month, day);
        }
    }
}
