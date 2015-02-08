using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class EditDriverPage
    {
        Model1Container context;
        Driver driver;
        public EditDriverPage() 
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
            Console.WriteLine("Driver's firstname: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Driver's lastname: ");
            string lname = Console.ReadLine();
            IQueryable<Driver> drivers = findDriver(fname, lname);
            if (drivers.Count() == 0)
            {
                Console.WriteLine("Can not find this driver");
            }
            else if (drivers.Count() == 1)
            {
                driver = drivers.ToArray()[0];
                editProcess();
            }
            else
            {
                int num = 65;
                foreach (Driver item in drivers)
                {
                    Console.WriteLine((char)num++ +" "+ item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Age + " " + item.Campus);
                }
                Console.Write("Choose one of these you want to edit:");
                char str = Convert.ToChar(Console.ReadLine());
                int ch = Convert.ToInt32(str);
                driver = drivers.ToArray()[ch - 65];
                editProcess();
            }
        }
        public IQueryable<Driver> findDriver(string fname,string lname) 
        {
            IQueryable<Driver> drivers = context.DriverSet.Where(d => d.FirstName == fname && d.LastName == lname);
            return drivers;
        }
        public void editProcess ()
        {
            Console.WriteLine("Driver's firstname: " + driver.FirstName + ".  Change to: (If you do not to change this item, press 'Enter')");
            driver.FirstName = firstname();
            Console.WriteLine("Driver's lastname: " + driver.LastName + ".  Change to: (If you do not to change this item, press 'Enter')");
            driver.FirstName = lastname();
            Console.WriteLine("Driver's age: " + driver.Age + ".  Change to: (If you do not to change this item, press 'Enter')");
            driver.Age = age();
            Console.WriteLine("Driver's salary: " + driver.Salary + ".  Change to: (If you do not to change this item, press 'Enter')");
            driver.Salary = salary();
            Console.WriteLine("Campus name: " + driver.Campus.CampusName + ".  Change to: (If you do not to change this item, press 'Enter')");
            driver.Campus = campus();
            Console.WriteLine("Car model: " + driver.CarModel.ModelName + ".  Change to: (If you do not to change this item, press 'Enter')");
            driver.CarModel = carModel();
            Console.WriteLine("City: " + driver.City.CityName + ".  Change to: ");
            driver.City = city();
            context.SaveChanges();
        }
        public City city()
        {
            var cities = (from s in context.CitySet
                          select s);
            int num = 65;
            foreach (var item in cities)
            {
                Console.Write((char)num++ + " " + item.CityName + "\t");
            }
            char str = Convert.ToChar(Console.ReadLine());
            int ch = Convert.ToInt32(str);
            City city = null;
            try
            {
                city = cities.ToArray()[ch - 65];
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error. Try again");
                editProcess();
            }
            return city;

        }
        public CarModel carModel()
        {
            string str = Console.ReadLine().ToLower();
            if (str.Equals(""))
            {
                return driver.CarModel;
            }
                CarModel carModel = context.CarModelSet.Where(c => c.ModelName == str).FirstOrDefault();
                if (carModel == null)
                {
                    carModel = new CarModel();
                    carModel.ModelName = str;
                    context.CarModelSet.Add(carModel);
                }
                return carModel;
        }
        public Campus campus()
        {
            string str = Console.ReadLine().ToLower();
            if (str.Equals(""))
            {
                return driver.Campus;
            }
            Campus campus = context.CampusSet.Where(c => c.CampusName == str).FirstOrDefault();
            if (campus == null)
            {
                campus = new Campus();
                campus.CampusName = str;
                context.CampusSet.Add(campus);
            }
            return campus;
        }
        public String firstname()
        {
            string str = Console.ReadLine();
            if (str.Equals(""))
            {
                return driver.FirstName;
            }
            return str.ToLower();
        }
        public String lastname()
        {
            string str = Console.ReadLine();
            if (str.Equals(""))
            {
                return driver.LastName;
            }
            return str.ToLower();
        }
        public int age()
        {
            string str = Console.ReadLine();
            if (str.Equals(""))
            {
                return driver.Age;
            }
            int num = Convert.ToInt32(str);
            if (num < 18 || num > 60)
            {
                Console.Clear();
                Console.WriteLine("The age is bad. Try again");
                editProcess();
            }
            return num;
        }
        public double salary()
        {
            string str = Console.ReadLine();
            if (str.Equals(""))
            {
                return driver.Salary;
            }
            double num = Convert.ToDouble(str);
            if (num < 0)
            {
                Console.Clear();
                Console.WriteLine("The salary is bad. Try again");
                editProcess();
            }
            return num;
        }
    }
}
