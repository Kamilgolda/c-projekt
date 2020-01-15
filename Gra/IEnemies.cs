using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gra
{
    interface IEnemies
    {
        int ID_Enemy { get; set; }
        string Name { get; set; }
        int HP { get; set; }
        int Attack { get; set; }
        int Speed_Attack { get; set; }
        int Armor { get; set; }
        int Lvl { get; set; }
        int Exp_drop { get; set; }
        
    }
    public class Enemy:IEnemies
    {
       public int ID_Enemy { get; set; }
       public string Name { get; set; }
       public int HP { get; set; }
       public int Attack { get; set; }
       public int Speed_Attack { get; set; }
       public int Armor { get; set; }
       public int Lvl { get; set; }
       public int Exp_drop { get; set; }
        public Image Img;
        public Grid Grid;

       public Enemy(int id,string n,int hp,int at,int sa,int a,int lvl,int exp)
        {
            ID_Enemy = id;
            Name = n;
            HP = hp;
            Attack = at;
            Speed_Attack = sa;
            Armor = a;
            Lvl = lvl;
            Exp_drop = exp;
                
        }
       public Enemy()
        {

        }
        public async void Enemy_move()
        {
            if (Name == "Wściekły Pies")
            {
                for (int i = 1; i < 7; i++)
                {

                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Pies\dog_" + i + ".png", UriKind.Relative));
                    await Task.Delay(300);
                    if (i == 6)
                    {
                        for (int k = 1; k < 7; k++)
                        {
                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Pies\dog_" + k + ".png", UriKind.Relative));
                            await Task.Delay(300);
                           
                            if(k==6)
                            {
                                for (int l = 1; l < 7; l++)
                                {
                                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Pies\dog_right_" + l + ".png", UriKind.Relative));
                                    int x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                    int y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                    Canvas.SetLeft(Grid, x + 10);
                                    // Canvas.SetBottom(Img, y + 5);
                                    await Task.Delay(100);
                                    if(l==6)
                                    {
                                        for (int m = 1; m < 7; m++)
                                        {
                                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Pies\dog_left_" + m + ".png", UriKind.Relative));
                                            x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                            y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                            Canvas.SetLeft(Grid, x - 10);
                                            // Canvas.SetBottom(Img, y + 5);
                                            await Task.Delay(100);
                                            
                                        }
                                        i = 0;
                                    }                                 
                                }
                            }
                        }                      
                    }
                }
            }

            if (Name == "Smutny Lejeń")
            {
                for (int i = 1; i < 11; i++)
                {

                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Jelen\jelen_" + i + ".png", UriKind.Relative));
                    await Task.Delay(100);
                    if (i == 10)
                    {
                        for (int k = 11; k < 21; k++)
                        {
                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Jelen\jelen_" + k + ".png", UriKind.Relative));
                            await Task.Delay(100);

                            if (k == 20)
                            {
                                for (int l = 1; l < 9; l++)
                                {
                                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Jelen\jelen_right_" + l + ".png", UriKind.Relative));
                                    int x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                    int y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                    Canvas.SetLeft(Grid, x + 10);
                                    // Canvas.SetBottom(Img, y + 5);
                                    await Task.Delay(100);
                                    if (l == 8)
                                    {
                                        for (int m = 1; m < 9; m++)
                                        {
                                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Jelen\jelen_left_" + m + ".png", UriKind.Relative));
                                            x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                            y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                            Canvas.SetLeft(Grid, x - 10);
                                            // Canvas.SetBottom(Img, y + 5);
                                            await Task.Delay(100);

                                        }
                                        i = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Name == "Kurczak Somsiada")
            {
                for (int i = 1; i < 11; i++)
                {

                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Kurczak\kurczak_1.png", UriKind.Relative));
                    await Task.Delay(100);
                    if (i == 10)
                    {
                                for (int l = 1; l < 4; l++)
                                {
                                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Kurczak\kurczak_right_" + l + ".png", UriKind.Relative));
                                    int x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                    int y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                    Canvas.SetLeft(Grid, x + 10);
                                    // Canvas.SetBottom(Img, y + 5);
                                    await Task.Delay(100);
                                    if (l == 3)
                                    {
                                        for (int m = 1; m < 4; m++)
                                        {
                                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Kurczak\kurczak_left_" + m + ".png", UriKind.Relative));
                                            x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                            y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                            Canvas.SetLeft(Grid, x - 10);
                                            // Canvas.SetBottom(Img, y + 5);
                                            await Task.Delay(100);

                                        }
                                        i = 0;
                                    }
                                }
                            
                     }
                    
                }
            }
            if (Name == "Głodny Dzik")
            {
                for (int i = 1; i < 9; i++)
                {

                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Dzik\dzik_" + i + ".png", UriKind.Relative));
                    await Task.Delay(100);
                    if (i == 8)
                    {
                        for (int k = 1; k < 9; k++)
                        {
                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Dzik\dzik_" + k + ".png", UriKind.Relative));
                            await Task.Delay(100);

                            if (k == 8)
                            {
                                for (int l = 1; l < 7; l++)
                                {
                                    Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Dzik\dzik_right_" + l + ".png", UriKind.Relative));
                                    int x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                    int y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                    Canvas.SetLeft(Grid, x + 10);
                                    // Canvas.SetBottom(Img, y + 5);
                                    await Task.Delay(100);
                                    if (l == 6)
                                    {
                                        for (int m = 1; m < 7; m++)
                                        {
                                            Img.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Skins\Enemies\Dzik\dzik_left_" + m + ".png", UriKind.Relative));
                                            x = Convert.ToInt32(Canvas.GetLeft(Grid));
                                            y = Convert.ToInt32(Canvas.GetBottom(Grid));
                                            Canvas.SetLeft(Grid, x - 10);
                                            // Canvas.SetBottom(Img, y + 5);
                                            await Task.Delay(100);

                                        }
                                        i = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
