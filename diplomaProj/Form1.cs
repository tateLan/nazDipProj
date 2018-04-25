using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomaProj
{
    public partial class Form1 : Form
    {
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
        }

        private void HideAllPnls()
        {
            pnl_auth.Hide();
;        }

        private void btn_auth_enter_Click(object sender, EventArgs e)
        {
            pnl_auth.Hide();
        }
    }
}
