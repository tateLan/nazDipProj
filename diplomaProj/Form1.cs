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
    }
}
