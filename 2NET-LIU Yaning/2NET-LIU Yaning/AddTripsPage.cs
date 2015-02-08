using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace _2NET_LIU_Yaning
{
    class AddTripsPage
    {
        Model1Container context;
        public AddTripsPage()
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
             Console.WriteLine("Type the detail path of your csv file: ");
             String path = Console.ReadLine();
            //读取csv文件
            using (CsvReader csv = new CsvReader(new StreamReader(path), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    Trip trip = new Trip();
                    trip.Departure = csv[0];
                    trip.DepartureTime =Convert.ToDateTime(csv[1]);
                    trip.Arrival = csv[2];
                    trip.ArrivalTime = Convert.ToDateTime(csv[3]);
                    trip.ClientFirstName = csv[4];
                    trip.ClientLastName = csv[5];
                    context.TripSet.Add(trip);
                    context.SaveChanges();
                }
            }
            Console.WriteLine("Do you want to back to the main page(Y/?)");
            char str = Convert.ToChar(Console.ReadLine().ToUpper());
            int ch = Convert.ToInt32(str);
            if (ch != 89)
                new AddTripsPage();
        }
    }
}
