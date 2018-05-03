﻿using System;
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


        Label inflbl = new Label();
        Label showIncLbl1 = new Label();
        Label showIncLbl2 = new Label();
        Label showIncLbl3 = new Label();
        Label showIncLbl4 = new Label();
        Label showIncLbl5 = new Label();
        Label showIncLblType = new Label();
        TextBox showIncType = new TextBox();
        TextBox showIncTb1 = new TextBox();
        TextBox showIncTb2 = new TextBox();
        TextBox showIncTb3 = new TextBox();
        TextBox showIncTb4 = new TextBox();
        TextBox showIncTb5 = new TextBox();

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

                        HideAllAdditionControls();
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
            HideAllAdditionControls();
            if (e.RowIndex > dgw_show.RowCount || e.RowIndex < 0)
                return;
            DataGridViewRow dgwr = dgw_show.Rows[e.RowIndex];
            MySqlDataReader reader = new MySqlCommand("call getType4showIncome(" + dgwr.Cells[3].Value + ")", connect).ExecuteReader();

            reader.Read();

            int assortimInd = Convert.ToInt16(reader[0]);

            reader.Close();

            switch (assortimInd)
            {
                case 1:     //windows
                    {
                        showIncLblType.Visible = true;
                        showIncLbl1.Visible = true;
                        showIncLbl2.Visible = true;
                        showIncLbl3.Visible = true;

                        showIncType.Visible = true;
                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncTb3.Visible = true;

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Виробник";
                        showIncLbl3.Text = "Назва";

                        reader = new MySqlCommand("select * from windows where windows.codeOfItem = " + dgwr.Cells[3].Value, connect).ExecuteReader();
                        while(reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[1].ToString();
                            showIncTb3.Text = reader[2].ToString();
                        }

                        showIncType.Text = "Вікна";

                        reader.Close();
                    }
                    break;
                case 2:     //doors
                    {
                        showIncLblType.Visible = true;
                        showIncLbl1.Visible = true;
                        showIncLbl2.Visible = true;
                        showIncLbl3.Visible = true;
                        showIncLbl4.Visible = true;
                        showIncLbl5.Visible = true;

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Виробник";
                        showIncLbl3.Text = "Тип";
                        showIncLbl4.Text = "Матеріал";
                        showIncLbl5.Text = "Колір";

                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncTb3.Visible = true;
                        showIncTb4.Visible = true;
                        showIncTb5.Visible = true;
                        showIncType.Visible = true;

                        reader = new MySqlCommand("select * from doors where doors.codeOfItem = " + dgwr.Cells[3].Value, connect).ExecuteReader();
                        while(reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[1].ToString();
                            showIncTb3.Text = reader[2].ToString();
                            showIncTb4.Text = reader[3].ToString();
                            showIncTb5.Text = reader[4].ToString();
                        }

                        showIncType.Text = "Двері";

                        reader.Close();
                    }
                    break;
                case 3:     //windowsill
                    {
                        showIncLblType.Visible = true;
                        showIncLbl1.Visible = true;
                        showIncLbl2.Visible = true;
                        showIncLbl3.Visible = true;
                        showIncLbl4.Visible = true;

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Виробник";
                        showIncLbl3.Text = "Матеріал";
                        showIncLbl4.Text = "Колір";

                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncTb3.Visible = true;
                        showIncTb4.Visible = true;
                        showIncType.Visible = true;

                        reader = new MySqlCommand("select * from windowsill where windowsill.codeOfItem = " + dgwr.Cells[3].Value, connect).ExecuteReader();
                        while (reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[1].ToString();
                            showIncTb3.Text = reader[2].ToString();
                            showIncTb4.Text = reader[3].ToString();
                        }

                        showIncType.Text = "Підвіконня";
                        reader.Close();
                    }
                    break;
                case 4:     //mosquito
                    {
                        showIncLblType.Visible = true;
                        showIncLbl1.Visible = true;
                        showIncLbl2.Visible = true;

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Назва";

                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncType.Visible = true;

                        reader = new MySqlCommand("select * from mosquito_net where mosquito_net.codeOfItem = " + dgwr.Cells[3].Value, connect).ExecuteReader();
                        while (reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[1].ToString();
                        }

                        showIncType.Text = "Сітки";
                        reader.Close();
                    }
                    break;
                case 5:     //reflux
                    {
                        showIncLblType.Visible = true;
                        showIncLbl1.Visible = true;
                        showIncLbl2.Visible = true;

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Назва";

                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncType.Visible = true;

                        reader = new MySqlCommand("select * from reflux where reflux.codeOfItem = " + dgwr.Cells[3].Value, connect).ExecuteReader();
                        while (reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[1].ToString();
                        }

                        showIncType.Text = "Відливи";
                        reader.Close();
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

            pnl_show.Controls.Remove(showIncLbl1);
            pnl_show.Controls.Remove(showIncLbl2);
            pnl_show.Controls.Remove(showIncLbl3);
            pnl_show.Controls.Remove(showIncLbl4);
            pnl_show.Controls.Remove(showIncLbl5);

            pnl_show.Controls.Remove(showIncTb1);
            pnl_show.Controls.Remove(showIncTb2);
            pnl_show.Controls.Remove(showIncTb3);
            pnl_show.Controls.Remove(showIncTb4);
            pnl_show.Controls.Remove(showIncTb5);

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
            this.Width = 1230;
            // 
            // showIncLblType
            // 
            showIncLblType.AutoSize = true;
            showIncLblType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLblType.Location = new Point(915, 78);
            showIncLblType.Name = "showIncLbl1";
            showIncLblType.Size = new Size(51, 20);
            showIncLblType.TabIndex = 3;
            showIncLblType.Text = "Вид продукту";
            // 
            // showIncType
            // 
            showIncType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncType.Location = new Point(1069, 75);
            showIncType.Name = "showIncTb1";
            showIncType.Size = new Size(133, 26);
            showIncType.TabIndex = 4;
            // 
            // showIncLbl1
            // 
            showIncLbl1.AutoSize = true;
            showIncLbl1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl1.Location = new Point(915, 118);
            showIncLbl1.Name = "showIncLbl1";
            showIncLbl1.Size = new Size(51, 20);
            showIncLbl1.TabIndex = 3;
            showIncLbl1.Text = "showIncLbl1";
            // 
            // showIncTb1
            // 
            showIncTb1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb1.Location = new Point(1002, 115);
            showIncTb1.Name = "showIncTb1";
            showIncTb1.Size = new Size(200, 26);
            showIncTb1.TabIndex = 4;
            // 
            // showIncLbl2
            // 
            showIncLbl2.AutoSize = true;
            showIncLbl2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl2.Location = new Point(915, 158);
            showIncLbl2.Name = "showIncLbl2";
            showIncLbl2.Size = new Size(51, 20);
            showIncLbl2.TabIndex = 3;
            showIncLbl2.Text = "showIncLbl1";
            // 
            // showIncTb2
            // 
            showIncTb2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb2.Location = new Point(1002, 155);
            showIncTb2.Name = "showIncTb2";
            showIncTb2.Size = new Size(200, 26);
            showIncTb2.TabIndex = 4;
            // 
            // showIncLbl3
            // 
            showIncLbl3.AutoSize = true;
            showIncLbl3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl3.Location = new Point(915, 198);
            showIncLbl3.Name = "showIncLbl3";
            showIncLbl3.Size = new Size(51, 20);
            showIncLbl3.TabIndex = 3;
            showIncLbl3.Text = "showIncLbl1";
            // 
            // showIncTb3
            // 
            showIncTb3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb3.Location = new Point(1002, 195);
            showIncTb3.Name = "showIncTb3";
            showIncTb3.Size = new Size(200, 26);
            showIncTb3.TabIndex = 4;
            // 
            // showIncLbl4
            // 
            showIncLbl4.AutoSize = true;
            showIncLbl4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl4.Location = new Point(915, 238);
            showIncLbl4.Name = "showIncLbl4";
            showIncLbl4.Size = new Size(51, 20);
            showIncLbl4.TabIndex = 3;
            showIncLbl4.Text = "showIncLbl1";
            // 
            // showIncTb4
            // 
            showIncTb4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb4.Location = new Point(1002, 235);
            showIncTb4.Name = "showIncTb4";
            showIncTb4.Size = new Size(200, 26);
            showIncTb4.TabIndex = 4;
            // 
            // showIncLbl5
            // 
            showIncLbl5.AutoSize = true;
            showIncLbl5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl5.Location = new Point(915, 278);
            showIncLbl5.Name = "showIncLbl5";
            showIncLbl5.Size = new Size(51, 20);
            showIncLbl5.TabIndex = 3;
            showIncLbl5.Text = "showIncLbl1";
            // 
            // showIncTb5
            // 
            showIncTb5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb5.Location = new Point(1002, 275);
            showIncTb5.Name = "showIncTb5";
            showIncTb5.Size = new Size(200, 26);
            showIncTb5.TabIndex = 4;

            pnl_show.Controls.Add(showIncLbl1);
            pnl_show.Controls.Add(showIncLbl2);
            pnl_show.Controls.Add(showIncLbl3);
            pnl_show.Controls.Add(showIncLbl4);
            pnl_show.Controls.Add(showIncLbl5);
            pnl_show.Controls.Add(showIncLblType);

            pnl_show.Controls.Add(showIncType);
            pnl_show.Controls.Add(showIncTb1);
            pnl_show.Controls.Add(showIncTb2);
            pnl_show.Controls.Add(showIncTb3);
            pnl_show.Controls.Add(showIncTb4);
            pnl_show.Controls.Add(showIncTb5);
        }

        private void HideAllAdditionControls()
        {
            showIncLbl1.Visible = false;
            showIncLbl2.Visible = false;
            showIncLbl3.Visible = false;
            showIncLbl4.Visible = false;
            showIncLbl5.Visible = false;
            showIncLblType.Visible = false;

            showIncTb1.Visible = false;
            showIncTb2.Visible = false;
            showIncTb3.Visible = false;
            showIncTb4.Visible = false;
            showIncTb5.Visible = false;
            showIncType.Visible = false;
        }
    }
}
