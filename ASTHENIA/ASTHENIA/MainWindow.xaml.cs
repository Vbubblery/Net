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



        public MainWindow(CreateNewGame createNewGame)
        {
            InitializeComponent();
         
            title.Background = Brushes.Gray;
            UpdateList();
        }

        public void UpdateList()
        {
            SaveList.Items.Clear();

           

            foreach (var player in _Context.Player)
            {
                SaveList.Items.Add(player.Name);
            }   

        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateNewGame(this);
            window.ShowDialog();
           
        }

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

                
            }
            _Context.SaveChanges();
            UpdateList();
            
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

        private void SaveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectName();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
          
        }

    } 
}
