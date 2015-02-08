using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class AddTripPage
    {
        Model1Container context;
        IQueryable<City> cities;
        public AddTripPage() 
        {
            Console.Clear();
            context = new Model1Container();
            getCity();
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
            //将获取的信息复制给对象trip并存入数据库
            Trip trip = new Trip();
            trip.Departure = setDeparture();
            trip.DepartureTime = setDepartureArrivalTime();
            trip.Arrival = setArrival();
            trip.ArrivalTime = setDepartureArrivalTime();
            trip.ClientFirstName = setFirstName();
            trip.ClientLastName = setLastName();
            context.TripSet.Add(trip);
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
            char str =Convert.ToChar(Console.ReadLine());
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
