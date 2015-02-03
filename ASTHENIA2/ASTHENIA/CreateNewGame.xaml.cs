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
        // Link to the MainWindow
        private MainWindow _parent;
        public CreateNewGame(MainWindow parent)
        {
            //initialization the CreateNewGame window
            InitializeComponent();
            // Link to the MainWindow
            _parent = parent;   
        }
        //Click the button to save the date of role
        private void Canvas_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            type();
            }
        //Enter to save the date of role
        private void RoleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                type();
            }
           
        }

        public void type()
        {

            if (RoleName.Text == "")//can't allow type the name with empty.
            {
                PopupWindow ww = new PopupWindow();
                ww.pic.Background = Brushes.White;
                ww.ttt.Content = "Please Type a string" + Environment.NewLine+"name for role!";
                ww.ttt.Foreground = Brushes.Red;
                ww.ShowDialog();
            }
            else
            {
                this.Close();
                var Myplayer = new Player();
                var MyWeapon = new Weapon();


                Myplayer.Name = RoleName.Text;
                Myplayer.XP = 0;
                Myplayer.HP = 100;
                Myplayer.MaxHP = 100;
                Myplayer.Cell_ID = 1;


                var ob = new Object();
                var imp = new ObjectType();
                imp.Name = "Nothing";
                imp.HPRestoreValue = 0;
                imp.DefenseBoost = 0;
                imp.AttackStrenghtBoost = 0;
                Context.Object.Add(ob);
                Context.ObjectType.Add(imp);

                MyWeapon.Name = "knife";
                MyWeapon.AttackRate = 50;
                MyWeapon.MissRate = 50;
                MyWeapon.Player_ID = Myplayer.ID;
                Context.Weapon.Add(MyWeapon);
                Context.Player.Add(Myplayer);
                Context.SaveChanges();
                _parent.UpdateList();
               _parent.but.IsEnabled = false;
               _parent.butt.IsEnabled = false;
            }
        }
    }
}
