using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class ViewAllDriverTripsPage
    {
        Model1Container context;
        public ViewAllDriverTripsPage()
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
                throw;
            }
        }
        public void run()
        {
            Console.WriteLine("Driver's ID:");
            string str = Console.ReadLine();
            int id = Convert.ToInt32(str);
            IQueryable<Trip> trips = getTrips(id);
            Console.WriteLine("The driver's trip list:\n");
            foreach (Trip item in trips)
            {
                Console.WriteLine("Departure: " + item.Departure + "Departure time: " + item.DepartureTime + "Arrival: " + item.Arrival + "Arrival time: " + item.ArrivalTime + "Client's name: " + item.ClientFirstName + " " + item.ClientLastName);
            }
            Console.WriteLine("Do you want to back to the main page(Y/?)");
            char st = Convert.ToChar(Console.ReadLine().ToUpper());
            int ch = Convert.ToInt32(st);
            if (ch != 89)
                new ViewAllDriverTripsPage();
        }
        public IQueryable<Trip> getTrips(int id)
        {
            return context.TripSet.Where(t => t.Driver.Id == id);
        }
    }
}
