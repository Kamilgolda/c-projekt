using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.IO;


namespace Gra
{
    public class Db
    {
        public static SqlConnection connection;
        public static bool polaczono = false;
        public static int ID_Account = 0;
        public static int ID_Character = 0;
        public static int Character = 0;
        public static string Name;

        public static void Connect()
        {
            try
            {
                string connectionString = @"Data source=savagelands.database.windows.net;database=savage_lands;User id=Projekt;Password=zaq1@WSX;";
                //@"Data source=DESKTOP-O745A5P\SQLEXPRESS;database=savage_lands;User id=player;Password=123456;"
                connection = new SqlConnection(connectionString);
                connection.Open();
                polaczono = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void Check_or_add_account(TextBox tbNickName)
        {
            try
            {
                Name = tbNickName.Text;
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Accounts";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Nickname"].ToString() == tbNickName.Text)
                    {
                        ID_Account = Convert.ToInt32(reader["ID_Account"]);
                        break;
                    }
                }
                reader.Close();
                if (ID_Account == 0)
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    string commandText = "INSERT INTO Accounts (Nickname) VALUES (@Nickname)";
                    cmd.CommandText = commandText;
                    SqlParameter param = new SqlParameter("@Nickname", tbNickName.Text);
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();

                    SqlCommand sqlCommand3 = connection.CreateCommand();
                    sqlCommand3.CommandText = "SELECT * FROM Accounts WHERE Nickname=@Nickname";
                    SqlParameter param3 = new SqlParameter("@Nickname", tbNickName.Text);
                    sqlCommand3.Parameters.Add(param3);
                    SqlDataReader reader3 = sqlCommand3.ExecuteReader();
                    while (reader3.Read())
                    {
                        ID_Account = Convert.ToInt32(reader3["ID_Account"]);
                        break;
                    }
                    reader3.Close();
                }


            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void Check_or_add_character()
        {
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Characters WHERE ID_Account=@ID_Account";
                SqlParameter param = new SqlParameter("@ID_Account", ID_Account);
                sqlCommand.Parameters.Add(param);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["Character"]) == Character)
                    {
                        ID_Character = Convert.ToInt32(reader["ID_Character"]);
                        break;
                    }
                }
                reader.Close();
                if (ID_Character == 0)
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    string commandText = "INSERT INTO Characters (ID_Account,Character) VALUES (@ID_Account,@Character)";
                    cmd.CommandText = commandText;
                    SqlParameter param1 = new SqlParameter("@ID_Account", ID_Account);
                    SqlParameter param2 = new SqlParameter("@Character", Character);
                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.ExecuteNonQuery();

                    SqlCommand sqlCommand3 = connection.CreateCommand();
                    sqlCommand3.CommandText = "SELECT * FROM Characters WHERE ID_Account=@ID_Account AND Character=@Character";
                    SqlParameter param3 = new SqlParameter("@ID_Account", ID_Account);
                    SqlParameter param4 = new SqlParameter("@Character", Character);
                    sqlCommand3.Parameters.Add(param3);
                    sqlCommand3.Parameters.Add(param4);
                    SqlDataReader reader3 = sqlCommand3.ExecuteReader();
                    while (reader3.Read())
                    {
                        ID_Character = Convert.ToInt32(reader3["ID_Character"]);
                        break;

                    }
                    reader3.Close();

                    SqlCommand cmd5 = connection.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    string commandText5 = "INSERT INTO Character_Properties VALUES (@ID_Character,653,400,0,50,0,0,0)";
                    cmd5.CommandText = commandText5;
                    SqlParameter param5 = new SqlParameter("@ID_Character", ID_Character);
                    cmd5.Parameters.Add(param5);
                    cmd5.ExecuteNonQuery();

                }


            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void Read_Data_Character(Grid mapa)
        {
            if (Character == 1)
            {
                try
                {
                    Game.wojownik = new Wojownik();
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = "SELECT * FROM Character_Properties WHERE ID_Character=@ID_Character";
                    SqlParameter param = new SqlParameter("@ID_Character", ID_Character);
                    sqlCommand.Parameters.Add(param);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Game.wojownik.X = Convert.ToInt32(reader["X"]);
                        Game.wojownik.Y = Convert.ToInt32(reader["Y"]);
                        Game.wojownik.Exp = Convert.ToInt32(reader["Exp"]);
                        Game.wojownik.HP = Convert.ToInt32(reader["HP"]);
                        Game.wojownik.Attack = Convert.ToInt32(reader["Attack"]);
                        Game.wojownik.Speed_Attack = Convert.ToInt32(reader["Speed_Attack"]);
                        Game.wojownik.Armor = Convert.ToInt32(reader["Armor"]);
                        Game.wojownik.Name = Name;
                        Canvas.SetBottom(mapa, -(Game.wojownik.Y - 400));
                        Canvas.SetLeft(mapa, -(Game.wojownik.X - 600));
                        
                        
                    }
                    reader.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("error");
                    MessageBox.Show(e.Message);
                }
            }
            if (Character == 2)
            {
                try
                {
                    Game.wizard = new Wizard();
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = "SELECT * FROM Character_Properties WHERE ID_Character=@ID_Character";
                    SqlParameter param = new SqlParameter("@ID_Character", ID_Character);
                    sqlCommand.Parameters.Add(param);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Game.wizard.X = Convert.ToInt32(reader["X"]);
                        Game.wizard.Y = Convert.ToInt32(reader["Y"]);
                        Game.wizard.Exp = Convert.ToInt32(reader["Exp"]);
                        Game.wizard.HP = Convert.ToInt32(reader["HP"]);
                        Game.wizard.Attack = Convert.ToInt32(reader["Attack"]);
                        Game.wizard.Speed_Attack = Convert.ToInt32(reader["Speed_Attack"]);
                        Game.wizard.Armor = Convert.ToInt32(reader["Armor"]);
                        Game.wizard.Name = Name;
                        Canvas.SetBottom(mapa, -(Game.wizard.Y - 400));
                        Canvas.SetLeft(mapa, -(Game.wizard.X - 600));


                    }
                    reader.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("error");
                    MessageBox.Show(e.Message);
                }
            }
            if (Character == 3)
            {
                try
                {
                    Game.knight = new Knight();
                    SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = "SELECT * FROM Character_Properties WHERE ID_Character=@ID_Character";
                    SqlParameter param = new SqlParameter("@ID_Character", ID_Character);
                    sqlCommand.Parameters.Add(param);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Game.knight.X = Convert.ToInt32(reader["X"]);
                        Game.knight.Y = Convert.ToInt32(reader["Y"]);
                        Game.knight.Exp = Convert.ToInt32(reader["Exp"]);
                        Game.knight.HP = Convert.ToInt32(reader["HP"]);
                        Game.knight.Attack = Convert.ToInt32(reader["Attack"]);
                        Game.knight.Speed_Attack = Convert.ToInt32(reader["Speed_Attack"]);
                        Game.knight.Armor = Convert.ToInt32(reader["Armor"]);
                        Game.knight.Name = Name;
                        Canvas.SetBottom(mapa, -(Game.knight.Y - 400));
                        Canvas.SetLeft(mapa, -(Game.knight.X - 600));


                    }
                    reader.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("error");
                    MessageBox.Show(e.Message);
                }
            }
        }
        public async static void Save_Data_Character()
        {
            if (Character == 1)
            {
                for(int i=0; ;i++)
                { 
                try
                {
                        await Task.Delay(1000);
                        SqlCommand cmd5 = connection.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    string commandText5 = "UPDATE Character_Properties SET X = @X , Y = @Y , Exp = @Exp , HP= @HP , Attack= @Attack , Speed_Attack = @Speed_Attack , Armor=@Armor  WHERE ID_Character = @ID_Character; ";
                    cmd5.CommandText = commandText5;
                    SqlParameter param1 = new SqlParameter("@ID_Character", ID_Character);
                    SqlParameter param2 = new SqlParameter("@X", Game.wojownik.X);
                    SqlParameter param3 = new SqlParameter("@Y", Game.wojownik.Y);
                    SqlParameter param4 = new SqlParameter("@Exp", Game.wojownik.Exp);
                    SqlParameter param5 = new SqlParameter("@HP", Game.wojownik.HP);
                    SqlParameter param6 = new SqlParameter("@Attack", Game.wojownik.Attack);
                    SqlParameter param7 = new SqlParameter("@Speed_Attack", Game.wojownik.Speed_Attack);
                    SqlParameter param8 = new SqlParameter("@Armor", Game.wojownik.Armor);

                    cmd5.Parameters.Add(param1);
                    cmd5.Parameters.Add(param2);
                    cmd5.Parameters.Add(param3);
                    cmd5.Parameters.Add(param4);
                    cmd5.Parameters.Add(param5);
                    cmd5.Parameters.Add(param6);
                    cmd5.Parameters.Add(param7);
                    cmd5.Parameters.Add(param8);
                    cmd5.ExecuteNonQuery();
                       
               

                    }
                catch (SqlException e)
                {
                    MessageBox.Show("error");
                    MessageBox.Show(e.Message);
                }
            }
        }
            if (Character == 2)
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        await Task.Delay(1000);
                        SqlCommand cmd5 = connection.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        string commandText5 = "UPDATE Character_Properties SET X = @X , Y = @Y , Exp = @Exp , HP= @HP , Attack= @Attack , Speed_Attack = @Speed_Attack , Armor=@Armor  WHERE ID_Character = @ID_Character; ";
                        cmd5.CommandText = commandText5;
                        SqlParameter param1 = new SqlParameter("@ID_Character", ID_Character);
                        SqlParameter param2 = new SqlParameter("@X", Game.wizard.X);
                        SqlParameter param3 = new SqlParameter("@Y", Game.wizard.Y);
                        SqlParameter param4 = new SqlParameter("@Exp", Game.wizard.Exp);
                        SqlParameter param5 = new SqlParameter("@HP", Game.wizard.HP);
                        SqlParameter param6 = new SqlParameter("@Attack", Game.wizard.Attack);
                        SqlParameter param7 = new SqlParameter("@Speed_Attack", Game.wizard.Speed_Attack);
                        SqlParameter param8 = new SqlParameter("@Armor", Game.wizard.Armor);

                        cmd5.Parameters.Add(param1);
                        cmd5.Parameters.Add(param2);
                        cmd5.Parameters.Add(param3);
                        cmd5.Parameters.Add(param4);
                        cmd5.Parameters.Add(param5);
                        cmd5.Parameters.Add(param6);
                        cmd5.Parameters.Add(param7);
                        cmd5.Parameters.Add(param8);
                        cmd5.ExecuteNonQuery();



                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("error");
                        MessageBox.Show(e.Message);
                    }
                }
            }
            if (Character == 3)
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        await Task.Delay(1000);
                        SqlCommand cmd5 = connection.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        string commandText5 = "UPDATE Character_Properties SET X = @X , Y = @Y , Exp = @Exp , HP= @HP , Attack= @Attack , Speed_Attack = @Speed_Attack , Armor=@Armor  WHERE ID_Character = @ID_Character; ";
                        cmd5.CommandText = commandText5;
                        SqlParameter param1 = new SqlParameter("@ID_Character", ID_Character);
                        SqlParameter param2 = new SqlParameter("@X", Game.knight.X);
                        SqlParameter param3 = new SqlParameter("@Y", Game.knight.Y);
                        SqlParameter param4 = new SqlParameter("@Exp", Game.knight.Exp);
                        SqlParameter param5 = new SqlParameter("@HP", Game.knight.HP);
                        SqlParameter param6 = new SqlParameter("@Attack", Game.knight.Attack);
                        SqlParameter param7 = new SqlParameter("@Speed_Attack", Game.knight.Speed_Attack);
                        SqlParameter param8 = new SqlParameter("@Armor", Game.knight.Armor);

                        cmd5.Parameters.Add(param1);
                        cmd5.Parameters.Add(param2);
                        cmd5.Parameters.Add(param3);
                        cmd5.Parameters.Add(param4);
                        cmd5.Parameters.Add(param5);
                        cmd5.Parameters.Add(param6);
                        cmd5.Parameters.Add(param7);
                        cmd5.Parameters.Add(param8);
                        cmd5.ExecuteNonQuery();



                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("error");
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }
        public static void Save_Progress_Quest()
        {
            foreach (Quests item in Game.Accepted_quests_list)
            {
                try
                {
                    // await Task.Delay(1000);
                    SqlCommand cmd5 = connection.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    string commandText5 = "UPDATE Done_Quests SET Done = @Done , Progress = @Progress WHERE ID_Character = @ID_Character AND ID_Quest=@ID_Quest; ";
                    cmd5.CommandText = commandText5;
                    SqlParameter param1 = new SqlParameter("@ID_Character", ID_Character);
                    SqlParameter param2 = new SqlParameter("@ID_Quest", item.ID_Quest);
                    SqlParameter param3 = new SqlParameter("@Done", item.Done);
                    SqlParameter param4 = new SqlParameter("@Progress", item.Progress);

                    cmd5.Parameters.Add(param1);
                    cmd5.Parameters.Add(param2);
                    cmd5.Parameters.Add(param3);
                    cmd5.Parameters.Add(param4);
                    cmd5.ExecuteNonQuery();



                }
                catch (SqlException e)
                {
                    MessageBox.Show("error");
                    MessageBox.Show(e.Message);
                }
            }  
            
        }
        public static void Read_NPC()
        {
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM NPC";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var n = new NPC();
                    n.ID_NPC = Convert.ToInt32(reader["ID_NPC"]);
                    n.Name = Convert.ToString(reader["Name"]);
                    Game.NPC_list.Add(n);
             
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void Read_Enemies()
        {
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Enemies";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var n = new Enemy();
                    n.ID_Enemy = Convert.ToInt32(reader["ID_Enemy"]);
                    n.Name = Convert.ToString(reader["Name"]);
                    n.HP = Convert.ToInt32(reader["HP"]);
                    n.Attack = Convert.ToInt32(reader["Attack"]);
                    n.Speed_Attack = Convert.ToInt32(reader["Speed_Attack"]);
                    n.Armor = Convert.ToInt32(reader["Armor"]);
                    n.Lvl = Convert.ToInt32(reader["Lvl"]);
                    n.Exp_drop = Convert.ToInt32(reader["Exp_drop"]);

                    Game.Enemy_list.Add(n);

                }
                reader.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void Read_Quests()
        {
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Quests";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var q = new Quests();
                    q.ID_Quest = Convert.ToInt32(reader["ID_Quest"]);
                    q.ID_NPC = Convert.ToInt32(reader["ID_NPC"]);
                    q.Descr = Convert.ToString(reader["Descr"]);
                    q.Short_desc= Convert.ToString(reader["Short_desc"]);
                    q.Exp = Convert.ToInt32(reader["Exp"]);
                    Game.Quests_list.Add(q);

                }
                
                reader.Close();

                SqlCommand sqlCommand2 = connection.CreateCommand();
                sqlCommand2.CommandText = "SELECT * FROM Done_Quests WHERE ID_Character=@ID_Character";
                SqlParameter param = new SqlParameter("@ID_Character", ID_Character);
                sqlCommand2.Parameters.Add(param);
                SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var quest = new Quests();
                    quest.ID_Quest = Convert.ToInt32(reader2["ID_Quest"]);
                    quest.Done= Convert.ToInt32(reader2["Done"]);
                    quest.Progress=Convert.ToString(reader2["Progress"]);
                    Game.Accepted_quests_list.Add(quest);
                }
                reader2.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void Add_or_check_quest()
        {
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Done_Quests WHERE ID_Character=@ID_Character AND ID_Quest=@ID_Quest";
                SqlParameter param = new SqlParameter("@ID_Character", ID_Character);
                SqlParameter paramm = new SqlParameter("@ID_Quest", Game.Cquest.ID_Quest);
                sqlCommand.Parameters.Add(param);
                sqlCommand.Parameters.Add(paramm);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {

                        if (Convert.ToInt32(reader["ID_Quest"]) == Game.Cquest.ID_Quest)
                        {
                            if (Convert.ToInt32(reader["Done"]) == 0)
                            {
                            reader.Close();
                            MessageBox.Show("Ten quest już był zaakceptowany");
                            }
                            else
                            MessageBox.Show("Ten quest już wykonano");
                        }
                        else
                        {
                        reader.Close();
                        SqlCommand cmd = connection.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            string commandText = "INSERT INTO Done_Quests (ID_Quest,ID_Character,Done,Progress) VALUES (@ID_Quest,@ID_Character,@Done,@Progress)";
                            cmd.CommandText = commandText;
                            SqlParameter param1 = new SqlParameter("@ID_Quest", Game.Cquest.ID_Quest);
                            SqlParameter param2 = new SqlParameter("@ID_Character", ID_Character);
                            SqlParameter param3 = new SqlParameter("@Done", "0");
                            SqlParameter param4 = new SqlParameter("@Progress", Game.Cquest.Progress);
                             cmd.Parameters.Add(param1);
                            cmd.Parameters.Add(param2);
                            cmd.Parameters.Add(param3);
                        cmd.Parameters.Add(param4);
                        cmd.ExecuteNonQuery();
                            Game.Accepted_quests_list.Add(Game.Cquest);
                        }
                    
                    
                }
                else
                {
                    reader.Close();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    string commandText = "INSERT INTO Done_Quests (ID_Quest,ID_Character,Done,Progress) VALUES (@ID_Quest,@ID_Character,@Done,@Progress)";
                    cmd.CommandText = commandText;
                    SqlParameter param1 = new SqlParameter("@ID_Quest", Game.Cquest.ID_Quest);
                    SqlParameter param2 = new SqlParameter("@ID_Character", ID_Character);
                    SqlParameter param3 = new SqlParameter("@Done", "0");
                    SqlParameter param4 = new SqlParameter("@Progress", Game.Cquest.Progress);
                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);
                    cmd.ExecuteNonQuery();
                    Game.Accepted_quests_list.Add(Game.Cquest);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
        public static void top_20()
        {
            string character;
            string nickname;
            string exp;
            StringBuilder sb = new StringBuilder();
            
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "SELECT TOP 20 Exp,Character,Nickname FROM Character_Properties,Characters,Accounts WHERE Character_Properties.ID_Character=Characters.Id_Character AND Characters.ID_Account=Accounts.ID_Account ORDER BY Exp DESC";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["Character"]) == 1)
                    {
                        character = "Wojownik";
                        nickname = Convert.ToString(reader["Nickname"]);
                        exp = Convert.ToString(reader["Exp"]);
                        
                        sb.AppendLine($"{nickname},{character},{exp}");
                    }
                    if (Convert.ToInt32(reader["Character"]) == 2)
                    {
                        character = "Mag";
                        nickname = Convert.ToString(reader["Nickname"]);
                        exp = Convert.ToString(reader["Exp"]);

                        sb.AppendLine($"{nickname},{character},{exp}");
                    }
                    if (Convert.ToInt32(reader["Character"]) == 3)
                    {
                        character = "Paladyn";
                        nickname = Convert.ToString(reader["Nickname"]);
                        exp = Convert.ToString(reader["Exp"]);

                        sb.AppendLine($"{nickname},{character},{exp}");
                    }
                }
                reader.Close();
                using (var sw = new StreamWriter("top20player.csv"))
                {
                    sw.WriteLine(sb);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("error");
                MessageBox.Show(e.Message);
            }
        }
    }
}
