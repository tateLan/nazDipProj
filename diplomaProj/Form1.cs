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
    public partial class Form1 : Form
    {
        //etalon-manager 12345Password

        private MySqlConnection connect;
        private string server = "176.98.27.33";
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private int managerID;

        int[] mngrArr;


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

        Label regNew_lbl1 = new Label();
        Label regNew_lblcodeOfItem = new Label();
        Label regNew_lblQuantity = new Label();
        Label regNew_lblPaid = new Label();
        Label regNew_lblDeliveryCost = new Label();
        public TextBox regNew_tb1 = new TextBox();
        public TextBox regNew_tbCodeOfItem = new TextBox();
        TextBox regNew_tbQuantity = new TextBox();
        TextBox regNew_tbPaid = new TextBox();
        TextBox regNew_tbDelCost = new TextBox();
        Button regNew_btnConfirm = new Button();
        CheckBox regNew_cbDelivery = new CheckBox();

        GetCodes2IncomeOutcome form2;
        //
        //start inits and stuff
        //
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
            pnl_choose_mngr.Dock = DockStyle.Fill;
        }

        private void HideAllPnls()
        {
            pnl_auth.Hide();
            pnl_mainMenu.Hide();
            pnl_registerNew.Hide();
            pnl_show.Hide();
            pnl_choose_mngr.Hide();
        }

        private void InitManagersCB()
        {
            MySqlDataReader reader = new MySqlCommand("select managers.codeOfManager, managers.nameOfManager, managers.lastNameOfManager from managers", connect).ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                cb_managersList.Items.Add(reader[1] + " " + reader[2]);
                i++;
            }
            reader.Close();

            mngrArr = new int[i];

            reader = new MySqlCommand("select managers.codeOfManager, managers.nameOfManager, managers.lastNameOfManager from managers", connect).ExecuteReader();

            for (int j = 0; j < i; j++)
            {
                reader.Read();
                mngrArr[j] = Convert.ToInt32(reader[0]);
            }
            reader.Close();
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

            regNew_lbl1.Visible = false;
            regNew_lblcodeOfItem.Visible = false;
            regNew_lblQuantity.Visible = false;
            regNew_lblPaid.Visible = false;
            regNew_lblDeliveryCost.Visible = false;
            regNew_cbDelivery.Visible = false;
            regNew_tb1.Visible = false;
            regNew_tbCodeOfItem.Visible = false;
            regNew_tbQuantity.Visible = false;
            regNew_tbPaid.Visible = false;
            regNew_tbDelCost.Visible = false;
            regNew_btnConfirm.Visible = false;

            regNew_cbDelivery.Checked = false;
            regNew_tb1.Text = "";
            regNew_tbCodeOfItem.Text = "";
            regNew_tbQuantity.Text = "";
            regNew_tbPaid.Text = "";
            regNew_tbDelCost.Text = "";

            regNew_btnConfirm.Click -= RegNew_btnConfirm_Income_Click;
            regNew_btnConfirm.Click -= RegNew_Sell_btnConfirm_Click;

            regNew_tb1.Click -= regNew_tbProvider;
            regNew_tb1.Click -= RegNew_Sell_tb1_Click;
            regNew_tbCodeOfItem.Click -= RegNew_tbCodeOfItem_Click;

            regNew_tbCodeOfItem.TextChanged -= RegNew_CheckIsWHAvailabe;
            regNew_tbQuantity.TextChanged -= RegNew_CheckIsWHAvailabe;

            dgw_show.CellMouseClick -= Dgw_show_CellMouseClick;
            dgw_show.CellClick -= Dgw_show_CellClick_Outcome;
            dgw_show.CellClick -= Dgw_show_CellClick_Warehouse;
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

        private void btn_auth_enter_Click(object sender, EventArgs e)
        {
            string login = "etalon-manager";
            string password = "12345Password";
            //if (login == tb_auth_login.Text && password == tb_auth_pass.Text)
            //{
            pnl_auth.Hide();
            GetConnect(login, password);
            pnl_choose_mngr.Show();
            InitManagersCB();
            HideAllBtns();
            //}
            //else
            //{
            //    lbl_auth_invalidData.Visible = true;
            //    tb_auth_pass.Text = "";
            //}
        }

        //
        //main menu
        //
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

            RegisterNewIncomeAddCtrls();

            regNew_btnConfirm.Location = new Point(400, 242);
            regNew_lbl1.Text = "Постачальник";
            regNew_tb1.Click += regNew_tbProvider;

            regNew_lbl1.Visible = true;
            regNew_lblcodeOfItem.Visible = true;
            regNew_lblQuantity.Visible = true;
            regNew_lblPaid.Visible = true;
            regNew_tb1.Visible = true;
            regNew_tbCodeOfItem.Visible = true;
            regNew_tbQuantity.Visible = true;
            regNew_tbPaid.Visible = true;
            regNew_btnConfirm.Visible = true;

            regNew_tb1.ReadOnly = true;
            regNew_tbCodeOfItem.ReadOnly = true;
            regNew_btnConfirm.Click += RegNew_btnConfirm_Income_Click;
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

        private void btn_mainMenu_registerSell_Click(object sender, EventArgs e)
        {
            HideAllBtns();
            pnl_mainMenu.Hide();
            pnl_registerNew.Show();

            RegisterNewIncomeAddCtrls();
            regNew_lbl1.Text = "Код клієнта";
            regNew_lblDeliveryCost.Enabled = false;
            regNew_tbDelCost.Enabled = false;
            regNew_cbDelivery.CheckedChanged += RegNew_cbDelivery_CheckedChanged;


            regNew_lbl1.Visible = true;
            regNew_lblcodeOfItem.Visible = true;
            regNew_lblQuantity.Visible = true;
            regNew_lblPaid.Visible = true;
            regNew_lblDeliveryCost.Visible = true;
            regNew_cbDelivery.Visible = true;
            regNew_tb1.Visible = true;
            regNew_tbCodeOfItem.Visible = true;
            regNew_tbQuantity.Visible = true;
            regNew_tbPaid.Visible = true;
            regNew_tbDelCost.Visible = true;
            regNew_btnConfirm.Visible = true;
            regNew_btnConfirm.Enabled = false;

            regNew_tb1.Click += RegNew_Sell_tb1_Click;
            regNew_tbCodeOfItem.TextChanged += RegNew_CheckIsWHAvailabe;
            regNew_tbQuantity.TextChanged += RegNew_CheckIsWHAvailabe;

            regNew_tb1.ReadOnly = true;
            regNew_tbCodeOfItem.ReadOnly = true;

            regNew_btnConfirm.Click += RegNew_Sell_btnConfirm_Click;
        }


        //
        //register income
        //
        private void RegisterNewIncomeAddCtrls()
        {
            // 
            // regNew_lbl1
            // 
            this.regNew_lbl1.AutoSize = true;
            this.regNew_lbl1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_lbl1.Location = new Point(280, 90);
            this.regNew_lbl1.Name = "regNew_lbl1";
            this.regNew_lbl1.Size = new Size(51, 20);
            this.regNew_lbl1.TabIndex = 1;
            this.regNew_lbl1.Text = "regNew_lbl1";
            // 
            // regNew_tb1
            // 
            this.regNew_tb1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_tb1.Location = new Point(399, 84);
            this.regNew_tb1.Name = "regNew_tb1";
            this.regNew_tb1.Size = new Size(174, 26);
            this.regNew_tb1.TabIndex = 2;
            // 
            // regNew_lblcodeOfItem
            // 
            this.regNew_lblcodeOfItem.AutoSize = true;
            this.regNew_lblcodeOfItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_lblcodeOfItem.Location = new Point(280, 131);
            this.regNew_lblcodeOfItem.Name = "regNew_lblcodeOfItem";
            this.regNew_lblcodeOfItem.Size = new Size(51, 20);
            this.regNew_lblcodeOfItem.TabIndex = 1;
            this.regNew_lblcodeOfItem.Text = "Код товару";
            // 
            // regNew_tbCodeOfItem
            // 
            this.regNew_tbCodeOfItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_tbCodeOfItem.Location = new Point(399, 123);
            this.regNew_tbCodeOfItem.Name = "regNew_tbCodeOfItem";
            this.regNew_tbCodeOfItem.Size = new Size(174, 26);
            this.regNew_tbCodeOfItem.TabIndex = 2;
            // 
            // regNew_lblQuantity
            // 
            this.regNew_lblQuantity.AutoSize = true;
            this.regNew_lblQuantity.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_lblQuantity.Location = new Point(280, 170);
            this.regNew_lblQuantity.Name = "regNew_lblQuantity";
            this.regNew_lblQuantity.Size = new Size(51, 20);
            this.regNew_lblQuantity.TabIndex = 1;
            this.regNew_lblQuantity.Text = "Кількість";
            // 
            // regNew_tbQuantity
            // 
            this.regNew_tbQuantity.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_tbQuantity.Location = new Point(399, 162);
            this.regNew_tbQuantity.Name = "regNew_tbQuantity";
            this.regNew_tbQuantity.Size = new Size(174, 26);
            this.regNew_tbQuantity.TabIndex = 2;
            // 
            // regNew_lblPaid
            // 
            this.regNew_lblPaid.AutoSize = true;
            this.regNew_lblPaid.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_lblPaid.Location = new Point(280, 208);
            this.regNew_lblPaid.Name = "regNew_lblPaid";
            this.regNew_lblPaid.Size = new Size(51, 20);
            this.regNew_lblPaid.TabIndex = 1;
            this.regNew_lblPaid.Text = "Заплачено";
            // 
            // regNew_tbPaid
            // 
            this.regNew_tbPaid.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_tbPaid.Location = new Point(399, 200);
            this.regNew_tbPaid.Name = "regNew_tbPaid";
            this.regNew_tbPaid.Size = new Size(174, 26);
            this.regNew_tbPaid.TabIndex = 2;
            // 
            // regNew_cbDelivery
            // 
            this.regNew_cbDelivery.AutoSize = true;
            this.regNew_cbDelivery.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_cbDelivery.Location = new Point(331, 242);
            this.regNew_cbDelivery.Name = "regNew_cbDelivery";
            this.regNew_cbDelivery.Size = new Size(106, 24);
            this.regNew_cbDelivery.TabIndex = 3;
            this.regNew_cbDelivery.Text = "Доставка та монтаж";
            this.regNew_cbDelivery.UseVisualStyleBackColor = true;
            // 
            // regNew_lblDeliveryCost
            // 
            this.regNew_lblDeliveryCost.AutoSize = true;
            this.regNew_lblDeliveryCost.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_lblDeliveryCost.Location = new Point(280, 285);
            this.regNew_lblDeliveryCost.Name = "regNew_lblDeliveryCost";
            this.regNew_lblDeliveryCost.Size = new Size(51, 20);
            this.regNew_lblDeliveryCost.TabIndex = 1;
            this.regNew_lblDeliveryCost.Text = "Ціна доставки";
            // 
            // regNew_tbDelCost
            // 
            this.regNew_tbDelCost.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_tbDelCost.Location = new Point(399, 282);
            this.regNew_tbDelCost.Name = "regNew_tbDelCost";
            this.regNew_tbDelCost.Size = new Size(174, 26);
            this.regNew_tbDelCost.TabIndex = 2;
            // 
            // regNew_btnConfirm
            // 
            this.regNew_btnConfirm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.regNew_btnConfirm.Location = new Point(400, 335);
            this.regNew_btnConfirm.Name = "regNew_btnConfirm";
            this.regNew_btnConfirm.Size = new Size(120, 41);
            this.regNew_btnConfirm.TabIndex = 4;
            this.regNew_btnConfirm.Text = "Підтвердити";
            this.regNew_btnConfirm.UseVisualStyleBackColor = true;

            pnl_registerNew.Controls.Add(regNew_lbl1);
            pnl_registerNew.Controls.Add(regNew_lblcodeOfItem);
            pnl_registerNew.Controls.Add(regNew_lblQuantity);
            pnl_registerNew.Controls.Add(regNew_lblPaid);
            pnl_registerNew.Controls.Add(regNew_lblDeliveryCost);
            pnl_registerNew.Controls.Add(regNew_cbDelivery);
            pnl_registerNew.Controls.Add(regNew_tb1);
            pnl_registerNew.Controls.Add(regNew_tbCodeOfItem);
            pnl_registerNew.Controls.Add(regNew_tbQuantity);
            pnl_registerNew.Controls.Add(regNew_tbPaid);
            pnl_registerNew.Controls.Add(regNew_tbDelCost);
            pnl_registerNew.Controls.Add(regNew_btnConfirm);


            regNew_lbl1.Visible = false;
            regNew_lblcodeOfItem.Visible = false;
            regNew_lblQuantity.Visible = false;
            regNew_lblPaid.Visible = false;
            regNew_lblDeliveryCost.Visible = false;
            regNew_cbDelivery.Visible = false;
            regNew_tb1.Visible = false;
            regNew_tbCodeOfItem.Visible = false;
            regNew_tbQuantity.Visible = false;
            regNew_tbPaid.Visible = false;
            regNew_tbDelCost.Visible = false;
            regNew_btnConfirm.Visible = false;

            regNew_tbCodeOfItem.Click += RegNew_tbCodeOfItem_Click;
        }

        private void RegNew_btnConfirm_Income_Click(object sender, EventArgs e)
        {
            if (regNew_tb1.Text != "" && regNew_tbCodeOfItem.Text != "" && regNew_tbQuantity.Text != "" && regNew_tbPaid.Text != "")
            {
                int num1;
                bool fl1 = int.TryParse(regNew_tbQuantity.Text, out num1);
                int num2;
                bool fl2 = int.TryParse(regNew_tbQuantity.Text, out num2);
                if (fl1 && fl2)
                {
                    bool flag = false;
                    string month;
                    string day;

                    if (Convert.ToInt16(DateTime.Now.Month.ToString()) < 10)
                        month = $"0{DateTime.Now.Month}";
                    else
                        month = DateTime.Now.Month.ToString();

                    if (Convert.ToInt16(DateTime.Now.Day.ToString()) < 10)
                        day = $"0{DateTime.Now.Day}";
                    else
                        day = DateTime.Now.Day.ToString();


                    string today = $"{DateTime.Now.Year}-{month}-{day}";
                    new MySqlCommand("insert into activity (activity.dateOfReg) values ('" + today + "')", connect).ExecuteNonQuery();

                    MySqlDataReader reader = new MySqlCommand("select id from activity order by id desc limit 1", connect).ExecuteReader();
                    reader.Read();

                    string id = reader[0].ToString();

                    reader.Close();

                    string q = $"insert into income values ({id}, {regNew_tb1.Text}, { regNew_tbCodeOfItem.Text}, {regNew_tbQuantity.Text}, {regNew_tbPaid.Text})";
                    new MySqlCommand(q, connect).ExecuteNonQuery();

                    reader = new MySqlCommand("select * from warehouse", connect).ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[1].ToString() == regNew_tbCodeOfItem.Text)
                        {
                            int quant = Convert.ToInt32(reader[2]);
                            string whitCode = reader[0].ToString();
                            reader.Close();
                            new MySqlCommand($"update warehouse set quantity=" +
                                $"'{quant + Convert.ToInt32(regNew_tbQuantity.Text)}' where codeOfWHitem='{whitCode}'", connect).ExecuteNonQuery();

                            flag = true;

                            break;
                        }
                    }

                    if (!flag)
                    {
                        reader.Close();
                        new MySqlCommand($"insert into warehouse(codeOfItem, quantity) values ('{id}', '{regNew_tbQuantity.Text}')", connect).ExecuteNonQuery();
                    }

                    MessageBox.Show("Дані внесено успішно!");

                    regNew_tb1.Text = "";
                    regNew_tbCodeOfItem.Text = "";
                    regNew_tbQuantity.Text = "";
                    regNew_tbPaid.Text = "";
                }
                else
                {
                    MessageBox.Show("Не може бути текстових даних");
                }
            }
            else
            {
                MessageBox.Show("Не може бути пустих полів!");
            }

        }

        //
        //register outcome
        //

        private void RegNew_cbDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if (regNew_cbDelivery.Checked == false)
            {
                regNew_lblDeliveryCost.Enabled = false;
                regNew_tbDelCost.Enabled = false;
                regNew_tbDelCost.Text = "";
            }
            else
            {
                regNew_lblDeliveryCost.Enabled = true;
                regNew_tbDelCost.Enabled = true;
            }
        }


        private void InsertOutcome(bool delFl, int delCost)
        {
            bool flag = false;
            string month;
            string day;

            if (Convert.ToInt16(DateTime.Now.Month.ToString()) < 10)
                month = $"0{DateTime.Now.Month}";
            else
                month = DateTime.Now.Month.ToString();

            if (Convert.ToInt16(DateTime.Now.Day.ToString()) < 10)
                day = $"0{DateTime.Now.Day}";
            else
                day = DateTime.Now.Day.ToString();


            string today = $"{DateTime.Now.Year}-{month}-{day}";
            new MySqlCommand("insert into activity (activity.dateOfReg) values ('" + today + "')", connect).ExecuteNonQuery();

            MySqlDataReader reader = new MySqlCommand("select id from activity order by id desc limit 1", connect).ExecuteReader();
            reader.Read();

            string id = reader[0].ToString();

            reader.Close();

            string q = $"insert into outcome values ({id}, '{today}', {regNew_tb1.Text}, {regNew_tbCodeOfItem.Text}, {regNew_tbQuantity.Text}, {regNew_tbPaid.Text}, {delFl}, {delCost}, {managerID})";
            new MySqlCommand(q, connect).ExecuteNonQuery();

            reader = new MySqlCommand("select * from warehouse", connect).ExecuteReader();

            while (reader.Read())
            {
                if (reader[1].ToString() == regNew_tbCodeOfItem.Text)
                {
                    int quant = Convert.ToInt32(reader[2]);
                    string whitCode = reader[0].ToString();
                    reader.Close();
                    new MySqlCommand($"update warehouse set quantity=" +
                        $"'{quant - Convert.ToInt32(regNew_tbQuantity.Text)}' where codeOfWHitem='{whitCode}'", connect).ExecuteNonQuery();

                    flag = true;

                    break;
                }
            }

            if (!flag)
            {
                reader.Close();
                new MySqlCommand($"insert into warehouse(codeOfItem, quantity) values ('{id}', '{regNew_tbQuantity.Text}')", connect).ExecuteNonQuery();
            }

            reader = new MySqlCommand("select * from clients where codeOfClient = " + regNew_tb1.Text, connect).ExecuteReader();
            reader.Read();
            int spent = Convert.ToInt32(reader[5]) + Convert.ToInt32(regNew_tbPaid.Text);
            int codeofcl = Convert.ToInt32(reader[0]);
            reader.Close();

            new MySqlCommand("update clients set spent=" + spent + " where codeOfClient=" + codeofcl + "", connect).ExecuteNonQuery();

            MessageBox.Show("Дані внесено успішно!");

            regNew_tb1.Text = "";
            regNew_tbCodeOfItem.Text = "";
            regNew_tbQuantity.Text = "";
            regNew_tbPaid.Text = "";
            regNew_tbDelCost.Text = "";
        }


        private void RegNew_Sell_btnConfirm_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            int paid = 0;
            int cost = 0;

            bool fl1;
            bool fl2;
            bool fl3;

            if (regNew_cbDelivery.Checked == true)
            {
                if (regNew_tb1.Text != "" && regNew_tbCodeOfItem.Text != "" && regNew_tbQuantity.Text != "" && regNew_tbPaid.Text != "" && regNew_tbDelCost.Text != "")
                {
                    fl1 = int.TryParse(regNew_tbQuantity.Text, out quantity);
                    fl2 = int.TryParse(regNew_tbPaid.Text, out paid);
                    fl3 = int.TryParse(regNew_tbDelCost.Text, out cost);

                    if (fl1 && fl2 && fl3)
                    {
                        InsertOutcome(true, cost);
                    }
                    else
                    {
                        MessageBox.Show("Допустимі лише числові значення!");
                    }
                }
                else
                {
                    MessageBox.Show("Не допустимі пусті поля!");
                }
            }
            else
            {
                if (regNew_tb1.Text != "" && regNew_tbCodeOfItem.Text != "" && regNew_tbQuantity.Text != "" && regNew_tbPaid.Text != "")
                {
                    fl1 = int.TryParse(regNew_tbQuantity.Text, out quantity);
                    fl2 = int.TryParse(regNew_tbPaid.Text, out paid);

                    if (fl1 && fl2)
                    {
                        InsertOutcome(false, 0);
                    }
                    else
                    {
                        MessageBox.Show("Допустимі лише числові значення!");
                    }
                }
                else
                {
                    MessageBox.Show("Не допустимі пусті поля!");
                }
            }
        }

        private void RegNew_CheckIsWHAvailabe(object sender, EventArgs e)
        {
            int codeItem;
            int quant;
            bool fl1 = int.TryParse(regNew_tbQuantity.Text, out quant);
            bool fl2 = int.TryParse(regNew_tbCodeOfItem.Text, out codeItem);

            if (fl1 && fl2)
            {
                MySqlDataReader reader = new MySqlCommand("select warehouse.quantity from warehouse where warehouse.codeOfItem = " + codeItem, connect).ExecuteReader();
                reader.Read();
                if (Convert.ToInt32(reader[0]) < quant)
                {
                    regNew_btnConfirm.Enabled = false;
                    MessageBox.Show($"Вибраного товару на складі доступно лише {reader[0]} одиниць");
                }
                else
                {
                    regNew_btnConfirm.Enabled = true;
                }
                reader.Close();
            }
        }

        private void RegNew_Sell_tb1_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "clients", this);
            form2.ShowDialog();
        }

        //
        //else
        //

        public void regNew_tbProvider(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "provider", this);
            form2.ShowDialog();

        }
        
        public void RegNew_tbCodeOfItem_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "items", this);
            form2.ShowDialog();
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

                        dgw_show.CellMouseClick += Dgw_show_CellMouseClick;

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
                        getAdditControls();

                        dgw_show.CellClick += Dgw_show_CellClick_Outcome;

                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("dateOfOutcome", "дата_продажі");
                        dgw_show.Columns.Add("nameClient", "ім'я_клієнта");
                        dgw_show.Columns.Add("lastNameClient", "прізвище_клієнта");
                        dgw_show.Columns.Add("codeOfItem", "код_товару");
                        dgw_show.Columns.Add("quantity", "кількість");
                        dgw_show.Columns.Add("paid", "заплачено");
                        dgw_show.Columns.Add("montageDelivery", "монтаж/доставка");
                        dgw_show.Columns.Add("montageDeliveryCost", "вартість_монтажу/доставки");
                        dgw_show.Columns.Add("nameManager", "ім'я_менеджера");
                        dgw_show.Columns.Add("lastNameManager", "прізвище_менеджера");
                        q = "call showOutcome";
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 11);

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
                case "warehouse":
                    {
                        getAdditControls();

                        dgw_show.CellClick += Dgw_show_CellClick_Warehouse;

                        dgw_show.Columns.Add("code", "код_складу");
                        dgw_show.Columns.Add("codeOfItem", "код_товару");
                        dgw_show.Columns.Add("quantify", "кількість");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 3);

                        reader.Close();

                        HideAllAdditionControls();
                    }
                    break;
            }
        }

        private void Dgw_show_CellClick_Warehouse(object sender, DataGridViewCellEventArgs e)
        {
            HideAllAdditionControls();
            if (e.RowIndex > dgw_show.RowCount || e.RowIndex < 0)
                return;
            DataGridViewRow dgwr = dgw_show.Rows[e.RowIndex];
            MySqlDataReader reader = new MySqlCommand("call getType4showIncome(" + dgwr.Cells[1].Value + ")", connect).ExecuteReader();

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

                        reader = new MySqlCommand("select * from windows where windows.codeOfItem = " + dgwr.Cells[1].Value, connect).ExecuteReader();
                        while (reader.Read())
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

                        reader = new MySqlCommand("call getDoorsExt(" + dgwr.Cells[1].Value + ")", connect).ExecuteReader();
                        while (reader.Read())
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

                        reader = new MySqlCommand("call getWindowsillExt(" + dgwr.Cells[1].Value + ")", connect).ExecuteReader();
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

                        reader = new MySqlCommand("select * from mosquito_net where mosquito_net.codeOfItem = " + dgwr.Cells[1].Value, connect).ExecuteReader();
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

                        reader = new MySqlCommand("select * from reflux where reflux.codeOfItem = " + dgwr.Cells[1].Value, connect).ExecuteReader();
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

        private void Dgw_show_CellClick_Outcome(object sender, DataGridViewCellEventArgs e)
        {
            HideAllAdditionControls();
            if (e.RowIndex > dgw_show.RowCount || e.RowIndex < 0)
                return;
            DataGridViewRow dgwr = dgw_show.Rows[e.RowIndex];
            MySqlDataReader reader = new MySqlCommand("call getType4showIncome(" + dgwr.Cells[4].Value + ")", connect).ExecuteReader();

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

                        reader = new MySqlCommand("select * from windows where windows.codeOfItem = " + dgwr.Cells[4].Value, connect).ExecuteReader();
                        while (reader.Read())
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

                        reader = new MySqlCommand("call getDoorsExt(" + dgwr.Cells[4].Value + ")", connect).ExecuteReader();
                        while (reader.Read())
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

                        reader = new MySqlCommand("call getWindowsillExt(" + dgwr.Cells[4].Value + ")", connect).ExecuteReader();
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

                        reader = new MySqlCommand("select * from mosquito_net where mosquito_net.codeOfItem = " + dgwr.Cells[4].Value, connect).ExecuteReader();
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

                        reader = new MySqlCommand("select * from reflux where reflux.codeOfItem = " + dgwr.Cells[4].Value, connect).ExecuteReader();
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
                        while (reader.Read())
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

                        reader = new MySqlCommand("call getDoorsExt(" + dgwr.Cells[3].Value + ")", connect).ExecuteReader();
                        while (reader.Read())
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

                        reader = new MySqlCommand("call getWindowsillExt(" + dgwr.Cells[3].Value + ")", connect).ExecuteReader();
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

        private void btn_manager_chose_accept_Click(object sender, EventArgs e)
        {
            if(cb_managersList.SelectedIndex != -1 )
            {
                managerID = mngrArr[cb_managersList.SelectedIndex];
                MessageBox.Show("Вітаю, " + cb_managersList.Text);
                pnl_choose_mngr.Hide();
                pnl_mainMenu.Show();
            }
        }
    }
}
