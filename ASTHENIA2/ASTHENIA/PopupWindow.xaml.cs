using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ASTHENIA
{

    public partial class PopupWindow : Window
    {
        //the popup window will auto-clise after 3s.
        private Timer timer = new Timer(3000);
        public PopupWindow()
        {
            InitializeComponent();

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                this.Close();
            });
        }  
    }
}
