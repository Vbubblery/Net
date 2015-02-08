using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class AddDriverPage
    {
        Model1Container context;
        public AddDriverPage() {
            Console.Clear();
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
            //将获得的信息给赋给对象driver并存入数据库
            context = new Model1Container();
            Driver driver = new Driver();
            driver.FirstName = firstname();
            driver.LastName = lastname();
            driver.Age = age();
            driver.Salary = salary();
            driver.Campus = campus();
            driver.CarModel = carModel();
            driver.City = city();
            context.DriverSet.Add(driver);
            context.SaveChanges();
        }
        public City city()
        {
            Console.Write("Driver's city: ");
            var cities = (from s in context.CitySet
                          select s);
            int num = 65;
            foreach (var item in cities)
            {
                Console.Write((char)num++ +" "+item.CityName+"\t");
            }
            char str = Convert.ToChar(Console.ReadLine());
            int ch = Convert.ToInt32(str);
            City city = null;
            try
            {
                city = cities.ToArray()[ch-65];
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error. Try again");
                run();
            }
            return city;
            
        }
        public CarModel carModel() 
        {
            Console.Write("Driver's car model: ");
            string str = Console.ReadLine().ToLower();
            //获取指定条件的calmodel
            CarModel carModel = context.CarModelSet.Where(c => c.ModelName== str).FirstOrDefault();
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
            Console.Write("Driver's campus: ");
            string str = Console.ReadLine().ToLower();
            Campus campus = context.CampusSet.Where(c => c.CampusName == str).FirstOrDefault();
            if (campus==null)
            {
                campus = new Campus();
                campus.CampusName = str;
                context.CampusSet.Add(campus);
            }
            return campus;
        }
        public String firstname() 
        {
            Console.Write("Driver's firstname: ");
            string str = Console.ReadLine();
            return str.ToLower();
        }
        public String lastname() 
        {
            Console.Write("Driver's lastname: ");
            string str = Console.ReadLine();
            return str.ToLower();
        }
        public int age()
        {
            Console.Write("Driver's age: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 18 || num > 60)
            {
                Console.Clear();
                Console.WriteLine("The age is bad. Try again");
                run();
            }
            return num;
        }
        public double salary() 
        {
            Console.Write("Driver's salary: ");
            double num = Convert.ToDouble(Console.ReadLine());
            if (num < 0)
            {
                Console.Clear();
                Console.WriteLine("The salary is bad. Try again");
                run();
            }
            return num;
        }
    }
}
