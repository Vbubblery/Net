using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class AcceptTripPage
    {
        //操作数据库的变量
        Model1Container context;
        //构造函数
        public AcceptTripPage()
        {
            Console.Clear();
            context = new Model1Container();
            run();
        }
        public void run()
        {
            //异常处理
            try
            {
                askDriverId();
            }
            catch (Exception)
            {
                Console.WriteLine("You have error input.");
                run();
            }
        }
        //获得driver的ID
        public void askDriverId()
        {
            Console.WriteLine("The driver's id:");
            string str = Console.ReadLine();
            int id = Convert.ToInt32(str);
            Driver driver = context.DriverSet.Find(id);
            //如果找到了这个driver,执行下面的代码,找不到则退出当前page
            if (!driver.Equals("null"))
            {
                //获得指定条件的trips
                IQueryable<Trip> trips = context.TripSet.Where(t => t.Departure.Equals(driver.City.CityName));
                foreach (Trip item in trips)
                {
                    Console.WriteLine("Id: " + item.Id + "  Departure: " + item.Departure + "  Departure time: " + item.DepartureTime + "  Arrival: " + item.Arrival + "  Arrival time: " + item.ArrivalTime + "  Client's name: " + item.ClientFirstName + " " + item.ClientLastName);
                }
                Console.WriteLine("Choose one of trips with id: ");
                int tripId = Convert.ToInt32(Console.ReadLine());
                Trip trip = context.TripSet.Find(tripId);
                trip.Driver = driver;
                context.SaveChanges();
            }
        }
    }
}
