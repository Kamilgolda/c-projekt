using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Windows.Threading;

namespace Gra
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        Menu m = new Menu();
        Moving mov = new Moving();
        //CHARACTERS
        public static Wojownik wojownik;
        public static Wizard wizard;
        public static Knight knight;
        //QUESTS
        public static List<Quests> Quests_list = new List<Quests>();
        public static List<Quests> Accepted_quests_list = new List<Quests>();
        public static Quests Cquest;
        //NPC
        public static List<NPC> NPC_list = new List<NPC>();
        //ENEMIES
        public static List<Enemy> Enemy_list = new List<Enemy>();
        //SOUND
        public MediaPlayer music_player = new MediaPlayer();
        public MediaPlayer quest_player = new MediaPlayer();
        int music_player_l = 0;
        //KATALOG GRY
        private static string Current_Directory = System.IO.Directory.GetCurrentDirectory();
        //WALKA
        bool Atak_C = false;
        bool Silny_Atak_C = false;




        public Game()
        {

            InitializeComponent();
            Play_Music();
         //   tbNickName.Focus();





        }

        #region Menu
        private void TB_NickName_GotMouseCapture(object sender, MouseEventArgs e) {

            m.MTB_NickName_GotMouseCapture(sender, e, tbNickName);
        }

        public void B_Rozpocznij_Click(object sender, RoutedEventArgs e) {

            m.MB_Rozpocznij_Click(sender, e, tbNickName, Menu, Choose_Character);
            
        }


        private void Character1_Click(object sender, RoutedEventArgs e)
        {
            Db.Character = 1;
            Character1.Opacity = 0.5;
            Character2.Opacity = 1;
            Character3.Opacity = 1;
        }

        private void Character2_Click(object sender, RoutedEventArgs e)
        {
            Db.Character = 2;
            Character2.Opacity = 0.5;
            Character1.Opacity = 1;
            Character3.Opacity = 1;
        }

        private void Character3_Click(object sender, RoutedEventArgs e)
        {
            Db.Character = 3;
            Character3.Opacity = 0.5;
            Character2.Opacity = 1;
            Character1.Opacity = 1;
        }


        public void B_Approve_Character_Click(object sender, RoutedEventArgs e)
        {
            //  player.Source = new BitmapImage(new Uri(@"Skins /0_Warrior_Idle Blinking_000.png", UriKind.Relative));
            m.MB_Approve_Character_Click(sender, e, Choose_Character, Start_the_game, player_area, mapa, player);
            mov.player = player;
            NPC_set_img_and_move();
            Enemies_set_img_and_move();
            load_statistics();
            load_quests();
            Play_Music();
            
        }

        public void B_Ustawienia_Click(object sender, RoutedEventArgs e)
        {
            m.MB_Ustawienia_Click(sender, e, Menu, Ustawienia);

        }
        public void B_wstecz_Click(object sender, RoutedEventArgs e)
        {
            m.MB_wstecz_Click(sender, e, Ustawienia, Menu);
        }
        public void B_zamknij_Click(object sender, RoutedEventArgs e)
        {
            m.MB_zamknij_Click(sender, e, Game123);

        }

        #endregion

        #region ładowanie statystyk
        public void load_statistics()
        {
            if (Db.Character == 1)
            {
                //BANER
                Hp_Game.Content = "HP: " + (wojownik.HP).ToString();
                Attack_Game.Content = "Attack: " + (wojownik.Attack).ToString();
                Armor_Game.Content = "Armor: " + (wojownik.Armor).ToString();
                SpeedAttack_Game.Content = " Speed Attack: " + (wojownik.Speed_Attack).ToString();
                Lvl_Game.Content = (wojownik.Lvl).ToString();
                Exp_Game.Content = "EXP: " + (wojownik.Exp).ToString();
                player_name.Content = wojownik.Name + " LVL " + wojownik.Lvl;

                //zmiana pasków zdriowia/exp
                //HP
                float hp = Convert.ToInt32((wojownik.HP));
                float maxhp = Convert.ToInt32((wojownik.MaxHP));
                float procent = ((1 - (hp / maxhp)) * 366) + 716;
                BarHp.Margin = new Thickness(116, 1.98, procent, 772);


                //EXP
                float pr1;
                float Exp = Convert.ToInt32((wojownik.Exp));


                if (Exp < 101)
                {
                    pr1 = ((1 - (Exp / 101)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }

                if (Exp < 201 && Exp > 100)
                {
                    Exp = Exp - 100;
                    pr1 = ((1 - (Exp / 101)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 401 && Exp > 200)
                {
                    Exp = Exp - 200;
                    pr1 = ((1 - (Exp / 200)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);


                }
                if (Exp < 801 && Exp > 400)
                {
                    Exp = Exp - 400;
                    pr1 = ((1 - (Exp / 401)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 1601 && Exp > 800)
                {
                    Exp = Exp - 800;
                    pr1 = ((1 - (Exp / 800)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 3201 && Exp > 1600)
                {
                    Exp = Exp - 1600;
                    pr1 = ((1 - (Exp / 1600)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 6401 && Exp > 3200)
                {
                    Exp = Exp - 3200;
                    pr1 = ((1 - (Exp / 3200)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 12801 && Exp > 6400)
                {
                    Exp = Exp - 6400;
                    pr1 = ((1 - (Exp / 6400)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 25601 && Exp > 12800)
                {
                    Exp = Exp - 12800;
                    pr1 = ((1 - (Exp / 12800)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }




            }
            if (Db.Character == 2)
            {
                //BANER
                Hp_Game.Content = "HP: " + (wizard.HP).ToString();
                Attack_Game.Content = "Attack: " + (wizard.Attack).ToString();
                Armor_Game.Content = "Armor: " + (wizard.Armor).ToString();
                SpeedAttack_Game.Content = " Speed Attack: " + (wizard.Speed_Attack).ToString();
                Lvl_Game.Content = (wizard.Lvl).ToString();
                Exp_Game.Content = "EXP: " + (wizard.Exp).ToString();
                //Oknowalki
                hpstat.Content = (wizard.HP).ToString();
                lvlstat.Content = (wizard.Lvl).ToString() + "Lvl";
                nickstat.Content = (wizard.Name).ToString();
                // expstat.Content = (postac2.Exp).ToString();
                sastat.Content = (wizard.Speed_Attack).ToString();
                armorstat.Content = (wizard.Armor).ToString();
                attackstat.Content = (wizard.Attack).ToString();

                //zmiana pasków zdriowia/exp
                //HP
                float hp = Convert.ToInt32((wizard.HP));
                float maxhp = Convert.ToInt32((wizard.MaxHP));
                float procent = ((1 - (hp / maxhp)) * 366) + 716;
                BarHp.Margin = new Thickness(116, 1.98, procent, 772);


                //EXP
                float pr1;
                float Exp = Convert.ToInt32((wizard.Exp));


                if (Exp < 101)
                {
                    pr1 = ((1 - (Exp / 101)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }

                if (Exp < 201 && Exp > 100)
                {
                    Exp = Exp - 100;
                    pr1 = ((1 - (Exp / 101)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 401 && Exp > 200)
                {
                    Exp = Exp - 200;
                    pr1 = ((1 - (Exp / 200)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);


                }
                if (Exp < 801 && Exp > 400)
                {
                    Exp = Exp - 400;
                    pr1 = ((1 - (Exp / 401)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 1601 && Exp > 800)
                {
                    Exp = Exp - 800;
                    pr1 = ((1 - (Exp / 800)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 3201 && Exp > 1600)
                {
                    Exp = Exp - 1600;
                    pr1 = ((1 - (Exp / 1600)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 6401 && Exp > 3200)
                {
                    Exp = Exp - 3200;
                    pr1 = ((1 - (Exp / 3200)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 12801 && Exp > 6400)
                {
                    Exp = Exp - 6400;
                    pr1 = ((1 - (Exp / 6400)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 25601 && Exp > 12800)
                {
                    Exp = Exp - 12800;
                    pr1 = ((1 - (Exp / 12800)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }

            }
            if (Db.Character == 3)
            {
                //BANER
                Hp_Game.Content = "HP: " + (knight.HP).ToString();
                Attack_Game.Content = "Attack: " + (knight.Attack).ToString();
                Armor_Game.Content = "Armor: " + (knight.Armor).ToString();
                SpeedAttack_Game.Content = " Speed Attack: " + (knight.Speed_Attack).ToString();
                Lvl_Game.Content = (knight.Lvl).ToString();
                Exp_Game.Content = "EXP: " + (knight.Exp).ToString();
                //Oknowalki
                hpstat.Content = (knight.HP).ToString();
                lvlstat.Content = (knight.Lvl).ToString() + "Lvl";
                nickstat.Content = (knight.Name).ToString();
                //expstat.Content = (postac3.Exp).ToString();
                sastat.Content = (knight.Speed_Attack).ToString();
                armorstat.Content = (knight.Armor).ToString();
                attackstat.Content = (knight.Attack).ToString();

                //zmiana pasków zdriowia/exp
                //HP
                float hp = Convert.ToInt32((knight.HP));
                float maxhp = Convert.ToInt32((knight.MaxHP));
                float procent = ((1 - (hp / maxhp)) * 366) + 716;
                BarHp.Margin = new Thickness(116, 1.98, procent, 772);


                //EXP
                float pr1;
                float Exp = Convert.ToInt32((knight.Exp));


                if (Exp < 101)
                {
                    pr1 = ((1 - (Exp / 101)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }

                if (Exp < 201 && Exp > 100)
                {
                    Exp = Exp - 100;
                    pr1 = ((1 - (Exp / 101)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 401 && Exp > 200)
                {
                    Exp = Exp - 200;
                    pr1 = ((1 - (Exp / 200)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);


                }
                if (Exp < 801 && Exp > 400)
                {
                    Exp = Exp - 400;
                    pr1 = ((1 - (Exp / 401)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 1601 && Exp > 800)
                {
                    Exp = Exp - 800;
                    pr1 = ((1 - (Exp / 800)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 3201 && Exp > 1600)
                {
                    Exp = Exp - 1600;
                    pr1 = ((1 - (Exp / 1600)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 6401 && Exp > 3200)
                {
                    Exp = Exp - 3200;
                    pr1 = ((1 - (Exp / 3200)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 12801 && Exp > 6400)
                {
                    Exp = Exp - 6400;
                    pr1 = ((1 - (Exp / 6400)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }
                if (Exp < 25601 && Exp > 12800)
                {
                    Exp = Exp - 12800;
                    pr1 = ((1 - (Exp / 12800)) * 366) + 19;
                    BarExp.Margin = new Thickness(815, 4.18, pr1, 771.82);

                }

            }

        } 
        #endregion

        #region moving
        private void Player_area_KeyDown(object sender, KeyEventArgs e)
        {
            mov.MPlayer_area_KeyDown(sender, e, player, mapa, xy,Okno_quest,Esc);
        }
        #endregion
        #region Przypisanie img i gridow dla NPC i ENEMIES
        private void NPC_set_img_and_move()
        {
            foreach (NPC item in NPC_list)
            {
                if (item.Name == "Major")
                {
                    item.Img = npc0;
                    item.NPC_move();
                }

                if (item.Name == "Zubr") item.Img = npc1;
                // item.NPC_move();
                if (item.Name == "Astrolog")
                {
                    item.Img = npc2;
                    item.NPC_move();
                }
                if (item.Name == "Nieznajomy")
                {
                    item.Img = npc3;
                    item.NPC_move();
                }
            }
        }
        private void Enemies_set_img_and_move()
        {
            Random rand = new Random();
            Enemy dog = null;
            Enemy boar = null;
            Enemy deer = null;
            Enemy chicken = null;
            System.Windows.Controls.Image[] dogs = new System.Windows.Controls.Image[10];
            dogs[0] = dog0;
            dogs[1] = dog1;
            dogs[2] = dog2;
            dogs[3] = dog3;
            dogs[4] = dog4;
            dogs[5] = dog5;
            dogs[6] = dog6;
            dogs[7] = dog7;
            dogs[8] = dog8;
            dogs[9] = dog9;

            System.Windows.Controls.Image[] boars = new System.Windows.Controls.Image[10];
            boars[0] = boar0;
            boars[1] = boar1;
            boars[2] = boar2;
            boars[3] = boar3;
            boars[4] = boar4;
            boars[5] = boar5;
            boars[6] = boar6;
            boars[7] = boar7;
            boars[8] = boar8;
            boars[9] = boar9;

            System.Windows.Controls.Image[] deers = new System.Windows.Controls.Image[10];
            deers[0] = deer0;
            deers[1] = deer1;
            deers[2] = deer2;
            deers[3] = deer3;
            deers[4] = deer4;
            deers[5] = deer5;
            deers[6] = deer6;
            deers[7] = deer7;
            deers[8] = deer8;
            deers[9] = deer9;

            System.Windows.Controls.Image[] chickens = new System.Windows.Controls.Image[6];
            chickens[0] = chicken0;
            chickens[1] = chicken1;
            chickens[2] = chicken2;
            chickens[3] = chicken3;
            chickens[4] = chicken4;
            chickens[5] = chicken5;

            Grid[] dogs_g = new Grid[10];
            dogs_g[0] = dog0_g;
            dogs_g[1] = dog1_g;
            dogs_g[2] = dog2_g;
            dogs_g[3] = dog3_g;
            dogs_g[4] = dog4_g;
            dogs_g[5] = dog5_g;
            dogs_g[6] = dog6_g;
            dogs_g[7] = dog7_g;
            dogs_g[8] = dog8_g;
            dogs_g[9] = dog9_g;

            Grid[] boars_g = new Grid[10];
            boars_g[0] = boar0_g;
            boars_g[1] = boar1_g;
            boars_g[2] = boar2_g;
            boars_g[3] = boar3_g;
            boars_g[4] = boar4_g;
            boars_g[5] = boar5_g;
            boars_g[6] = boar6_g;
            boars_g[7] = boar7_g;
            boars_g[8] = boar8_g;
            boars_g[9] = boar9_g;

            Grid[] deers_g = new Grid[10];
            deers_g[0] = deer0_g;
            deers_g[1] = deer1_g;
            deers_g[2] = deer2_g;
            deers_g[3] = deer3_g;
            deers_g[4] = deer4_g;
            deers_g[5] = deer5_g;
            deers_g[6] = deer6_g;
            deers_g[7] = deer7_g;
            deers_g[8] = deer8_g;
            deers_g[9] = deer9_g;

            Grid[] chickens_g = new Grid[6];
            chickens_g[0] = chicken0_g;
            chickens_g[1] = chicken1_g;
            chickens_g[2] = chicken2_g;
            chickens_g[3] = chicken3_g;
            chickens_g[4] = chicken4_g;
            chickens_g[5] = chicken5_g;
            int i = 0;
            foreach (Enemy item in Enemy_list)
            {
                if (item.Name == "Wściekły Pies")
                    dog = item;
                if (item.Name == "Smutny Lejeń")
                    deer = item;
                if (item.Name == "Głodny Dzik")
                    boar = item;
                if (item.Name == "Kurczak Somsiada")
                    chicken = item;

            }
            for (int k = 0; k < 9; k++)
            {
                Game.Enemy_list.Add(new Enemy(dog.ID_Enemy, dog.Name, dog.HP, dog.Attack, dog.Speed_Attack, dog.Armor, dog.Lvl, dog.Exp_drop));
                Game.Enemy_list.Add(new Enemy(deer.ID_Enemy, deer.Name, deer.HP, deer.Attack, deer.Speed_Attack, deer.Armor, deer.Lvl, deer.Exp_drop));
                Game.Enemy_list.Add(new Enemy(boar.ID_Enemy, boar.Name, boar.HP, boar.Attack, boar.Speed_Attack, boar.Armor, boar.Lvl, boar.Exp_drop));
            }
            for (int l = 0; l < 5; l++)
            {
                Game.Enemy_list.Add(new Enemy(chicken.ID_Enemy, chicken.Name, chicken.HP, chicken.Attack, chicken.Speed_Attack, chicken.Armor, chicken.Lvl, chicken.Exp_drop));
            }

            foreach (Enemy item in Enemy_list)
            {
                if (item.Name == "Wściekły Pies")
                {
                    item.Img = dogs[i];
                    item.Grid = dogs_g[i];
                    i++;
                    item.Enemy_move();
                }

            }
            i = 0;
            foreach (Enemy item in Enemy_list)
            {
                if (item.Name == "Smutny Lejeń")
                {
                    item.Img = deers[i];
                    item.Grid = deers_g[i];
                    i++;
                    item.Enemy_move();
                }

            }
            i = 0;
            foreach (Enemy item in Enemy_list)
            {
                if (item.Name == "Głodny Dzik")
                {
                    item.Img = boars[i];
                    item.Grid = boars_g[i];
                    i++;
                    item.Enemy_move();
                }

            }
            i = 0;
            foreach (Enemy item in Enemy_list)
            {
                if (item.Name == "Kurczak Somsiada")
                {
                    item.Img = chickens[i];
                    item.Grid = chickens_g[i];
                    i++;
                    item.Enemy_move();
                }
            }
            Array.Clear(dogs, 0, 10);
            Array.Clear(dogs_g, 0, 10);
            Array.Clear(deers, 0, 10);
            Array.Clear(deers_g, 0, 10);
            Array.Clear(boars, 0, 10);
            Array.Clear(boars_g, 0, 10);
            Array.Clear(chickens, 0, 6);
            Array.Clear(chickens_g, 0, 6);

        } 
        #endregion
        #region Questy/Rozmowa z npc
        private async void Npc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Talk.Visibility = Visibility.Visible;
            int done = 0;
            ZaakceptujQ.Visibility = Visibility.Visible;
            OdrzućQ.Content = "Odrzuć";
            ICharacters gracz = null;
            if (Db.Character == 1) gracz = wojownik;
            if (Db.Character == 2) gracz = wizard;
            if (Db.Character == 3) gracz = knight;
            foreach (NPC item in NPC_list)
            {
                if (sender == item.Img)
                {

                    foreach (Quests quest in Quests_list)
                    {
                        if (quest.ID_NPC == item.ID_NPC)
                        {
                            foreach (Quests dq in Accepted_quests_list)
                            {
                                if (dq.ID_Quest == quest.ID_Quest)
                                {
                                    if (dq.Done == 1)
                                    {
                                        if (quest.ID_NPC == 1)
                                        {

                                            dq.Done = 2;
                                            done = dq.Done;
                                            ZaakceptujQ.Visibility = Visibility.Hidden;
                                            OdrzućQ.Content = "Zakończ Zadanie";

                                            quest_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Quests\major2.mp3"));
                                            quest_player.Volume = 1;
                                            quest_player.Play();
                                            quest.Progress = "1/1";
                                            string tekst = "Ktoś wymyślił ziemię. Słońce ? Słońce się obraca na... Na czym się obraca ? Na płaskim ? To on był orbitem ! Musiałoby mieć sto lat. To musi być coś okrągłego. Pewne rzeczy świat nauczył mnie";
                                            TekstQ_short.Text = "Nagroda: 100EXP";
                                            gracz.Exp += quest.Exp;
                                            if (Db.Character == 1) wojownik.HP = wojownik.MaxHP;
                                            if (Db.Character == 2) wizard.HP = wizard.MaxHP;
                                            if (Db.Character == 3) knight.HP = knight.MaxHP;
                                            load_statistics();
                                            string tekst3 = "";

                                            for (int i = 0; i < tekst.Length; i++)
                                            {

                                                tekst3 += tekst[i];
                                                TekstQ.Text = tekst3;
                                                await Task.Delay(100);
                                                q_scroll.ScrollToEnd();

                                                if (Talk.Visibility == Visibility.Hidden) break;
                                            }
                                            break;
                                        }
                                        if (quest.ID_NPC == 3)
                                        {

                                            dq.Done = 2;
                                            done = dq.Done;
                                            ZaakceptujQ.Visibility = Visibility.Hidden;
                                            OdrzućQ.Content = "Zakończ Zadanie";

                                            quest.Progress = "8/8";
                                            string tekst = "Dziekuje ! Wreszcie mogę kontynuować badania.";
                                            TekstQ_short.Text = "Nagroda: 400EXP";
                                            gracz.Exp += quest.Exp;
                                            if (Db.Character == 1) wojownik.HP = wojownik.MaxHP;
                                            if (Db.Character == 2) wizard.HP = wizard.MaxHP;
                                            if (Db.Character == 3) knight.HP = knight.MaxHP;
                                            load_statistics();
                                            string tekst3 = "";

                                            for (int i = 0; i < tekst.Length; i++)
                                            {

                                                tekst3 += tekst[i];
                                                TekstQ.Text = tekst3;
                                                await Task.Delay(100);
                                                q_scroll.ScrollToEnd();

                                                if (Talk.Visibility == Visibility.Hidden) break;
                                            }
                                            break;
                                        }
                                        if (quest.ID_NPC == 4)
                                        {

                                            dq.Done = 2;
                                            done = dq.Done;
                                            ZaakceptujQ.Visibility = Visibility.Hidden;
                                            OdrzućQ.Content = "Zakończ Zadanie";

                                            quest.Progress = "2/2";
                                            string tekst = "Wspaniale ! Przyjdź później jak skończe go przyrządzać";
                                            TekstQ_short.Text = "Nagroda: 500EXP";
                                            gracz.Exp += quest.Exp;
                                            if (Db.Character == 1) wojownik.HP = wojownik.MaxHP;
                                            if (Db.Character == 2) wizard.HP = wizard.MaxHP;
                                            if (Db.Character == 3) knight.HP = knight.MaxHP;
                                            load_statistics();
                                            string tekst3 = "";

                                            for (int i = 0; i < tekst.Length; i++)
                                            {

                                                tekst3 += tekst[i];
                                                TekstQ.Text = tekst3;
                                                await Task.Delay(100);
                                                q_scroll.ScrollToEnd();

                                                if (Talk.Visibility == Visibility.Hidden) break;
                                            }
                                            break;
                                        }

                                    }
                                    if (dq.Done == 2)
                                    {
                                        if (quest.ID_NPC == 1)
                                        {
                                            quest_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Quests\major3.mp3"));
                                            quest_player.Volume = 1;
                                            quest_player.Play();
                                            TekstQ.Text = "To jest wspaniała sprawa że tak zwierzyna jest wspaniała i elegancka.";
                                            TekstQ_short.Text = "";
                                        }
                                        if (quest.ID_NPC == 3)
                                        {
                                            TekstQ.Text = "Dziekuje za Twoją pomoc";
                                            TekstQ_short.Text = "";
                                        }
                                        if (quest.ID_NPC == 4)
                                        {

                                            TekstQ.Text = "Spróbuj tego !";
                                            TekstQ_short.Text = "";
                                            if (Db.Character == 1) wojownik.HP = wojownik.MaxHP;
                                            if (Db.Character == 2) wizard.HP = wizard.MaxHP;
                                            if (Db.Character == 3) knight.HP = knight.MaxHP;
                                            load_statistics();
                                        }
                                        done = dq.Done;
                                        ZaakceptujQ.Visibility = Visibility.Hidden;
                                        OdrzućQ.Content = "Odejdź";

                                        break;
                                    }




                                }
                            }

                            if (done == 0 && quest.ID_NPC == 1)
                            {
                                quest_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Quests\major1.mp3"));
                                quest_player.Volume = 1;
                                quest_player.Play();
                                string tekst = "";
                                string tekst2 = "";

                                Cquest = quest;
                                Cquest.Progress = "0/1";
                                npc1_g.Visibility = Visibility.Visible;
                                for (int i = 0; i < quest.Descr.Length; i++)
                                {

                                    tekst += quest.Descr[i];
                                    TekstQ.Text = tekst;
                                    await Task.Delay(100);
                                    q_scroll.ScrollToEnd();
                                    if (i < quest.Short_desc.Length)
                                    {
                                        tekst2 += quest.Short_desc[i];
                                        TekstQ_short.Text = tekst2;

                                        // await Task.Delay(100);
                                    }
                                    if (Talk.Visibility == Visibility.Hidden) break;
                                }
                                break;
                            }
                            if (done == 0 && quest.ID_NPC == 3)
                            {

                                string tekst = "";
                                string tekst2 = "";

                                Cquest = quest;
                                Cquest.Progress = "0/8";
                                for (int i = 0; i < quest.Descr.Length; i++)
                                {

                                    tekst += quest.Descr[i];
                                    TekstQ.Text = tekst;
                                    await Task.Delay(100);
                                    q_scroll.ScrollToEnd();
                                    if (i < quest.Short_desc.Length)
                                    {
                                        tekst2 += quest.Short_desc[i];
                                        TekstQ_short.Text = tekst2;

                                        // await Task.Delay(100);
                                    }
                                    if (Talk.Visibility == Visibility.Hidden) break;
                                }
                                break;
                            }
                            if (done == 0 && quest.ID_NPC == 4)
                            {

                                string tekst = "";
                                string tekst2 = "";

                                Cquest = quest;
                                Cquest.Progress = "0/2";
                                for (int i = 0; i < quest.Descr.Length; i++)
                                {

                                    tekst += quest.Descr[i];
                                    TekstQ.Text = tekst;
                                    await Task.Delay(100);
                                    q_scroll.ScrollToEnd();
                                    if (i < quest.Short_desc.Length)
                                    {
                                        tekst2 += quest.Short_desc[i];
                                        TekstQ_short.Text = tekst2;

                                        // await Task.Delay(100);
                                    }
                                    if (Talk.Visibility == Visibility.Hidden) break;
                                }
                                break;
                            }
                        }
                    }
                    if (item.ID_NPC == 2)
                    {
                        quest_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Quests\zubr.mp3"));
                        quest_player.Volume = 1;
                        quest_player.Play();
                        string tekst = "Inaczej ? OO Jak inaczej ? Major Cię przyslal ? Czy móglbys Mu to przekazac ? \n    -Otrzymujesz 'Model ruchu obiegowego Ziemi'(x1)";
                        string tekst2 = "Przekaż przedmiot Majorowi";
                        string tekst3 = "";
                        string tekst4 = "";
                        if (Db.Character == 1) wojownik.HP = wojownik.MaxHP;
                        if (Db.Character == 2) wizard.HP = wizard.MaxHP;
                        if (Db.Character == 3) knight.HP = knight.MaxHP;
                        load_statistics();
                        ZaakceptujQ.Visibility = Visibility.Hidden;
                        OdrzućQ.Content = "OK";
                        foreach (Quests quest in Game.Accepted_quests_list)
                        {
                            if (quest.ID_Quest == 1)
                            {
                                quest.Short_desc = tekst2;
                                quest.Progress = "0/1";
                                quest.Done = 1;

                                npc1.IsEnabled = false;
                                break;
                            }

                        }
                        for (int i = 0; i < tekst.Length; i++)
                        {

                            tekst3 += tekst[i];
                            TekstQ.Text = tekst3;
                            await Task.Delay(100);
                            q_scroll.ScrollToEnd();
                            if (i < tekst2.Length)
                            {

                                tekst4 += tekst2[i];
                                TekstQ_short.Text = tekst4;
                            }
                            if (Talk.Visibility == Visibility.Hidden) break;
                        }
                        await Task.Delay(300000);
                        npc1_g.Visibility = Visibility.Collapsed;
                    }
                    break;
                }


            }
        }

        private void OdrzućQ_Click(object sender, RoutedEventArgs e)
        {
            Db.Save_Progress_Quest();
            load_quests();
            TekstQ.Text = "";
            TekstQ_short.Text = "";
            quest_player.Stop();
            Talk.Visibility = Visibility.Hidden;
            player_area.Focusable = true;
            Keyboard.Focus(player_area);
        }

        private void ZaakceptujQ_Click(object sender, RoutedEventArgs e)
        {
            TekstQ.Text = "";
            TekstQ_short.Text = "";
            quest_player.Stop();
            Db.Add_or_check_quest();
            Db.Save_Progress_Quest();
            load_quests();
            Talk.Visibility = Visibility.Hidden;
            player_area.Focusable = true;
            Keyboard.Focus(player_area);
        } 
        #endregion
        #region Walka/okno walki
        private async void Enemy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Start_the_game.Visibility = Visibility.Hidden;
            OknoWalki.Visibility = Visibility.Visible;
            Play_Video();
            Random rand = new Random();
            ICharacters gracz = null;
            Enemy przeciwnik = null;
            if (Db.Character == 1) gracz = wojownik;
            if (Db.Character == 2) gracz = wizard;
            if (Db.Character == 3) gracz = knight;
            int attack_p;
            int speed_attack_p;
            int armor_p;
            int attack_e;
            int speed_attack_e;
            int armor_e;
            foreach (Enemy item in Enemy_list)
            {
                if (sender == item.Img)
                {
                    przeciwnik = item;
                    break;
                }

            }
            int HP_przeciwnika = 0;
                HP_przeciwnika+= przeciwnik.HP;
            //Oknowalki
            hpstat.Content = gracz.HP;
            lvlstat.Content = gracz.Lvl + "lvl";
            nickstat.Content = gracz.Name;
            // expstat.Content = (wojownik.Exp).ToString();
            sastat.Content = gracz.Speed_Attack;
            armorstat.Content = gracz.Armor;
            attackstat.Content = gracz.Attack;

            nickstat_e.Content = przeciwnik.Name;
            lvlstat_e.Content = przeciwnik.Lvl + "lvl";
            hpstat_e.Content = przeciwnik.HP;
            attackstat_e.Content = przeciwnik.Attack;
            armorstat_e.Content = przeciwnik.Armor;
            sastat_e.Content = przeciwnik.Speed_Attack;


            zamknijokno.IsEnabled = false;
            wyswietlacz.Text = "Rozpoczęła się walka pomiędzy " + gracz.Name + " lvl " + gracz.Lvl + " a " + przeciwnik.Name + " lvl " + przeciwnik.Lvl;
            int kto = rand.Next(0, 2);
            if (kto == 1)
            {
                await Task.Delay(1000);
                wyswietlacz.Text += "\nWalkę rozpoczyna " + przeciwnik.Name;
            }
            else
            {
                await Task.Delay(1000);
                wyswietlacz.Text += "\nWalkę rozpoczyna " + gracz.Name;


            }
            while (kto < 3)
            {
                if (kto == 1)
                {
                    Atak.IsEnabled = false;
                    Silny_Atak.IsEnabled = false;
                    int cat = rand.Next(0, 2);
                    if (cat == 0)
                    {
                        speed_attack_e = (rand.Next(0, przeciwnik.Speed_Attack + 1)) / 5;
                        armor_p = rand.Next(0, gracz.Armor + 1);
                        attack_e = rand.Next(0, przeciwnik.Attack + 1);
                        if (speed_attack_e < 1)
                        {
                            if (armor_p > attack_e)
                            {
                                wyswietlacz.Text += "\n" + przeciwnik.Name + " uderza z siłą +" + attack_e + "\n   - " + gracz.Name + " wykonuje unik ";
                                //      hpstat.Content = gracz.HP;
                                wysw_viewer.ScrollToEnd();
                                kto = 0;
                            }
                            else
                            {
                                gracz.HP -= attack_e;
                                wyswietlacz.Text += "\n" + przeciwnik.Name + " uderza z siłą +" + attack_e + "\n   - " + gracz.Name + " otrzymuje -" + attack_e + " obrażeń";
                                wysw_viewer.ScrollToEnd();
                                if (gracz.HP <= 0)
                                {
                                    hpstat.Content = 0;
                                    wyswietlacz.Text += "\n Walkę wygrywa " + przeciwnik.Name;
                                    wysw_viewer.ScrollToEnd();
                                    kto = 3;
                                }
                                else
                                {
                                    hpstat.Content = gracz.HP;
                                    kto = 0;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < speed_attack_e; i++)
                            {
                                attack_e = rand.Next(0, przeciwnik.Attack + 1);
                                armor_p = rand.Next(0, gracz.Armor + 1);
                                if (armor_p > attack_e)
                                {
                                    wyswietlacz.Text += "\n" + przeciwnik.Name + " uderza z siłą +" + attack_e + "\n   - " + gracz.Name + " wykonuje unik ";
                                    wysw_viewer.ScrollToEnd();

                                }
                                else
                                {
                                    gracz.HP -= attack_e;
                                    wyswietlacz.Text += "\n" + przeciwnik.Name + " uderza z siłą +" + attack_e + "\n   - " + gracz.Name + " otrzymuje -" + attack_e + " obrażeń";
                                    wysw_viewer.ScrollToEnd();


                                }
                            }
                            if (gracz.HP <= 0)
                            {
                                hpstat.Content = 0;
                                wyswietlacz.Text += "\n Walkę wygrywa " + przeciwnik.Name;
                                wysw_viewer.ScrollToEnd();
                                kto = 3;
                            }
                            else
                            {
                                hpstat.Content = gracz.HP;
                                kto = 0;
                            }

                        }
                    }
                    else
                    {
                        armor_p = rand.Next(0, gracz.Armor + 1);
                        attack_e = (rand.Next(0, przeciwnik.Attack + 1)) * 3;
                        if (armor_p > attack_e)
                        {
                            wyswietlacz.Text += "\n" + przeciwnik.Name + " uderza z siłą +" + attack_e + "\n   - " + gracz.Name + " wykonuje unik ";
                            wysw_viewer.ScrollToEnd();
                            kto = 0;
                        }
                        else
                        {
                            gracz.HP -= attack_e;
                            wyswietlacz.Text += "\n" + przeciwnik.Name + " uderza z siłą +" + attack_e + "\n   - " + gracz.Name + " otrzymuje -" + attack_e + " obrażeń";
                            wysw_viewer.ScrollToEnd();
                            if (gracz.HP <= 0)
                            {
                                hpstat.Content = 0;
                                wyswietlacz.Text += "\n Walkę wygrywa " + przeciwnik.Name;
                                wysw_viewer.ScrollToEnd();
                                kto = 3;
                            }
                            else
                            {
                                hpstat.Content = gracz.HP;
                                kto = 0;
                            }
                        }
                    }

                    //    kto = 0; 
                }
                else
                {
                    Atak.IsEnabled = true;
                    Silny_Atak.IsEnabled = true;
                    if (Atak_C == false && Silny_Atak_C == false)
                    {
                        await Task.Delay(1000);
                    }
                    // await Task.Delay(10000);
                    if (Atak_C == true)
                    {
                        Atak_C = false;
                        speed_attack_p = (rand.Next(0, gracz.Speed_Attack + 1)) / 5;
                        armor_e = rand.Next(0, przeciwnik.Armor + 1);
                        attack_p = rand.Next(0, gracz.Attack + 1);
                        if (speed_attack_p < 1)
                        {
                            if (armor_e > attack_p)
                            {
                                wyswietlacz.Text += "\n" + gracz.Name + " uderza z siłą +" + attack_p + "\n   - " + przeciwnik.Name + " wykonuje unik ";
                                wysw_viewer.ScrollToEnd();
                                kto = 1;
                            }
                            else
                            {
                                przeciwnik.HP -= attack_p;
                                wyswietlacz.Text += "\n" + gracz.Name + " uderza z siłą +" + attack_p + "\n   - " + przeciwnik.Name + " otrzymuje -" + attack_p + " obrażeń";
                                wysw_viewer.ScrollToEnd();
                                if (przeciwnik.HP <= 0)
                                {
                                    if (przeciwnik.Name == "Kurczak Somsiada")
                                    {
                                        foreach (Quests item in Accepted_quests_list)
                                        {
                                            if (item.ID_Quest == 6 && item.Done == 0)
                                            {
                                                if (item.Progress == "1/2")
                                                {
                                                    item.Progress = "2/2";
                                                    item.Done = 1;
                                                }
                                                if (item.Progress == "0/2")
                                                {
                                                    item.Progress = "1/2";
                                                }

                                                load_quests();
                                                Db.Save_Progress_Quest();
                                            }
                                        }
                                    }
                                    if (przeciwnik.Name == "Wściekły Pies")
                                    {
                                        foreach (Quests item in Accepted_quests_list)
                                        {
                                            if (item.ID_Quest == 4 && item.Done == 0)
                                            {
                                                if (item.Progress == "7/8")
                                                {
                                                    item.Progress = "8/8";
                                                    item.Done = 1;
                                                }
                                                if (item.Progress == "6/8")
                                                {
                                                    item.Progress = "7/8";
                                                }
                                                if (item.Progress == "5/8")
                                                {
                                                    item.Progress = "6/8";
                                                }
                                                if (item.Progress == "4/8")
                                                {
                                                    item.Progress = "5/8";
                                                }
                                                if (item.Progress == "3/8")
                                                {
                                                    item.Progress = "4/8";
                                                }
                                                if (item.Progress == "2/8")
                                                {
                                                    item.Progress = "3/8";
                                                }
                                                if (item.Progress == "1/8")
                                                {
                                                    item.Progress = "2/8";
                                                }
                                                if (item.Progress == "0/8")
                                                {
                                                    item.Progress = "1/8";
                                                }

                                                load_quests();
                                                Db.Save_Progress_Quest();
                                            }
                                        }
                                    }
                                    hpstat_e.Content = 0;
                                    wyswietlacz.Text += "\n Walkę wygrywa " + gracz.Name;
                                    wysw_viewer.ScrollToEnd();
                                    gracz.Exp += przeciwnik.Exp_drop;
                                    kto = 3;
                                    zamknijokno.IsEnabled = true;
                                    przeciwnik.HP = HP_przeciwnika;
                                    przeciwnik.Grid.Visibility = Visibility.Hidden;
                                    await Task.Delay(180000);
                                    przeciwnik.Grid.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    hpstat_e.Content = przeciwnik.HP;
                                    kto = 1;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < speed_attack_p; i++)
                            {
                                attack_p = rand.Next(0, gracz.Attack + 1);
                                armor_e = rand.Next(0, przeciwnik.Armor + 1);
                                if (armor_e > attack_p)
                                {
                                    wyswietlacz.Text += "\n" + gracz.Name + " uderza z siłą +" + attack_p + "\n   - " + przeciwnik.Name + " wykonuje unik ";
                                    wysw_viewer.ScrollToEnd();

                                }
                                else
                                {
                                    przeciwnik.HP -= attack_p;
                                    wyswietlacz.Text += "\n" + gracz.Name + " uderza z siłą +" + attack_p + "\n   - " + przeciwnik.Name + " otrzymuje -" + attack_p + " obrażeń";
                                    hpstat_e.Content = przeciwnik.HP;
                                    wysw_viewer.ScrollToEnd();


                                }
                            }
                            if (przeciwnik.HP <= 0)
                            {
                                if (przeciwnik.Name == "Kurczak Somsiada")
                                {
                                    foreach (Quests item in Accepted_quests_list)
                                    {
                                        if (item.ID_Quest == 6 && item.Done == 0)
                                        {
                                            if (item.Progress == "1/2")
                                            {
                                                item.Progress = "2/2";
                                                item.Done = 1;
                                            }
                                            if (item.Progress == "0/2")
                                            {
                                                item.Progress = "1/2";
                                            }

                                            load_quests();
                                            Db.Save_Progress_Quest();
                                        }
                                    }
                                }
                                if (przeciwnik.Name == "Wściekły Pies")
                                {
                                    foreach (Quests item in Accepted_quests_list)
                                    {
                                        if (item.ID_Quest == 4 && item.Done == 0)
                                        {
                                            if (item.Progress == "7/8")
                                            {
                                                item.Progress = "8/8";
                                                item.Done = 1;
                                            }
                                            if (item.Progress == "6/8")
                                            {
                                                item.Progress = "7/8";
                                            }
                                            if (item.Progress == "5/8")
                                            {
                                                item.Progress = "6/8";
                                            }
                                            if (item.Progress == "4/8")
                                            {
                                                item.Progress = "5/8";
                                            }
                                            if (item.Progress == "3/8")
                                            {
                                                item.Progress = "4/8";
                                            }
                                            if (item.Progress == "2/8")
                                            {
                                                item.Progress = "3/8";
                                            }
                                            if (item.Progress == "1/8")
                                            {
                                                item.Progress = "2/8";
                                            }
                                            if (item.Progress == "0/8")
                                            {
                                                item.Progress = "1/8";
                                            }

                                            load_quests();
                                            Db.Save_Progress_Quest();
                                        }
                                    }
                                }
                                hpstat_e.Content = 0;
                                wyswietlacz.Text += "\n Walkę wygrywa " + gracz.Name;
                                wysw_viewer.ScrollToEnd();
                                gracz.Exp += przeciwnik.Exp_drop;
                                kto = 3;
                                zamknijokno.IsEnabled = true;
                                przeciwnik.HP = HP_przeciwnika;
                                przeciwnik.Grid.Visibility = Visibility.Hidden;
                                await Task.Delay(180000);
                                przeciwnik.Grid.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                hpstat_e.Content = przeciwnik.HP;
                                kto = 1;
                            }

                        }
                    }
                    if (Silny_Atak_C == true)
                    {
                        Silny_Atak_C = false;
                        armor_e = rand.Next(0, przeciwnik.Armor + 1);
                        attack_p = (rand.Next(0, gracz.Attack + 1)) * 3;
                        if (armor_e > attack_p)
                        {
                            wyswietlacz.Text += "\n" + gracz.Name + " uderza z siłą +" + attack_p + "\n   - " + przeciwnik.Name + " wykonuje unik ";
                            wysw_viewer.ScrollToEnd();
                            kto = 1;
                        }
                        else
                        {
                            przeciwnik.HP -= attack_p;
                            wyswietlacz.Text += "\n" + gracz.Name + " uderza z siłą +" + attack_p + "\n   - " + przeciwnik.Name + " otrzymuje -" + attack_p + " obrażeń";
                            wysw_viewer.ScrollToEnd();
                            if (przeciwnik.HP <= 0)
                            {
                                if (przeciwnik.Name == "Kurczak Somsiada")
                                {
                                    foreach (Quests item in Accepted_quests_list)
                                    {
                                        if (item.ID_Quest == 6 && item.Done == 0)
                                        {
                                            if (item.Progress == "1/2")
                                            {
                                                item.Progress = "2/2";
                                                item.Done = 1;
                                            }
                                            if (item.Progress == "0/2")
                                            {
                                                item.Progress = "1/2";
                                            }

                                            load_quests();
                                            Db.Save_Progress_Quest();
                                        }

                                    }
                                }
                                if (przeciwnik.Name == "Wściekły Pies")
                                {
                                    foreach (Quests item in Accepted_quests_list)
                                    {
                                        if (item.ID_Quest == 4 && item.Done == 0)
                                        {
                                            if (item.Progress == "7/8")
                                            {
                                                item.Progress = "8/8";
                                                item.Done = 1;
                                            }
                                            if (item.Progress == "6/8")
                                            {
                                                item.Progress = "7/8";
                                            }
                                            if (item.Progress == "5/8")
                                            {
                                                item.Progress = "6/8";
                                            }
                                            if (item.Progress == "4/8")
                                            {
                                                item.Progress = "5/8";
                                            }
                                            if (item.Progress == "3/8")
                                            {
                                                item.Progress = "4/8";
                                            }
                                            if (item.Progress == "2/8")
                                            {
                                                item.Progress = "3/8";
                                            }
                                            if (item.Progress == "1/8")
                                            {
                                                item.Progress = "2/8";
                                            }
                                            if (item.Progress == "0/8")
                                            {
                                                item.Progress = "1/8";
                                            }

                                            load_quests();
                                            Db.Save_Progress_Quest();
                                        }
                                    }
                                }
                                hpstat_e.Content = 0;
                                wyswietlacz.Text += "\n Walkę wygrywa " + gracz.Name;
                                wysw_viewer.ScrollToEnd();
                                gracz.Exp += przeciwnik.Exp_drop;
                                kto = 3;
                                zamknijokno.IsEnabled = true;
                                przeciwnik.HP = HP_przeciwnika;
                                przeciwnik.Grid.Visibility = Visibility.Hidden;
                                await Task.Delay(180000);
                                przeciwnik.Grid.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                hpstat_e.Content = przeciwnik.HP;
                                kto = 1;
                            }
                        }
                    }
                    // kto = 1;
                }
                //  kto = 3;

            }
            zamknijokno.IsEnabled = true;


        }
        private void Atak_Click(object sender, RoutedEventArgs e)
        {
            Atak_C = true;
            Silny_Atak_C = false;
        }

        private void Silny_Atak_Click(object sender, RoutedEventArgs e)
        {
            Atak_C = false;
            Silny_Atak_C = true;
        }

        private void zamknijokno_Click(object sender, RoutedEventArgs e)
        {
            load_statistics();
            ICharacters gracz = null;
            if (Db.Character == 1) gracz = wojownik;
            if (Db.Character == 2) gracz = wizard;
            if (Db.Character == 3) gracz = knight;

            if(gracz.HP<1)
            {
                death.Visibility = Visibility.Visible;
                player.Visibility = Visibility.Hidden;
            }
            OknoWalki.Visibility = Visibility.Hidden;
            Start_the_game.Visibility = Visibility.Visible;
            player_area.Focusable = true;
            Keyboard.Focus(player_area);
        }
        private void Respawn_Click(object sender, RoutedEventArgs e)
        {
            if (Db.Character == 1)
            {
                wojownik.HP = wojownik.MaxHP;
                wojownik.X = 653;
                wojownik.Y = 400;
            }
            if (Db.Character == 2)
            {
                wizard.HP = wizard.MaxHP;
                wizard.X = 653;
                wizard.Y = 400;
            }
            if (Db.Character == 3)
            {
                knight.HP = knight.MaxHP;
                knight.X = 653;
                knight.Y = 400;
            }
            load_statistics();
            Canvas.SetBottom(mapa, -(400 - 400));
            Canvas.SetLeft(mapa, -(653 - 600));
            player.Visibility = Visibility.Visible;
            death.Visibility = Visibility.Hidden;
            player_area.Focusable = true;
            Keyboard.Focus(player_area);

        }


        #endregion
        #region OKNO ZADAŃ /N
        public void load_quests()
        {
            Label[] q_labels = new Label[6];
            q_labels[0] = L_q1;
            q_labels[1] = L_q2;
            q_labels[2] = L_q3;
            q_labels[3] = L_q4;
            q_labels[4] = L_q5;
            q_labels[5] = L_q6;
            int i = 0;
            for(i=0;i<6;i++)
            {
                q_labels[i].Content = "";
            }
            i = 0;
            foreach (Quests quest in Accepted_quests_list)
            {
                if (quest.Done == 0)
                {
                    foreach (Quests q in Quests_list)
                    {
                        if (quest.ID_Quest == q.ID_Quest)
                        {
                            q_labels[i].Content = q.Short_desc + "\n   Postep: " + quest.Progress;
                            i++;
                        }
                    }


                }
                if (quest.Done == 1)
                {
                    if (quest.ID_Quest == 1)
                    {
                        string tekst = "Przekaż przedmiot Majorowi";
                        q_labels[i].Content = tekst + "\n   Postep: " + quest.Progress;
                        i++;
                    }
                    if (quest.ID_Quest == 6)
                    {
                        string tekst = "Wróć do Nieznajomego";
                        q_labels[i].Content = tekst + "\n   Postep: " + quest.Progress;
                        i++;
                    }
                    if (quest.ID_Quest == 4)
                    {
                        string tekst = "Wróć do Astrologa";
                        q_labels[i].Content = tekst + "\n   Postep: " + quest.Progress;
                        i++;
                    }
                }



            }
            foreach (Quests item in Accepted_quests_list)
            {
                if (item.ID_Quest == 1 && item.Done == 0)
                {
                    npc1_g.Visibility = Visibility.Visible;
                    npc1.IsEnabled = true;
                }
            }

        }
        private void Okno_quest_close_Click(object sender, RoutedEventArgs e)
        {
            mov.oknoquest_visiblity = false;
            Okno_quest.Visibility = Visibility.Hidden;
            player_area.Focusable = true;
            Keyboard.Focus(player_area);

        } 
        #endregion
        #region Muzyka/Video w tle
        public async void Play_Music()
        {
            if (music_player != null)
            {
                if (Start_the_game.Visibility == Visibility.Visible)
                {
                    while (music_player.Volume > 0.0)
                    {
                        music_player.Volume = music_player.Volume - 0.01;
                        await Task.Delay(100);
                    }
                    music_player.Volume = 0.2;
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\vista point.mp3"));
                  
                }
                else
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\Vista Point menu.mp3"));
                
                music_player.MediaEnded += new EventHandler(Music_Ended);
                music_player.Play();

                return;
            }
        }
        private void Music_Ended(object sender, EventArgs e)
        {
            //music_player.Open(new Uri(backgroundMusicFilePath));
            if (Start_the_game.Visibility == Visibility.Collapsed)
            {
                music_player.Position = TimeSpan.Zero;
                music_player.Play();
                
            }
            else
            {
                music_player_l++;
                if (music_player_l == 0)
                {
                    
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\vista point.mp3"));
                    music_player.Play();
                }
                if (music_player_l == 1)
                {
                 
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\Take Flight.mp3"));
                    music_player.Play();
                }
                if (music_player_l == 2)
                {
                  
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\Fight.mp3"));
                    music_player.Play();
                }
                if (music_player_l == 3)
                {
                  
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\Carol of the Bells.mp3"));
                    music_player.Play();
                }
                if (music_player_l == 4)
                {
                  
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\We Three Gentlemen.mp3"));
                    music_player.Play();
                }
                if (music_player_l == 5)
                {
                   
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\ac3.mp3"));
                    music_player.Play();
                }
                if (music_player_l == 6)
                {
                    music_player_l = -1;
              
                    music_player.Open(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\Artemis.mp3"));
                    music_player.Play();
                }
            }
        }
        public  void Play_Video()
        {
            if (background_fight != null)
            {
                
                    background_fight.Source=(new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\background_fight.mp4"));
                background_fight.MediaEnded += new RoutedEventHandler(Video_Ended);
                background_fight.Play();

                return;
            }
        }
        private void Video_Ended(object sender, EventArgs e)
        {
            background_fight.Source = (new Uri(Current_Directory.Substring(0, Current_Directory.Length - 9) + @"Sounds\Tracks\background_fight.mp4"));
             background_fight.Position = TimeSpan.Zero;
            background_fight.Play();

            
        }



        #endregion

        private void Eksportuj_Statystyki(object sender, RoutedEventArgs e)
        {
            Db.top_20();
        }

        private void Powrót(object sender, RoutedEventArgs e)
        {
            Esc.Visibility = Visibility.Hidden;
            player_area.Focusable = true;
            Keyboard.Focus(player_area);
        }
    }

}
