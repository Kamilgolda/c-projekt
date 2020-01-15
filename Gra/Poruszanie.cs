using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Threading;

namespace Gra
{
    public class Moving
    {

        private static string Current_Directory = System.IO.Directory.GetCurrentDirectory();
        private readonly Bitmap collision_map_bitmap =new Bitmap(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"maps\collision_map.png"); 
        private int x; // x gracza
        private int y; // y gracza
        public static int xu_map=653; //x gracza wzgledem mapy
        public static int yu_map=400; //y gracza wzgledem mapy
        private int x_map; //x mapy
        private int y_map; //y mapy
        private int speed=8; //predkosc poruszania sie
        public System.Windows.Controls.Image player;
        bool move = true;
        public bool oknoquest_visiblity = false;
        public bool esc_visiblity = false;

        public Moving()
        {
          
        }
      
        #region map movement
           private void Move_Map(System.Windows.Controls.Image player, Grid mapa)
           {
            x_map = Convert.ToInt32(Canvas.GetLeft(mapa));
            y_map = Convert.ToInt32(Canvas.GetBottom(mapa));
            if(x_map>=-speed)
            {
                if (y_map >= -7200 + speed)
                {
                    UP(player, mapa);
                }
                if (y_map <= -speed)
                {
                    DOWN(player, mapa);
                }
                RIGHT(player, mapa);
            }
            else if (x_map <= -10800+speed)
            {
                if (y_map >= -7200 + speed)
                {
                    UP(player, mapa);
                }

                if (y_map <= -speed)
                {
                    DOWN(player, mapa);
                }
                LEFT(player, mapa);
            }
            else if (y_map >=-speed)
            {
                UP(player, mapa);
                LEFT(player, mapa);
                RIGHT(player, mapa);
            }
            else if (y_map <= -7200+speed)
            {
                DOWN(player, mapa);
                LEFT(player, mapa);
                RIGHT(player, mapa);
            }
            else
               {
                UP(player, mapa);
                DOWN(player, mapa);
                LEFT(player, mapa);
                RIGHT(player, mapa);
            }

        }
        private void UP(System.Windows.Controls.Image player,Grid mapa)
        {
            if (y > 300)
            {
                Canvas.SetBottom(mapa, y_map -= speed);
                Canvas.SetBottom(player, y -= speed);
            }
        }
        private void DOWN(System.Windows.Controls.Image player,Grid mapa)
        {
            if (y < 300)
            {
                Canvas.SetBottom(mapa, y_map += speed);
                Canvas.SetBottom(player, y += speed);
            }
        }
        private void LEFT(System.Windows.Controls.Image player,Grid mapa)
        {
            if (x < 500)
            {
                Canvas.SetLeft(mapa, x_map += speed);
                Canvas.SetLeft(player, x += speed);
            }
        }
        private void RIGHT(System.Windows.Controls.Image player,Grid mapa)
        {
            if (x > 500)
            {
                Canvas.SetLeft(mapa, x_map -= speed);
                Canvas.SetLeft(player, x -= speed);
            }
        }
        #endregion
        #region player movement 
        public async void MPlayer_area_KeyDown(object sender, KeyEventArgs e, System.Windows.Controls.Image player, Grid mapa, Label xy, Grid Okno_quest,Grid Esc)
        {
            x = Convert.ToInt32(Canvas.GetLeft(player));
            y = Convert.ToInt32(Canvas.GetBottom(player));
            // Animation_run_up(player, e);

            switch (e.Key)
            {
                case Key.Escape:
                    {
                        if (esc_visiblity == false)
                        {
                            esc_visiblity = true;
                            Esc.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Esc.Visibility = Visibility.Hidden;
                            esc_visiblity = false;
                        }

                        break;
                    }
                case Key.N:
                    {
                        if (oknoquest_visiblity == false)
                        {
                            oknoquest_visiblity = true;
                            Okno_quest.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Okno_quest.Visibility = Visibility.Hidden;
                            oknoquest_visiblity = false;
                        }
                        break;
                    }
                case Key.W:
                    {

                        if (move == true && Is_black('w') == false)
                        {
                            move = false;
                            if(Db.Character==1)
                            {
                                speed = 8;
                            for (int i = 0; i < 15; i++)
                            {
                                if (Keyboard.IsKeyDown(Key.A) == false && Keyboard.IsKeyDown(Key.D) == false)
                                {
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Forward\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Forward\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Forward\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                }
                                yu_map += speed;
                                Canvas.SetBottom(player, y += speed);
                                Move_Map(player, mapa);



                                if (Keyboard.IsKeyDown(Key.A))
                                {


                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    xu_map -= speed;
                                    Canvas.SetLeft(player, x -= speed);
                                    Move_Map(player, mapa);

                                }

                                if (Keyboard.IsKeyDown(Key.D))
                                {
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    xu_map += speed;
                                    Canvas.SetLeft(player, x += speed);
                                    Move_Map(player, mapa);

                                }
                                i += 3;
                            }
                        }
                            if (Db.Character == 2)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)
                                {
                                    if (Keyboard.IsKeyDown(Key.A) == false && Keyboard.IsKeyDown(Key.D) == false)
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        
                                        if(i==9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }

                                    }
                                    yu_map += speed;
                                    Canvas.SetBottom(player, y += speed);
                                    Move_Map(player, mapa);



                                    if (Keyboard.IsKeyDown(Key.A))
                                    {

                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map -= speed;
                                        Canvas.SetLeft(player, x -= speed);
                                        Move_Map(player, mapa);

                                    }

                                    if (Keyboard.IsKeyDown(Key.D))
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map += speed;
                                        Canvas.SetLeft(player, x += speed);
                                        Move_Map(player, mapa);

                                    }
                                    i += 3;
                                }
                            }
                            if (Db.Character == 3)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)
                                {
                                    if (Keyboard.IsKeyDown(Key.A) == false && Keyboard.IsKeyDown(Key.D) == false)
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }

                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }

                                    }
                                    yu_map += speed;
                                    Canvas.SetBottom(player, y += speed);
                                    Move_Map(player, mapa);



                                    if (Keyboard.IsKeyDown(Key.A))
                                    {

                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map -= speed;
                                        Canvas.SetLeft(player, x -= speed);
                                        Move_Map(player, mapa);

                                    }

                                    if (Keyboard.IsKeyDown(Key.D))
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map += speed;
                                        Canvas.SetLeft(player, x += speed);
                                        Move_Map(player, mapa);

                                    }
                                    i += 3;
                                }
                            }
                            move = true;
                        }
                        e.Handled = true;
                        break;
                    }


                case Key.S:
                    {

                        if (move == true && Is_black('s') == false)
                        {

                            move = false;
                            if (Db.Character == 1)                    
                            {
                                speed = 8;
                                for (int i = 0; i < 15; i++)
                                
                                    {
                                        if (Keyboard.IsKeyDown(Key.A) == false && Keyboard.IsKeyDown(Key.D) == false)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Back\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Back\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Back\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        yu_map -= speed;
                                        Canvas.SetBottom(player, y -= speed);
                                        Move_Map(player, mapa);

                                        if (Keyboard.IsKeyDown(Key.A))
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            xu_map -= speed;
                                            Canvas.SetLeft(player, x -= speed);
                                            Move_Map(player, mapa);

                                        }

                                        if (Keyboard.IsKeyDown(Key.D))
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            xu_map += speed;
                                            Canvas.SetLeft(player, x += speed);
                                            Move_Map(player, mapa);
                                        }
                                        i += 3;
                                    } 
                                }
                            if (Db.Character == 2)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)

                                {
                                    if (Keyboard.IsKeyDown(Key.A) == false && Keyboard.IsKeyDown(Key.D) == false)
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }

                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                    }
                                    yu_map -= speed;
                                    Canvas.SetBottom(player, y -= speed);
                                    Move_Map(player, mapa);

                                    if (Keyboard.IsKeyDown(Key.A))
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map -= speed;
                                        Canvas.SetLeft(player, x -= speed);
                                        Move_Map(player, mapa);

                                    }

                                    if (Keyboard.IsKeyDown(Key.D))
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map += speed;
                                        Canvas.SetLeft(player, x += speed);
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }
                            if (Db.Character == 3)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)

                                {
                                    if (Keyboard.IsKeyDown(Key.A) == false && Keyboard.IsKeyDown(Key.D) == false)
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }

                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Back_Forward\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                    }
                                    yu_map -= speed;
                                    Canvas.SetBottom(player, y -= speed);
                                    Move_Map(player, mapa);

                                    if (Keyboard.IsKeyDown(Key.A))
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map -= speed;
                                        Canvas.SetLeft(player, x -= speed);
                                        Move_Map(player, mapa);

                                    }

                                    if (Keyboard.IsKeyDown(Key.D))
                                    {
                                        if (i < 7)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + (i + 1) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + (i + 2) + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        if (i == 9)
                                        {
                                            player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + i + ".png", UriKind.Relative));
                                            await Task.Delay(10);
                                        }
                                        xu_map += speed;
                                        Canvas.SetLeft(player, x += speed);
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }


                            move = true;

                        }
                        e.Handled = true;
                        break;
                    }

                case Key.A:
                    {

                        if (move == true && Is_black('a') == false)
                        {
                            move = false;
                            if (Db.Character == 1)
                            {
                                speed = 8;
                                for (int i = 0; i < 15; i++)
                                {


                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Left\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                    await Task.Delay(10);

                                    xu_map -= speed;
                                    Canvas.SetLeft(player, x -= speed);
                                    Move_Map(player, mapa);


                                    if (Keyboard.IsKeyDown(Key.W))
                                    {
                                        yu_map += speed;
                                        Canvas.SetBottom(player, y += speed);
                                        Move_Map(player, mapa);
                                    }
                                    if (Keyboard.IsKeyDown(Key.S))
                                    {
                                        yu_map -= speed;
                                        Canvas.SetBottom(player, y -= speed);
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                        }
                            if (Db.Character == 2)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)
                                {


                                    if (i < 7)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + (i + 1) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + (i + 2) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }
                                    if (i == 9)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Left\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }

                                    xu_map -= speed;
                                    Canvas.SetLeft(player, x -= speed);
                                    Move_Map(player, mapa);


                                    if (Keyboard.IsKeyDown(Key.W))
                                    {
                                        yu_map += speed;
                                        Canvas.SetBottom(player, y += speed);
                                        Move_Map(player, mapa);
                                    }
                                    if (Keyboard.IsKeyDown(Key.S))
                                    {
                                        yu_map -= speed;
                                        Canvas.SetBottom(player, y -= speed);
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }
                            if (Db.Character == 3)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)
                                {


                                    if (i < 7)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + (i + 1) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + (i + 2) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }
                                    if (i == 9)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Left\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }

                                    xu_map -= speed;
                                    Canvas.SetLeft(player, x -= speed);
                                    Move_Map(player, mapa);


                                    if (Keyboard.IsKeyDown(Key.W))
                                    {
                                        yu_map += speed;
                                        Canvas.SetBottom(player, y += speed);
                                        Move_Map(player, mapa);
                                    }
                                    if (Keyboard.IsKeyDown(Key.S))
                                    {
                                        yu_map -= speed;
                                        Canvas.SetBottom(player, y -= speed);
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }

                            move = true;
                        }
                        e.Handled = true;
                        break;
                    }

                case Key.D:
                    {

                        if (move == true && Is_black('d') == false)
                        {
                            move = false;
                            if (Db.Character == 1)
                            {
                                speed = 8;
                                for (int i = 0; i < 15; i++)
                                {

                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + i + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + (i + 1) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    player.Source = new BitmapImage(new Uri(@"Skins\Warrior\Run\Right\0_Warrior_Run_" + (i + 2) + ".png", UriKind.Relative));
                                    await Task.Delay(10);
                                    xu_map += speed;
                                    Canvas.SetLeft(player, x += speed);
                                    Move_Map(player, mapa);


                                    if (Keyboard.IsKeyDown(Key.W))
                                    {
                                        Canvas.SetBottom(player, y += speed);
                                        yu_map += speed;
                                        Move_Map(player, mapa);
                                    }
                                    if (Keyboard.IsKeyDown(Key.S))
                                    {
                                        Canvas.SetBottom(player, y -= speed);
                                        yu_map -= speed;
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }
                            if (Db.Character == 2)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)
                                {

                                    if (i < 7)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + (i + 1) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + (i + 2) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }
                                    if (i == 9)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Wizard\Run\Right\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }
                                    xu_map += speed;
                                    Canvas.SetLeft(player, x += speed);
                                    Move_Map(player, mapa);


                                    if (Keyboard.IsKeyDown(Key.W))
                                    {
                                        Canvas.SetBottom(player, y += speed);
                                        yu_map += speed;
                                        Move_Map(player, mapa);
                                    }
                                    if (Keyboard.IsKeyDown(Key.S))
                                    {
                                        Canvas.SetBottom(player, y -= speed);
                                        yu_map -= speed;
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }
                            if (Db.Character == 3)
                            {
                                speed = 7;
                                for (int i = 0; i < 10; i++)
                                {

                                    if (i < 7)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + (i + 1) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + (i + 2) + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }
                                    if (i == 9)
                                    {
                                        player.Source = new BitmapImage(new Uri(@"Skins\Knight\Run\Right\" + i + ".png", UriKind.Relative));
                                        await Task.Delay(10);
                                    }
                                    xu_map += speed;
                                    Canvas.SetLeft(player, x += speed);
                                    Move_Map(player, mapa);


                                    if (Keyboard.IsKeyDown(Key.W))
                                    {
                                        Canvas.SetBottom(player, y += speed);
                                        yu_map += speed;
                                        Move_Map(player, mapa);
                                    }
                                    if (Keyboard.IsKeyDown(Key.S))
                                    {
                                        Canvas.SetBottom(player, y -= speed);
                                        yu_map -= speed;
                                        Move_Map(player, mapa);
                                    }
                                    i += 3;
                                }
                            }
                            move = true;
                        }
                        e.Handled = true;
                        break;
                    }

            }
            xy.Content = xu_map + " " + yu_map;
        }
            bool Is_black(char kierunek)
            {
               Color pixelcolor;
                int i = 0;
                int k = 0;

                if (kierunek == 'w')
                {
                    while (k < 32)
                    {
                        while (i < 80)
                        {
                            pixelcolor = collision_map_bitmap.GetPixel((xu_map - 40) + i, 8000 - ((yu_map - k)));
                            if (pixelcolor.R == 0 && pixelcolor.G == 0 && pixelcolor.B == 0)
                                return true;
                            i++;
                        }
                        i = 0;
                        k++;
                    }
                }
                if (kierunek == 's')
                {
                    while (k < 32)
                    {
                        while (i < 80)
                        {
                            pixelcolor = collision_map_bitmap.GetPixel((xu_map - 40) + i, 8000 - ((yu_map -55)-k));
                            if (pixelcolor.R == 0 && pixelcolor.G == 0 && pixelcolor.B == 0)
                                return true;

                            i++;
                        }
                        i = 0;
                        k++;
                    }
                }
                if (kierunek == 'a')
                {
                    while (k < 32)
                    {
                        while (i < 60)
                        {
                            pixelcolor = collision_map_bitmap.GetPixel((xu_map - 40) - k, 8000 - ((yu_map) - i));
                            if (pixelcolor.R == 0 && pixelcolor.G == 0 && pixelcolor.B == 0)
                                return true;

                            i++;
                        }
                        i = 0;
                        k++;
                    }
                }
                if (kierunek == 'd')
                {
                    while (k < 32)
                    {
                        while (i < 60)
                        {
                            pixelcolor = collision_map_bitmap.GetPixel((xu_map + 40) + k, 8000 - ((yu_map) - i));
                            if (pixelcolor.R == 0 && pixelcolor.G == 0 && pixelcolor.B == 0)
                                return true;

                            i++;
                        }
                        i = 0;
                        k++;
                    }
                }
                return false;

            }
 
            #endregion
            

        }
        
        }


