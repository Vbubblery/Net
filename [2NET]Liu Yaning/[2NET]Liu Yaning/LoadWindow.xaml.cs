using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2NET_Liu_Yaning
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        public LoadWindow()
        {
            InitializeComponent();
        }
        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
