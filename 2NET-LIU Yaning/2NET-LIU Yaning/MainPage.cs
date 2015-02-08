using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NET_LIU_Yaning
{
    class MainPage
    {
        //构造函数
        public MainPage() {
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
            while (true)
            {
                //主界面信息输出
                int num = 0;
                Console.WriteLine("TAXI DRIVER APPLICATION \n");
                Console.WriteLine("#############################\n");
                Console.WriteLine("1:Add a driver");
                Console.WriteLine("2:Edit a driver");
                Console.WriteLine("3:Add a trip");
                Console.WriteLine("4:Import trips");
                Console.WriteLine("5:View all trips for a driver");
                Console.WriteLine("6:Accept trips");
                Console.WriteLine("7:All trips");
                Console.Write("Please type the number which one you choose: ");
                //异常处理
                try
                {
                    string str = Console.ReadLine();
                    num = Convert.ToInt32(str);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.Write("Just type the number between 1-5");
                }
                //判断用户选择的功能
                switch (num)
                {
                    case 1: new AddDriverPage(); Console.Clear(); break;
                    case 2: new EditDriverPage(); Console.Clear(); break;
                    case 3: new AddTripPage(); Console.Clear(); break;
                    case 4: new AddTripsPage(); Console.Clear(); break;
                    case 5: new ViewAllDriverTripsPage(); Console.Clear(); break;
                    case 6: new AcceptTripPage(); Console.Clear(); break;
                    case 7: new AllTripsPage(); Console.Clear(); break;
                    default:
                        Console.Clear();
                        Console.Write("Just type the number between 1-5"); break;
                }
            }
        }
    }
}
