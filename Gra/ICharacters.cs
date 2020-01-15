using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    interface ICharacters
    {
         int HP { get; set; }
        int Attack { get; set; }
        int Speed_Attack { get; set; }
        int Armor { get; set; }
        string Name { get; set; }
         int Lvl { get; set; }
         int Exp { get; set; }

    }

    public class Wojownik : ICharacters
    {
        public int HP { get; set; }
        public int MaxHP {
            get
            {
                if (Lvl > 1)
                {
                   int MHP = 50;
                    MHP += 50 * Lvl;
                    return MHP;
                }
                else
                    return 50;
            }
            set { } }
        public int Attack
        {
            get
            {
                if (Lvl > 1)
                {
                    int AT = 5;
                    AT += 5 * Lvl;
                    return AT;
                }
                else
                    return 5;
            }
            set { }
        }
        public int Speed_Attack
        {
            get
            {
                if (Lvl > 1)
                {
                    int SA = 10;
                    SA += 2 * Lvl;
                    return SA;
                }
                else
                    return 10;
            }
            set { }
        }
    
        public int Armor {
            get
            {
                if (Lvl > 1)
                {
                    int A = 10;
                    A += 5 * Lvl;
                    return A;
                }
                else
                    return 10;
            }
            set { }
        }
        public int Exp { get; set; }
        public int X {
            get
            {
                return Moving.xu_map;
            } 
            set
            {
                Moving.xu_map = value;
            }
        }
        public int Y {
            get
            {
                return Moving.yu_map;
            }
            set
            {
                Moving.yu_map = value;
            }
        }
        public int Lvl
        {
            get {
                if (Exp < 101)
                    return  1;
                if (Exp < 201)
                    return 2;
                if (Exp < 401)
                    return 3;
                if (Exp < 801)
                    return 4;
                if (Exp < 1601)
                    return 5;
                if (Exp < 3201)
                    return 6;
                if (Exp < 6401)
                    return 7;
                if (Exp < 12801)
                    return 8;
                if (Exp < 25601)
                    return 9;
                else
                    return 10;

            }
            set {
                
            }
        }
        public string Name { get => Db.Name; set { } }



       
    }
    public class Wizard : ICharacters
    {
        public int HP { get; set; }
        public int MaxHP
        {
            get
            {
                if (Lvl > 1)
                {
                    int MHP = 30;
                    MHP += 30 * Lvl;
                    return MHP;
                }
                else
                    return 30;
            }
            set { }
        }
        public int Attack
        {
            get
            {
                if (Lvl > 1)
                {
                    int AT = 8;
                    AT += 8 * Lvl;
                    return AT;
                }
                else
                    return 8;
            }
            set { }
        }
        public int Speed_Attack
        {
            get
            {
                if (Lvl > 1)
                {
                    int SA = 10;
                    SA += 2 * Lvl;
                    return SA;
                }
                else
                    return 10;
            }
            set { }
        }

        public int Armor
        {
            get
            {
                if (Lvl > 1)
                {
                    int A = 5;
                    A += 3 * Lvl;
                    return A;
                }
                else
                    return 5;
            }
            set { }
        }
        public int Exp { get; set; }
        public int X
        {
            get
            {
                return Moving.xu_map;
            }
            set
            {
                Moving.xu_map = value;
            }
        }
        public int Y
        {
            get
            {
                return Moving.yu_map;
            }
            set
            {
                Moving.yu_map = value;
            }
        }
        public int Lvl
        {
            get
            {
                if (Exp < 101)
                    return 1;
                if (Exp < 201)
                    return 2;
                if (Exp < 401)
                    return 3;
                if (Exp < 801)
                    return 4;
                if (Exp < 1601)
                    return 5;
                if (Exp < 3201)
                    return 6;
                if (Exp < 6401)
                    return 7;
                if (Exp < 12801)
                    return 8;
                if (Exp < 25601)
                    return 9;
                else
                    return 10;

            }
            set
            {

            }
        }
        public string Name { get => Db.Name; set { } }

    }
    public class Knight : ICharacters
    {
        public int HP { get; set; }
        public int MaxHP
        {
            get
            {
                if (Lvl > 1)
                {
                    int MHP = 60;
                    MHP += 60 * Lvl;
                    return MHP;
                }
                else
                    return 60;
            }
            set { }
        }
        public int Attack
        {
            get
            {
                if (Lvl > 1)
                {
                    int AT = 4;
                    AT += 4 * Lvl;
                    return AT;
                }
                else
                    return 4;
            }
            set { }
        }
        public int Speed_Attack
        {
            get
            {
                if (Lvl > 1)
                {
                    int SA = 15;
                    SA += 2 * Lvl;
                    return SA;
                }
                else
                    return 15;
            }
            set { }
        }

        public int Armor
        {
            get
            {
                if (Lvl > 1)
                {
                    int A = 12;
                    A += 3 * Lvl;
                    return A;
                }
                else
                    return 12;
            }
            set { }
        }
        public int Exp { get; set; }
        public int X
        {
            get
            {
                return Moving.xu_map;
            }
            set
            {
                Moving.xu_map = value;
            }
        }
        public int Y
        {
            get
            {
                return Moving.yu_map;
            }
            set
            {
                Moving.yu_map = value;
            }
        }
        public int Lvl
        {
            get
            {
                if (Exp < 101)
                    return 1;
                if (Exp < 201)
                    return 2;
                if (Exp < 401)
                    return 3;
                if (Exp < 801)
                    return 4;
                if (Exp < 1601)
                    return 5;
                if (Exp < 3201)
                    return 6;
                if (Exp < 6401)
                    return 7;
                if (Exp < 12801)
                    return 8;
                if (Exp < 25601)
                    return 9;
                else
                    return 10;

            }
            set
            {

            }
        }
        public string Name { get => Db.Name; set { } }

    }
}
