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

    public partial class GameIng : Window
    {
        //define some variable
        RANDOM rdm;
        private RpgGamingEntities _Context;
        private MainWindow _Game;
        Rectangle maps = new Rectangle();
        bool Do = false;
        int Gr = 0;
        int Ga = 0;
        int Gm = 0;
        int h, m, s;
        long HPOfMonster;
        long HPOfRoles;
        long XPOfRoles;
        int AttackOfMonster = 30;
        int AttackRatePosition = 0;
        int AttackOfRole = 30;
        int AttackOfRoleBoost =0;
        int aa,ss;
        int a = 0;
        int b = 0;
        int PlayerId;
        ////initialization the GameIng window
        public GameIng(MainWindow Game)//call MainWindow's function
        {
            InitializeComponent();
            _Game = Game;
           
            //Get information about the player and set the role's position 
            In();
            Set(maps, a, b);

            // create a timer to get the run time 
            DispatcherTimer messageTimer = new DispatcherTimer();
            messageTimer.Tick += new EventHandler(messageTimer_Tick);
            messageTimer.Interval = new TimeSpan(0, 0, 1);
            messageTimer.Start();
        }

        //the rectangle is the postion where the role is.
        public void Set(Rectangle maps, int y, int x)
        {
            maps.SetValue(Grid.RowProperty, x);
            maps.SetValue(Grid.ColumnProperty, y);
            //the picture of role
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource =
     new BitmapImage(new Uri(@"role.jpg", UriKind.Relative));
            maps.Fill = imgBrush;
            Map.Children.Add(maps);
        }
        //First show the information about the role.Its' static.
        public void In()
        {
            
            info.Text = null;
            RpgGamingEntities Context = new RpgGamingEntities();
            string name = _Game.GetName();
            var lollol = from Name in Context.Player
                         where Name.Name == name
                         select Name;
           
            foreach (var item in lollol)
            {
                HPOfRoles = item.HP;
                XPOfRoles = item.XP;
                int level = 1;
                level = level + (int)item.XP / 500;
                info.Text = "The Information :" + Environment.NewLine + "Role's Name:    " + item.Name + Environment.NewLine + "Role's HP:    " + item.HP.ToString() + Environment.NewLine + "Role's MaxHP:   " + item.MaxHP + Environment.NewLine + "Role's Level:    " + level + Environment.NewLine + "Role's XP:    " + item.XP + Environment.NewLine + Environment.NewLine + "Roles's Positon:    " + "(" + item.Cell.PosX + "," + item.Cell.PosY + ")";
                a = item.Cell.PosX - 1;
                b = item.Cell.PosY - 1;
                PlayerId = item.ID;

            }
            var lo = from aaa in Context.Weapon
                     where aaa.Player_ID == PlayerId
                     select aaa;
            foreach (var item2 in lo)
            {
                 aa = item2.AttackRate + AttackRatePosition;
                info.Text += Environment.NewLine + "AttackRate:   " + aa + Environment.NewLine + "MissRate:   " + item2.MissRate;
            }
           
                
        }
        //When the date of role changes.It will be run.
        public void Out() { 
              info.Text = null;
            RpgGamingEntities Context = new RpgGamingEntities();
            string name = _Game.GetName();
            var lollol = from Name in Context.Player
                         where Name.Name == name
                         select Name;
            foreach (var item in lollol)
            {
                
                int c = a + 1;
                int d = b + 1;
                int level = 1;
                level += (int)XPOfRoles / 500;
                info.Text = "The Information :" + Environment.NewLine + "Role's Name:    " + item.Name + Environment.NewLine + "Role's HP:    " + HPOfRoles + Environment.NewLine + "Role's MaxHP:   " + item.MaxHP + Environment.NewLine + "Role's Level:    " + level + Environment.NewLine + "Role's XP:    " + XPOfRoles + Environment.NewLine + Environment.NewLine + "Roles's Positon:    " + "(" + c + "," + d + ")";
                AttackOfRole += level * 2;
            }
            var lo = from aaa in Context.Weapon
                     where aaa.Player_ID == PlayerId
                     select aaa;
            foreach (var item2 in lo)
            {
                
               aa = item2.AttackRate + AttackRatePosition;
                info.Text += Environment.NewLine + "AttackRate:   " + aa + Environment.NewLine+"MissRate:   "+item2.MissRate;
                ss = item2.MissRate;
            }

        }
        //Get the role's attack and miss rate and retuen them to the random.
        public int GetAttackRate()
        {
        return aa;
        }
        public int GetMissRate()
        {
            return ss;
        }
        private void Window_Closed_1(object sender, EventArgs e)
        {
            Save();
            _Game.Show();
            _Game.UpdateList();
            _Game.but.IsEnabled = false;
            _Game.butt.IsEnabled = false;

        }
        //Judge the cell where role can move to here and get potion and wheather battle.
        public bool CanMove()
        {
            string de = "";
            rdm = new RANDOM();
            int x = a + 1;
            int y = b + 1;
            RpgGamingEntities Context = new RpgGamingEntities();
           
            bool move = false;
            var wher = from pp in Context.Cell
                       where pp.PosX==x&&pp.PosY==y
                       select pp;
            foreach (var item in wher)
            {       
                move = item.CanMoveTo;
                de = item.Description;
            }
            if (move == true)
            {
                Map.Children.Clear();
                Set(maps, a, b);

                MessageBox.Show("Come to a "+de);
                if (rdm.PickupRandom(this) == true || rdm.PickupWeaponRandom(this) == true)
                {
                    PopupWindow win = new PopupWindow();
                    win.ShowDialog();
                }
                Do=true;
                if (rdm.FightRandom()==true)
                {
                   
                    MessageBox.Show("Battling!!!");
                    Preparebattle();
                    battle();
                }
                else
                {
                }

            }
            else
            { 
                Do=false;
            }
            return Do;
        }
        public bool move() {
            return Do;
        }
        //return the miss attack of monster to random
        public int MA() {
            return Ga;
        }
        public int MM()
        {
            return Gm;
        }
        //loading the information of battle.
        public void Preparebattle()
        {

            int x = a + 1;
            int y = b + 1;
            RpgGamingEntities Context = new RpgGamingEntities();
            var wher = from pp in Context.Cell
                       where pp.PosX == x && pp.PosY == y
                       select pp;
            foreach (var item in wher)
            {
                Gr = item.MonsterGroup;
            }

            var Mon = from bb in Context.Monster
                      where bb.Group == Gr
                      select bb;
            foreach (var item2 in Mon)
            {
                HPOfMonster = item2.HP;
                Ga = item2.AttackRate;
                Gm = item2.MissRate;
            }
            

        }
        //the battle is begining
        public void battle() {
            rdm = new RANDOM();

            while (HPOfRoles>0&&HPOfMonster>0)
            {
                if (rdm.attackRandom(this)==true&&rdm.MonsterMiss(this)==false)
                {
                    HPOfMonster -= AttackOfRole;
                    HPOfMonster -= AttackOfRoleBoost;
                }
                else if (rdm.attackRandom(this)==true&&rdm.MonsterMiss(this)==true)
                {
                    
                }
                if (rdm.MonsterAttack(this)==true&&rdm.missRandom(this)==false)
                {
                    HPOfRoles -= AttackOfMonster;
                }
                else if (rdm.MonsterAttack(this)==true&&rdm.missRandom(this)==true)
                {
                    
                }
              
                
            }

            if (HPOfRoles>0)
            {
                MessageBox.Show("You Win!");
                XPOfRoles += 20;
                
            }
            else if (HPOfRoles<=0)
            {

                MessageBox.Show("You Lose"+ Environment.NewLine +"back to birth place");
                a = 0;
                b = 0;
                Map.Children.Clear();
                Set(maps, a, b);
                XPOfRoles -= 100;
                if (XPOfRoles<0)
                {
                    XPOfRoles = 0;
                }
                HPOfRoles = 100;
                
            }
            
        }
        //role can move by the direction key of keyboard
        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)
            {
                b--;
                CanMove();
                if (move()==true)
                {
                  Out();  
                }
                else
                {
                    b++;
                }
                
                return;
            }
            if (e.Key == System.Windows.Input.Key.Down)
            {
                b++;
                CanMove();
                if (move() == true)
                {
                    Out();
                }
                else
                {
                    b--;
                }
                return;
            }
            if (e.Key == System.Windows.Input.Key.Left)
            {
                a--;
                CanMove();
                if (move() == true)
                {
                    Out();
                }
                else
                {
                    a++;
                }
                return;
            }
            if (e.Key == System.Windows.Input.Key.Right)
            {
                a++;
                CanMove();
                if (move() == true)
                {
                    Out();
                }
                else
                {
                    a--;
                }
                return;
            }
            
        }
        // pick up something
        public void PickUpWeaponBowAndArrow()
        {
            int PlayerID = 0;
              RpgGamingEntities Context = new RpgGamingEntities();
            string name = _Game.GetName();
            var lollol = from Name in Context.Player
                         where Name.Name == name
                         select Name;
            foreach (var item in lollol)
            {
                PlayerID = item.ID;
            }
            var BowAndArrow = new Weapon();
            var Dele = from kk in Context.Weapon
                       where kk.Player_ID == PlayerID
                       select kk;
            foreach (var item2 in Dele)
            {
                Context.Weapon.Remove(item2);
            }

            BowAndArrow.Name = "Bow And Arrow";
            BowAndArrow.AttackRate = 85;
            BowAndArrow.MissRate = 20;
            BowAndArrow.Player_ID = PlayerID;
            Context.Weapon.Add(BowAndArrow);
            Context.SaveChanges();
        }
        public void PickUpHealthPotion()
        {
            RpgGamingEntities Context = new RpgGamingEntities();
            var ob = new Object();
            var Health = new ObjectType();
            Health.Name = "Health Potion";
            Health.HPRestoreValue = 100;
            Health.DefenseBoost = 0;
            Health.AttackStrenghtBoost = 0;

            ob.ObjectTypeID = Health.ID;
            ob.PlayerID = PlayerId;
            Context.Object.Add(ob);
            Context.ObjectType.Add(Health);
            Context.SaveChanges();
        }
        public void PickUpDefensePotion()
        { 
        RpgGamingEntities Context = new RpgGamingEntities();
        var ob = new Object();
        var def = new ObjectType();
        def.Name = "Defense Potion";
        def.HPRestoreValue = 0;
        def.AttackStrenghtBoost = 0;
        def.DefenseBoost = 20;

        ob.ObjectTypeID = def.ID;
        ob.PlayerID = PlayerId;
        Context.ObjectType.Add(def);
        Context.Object.Add(ob);
        Context.SaveChanges();

        }
        public void PickAttackPotion()
        {
            RpgGamingEntities Context = new RpgGamingEntities();
            var ob = new Object();
            var imp = new ObjectType();
            imp.Name = "Attack Potion";
            imp.HPRestoreValue = 0;
            imp.DefenseBoost = 0;
            imp.AttackStrenghtBoost = 10;
            ob.ObjectTypeID = imp.ID;
            ob.PlayerID = PlayerId;
            Context.Object.Add(ob);
            Context.ObjectType.Add(imp);
            Context.SaveChanges();
        
        }
        //save the date of role
        public void Save()
        {

            _Context = new RpgGamingEntities();
            Cell cell1 = _Context.Cell.FirstOrDefault(cc => cc.PosX == a+1 &&cc.PosY ==b+1);
            Player player1 = _Context.Player.FirstOrDefault(cc => cc.ID == PlayerId);
         
            player1.Cell_ID = cell1.ID;
            player1.HP = HPOfRoles;
            player1.XP = XPOfRoles;
           


            _Context.SaveChanges();
        }
        //use the potion that in the role's bag
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            _Context = new RpgGamingEntities();
            var YH = from tt in _Context.Object
                     where tt.PlayerID == PlayerId
                     select tt;
            foreach (var item in YH)
            {
                string search = "";
                var att = from ww in _Context.ObjectType
                         where ww.Name == "Attack Potion"
                         select ww;
                foreach (var item55 in att)
                {
                    search = item55.Name;
                    
                }
                if (search != "Attack Potion")
                {
                    
                    PopupWindow error = new PopupWindow();
                    error.pic.Background = Brushes.White;
                    error.ttt.Content = "You don't have it!!!";

                    error.ShowDialog();
                }
                else
                {
                    test.Text += "222";
                    AttackOfRoleBoost += 20;
                    foreach (var item2 in att)
                    {
                        _Context.ObjectType.Remove(item2);
                        var ag = from tt in _Context.Object
                                 where tt.ObjectTypeID == item2.ID
                                 select tt;
                        foreach (var item3 in ag)
                        {
                            _Context.Object.Remove(item3);
                            
                        }
                        break;
                    }
                }
            }
            _Context.SaveChanges();
            

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _Context = new RpgGamingEntities();
            var YH = from tt in _Context.Object
                     where tt.PlayerID == PlayerId
                     select tt;
            foreach (var item in YH)
            {
                string search = "";
                var att = from ww in _Context.ObjectType
                          where ww.Name == "Defense Potion"
                          select ww;
                foreach (var item55 in att)
                {
                    search = item55.Name;

                }
                if (search!= "Defense Potion")
                {
                    PopupWindow error = new PopupWindow();
                    error.pic.Background = Brushes.White;
                    error.ttt.Content = "You don't have it!!!";

                    error.ShowDialog();
                }
                else
                {
                     AttackOfMonster -= 5;
                    foreach (var item2 in att)
                    {
                        _Context.ObjectType.Remove(item2);
                        var ag = from tt in _Context.Object
                                 where tt.ObjectTypeID == item2.ID
                                 select tt;
                        foreach (var item3 in ag)
                        {
                            _Context.Object.Remove(item3);

                        }
                        break;
                    }
                }
            }
            _Context.SaveChanges();
            

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _Context = new RpgGamingEntities();
            var YH = from tt in _Context.Object
                     where tt.PlayerID == PlayerId
                     select tt;
            foreach (var item in YH)
            {
                string search = "";
                var att = from ww in _Context.ObjectType
                          where ww.Name == "Health Potion"
                          select ww;
                foreach (var item55 in att)
                {
                    search = item55.Name;

                }
                if (search != "Health Potion")
                {
                    PopupWindow error = new PopupWindow();
                    error.pic.Background = Brushes.White;
                    error.ttt.Content = "You don't have it!!!";

                    error.ShowDialog();
                }
                else
                {
                    HPOfRoles += 50;
                    if (HPOfRoles>100)
                    {
                        HPOfRoles = 100;
                    }
                    foreach (var item2 in att)
                    {
                        _Context.ObjectType.Remove(item2);
                        var ag = from tt in _Context.Object
                                 where tt.ObjectTypeID == item2.ID
                                 select tt;
                        foreach (var item3 in ag)
                        {
                            _Context.Object.Remove(item3);

                        }
                        break;
                    }
                }
            }
            _Context.SaveChanges();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            type(); 
        }
        //user can type cmd to control role
        private void cmd_KeyDown(object sender, KeyEventArgs e)
        {
            type();
        }
        public void type() {
            if (cmd.Text == "up" || cmd.Text == "UP" || cmd.Text == "Up")
            {
                b--;
                CanMove();
                if (move() == true)
                {
                    Out();
                    cmd.Text = "";
                }
                else
                {
                    cmd.Text = "";
                    b++;
                }
               
                return;
            }
            else if (cmd.Text == "down" || cmd.Text == "DOWN" || cmd.Text == "Down")
            {
                b++;
                CanMove();
                if (move() == true)
                {
                    cmd.Text = "";
                    Out();
                }
                else
                {
                    cmd.Text = "";
                    b--;
                }
                return;
            }
            else if (cmd.Text == "left" || cmd.Text == "LEFT" || cmd.Text == "Left")
            {
                a--;
                CanMove();
                if (move() == true)
                {
                    cmd.Text = "";
                    Out();
                }
                else

                {
                    cmd.Text = "";
                    a++;
                }
                return;
            }
            else if (cmd.Text == "right" || cmd.Text == "RIGHT" || cmd.Text == "Right")
            {
                a++;
                CanMove();
                if (move() == true)
                {
                    cmd.Text = "";
                    Out();
                }
                else
                {
                    cmd.Text = "";
                    a--;
                }
                return;
            }
            
        }
        //Get the run time.
        public static DateTime StartTime = DateTime.Now;
        void messageTimer_Tick(object sender, EventArgs e)
        {
            s++;
            if (s==60)
            {
                s = 0;
                m++;
            }
            if (m==60)
            {
                m = 0;
                h++;
            }
            time.Content = "The working time is:" + Environment.NewLine + h + ":" + m + ":" + s;
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            h = 0;
            m = 0;
            s = 0;
            time.Content = "The working time is:" + Environment.NewLine + h + ":" + m + ":" + s;
        }


    }
}