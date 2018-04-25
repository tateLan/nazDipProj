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

        public Form1()
        {
            InitializeComponent();

            InitPanels();
            HideAllPnls();

            tb_auth_login.Select();

            pnl_auth.Show();
        }

        private void InitPanels()
        {
            pnl_auth.Dock = DockStyle.Fill;
            pnl_mainMenu.Dock = DockStyle.Fill;
        }

        private void HideAllPnls()
        {
            pnl_auth.Hide();
            pnl_mainMenu.Hide();
        }

        private void btn_auth_enter_Click(object sender, EventArgs e)
        {
            string login = "etalon-manager";
            string password = "12345Password";
            if (login == tb_auth_login.Text && password == tb_auth_pass.Text)
            {
                pnl_auth.Hide();
                GetConnect(login, password);
                pnl_mainMenu.Show();
                HideAllBtns();
            }
            else
            {
                lbl_auth_invalidData.Visible = true;
                tb_auth_pass.Text = "";
            }
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
        }

        private void btn_mainMenu_registerSell_Click(object sender, EventArgs e)
        {
            HideAllBtns();
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

            btn_mainMenu_slot1.Text = "Переглянути вікна";
            btn_mainMenu_slot2.Text = "Переглянути двері";
            btn_mainMenu_slot3.Text = "Переглянути підвіконня";
            btn_mainMenu_slot4.Text = "Переглянути відливи";
            btn_mainMenu_slot5.Text = "Переглянути москітні сітки";
            btn_mainMenu_slot6.Text = "Переглянути поставки";
            btn_mainMenu_slot7.Text = "Переглянути продажі";
            btn_mainMenu_slot8.Text = "Переглянути склад";
        }

        private void AddItem(object sender, EventArgs e)
        {

        }

        private void ChangeItem(object sender, EventArgs e)
        {

        }

        private void AddClient(object sender, EventArgs e)
        {

        }

        private void ChangeClient(object sender, EventArgs e)
        {

        }
    }
}
