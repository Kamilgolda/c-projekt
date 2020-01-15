using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gra
{
   public class NPC
    {
        public int ID_NPC;
        public string Name;
        public Image Img;

      public async void NPC_move()
        {
            if (Name == "Major") 
            {
                for (int i = 0; i < 30; i++)
                {

                    Img.Source = new BitmapImage(new Uri(@"Skins\NPC\Major\Major_" + i + ".png", UriKind.Relative));
                    await Task.Delay(100);
                    if (i == 29) i = 0;
                }
            }
            if (Name == "Astrolog")
            {
                for (int i = 1; i < 31; i++)
                {

                    Img.Source = new BitmapImage(new Uri(@"Skins\NPC\Astrolog\Astrolog_" + i + ".png", UriKind.Relative));
                    await Task.Delay(100);
                    if (i == 30) i = 0;
                }
            }
            if (Name == "Nieznajomy")
            {
                for (int i = 1; i < 31; i++)
                {

                    Img.Source = new BitmapImage(new Uri(@"Skins\NPC\Nieznajomy\Nieznajomy_" + i + ".png", UriKind.Relative));
                    await Task.Delay(100);
                    if (i == 30) i = 0;
                }
            }
        }
    }
}
