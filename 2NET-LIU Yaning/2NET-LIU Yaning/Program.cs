using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
namespace _2NET_LIU_Yaning
{
    class Program
    {
        Model1Container context;
        static void Main(string[] args)
        {
            Program p = new Program(); //重构本身
        }
        public Program() //构造函数
        {
            context = new Model1Container(); //初始化数据实体控制器
            initCity();
            run();
        }
        public void run()
        {
            new MainPage();

        }
        public void initCity() 
        {
            ArrayList ary = new ArrayList() { "Paris", "Marseille", "Lyon" };
            var cities = (from s in context.CitySet
                          select s);

            if (cities.Count() == 0) {
                foreach (String item in ary)
                {
                    context.CitySet.Add(new City(item));
                }
                context.SaveChanges();
            }
        }

    }
}
