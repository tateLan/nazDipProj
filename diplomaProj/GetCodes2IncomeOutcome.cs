using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace diplomaProj
{
    public partial class GetCodes2IncomeOutcome : Form
    {
        MySqlConnection connect;
        string table;

        public GetCodes2IncomeOutcome(MySqlConnection con, string table)
        {
            InitializeComponent();

            connect = con;
            this.table = table;

        }
    }
}
