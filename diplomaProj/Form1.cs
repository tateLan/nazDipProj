using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace diplomaProj
{
    public partial class Form1 : Form
    {
        //etalon-manager 12345Password

        private MySqlConnection connect;
        private string server = "176.98.27.33";
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        Label label4 = new Label();
        Label label5 = new Label();
        Label label6 = new Label();
        Label label7 = new Label();
        Label label8 = new Label();
        TextBox textBox1 = new TextBox();
        TextBox textBox2 = new TextBox();
        TextBox textBox3 = new TextBox();
        TextBox textBox4 = new TextBox();
        TextBox textBox5 = new TextBox();

        public Form1()
        {
            InitializeComponent();

            InitDict();
            InitPanels();
            HideAllPnls();

            tb_auth_login.Select();

            pnl_auth.Show();
        }

        private void InitDict()
        {
            dict.Add(" Переглянути вікна", "windows");
            dict.Add(" Переглянути двері", "doors");
            dict.Add(" Переглянути підвіконня", "windowsill");
            dict.Add(" Переглянути відливи", "reflux");
            dict.Add(" Переглянути москітні сітки", "mosquito_net");
            dict.Add(" Переглянути поставки", "income");
            dict.Add(" Переглянути продажі", "outcome");
            dict.Add(" Переглянути склад", "warehouse");
        }

        private void InitPanels()
        {
            pnl_auth.Dock = DockStyle.Fill;
            pnl_mainMenu.Dock = DockStyle.Fill;
            pnl_registerNew.Dock = DockStyle.Fill;
            pnl_show.Dock = DockStyle.Fill;
        }

        private void HideAllPnls()
        {
            pnl_auth.Hide();
            pnl_mainMenu.Hide();
            pnl_registerNew.Hide();
            pnl_show.Hide();
        }

        private void btn_auth_enter_Click(object sender, EventArgs e)
        {
            string login = "etalon-manager";
            string password = "12345Password";
            //if (login == tb_auth_login.Text && password == tb_auth_pass.Text)
            //{
            pnl_auth.Hide();
            GetConnect(login, password);
            pnl_mainMenu.Show();
            HideAllBtns();
            //}
            //else
            //{
            //    lbl_auth_invalidData.Visible = true;
            //    tb_auth_pass.Text = "";
            //}
        }

        private void GetConnect(string log, string pass)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = server;
                builder.Port = 3306;
                builder.ConnectionProtocol = MySqlConnectionProtocol.Tcp;
                builder.SslMode = MySqlSslMode.None;
                builder.Database = "windowsSellerCompany";
                builder.UserID = log;
                builder.Password = pass;

                connect = new MySqlConnection(builder.ConnectionString);
                connect.Open();

                new MySqlCommand("use windowsSellerCompany", connect).ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void HideAllBtns()
        {
            btn_mainMenu_slot1.Hide();
            btn_mainMenu_slot2.Hide();
            btn_mainMenu_slot3.Hide();
            btn_mainMenu_slot4.Hide();
            btn_mainMenu_slot5.Hide();
            btn_mainMenu_slot6.Hide();
            btn_mainMenu_slot7.Hide();
            btn_mainMenu_slot8.Hide();

            btn_mainMenu_slot1.Click -= ShowInfo;
            btn_mainMenu_slot2.Click -= ShowInfo;
            btn_mainMenu_slot3.Click -= ShowInfo;
            btn_mainMenu_slot4.Click -= ShowInfo;
            btn_mainMenu_slot5.Click -= ShowInfo;
            btn_mainMenu_slot6.Click -= ShowInfo;
            btn_mainMenu_slot7.Click -= ShowInfo;
            btn_mainMenu_slot8.Click -= ShowInfo;

            btn_mainMenu_slot3.Click -= AddItem;
            btn_mainMenu_slot4.Click -= ChangeItem;
            btn_mainMenu_slot5.Click -= AddClient;
            btn_mainMenu_slot6.Click -= ChangeClient;
        }

        private void btn_mainMenu_addChangeInfo_Click(object sender, EventArgs e)
        {
            HideAllBtns();

            btn_mainMenu_slot3.Text = "Додати нову одиницю товару";
            btn_mainMenu_slot4.Text = "Змінити інформацію про товар";
            btn_mainMenu_slot5.Text = "Додати нового клієнта";
            btn_mainMenu_slot6.Text = "Змінити інформацію про клієнта";

            btn_mainMenu_slot3.Click += AddItem;
            btn_mainMenu_slot4.Click += ChangeItem;
            btn_mainMenu_slot5.Click += AddClient;
            btn_mainMenu_slot6.Click += ChangeClient;

            btn_mainMenu_slot3.Show();
            btn_mainMenu_slot4.Show();
            btn_mainMenu_slot5.Show();
            btn_mainMenu_slot6.Show();
        }

        private void btn_mainMenu_registerIncome_Click(object sender, EventArgs e)
        {
            HideAllBtns();
            pnl_mainMenu.Hide();
            pnl_registerNew.Show();
        }

        private void btn_mainMenu_registerSell_Click(object sender, EventArgs e)
        {
            HideAllBtns();
            pnl_mainMenu.Hide();
            pnl_registerNew.Show();
        }

        private void btn_mainMenu_checkInfo_Click(object sender, EventArgs e)
        {
            HideAllBtns();

            btn_mainMenu_slot1.Show();
            btn_mainMenu_slot2.Show();
            btn_mainMenu_slot3.Show();
            btn_mainMenu_slot4.Show();
            btn_mainMenu_slot5.Show();
            btn_mainMenu_slot6.Show();
            btn_mainMenu_slot7.Show();
            btn_mainMenu_slot8.Show();

            btn_mainMenu_slot1.Click += ShowInfo;
            btn_mainMenu_slot2.Click += ShowInfo;
            btn_mainMenu_slot3.Click += ShowInfo;
            btn_mainMenu_slot4.Click += ShowInfo;
            btn_mainMenu_slot5.Click += ShowInfo;
            btn_mainMenu_slot6.Click += ShowInfo;
            btn_mainMenu_slot7.Click += ShowInfo;
            btn_mainMenu_slot8.Click += ShowInfo;

            btn_mainMenu_slot1.Text = "Переглянути вікна";
            btn_mainMenu_slot2.Text = "Переглянути двері";
            btn_mainMenu_slot3.Text = "Переглянути підвіконня";
            btn_mainMenu_slot4.Text = "Переглянути відливи";
            btn_mainMenu_slot5.Text = "Переглянути москітні сітки";
            btn_mainMenu_slot6.Text = "Переглянути поставки";
            btn_mainMenu_slot7.Text = "Переглянути продажі";
            btn_mainMenu_slot8.Text = "Переглянути склад";
        }

        private void AddItem(object sender, EventArgs e) //empty
        {
        }

        private void ChangeItem(object sender, EventArgs e)//empty
        {

        }

        private void AddClient(object sender, EventArgs e)//empty
        {

        }

        private void ChangeClient(object sender, EventArgs e)//empty
        {

        }

        private void ShowInfo(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_show.Show();
            string subj = dict[sender.ToString().Split(':')[1]];
            string q;
            MySqlDataReader reader;

            switch (subj)
            {
                case "windows":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("manufacturer", "виробник");
                        dgw_show.Columns.Add("name", "найменування");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 3);

                        reader.Close();
                    }
                    break;
                case "doors":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("manufacturer", "виробник");
                        dgw_show.Columns.Add("type", "тип_дверей");
                        dgw_show.Columns.Add("material", "матеріал");
                        dgw_show.Columns.Add("color", "колір");

                        q = "call showDoors";
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 5);

                        reader.Close();
                    }
                    break;
                case "windowsill":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("manufacturer", "виробник");
                        dgw_show.Columns.Add("material", "матеріал");
                        dgw_show.Columns.Add("color", "колір");

                        q = "call showWindowsill";
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 4);

                        reader.Close();
                    }
                    break;
                case "reflux":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("name", "найменування");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 2);

                        reader.Close();
                    }
                    break;
                case "mosquito_net":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("name", "найменування");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 2);

                        reader.Close();
                    }
                    break;
                case "income":
                    {
                        getAdditControls();
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("dateOfIncome", "дата_поставки");
                        dgw_show.Columns.Add("provider", "постачальник");
                        dgw_show.Columns.Add("codeOfItem", "код_товару");
                        dgw_show.Columns.Add("quantity", "кількість");
                        dgw_show.Columns.Add("paid", "заплачено");
                        dgw_show.CellMouseClick += Dgw_show_CellMouseClick;

                        q = "call showIncome";
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        object[] arr = new object[6];

                        while (reader.Read())
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (i == 1)
                                {
                                    arr[i] = Convert.ToDateTime(reader[i]).Date.ToShortDateString().Split(' ')[0];
                                }
                                else
                                    arr[i] = reader[i];
                            }
                            dgw_show.Rows.Add(arr);
                        }

                        reader.Close();


                    }
                    break;
                case "outcome":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("dateOfOutcome", "дата_продажі");
                        dgw_show.Columns.Add("codeOfClient", "код_клієнта");
                        dgw_show.Columns.Add("codeOfItem", "код_товару");
                        dgw_show.Columns.Add("quantity", "кількість");
                        dgw_show.Columns.Add("paid", "заплачено");
                        dgw_show.Columns.Add("montageDelivery", "монтаж/доставка");
                        dgw_show.Columns.Add("montageDeliveryCost", "вартість_монтажу/доставки");
                        dgw_show.Columns.Add("Manager", "менеджер");
                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 9);

                        reader.Close();

                    }
                    break;
                case "warehouse":
                    {
                        dgw_show.Columns.Add("code", "код_складу");
                        dgw_show.Columns.Add("codeOfItem", "код_товару");
                        dgw_show.Columns.Add("dateOfIncome", "дата_прибуття");
                        dgw_show.Columns.Add("quantify", "кількість");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 4);

                        reader.Close();
                    }
                    break;
            }
        }

        private void Dgw_show_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dgwr = dgw_show.Rows[e.RowIndex];
            MySqlDataReader reader = new MySqlCommand("call getType4showIncome(" + dgwr.Cells[3].Value + ")", connect).ExecuteReader();

            reader.Read();

            int assortimInd = Convert.ToInt16(reader[0]);

            reader.Close();

            switch(assortimInd)
            {
                case 1:     //windows
                    {

                    }break;
                case 2:     //doors
                    {

                    }
                    break;
                case 3:     //windowsill
                    {

                    }
                    break;
                case 4:     //mosquito
                    {

                    }
                    break;
                case 5:     //reflux
                    {

                    }
                    break;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            HideAllPnls();
            HideAllBtns();
            pnl_mainMenu.Show();

            dgw_show.CellMouseClick -= Dgw_show_CellMouseClick;

            pnl_show.Controls.Remove(label4);
            pnl_show.Controls.Remove(label5);
            pnl_show.Controls.Remove(label6);
            pnl_show.Controls.Remove(label7);
            pnl_show.Controls.Remove(label8);
                              
            pnl_show.Controls.Remove(textBox1);
            pnl_show.Controls.Remove(textBox2);
            pnl_show.Controls.Remove(textBox3);
            pnl_show.Controls.Remove(textBox4);
            pnl_show.Controls.Remove(textBox5);

            this.Width = 920;

            dgw_show.Rows.Clear();
            dgw_show.Columns.Clear();
        }

        private void InitDGW(MySqlDataReader reader, int count)
        {
            object[] arr = new object[count];

            while (reader.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    arr[i] = reader[i];
                }
                dgw_show.Rows.Add(arr);
            }

        }

        private void getAdditControls()
        {
            this.Width = 1220;

            

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.Location = new System.Drawing.Point(915, 76);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 20);
            label4.TabIndex = 3;
            label4.Text = "label4";
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            textBox1.Location = new System.Drawing.Point(1002, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(167, 26);
            textBox1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label5.Location = new System.Drawing.Point(915, 106);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 20);
            label5.TabIndex = 3;
            label5.Text = "label4";
            // 
            // textBox2
            // 
            textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            textBox2.Location = new System.Drawing.Point(1002, 103);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(167, 26);
            textBox2.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label6.Location = new System.Drawing.Point(915, 138);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 20);
            label6.TabIndex = 3;
            label6.Text = "label4";
            // 
            // textBox3
            // 
            textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            textBox3.Location = new System.Drawing.Point(1002, 135);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(167, 26);
            textBox3.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label7.Location = new System.Drawing.Point(915, 174);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(51, 20);
            label7.TabIndex = 3;
            label7.Text = "label4";
            // 
            // textBox4
            // 
            textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            textBox4.Location = new System.Drawing.Point(1002, 172);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(167, 26);
            textBox4.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label8.Location = new System.Drawing.Point(915, 207);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(51, 20);
            label8.TabIndex = 3;
            label8.Text = "label4";
            // 
            // textBox5
            // 
            textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            textBox5.Location = new System.Drawing.Point(1002, 204);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(167, 26);
            textBox5.TabIndex = 4;

            pnl_show.Controls.Add(label4);
            pnl_show.Controls.Add(label5);
            pnl_show.Controls.Add(label6);
            pnl_show.Controls.Add(label7);
            pnl_show.Controls.Add(label8);

            pnl_show.Controls.Add(textBox1);
            pnl_show.Controls.Add(textBox2);
            pnl_show.Controls.Add(textBox3);
            pnl_show.Controls.Add(textBox4);
            pnl_show.Controls.Add(textBox5);

            
        }
    }
}
