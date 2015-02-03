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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASTHENIA
{

    public partial class MainWindow : Window
    {
        
        private RpgGamingEntities _Context = new RpgGamingEntities();
        public MainWindow()
        {
            InitializeComponent();
            
            title.Background = Brushes.Gray;
            UpdateList();  //every time i changed the selectview ..the date will be updated

          
        }
        //clear and load the date.
        public void UpdateList()
        {
            SaveList.Items.Clear();
            GetInformation.Text = null;
            foreach (var player in _Context.Player)
            {
                SaveList.Items.Add(player.Name);
            }   

        }
        //show the window to new a role
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateNewGame(this);
            window.ShowDialog();
          
        }
        //delect the role from database
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetInformation.Text = "";
            string GotName = SaveList.SelectedItem.ToString();
            var lol = from Name in _Context.Player
                       where Name.Name == GotName
                       select Name;
           
            foreach (var item in lol)
            {
                var TXT = from Name in _Context.Weapon
                          where Name.Player_ID == item.ID
                          select Name;
                foreach (var item2 in TXT)
                {
                    _Context.Weapon.Remove(item2);
                }
                
                _Context.Player.Remove(item);
                var TXT2 = from cc in _Context.Object
                          where cc.PlayerID == item.ID
                          select cc;
                foreach (var item3 in TXT2)
                {
                    int num =item3.ObjectTypeID;
                    var TXT3 = from ss in _Context.ObjectType
                               where ss.ID == num
                               select ss;
                    foreach (var item4 in TXT3)
                    {
                        _Context.ObjectType.Remove(item4);
                    }
                    _Context.Object.Remove(item3);

                }
            }
            _Context.SaveChanges();
            UpdateList();
            but.IsEnabled = false;
            butt.IsEnabled = false;
        }
        //Show the information
        public string GetName()
        {
            string AA = "";
            string each = SaveList.SelectedItem.ToString();
            var lollol = from Name in _Context.Player
                         where Name.Name == each
                         select Name;

            foreach (var item in lollol)
            {
                AA = item.Name;
            }
            return AA;
        }
        public void _selectName()
        {
            RpgGamingEntities Context = new RpgGamingEntities();
            if (SaveList.SelectedItem == null)
                return;

            if (SaveList.SelectedValue == SaveList.SelectedItem.ToString())
            {
                string each = SaveList.SelectedItem.ToString();
                var lollol = from Name in Context.Player
                             where Name.Name == each
                             select Name;
                foreach (var item in lollol)
                {
                    int level = 1;
                    level = level + (int)item.XP / 500;
                    GetInformation.Text = "The Information :" + Environment.NewLine + "Role's Name:    " + item.Name + Environment.NewLine + "Role's HP:    " + item.HP.ToString() + Environment.NewLine + "Role's MaxHP:   " + item.MaxHP + Environment.NewLine + "Role's Level:    " + level + Environment.NewLine + "Role's XP:    " + item.XP + Environment.NewLine + Environment.NewLine + "Roles's Positon:    " + "(" + item.Cell.PosX + "," + item.Cell.PosY + ")";
                }
            }
        }
        public void SelectName()
        {
            if (SaveList.SelectedItem == null)
                return;
            
            if (SaveList.SelectedValue == SaveList.SelectedItem.ToString())
            {
                string each = SaveList.SelectedItem.ToString();
                var lollol = from Name in _Context.Player
                             where Name.Name == each
                             select Name;
                foreach (var item in lollol)
                {
                    int level =1;
                    level = level + (int)item.XP/500 ;
                    GetInformation.Text = "The Information :" + Environment.NewLine + "Role's Name:    " + item.Name + Environment.NewLine + "Role's HP:    " + item.HP.ToString() + Environment.NewLine + "Role's MaxHP:   " + item.MaxHP + Environment.NewLine + "Role's Level:    " +level + Environment.NewLine + "Role's XP:    " + item.XP + Environment.NewLine + Environment.NewLine + "Roles's Positon:    " + "(" + item.Cell.PosX + "," + item.Cell.PosY + ")";
                }
            }
        }
        //must select a item.then we can load it or delet it .
        private void SaveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectName();
            but.IsEnabled = true;
            butt.IsEnabled = true;
        }
      //loading it  
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
                 Loading ss = new Loading(this);
            ss.Show();
            Hide();
           
            
           
        }
        //start the game
        public void showit() {
            var ww = new GameIng(this);
            ww.Show();
        }

    } 
}
