using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using Gra;

namespace Gra
{
    public class Menu 
    {
#region Menu
        public void MTB_NickName_GotMouseCapture(object sender, MouseEventArgs e,TextBox tbNickName) //po nacisnieciu textboxa, usuwa tekst
        {
            tbNickName.Text = "";
        }

        public void MB_Rozpocznij_Click(object sender, RoutedEventArgs e,TextBox tbNickName, Grid Menu, Grid Choose_Character)
        {

            if (tbNickName.Text == "Twój Nick:" || tbNickName.Text.Length <4) 
            {
                
            }
            else
            {
                Db.Connect();
                if (Db.polaczono == true)
                {
                    Db.Check_or_add_account(tbNickName);
                    Menu.Visibility = Visibility.Hidden;
                    Choose_Character.Visibility = Visibility.Visible;
                }
                
            }
            
        }
        public void MB_Approve_Character_Click(object sender, RoutedEventArgs e,Grid Choose_Character,Grid Start_the_game,Canvas player_area,Grid mapa, System.Windows.Controls.Image player)
        {
            if (Db.Character != 0)
            {
                    Db.Check_or_add_character();
                Choose_Character.Visibility = Visibility.Collapsed;
                Start_the_game.Visibility = Visibility.Visible;
                Db.Read_Data_Character(mapa);
                Db.Save_Data_Character();
                Db.Read_NPC();
                Db.Read_Enemies();
                Db.Read_Quests();
                
                player_area.Focusable = true;
                Keyboard.Focus(player_area);
                //MessageBox.Show("X:" + Convert.ToString(Game.wojownik.X) +
                //    "Y:" + Convert.ToString(Game.wojownik.Y) +
                //    "Exp:" + Convert.ToString(Game.wojownik.Exp) +
                //    "Hp:" + Convert.ToString(Game.wojownik.HP) +
                //    "Attack:" + Convert.ToString(Game.wojownik.Attack) +
                //    "SA:" + Convert.ToString(Game.wojownik.Speed_Attack) +
                //    "Armor:" + Convert.ToString(Game.wojownik.Armor) +
                //    "Lvl:" + Convert.ToString(Game.wojownik.Lvl) +
                //    "MaxHP:" + Convert.ToString(Game.wojownik.MaxHP) +
                //     "Nazwa:" + Convert.ToString(Game.wojownik.Name));
                if (Db.Character == 1)
                {
                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Back\0_Warrior_Run_0.png", UriKind.Relative));
                   
                }
                if (Db.Character == 2)
                {
                    player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\0.png", UriKind.Relative));

                }
                if (Db.Character == 3)
                {
                    player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\0.png", UriKind.Relative));

                }

            }
            else
            {
                MessageBox.Show("Wybierz POSTAC !");
            }

            
        }

         public void MB_Ustawienia_Click(object sender, RoutedEventArgs e,Grid Menu,Grid Ustawienia) //wlacz ustawienia
        {
            Menu.Visibility = Visibility.Hidden;
            Ustawienia.Visibility = Visibility.Visible;
        }

        public void MB_wstecz_Click(object sender, RoutedEventArgs e,Grid Ustawienia,Grid Menu) // Wróc do menu z ustawien
        {
            Ustawienia.Visibility = Visibility.Collapsed;
             Menu.Visibility = Visibility.Visible;
        }
        public void MB_zamknij_Click(object sender, RoutedEventArgs e, Window nazwa) // zamknij program
        {
            nazwa.Close();
        }
        #endregion
    }
}
