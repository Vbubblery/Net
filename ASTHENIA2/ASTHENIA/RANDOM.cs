using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTHENIA
{
    
    class RANDOM
    {
        
        RpgGamingEntities Context;
        private GameIng _Gaming;
        //judge fight.
        public bool FightRandom()
        {
            Context = new RpgGamingEntities();
            bool b = false;
            Random rad = new Random();
            int num = rad.Next(1, 101);
            if (num >0&&num<51)
            {
                b = true;
            }
            else
            {
                b = false;
            }

            return b;
        } 
        //judge  role's attack
        public bool attackRandom(GameIng Gaming)
        {
            
            Context = new RpgGamingEntities();
            _Gaming = Gaming;
          
            bool b = false;
            Random rad2 = new Random();
            int num = rad2.Next(1,101);
            int Get =_Gaming.GetAttackRate();
            if (num >0&&num<=Get)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }
        //judge role's miss
        public bool missRandom(GameIng Gaming)
        {
            _Gaming = Gaming;
            bool b = false;
            Random rad3 = new Random();
            int num = rad3.Next(1,101);
            int Get = _Gaming.GetMissRate();
            if (num>0&&num<=Get)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;



        }
        //judge pick up some thing
        public bool PickupRandom(GameIng Gaming)
        {
            _Gaming = Gaming;
            bool b = false;
            Random rad4 = new Random();
            int num = rad4.Next(1, 101);
           
            
            if (num>0&&num<11)
            {
                 Random rad5 = new Random();
                int num2 = rad5.Next(1,31);
                
                if (num2==1&&num2<=10)
                {
                    _Gaming.PickUpHealthPotion();
                  
                    b = true;
                }
                else if (num2>=11&&num2<=20)
                {
                    _Gaming.PickUpDefensePotion();
                
                    b = true;
                }
                else if (num2>=21&&num2<=30)
                {
                    _Gaming.PickAttackPotion();
             
                    b = true;
                }

               
            }
            else
            {
                b = false;
            }
            return b;
            
        }
        public bool PickupWeaponRandom(GameIng Gaming)
        {
            _Gaming = Gaming;
            bool b = false;
            Random rad6 = new Random();
            int num = rad6.Next(1,101);
            if (num>0&&num<6)
            {
                b = true;
                _Gaming.PickUpWeaponBowAndArrow();
            }
            else
            {
                b = false;
            }
            return b;
        }
        //judge monster's attack and miss
        public bool MonsterAttack(GameIng Gaming)
        {
            bool b =false;
            _Gaming = Gaming;
            Random rad7 = new Random();
            int Get = _Gaming.MA();
            int num = rad7.Next(1, 101);
            if (num>0&&num<=Get)
            {
                b=true;
                return b;
            }
            else
            {
                b=false;
            return b;
            }
        }
        public bool MonsterMiss(GameIng Gaming)
        {
            bool b = false;
            _Gaming = Gaming;
            Random rad8 = new Random();
            int Get = _Gaming.MM();
            int num = rad8.Next(1, 101);
            if (num > 0 && num <= Get)
            {
                b = true;
                
            }
            else
            {
                b = false;
                
            }
            return b;
        }

    }
}
