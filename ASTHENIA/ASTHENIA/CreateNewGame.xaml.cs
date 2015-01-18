using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASTHENIA
{
     
    
    public partial class CreateNewGame : Window
    {
        RpgGamingEntities Context = new RpgGamingEntities();
        
        
        private MainWindow _parent;

      
        public CreateNewGame(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
{

            _parent.Hide();
            this.Close();
            var _windows = new GameIng(this);
            _windows.Show();
            var Myplayer = new Player();
            var MyWeapon = new Weapon();

            Myplayer.Name = RoleName.Text;
            Myplayer.XP = 0;
            Myplayer.HP = 100;
            Myplayer.MaxHP = 100;
            Myplayer.Cell_ID = 1;
            
            MyWeapon.Name = "knife";
            MyWeapon.AttackRate = 50;
            MyWeapon.MissRate = 50;
            MyWeapon.Player_ID = Myplayer.ID;
            Context.Weapon.Add(MyWeapon);
            Context.Player.Add(Myplayer);
            Context.SaveChanges();
            _parent.UpdateList();
        }
        public void show() {
            _parent.Show();
        }
        public void close()
        {
            _parent.Close();
        }



    }
}
