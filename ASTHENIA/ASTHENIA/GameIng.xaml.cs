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
       
    public partial class GameIng : Window
    {
        private CreateNewGame _createNewGame;
        
        public GameIng(CreateNewGame createNewGame)
        {
            InitializeComponent();
            _createNewGame = createNewGame;
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            
           _createNewGame.show();
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
              Close();
            
        }




    }
}
