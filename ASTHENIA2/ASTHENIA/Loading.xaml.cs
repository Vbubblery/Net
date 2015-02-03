using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ASTHENIA
{

    public partial class Loading : Window
    {
        private MainWindow _Game;
        public Loading(MainWindow Game)
        {
            InitializeComponent();
            _Game = Game;
        }

        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            _Game.showit();
            this.Close();
        }


    }
}
