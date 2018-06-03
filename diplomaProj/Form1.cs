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
        string chItem_type;

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

        Label label6 = new Label();
        Label label5 = new Label();
        Label lbl_addch_cblbl = new Label();
        ComboBox cb_addch_itemType = new ComboBox();
        Button btn_addch_confirm = new Button();
        public TextBox tb_adch_slot5tb = new TextBox();
        Label lbl_adch_slot5lbl = new Label();
        public TextBox tb_adch_slot4tb = new TextBox();
        Label lbl_adch_slot4lbl = new Label();
        public TextBox tb_adch_slot3tb = new TextBox();
        Label lbl_adch_slot3lbl = new Label();
        public TextBox tb_adch_slot2tb = new TextBox();
        Label lbl_adch_slot2lbl = new Label();
        public TextBox tb_adch_slot1tb = new TextBox();
        Label lbl_adch_slot1lbl = new Label();

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

            GetConnect();

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
            pnl_add_change.Dock = DockStyle.Fill;
            pnl_root.Dock = DockStyle.Fill;
            pnl_send2factory.Dock = DockStyle.Fill;
            pnl_showfactoryProces.Dock = DockStyle.Fill;
            pnl_changeFstatus.Dock = DockStyle.Fill;
        }

        private void HideAllPnls()
        {
            pnl_auth.Hide();
            pnl_mainMenu.Hide();
            pnl_registerNew.Hide();
            pnl_show.Hide();
            pnl_choose_mngr.Hide();
            pnl_add_change.Hide();
            pnl_root.Hide();
            pnl_send2factory.Hide();
            pnl_showfactoryProces.Hide();
            pnl_changeFstatus.Hide();
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

        private void GetConnect()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = server;
                builder.Port = 3306;
                builder.ConnectionProtocol = MySqlConnectionProtocol.Tcp;
                builder.SslMode = MySqlSslMode.None;
                builder.Database = "windowsSellerCompany";
                builder.UserID = "etalon-manager";
                builder.Password = "12345Password";

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

            btn_mainMenu_slot3.Click -= sendToFactory;
            btn_mainMenu_slot4.Click -= checkFactoryStatus;
            btn_mainMenu_slot5.Click -= changeFactoryStatus;
            btn_mainMenu_slot6.Click -= addFactory;
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

            pnl_add_change.Controls.Remove(lbl_adch_slot1lbl);
            pnl_add_change.Controls.Remove(tb_adch_slot1tb);
            pnl_add_change.Controls.Remove(lbl_adch_slot2lbl);
            pnl_add_change.Controls.Remove(tb_adch_slot2tb);
            pnl_add_change.Controls.Remove(lbl_adch_slot3lbl);
            pnl_add_change.Controls.Remove(tb_adch_slot3tb);
            pnl_add_change.Controls.Remove(lbl_adch_slot4lbl);
            pnl_add_change.Controls.Remove(tb_adch_slot4tb);
            pnl_add_change.Controls.Remove(lbl_adch_slot5lbl);
            pnl_add_change.Controls.Remove(tb_adch_slot5tb);
            pnl_add_change.Controls.Remove(btn_addch_confirm);
            pnl_add_change.Controls.Remove(cb_addch_itemType);
            pnl_add_change.Controls.Remove(lbl_addch_cblbl);

            UnbindHandlersCHADD();
            cb_addch_itemType.Items.Clear();
            cb_addch_itemType.SelectedIndexChanged -= Cb_addch_itemType_SelectedIndexChanged;

            tb_adch_slot1tb.Text = "";
            tb_adch_slot2tb.Text = "";
            tb_adch_slot3tb.Text = "";
            tb_adch_slot4tb.Text = "";
            tb_adch_slot5tb.Text = "";

            tb_send2fac_codeoffactory.Text = "";
            tb_send2fac_codeoforder.Text = "";

            dgw_showfactoryProcess.Rows.Clear();
            dgw_showfactoryProcess.Columns.Clear();

            cb_fStatus.Items.Clear();
        }

        private void UnbindHandlersCHADD()
        {
            btn_addch_confirm.Click -= Btn_addch_confirm_AddUSer_Click;
            tb_adch_slot1tb.Click -= Tb_adch_slot1tb_ChangeClient_Click;

            tb_adch_slot1tb.ReadOnly = false;
            tb_adch_slot2tb.ReadOnly = false;
            tb_adch_slot3tb.ReadOnly = false;
            tb_adch_slot4tb.ReadOnly = false;
            tb_adch_slot5tb.ReadOnly = false;

            btn_addch_confirm.Click -= Btn_addch_confirm_ChangeClient_Click;

            tb_adch_slot1tb.Click -= Tb_adch_slot1tb_DoorsChange_Click;
            tb_adch_slot3tb.Click -= Tb_adch_slot3tb_DoorsChange_TypePick_Click;
            tb_adch_slot5tb.Click -= Tb_adch_slot5tb_DoorsChange_ColorPick_Click;

            btn_addch_confirm.Click -= Btn_addch_confirm_ChangeDoors_Click;

            tb_adch_slot1tb.Click -= Tb_adch_slot1tb_RefluxChange_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_ChangeReflux_Click;

            tb_adch_slot1tb.Click -= Tb_adch_slot1tb_WindowsChange_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_WindowsChange_Click;

            tb_adch_slot1tb.Click -= Tb_adch_slot1tb_WindowsillChange_Click;
            tb_adch_slot4tb.Click -= Tb_adch_slot4tb_WindowsillChange_ColorPick_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_WindowsillChange_Click;

            tb_adch_slot1tb.Click -= Tb_adch_slot1tb_MosquitoChange_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_MosquitoChange_Click;

            btn_addch_confirm.Click -= Btn_addch_confirm_AddReflux_Click;

            btn_addch_confirm.Click -= Btn_addch_confirm_AddDoors_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_AddWindows_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_AddWindowsill_Click;
            btn_addch_confirm.Click -= Btn_addch_confirm_AddMosquito_Click;
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
            MySqlDataReader reader = new MySqlCommand("select login, pass from loginData where id = 1", connect).ExecuteReader();
            reader.Read();

            string login = reader[0].ToString();
            string password = reader[1].ToString();

            reader.Close();
            if (tb_auth_login.Text == "root")
            {
                reader = new MySqlCommand("select login, pass from loginData where id = 2", connect).ExecuteReader();
                reader.Read();

                string root_password = reader[1].ToString();
                if (root_password == tb_auth_pass.Text)
                {
                    pnl_auth.Hide();
                    pnl_root.Show();

                    HideRootCTRLS();
                }
                else
                {
                    lbl_auth_invalidData.Visible = true;
                    tb_auth_pass.Text = "";
                }
                reader.Close();
            }
            else
            {
                if (login == tb_auth_login.Text && password == tb_auth_pass.Text)
                {
                    pnl_auth.Hide();
                    pnl_choose_mngr.Show();
                    InitManagersCB();
                    HideAllBtns();
                }
                else
                {
                    lbl_auth_invalidData.Visible = true;
                    tb_auth_pass.Text = "";
                }
            }
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

            regNew_tbCodeOfItem.Click += RegNew_tbCodeOfItem_Click;
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

            regNew_tbCodeOfItem.Click += RegNew_tbCodeOfItemOUTcome_Click;
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
                        new MySqlCommand($"insert into warehouse(codeOfItem, quantity) values ('{regNew_tbCodeOfItem.Text}', '{regNew_tbQuantity.Text}')", connect).ExecuteNonQuery();
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

        public void RegNew_tbCodeOfItem_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "items-inc", this);
            form2.ShowDialog();
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

        public void RegNew_tbCodeOfItemOUTcome_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "items", this);
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

        private void AddItem(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_add_change.Show();

            AddChange_addctrls();

            lbl_addch_cblbl.Text = "Виберіть тип товару:";
            cb_addch_itemType.DropDownStyle = ComboBoxStyle.DropDownList;

            MySqlDataReader reader = new MySqlCommand("select nameOfItem from assortment", connect).ExecuteReader();

            while (reader.Read())
            {
                cb_addch_itemType.Items.Add(reader[0]);
            }

            reader.Close();

            lbl_addch_cblbl.Visible = true;
            cb_addch_itemType.Visible = true;
            cb_addch_itemType.SelectedIndexChanged += Cb_addch_itemType_AddItem_SelectedIndexChanged; ;

        }

        private void Cb_addch_itemType_AddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnbindHandlersCHADD();

            lbl_adch_slot1lbl.Visible = false;
            tb_adch_slot1tb.Visible = false;
            lbl_adch_slot2lbl.Visible = false;
            tb_adch_slot2tb.Visible = false;
            lbl_adch_slot3lbl.Visible = false;
            tb_adch_slot3tb.Visible = false;
            lbl_adch_slot4lbl.Visible = false;
            tb_adch_slot4tb.Visible = false;
            lbl_adch_slot5lbl.Visible = false;
            tb_adch_slot5tb.Visible = false;
            btn_addch_confirm.Visible = false;


            switch (cb_addch_itemType.Text)
            {
                case "Відлив":
                    {
                        chItem_type = "reflux";

                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot2lbl.Text = "Назва";

                        tb_adch_slot1tb.ReadOnly = true;

                        btn_addch_confirm.Text = "Додати";

                        btn_addch_confirm.Click += Btn_addch_confirm_AddReflux_Click;
                    }
                    break;
                case "Двері":
                    {
                        chItem_type = "doors";

                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        lbl_adch_slot3lbl.Visible = true;
                        tb_adch_slot3tb.Visible = true;
                        lbl_adch_slot4lbl.Visible = true;
                        tb_adch_slot4tb.Visible = true;
                        lbl_adch_slot5lbl.Visible = true;
                        tb_adch_slot5tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot2lbl.Text = "Виробник";
                        lbl_adch_slot3lbl.Text = "Тип дверей";
                        lbl_adch_slot4lbl.Text = "Матеріал";
                        lbl_adch_slot5lbl.Text = "Колір";
                        btn_addch_confirm.Text = "Додати";

                        tb_adch_slot3tb.ReadOnly = true;
                        tb_adch_slot5tb.ReadOnly = true;

                        tb_adch_slot3tb.Click += Tb_adch_slot3tb_DoorsChange_TypePick_Click;
                        tb_adch_slot5tb.Click += Tb_adch_slot5tb_DoorsChange_ColorPick_Click;

                        btn_addch_confirm.Click += Btn_addch_confirm_AddDoors_Click;
                    }
                    break;
                case "Вікна":
                    {
                        chItem_type = "windows";


                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        lbl_adch_slot3lbl.Visible = true;
                        tb_adch_slot3tb.Visible = true;
                        btn_addch_confirm.Visible = true;


                        lbl_adch_slot2lbl.Text = "Виробник";
                        lbl_adch_slot3lbl.Text = "Назва";
                        btn_addch_confirm.Text = "Додати";

                        tb_adch_slot1tb.ReadOnly = true;

                        btn_addch_confirm.Click += Btn_addch_confirm_AddWindows_Click;
                    }
                    break;
                case "Підвіконня":
                    {
                        chItem_type = "windowsill";


                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        lbl_adch_slot3lbl.Visible = true;
                        tb_adch_slot3tb.Visible = true;
                        lbl_adch_slot4lbl.Visible = true;
                        tb_adch_slot4tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot2lbl.Text = "Виробник";
                        lbl_adch_slot3lbl.Text = "Матеріал";
                        lbl_adch_slot4lbl.Text = "Колір";
                        btn_addch_confirm.Text = "Додати";

                        tb_adch_slot4tb.ReadOnly = true;

                        tb_adch_slot4tb.Click += Tb_adch_slot4tb_WindowsillChange_ColorPick_Click;

                        btn_addch_confirm.Click += Btn_addch_confirm_AddWindowsill_Click;
                    }
                    break;
                case "Москітна сітка":
                    {
                        chItem_type = "mosquito_net";

                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot2lbl.Text = "Назва";

                        btn_addch_confirm.Text = "Додати";

                        btn_addch_confirm.Click += Btn_addch_confirm_AddMosquito_Click;
                    }
                    break;
            }
        }

        private void Btn_addch_confirm_AddMosquito_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot2tb.Text != "")
            {
                int id = AddItem2Items();

                new MySqlCommand($"insert into doors values ('{id}', '{tb_adch_slot2tb.Text}')", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot2tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Btn_addch_confirm_AddWindowsill_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "" && tb_adch_slot4tb.Text != "")
            {
                int id = AddItem2Items();

                new MySqlCommand($"insert into windowsill values ('{id}', '{tb_adch_slot2tb.Text}', '{tb_adch_slot3tb.Text}', " +
                    $"'{tb_adch_slot4tb.Text}')", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot2tb.Text = "";
                tb_adch_slot3tb.Text = "";
                tb_adch_slot4tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Btn_addch_confirm_AddWindows_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "")
            {
                int id = AddItem2Items();

                new MySqlCommand($"insert into windows values ('{id}', '{tb_adch_slot2tb.Text}', '{tb_adch_slot3tb.Text}')", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot2tb.Text = "";
                tb_adch_slot3tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Btn_addch_confirm_AddDoors_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "" && tb_adch_slot4tb.Text != "" && tb_adch_slot5tb.Text != "")
            {
                int id = AddItem2Items();

                new MySqlCommand($"insert into doors values ('{id}', '{tb_adch_slot2tb.Text}', '{tb_adch_slot3tb.Text}', " +
                    $"'{tb_adch_slot4tb.Text}', '{tb_adch_slot5tb.Text}')", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot2tb.Text = "";
                tb_adch_slot3tb.Text = "";
                tb_adch_slot4tb.Text = "";
                tb_adch_slot5tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Btn_addch_confirm_AddReflux_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot2tb.Text != "")
            {
                int id = AddItem2Items();

                new MySqlCommand($"insert into reflux values ('{id}', '{tb_adch_slot2tb.Text}')", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot2tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private int AddItem2Items()
        {
            MySqlDataReader reader = new MySqlCommand("select * from assortment", connect).ExecuteReader();
            int code = 0;

            while (reader.Read())
            {
                if (reader[1].ToString() == cb_addch_itemType.Text)
                {
                    code = Convert.ToInt32(reader[0]);
                    break;
                }
            }

            reader.Close();

            new MySqlCommand("insert into items(typeOfProduct) values('" + code + "')", connect).ExecuteNonQuery();

            reader = new MySqlCommand("select id from items order by id desc limit 1", connect).ExecuteReader();
            reader.Read();

            int id = Convert.ToInt32(reader[0]);

            reader.Close();

            return id;
        }

        private void ChangeItem(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_add_change.Show();

            AddChange_addctrls();

            lbl_addch_cblbl.Text = "Виберіть тип товару:";
            cb_addch_itemType.DropDownStyle = ComboBoxStyle.DropDownList;

            MySqlDataReader reader = new MySqlCommand("select nameOfItem from assortment", connect).ExecuteReader();

            while (reader.Read())
            {
                cb_addch_itemType.Items.Add(reader[0]);
            }

            reader.Close();

            lbl_addch_cblbl.Visible = true;
            cb_addch_itemType.Visible = true;
            cb_addch_itemType.SelectedIndexChanged += Cb_addch_itemType_SelectedIndexChanged;
        }

        private void Cb_addch_itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnbindHandlersCHADD();

            lbl_adch_slot1lbl.Visible = false;
            tb_adch_slot1tb.Visible = false;
            lbl_adch_slot2lbl.Visible = false;
            tb_adch_slot2tb.Visible = false;
            lbl_adch_slot3lbl.Visible = false;
            tb_adch_slot3tb.Visible = false;
            lbl_adch_slot4lbl.Visible = false;
            tb_adch_slot4tb.Visible = false;
            lbl_adch_slot5lbl.Visible = false;
            tb_adch_slot5tb.Visible = false;
            btn_addch_confirm.Visible = false;

            tb_adch_slot1tb.ReadOnly = true;

            tb_adch_slot1tb.Text = "";
            tb_adch_slot2tb.Text = "";
            tb_adch_slot3tb.Text = "";
            tb_adch_slot4tb.Text = "";
            tb_adch_slot5tb.Text = "";

            switch (cb_addch_itemType.Text)
            {
                case "Відлив":
                    {
                        chItem_type = "reflux";

                        lbl_adch_slot1lbl.Visible = true;
                        tb_adch_slot1tb.Visible = true;
                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot1lbl.Text = "Код";
                        lbl_adch_slot2lbl.Text = "Назва";

                        tb_adch_slot1tb.ReadOnly = true;

                        btn_addch_confirm.Text = "Змінити";

                        tb_adch_slot1tb.Click += Tb_adch_slot1tb_RefluxChange_Click;

                        btn_addch_confirm.Click += Btn_addch_confirm_ChangeReflux_Click;
                    }
                    break;
                case "Двері":
                    {
                        chItem_type = "doors";

                        lbl_adch_slot1lbl.Visible = true;
                        tb_adch_slot1tb.Visible = true;
                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        lbl_adch_slot3lbl.Visible = true;
                        tb_adch_slot3tb.Visible = true;
                        lbl_adch_slot4lbl.Visible = true;
                        tb_adch_slot4tb.Visible = true;
                        lbl_adch_slot5lbl.Visible = true;
                        tb_adch_slot5tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot1lbl.Text = "Код";
                        lbl_adch_slot2lbl.Text = "Виробник";
                        lbl_adch_slot3lbl.Text = "Тип дверей";
                        lbl_adch_slot4lbl.Text = "Матеріал";
                        lbl_adch_slot5lbl.Text = "Колір";
                        btn_addch_confirm.Text = "Змінити";

                        tb_adch_slot3tb.ReadOnly = true;
                        tb_adch_slot5tb.ReadOnly = true;

                        tb_adch_slot1tb.Click += Tb_adch_slot1tb_DoorsChange_Click;
                        tb_adch_slot3tb.Click += Tb_adch_slot3tb_DoorsChange_TypePick_Click;
                        tb_adch_slot5tb.Click += Tb_adch_slot5tb_DoorsChange_ColorPick_Click;

                        btn_addch_confirm.Click += Btn_addch_confirm_ChangeDoors_Click;
                    }
                    break;
                case "Вікна":
                    {
                        chItem_type = "windows";

                        lbl_adch_slot1lbl.Visible = true;
                        tb_adch_slot1tb.Visible = true;
                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        lbl_adch_slot3lbl.Visible = true;
                        tb_adch_slot3tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot1lbl.Text = "Код";
                        lbl_adch_slot2lbl.Text = "Виробник";
                        lbl_adch_slot3lbl.Text = "Назва";
                        btn_addch_confirm.Text = "Змінити";

                        tb_adch_slot1tb.ReadOnly = true;

                        tb_adch_slot1tb.Click += Tb_adch_slot1tb_WindowsChange_Click;
                        btn_addch_confirm.Click += Btn_addch_confirm_WindowsChange_Click;
                    }
                    break;
                case "Підвіконня":
                    {
                        chItem_type = "windowsill";

                        lbl_adch_slot1lbl.Visible = true;
                        tb_adch_slot1tb.Visible = true;
                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        lbl_adch_slot3lbl.Visible = true;
                        tb_adch_slot3tb.Visible = true;
                        lbl_adch_slot4lbl.Visible = true;
                        tb_adch_slot4tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot1lbl.Text = "Код";
                        lbl_adch_slot2lbl.Text = "Виробник";
                        lbl_adch_slot3lbl.Text = "Тип дверей";
                        lbl_adch_slot4lbl.Text = "Матеріал";
                        btn_addch_confirm.Text = "Змінити";

                        tb_adch_slot1tb.ReadOnly = true;
                        tb_adch_slot4tb.ReadOnly = true;

                        tb_adch_slot1tb.Click += Tb_adch_slot1tb_WindowsillChange_Click;
                        tb_adch_slot4tb.Click += Tb_adch_slot4tb_WindowsillChange_ColorPick_Click;

                        btn_addch_confirm.Click += Btn_addch_confirm_WindowsillChange_Click;
                    }
                    break;
                case "Москітна сітка":
                    {
                        chItem_type = "mosquito_net";

                        lbl_adch_slot1lbl.Visible = true;
                        tb_adch_slot1tb.Visible = true;
                        lbl_adch_slot2lbl.Visible = true;
                        tb_adch_slot2tb.Visible = true;
                        btn_addch_confirm.Visible = true;

                        lbl_adch_slot1lbl.Text = "Код";
                        lbl_adch_slot2lbl.Text = "Виробник";

                        tb_adch_slot1tb.ReadOnly = true;

                        btn_addch_confirm.Text = "Змінити";

                        tb_adch_slot1tb.Click += Tb_adch_slot1tb_MosquitoChange_Click;
                        btn_addch_confirm.Click += Btn_addch_confirm_MosquitoChange_Click;
                    }
                    break;
            }
        }

        private void Btn_addch_confirm_MosquitoChange_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot1tb.Text != "" && tb_adch_slot2tb.Text != "")
            {
                new MySqlCommand($"update mosquito_net set nameOfItem='{tb_adch_slot2tb.Text}' where codeOfItem='{tb_adch_slot1tb.Text}'", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot1tb.Text = "";
                tb_adch_slot2tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Tb_adch_slot1tb_MosquitoChange_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-mosquito", this);
            form2.ShowDialog();
        }

        private void Btn_addch_confirm_WindowsillChange_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot1tb.Text != "" && tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "" && tb_adch_slot4tb.Text != "")
            {
                new MySqlCommand($"update windowsill set manufacturer='{tb_adch_slot2tb.Text}', material='{tb_adch_slot3tb.Text}', colour='{tb_adch_slot4tb.Text}' where codeOfItem='{tb_adch_slot1tb.Text}'", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot1tb.Text = "";
                tb_adch_slot2tb.Text = "";
                tb_adch_slot3tb.Text = "";
                tb_adch_slot4tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Tb_adch_slot4tb_WindowsillChange_ColorPick_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-colors", this);
            form2.ShowDialog();
        }

        private void Tb_adch_slot1tb_WindowsillChange_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-windowsill", this);
            form2.ShowDialog();
        }

        private void Btn_addch_confirm_WindowsChange_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot1tb.Text != "" && tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "")
            {
                new MySqlCommand($"update windows set manufacturer='{tb_adch_slot2tb.Text}', nameOfItem='{tb_adch_slot3tb.Text}' where codeOfItem='{tb_adch_slot1tb.Text}'", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot1tb.Text = "";
                tb_adch_slot2tb.Text = "";
                tb_adch_slot3tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Tb_adch_slot1tb_WindowsChange_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-windows", this);
            form2.ShowDialog();
        }

        private void Btn_addch_confirm_ChangeReflux_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot1tb.Text != "" && tb_adch_slot2tb.Text != "")
            {
                new MySqlCommand($"update reflux set nameOfItem='{tb_adch_slot2tb.Text}' where codeOfItem='{tb_adch_slot1tb.Text}'", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot1tb.Text = "";
                tb_adch_slot2tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Tb_adch_slot1tb_RefluxChange_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-reflux", this);
            form2.ShowDialog();
        }

        private void Btn_addch_confirm_ChangeDoors_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot1tb.Text != "" && tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "" && tb_adch_slot4tb.Text != "" && tb_adch_slot5tb.Text != "")
            {
                new MySqlCommand($"update doors set manufacturer='{tb_adch_slot2tb.Text}', typeOfDoors='{tb_adch_slot3tb.Text}', " +
                    $"material='{tb_adch_slot4tb.Text}', colour='{tb_adch_slot5tb.Text}' where codeOfItem='{tb_adch_slot1tb.Text}'", connect).ExecuteNonQuery();

                MessageBox.Show("Дані внесено успішно!");

                tb_adch_slot1tb.Text = "";
                tb_adch_slot2tb.Text = "";
                tb_adch_slot3tb.Text = "";
                tb_adch_slot4tb.Text = "";
                tb_adch_slot5tb.Text = "";
            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void Tb_adch_slot5tb_DoorsChange_ColorPick_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "colors", this);
            form2.ShowDialog();
        }

        private void Tb_adch_slot3tb_DoorsChange_TypePick_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "types", this);
            form2.ShowDialog();
        }

        private void Tb_adch_slot1tb_DoorsChange_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-doors", this);
            form2.ShowDialog();
        }

        private void AddClient(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_add_change.Show();


            AddChange_addctrls();

            lbl_adch_slot1lbl.Visible = true;
            tb_adch_slot1tb.Visible = true;
            lbl_adch_slot2lbl.Visible = true;
            tb_adch_slot2tb.Visible = true;
            lbl_adch_slot3lbl.Visible = true;
            tb_adch_slot3tb.Visible = true;
            lbl_adch_slot4lbl.Visible = true;
            tb_adch_slot4tb.Visible = true;
            btn_addch_confirm.Visible = true;

            lbl_adch_slot1lbl.Text = "Ім'я";
            lbl_adch_slot2lbl.Text = "Прізвище";
            lbl_adch_slot3lbl.Text = "Номер";
            lbl_adch_slot4lbl.Text = "Адреса";
            btn_addch_confirm.Text = "Підтвердити";

            btn_addch_confirm.Click += Btn_addch_confirm_AddUSer_Click;
        }

        private void ChangeClient(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_add_change.Show();

            AddChange_addctrls();

            lbl_adch_slot1lbl.Text = "Код";
            lbl_adch_slot2lbl.Text = "Ім'я";
            lbl_adch_slot3lbl.Text = "Прізвище";
            lbl_adch_slot4lbl.Text = "Номер";
            lbl_adch_slot5lbl.Text = "Адреса";
            btn_addch_confirm.Text = "Змінити";

            tb_adch_slot1tb.ReadOnly = true;
            tb_adch_slot1tb.Click += Tb_adch_slot1tb_ChangeClient_Click;
            btn_addch_confirm.Click += Btn_addch_confirm_ChangeClient_Click;

            lbl_adch_slot1lbl.Visible = true;
            tb_adch_slot1tb.Visible = true;
            lbl_adch_slot2lbl.Visible = true;
            tb_adch_slot2tb.Visible = true;
            lbl_adch_slot3lbl.Visible = true;
            tb_adch_slot3tb.Visible = true;
            lbl_adch_slot4lbl.Visible = true;
            tb_adch_slot4tb.Visible = true;
            lbl_adch_slot5lbl.Visible = true;
            tb_adch_slot5tb.Visible = true;
            btn_addch_confirm.Visible = true;

            tb_adch_slot1tb.Text = "";
            tb_adch_slot2tb.Text = "";
            tb_adch_slot3tb.Text = "";
            tb_adch_slot4tb.Text = "";
            tb_adch_slot5tb.Text = "";
        }

        private void Btn_addch_confirm_ChangeClient_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "" && tb_adch_slot4tb.Text != "" && tb_adch_slot5tb.Text != "")
            {
                int ph;
                bool fl1 = int.TryParse(tb_adch_slot4tb.Text, out ph);

                if (fl1)
                {
                    new MySqlCommand($"update clients set firstName='{tb_adch_slot2tb.Text}', " +
                        $"lastName='{tb_adch_slot3tb.Text}', phoneNumber='{tb_adch_slot4tb.Text}', " +
                        $"adress='{tb_adch_slot5tb.Text}' where codeOfClient='{tb_adch_slot1tb.Text}'", connect).ExecuteNonQuery();
                    MessageBox.Show("Дані змінено успішно!");

                    tb_adch_slot1tb.Text = "";
                    tb_adch_slot2tb.Text = "";
                    tb_adch_slot3tb.Text = "";
                    tb_adch_slot4tb.Text = "";
                    tb_adch_slot5tb.Text = "";
                }
                else
                    MessageBox.Show("Введено неправильний номер телефону!");
            }
            else
                MessageBox.Show("Пусті поля не допускаються!");
        }

        private void Tb_adch_slot1tb_ChangeClient_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "ch-clients", this);
            form2.ShowDialog();
        }

        private void Btn_addch_confirm_AddUSer_Click(object sender, EventArgs e)
        {
            if (tb_adch_slot1tb.Text != "" && tb_adch_slot2tb.Text != "" && tb_adch_slot3tb.Text != "" && tb_adch_slot4tb.Text != "")
            {
                int ph;
                bool fl1 = int.TryParse(tb_adch_slot3tb.Text, out ph);

                if (fl1)
                {
                    new MySqlCommand($"insert into clients(firstName, lastName, phoneNumber, adress, spent) " +
                        $"values ('{tb_adch_slot1tb.Text}', '{tb_adch_slot2tb.Text}', '{tb_adch_slot3tb.Text}', '{tb_adch_slot4tb.Text}', '0')", connect).ExecuteNonQuery();
                    MessageBox.Show("Клієнт зареєстрований успішно!");

                    tb_adch_slot1tb.Text = "";
                    tb_adch_slot2tb.Text = "";
                    tb_adch_slot3tb.Text = "";
                    tb_adch_slot4tb.Text = "";
                }
                else
                    MessageBox.Show("Введено неправильний номер телефону!");
            }
            else
                MessageBox.Show("Пусті поля не допускаються!");
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
                        dgw_show.Columns.Add("manu", "виробник");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 3);

                        reader.Close();
                    }
                    break;
                case "mosquito_net":
                    {
                        dgw_show.Columns.Add("code", "код");
                        dgw_show.Columns.Add("name", "найменування");
                        dgw_show.Columns.Add("manu", "виробник");

                        q = "select * from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 3);

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

                        dgw_show.Columns.Add("codeOfItem", "код_товару");
                        dgw_show.Columns.Add("quantify", "кількість");

                        q = "select warehouse.codeOfItem, warehouse.quantity from " + subj;
                        reader = new MySqlCommand(q, connect).ExecuteReader();

                        InitDGW(reader, 2);

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
            MySqlDataReader reader = new MySqlCommand("call getType4showIncome(" + dgwr.Cells[0].Value + ")", connect).ExecuteReader();

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

                        reader = new MySqlCommand("select * from windows where windows.codeOfItem = " + dgwr.Cells[0].Value, connect).ExecuteReader();
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

                        reader = new MySqlCommand("call getDoorsExt(" + dgwr.Cells[0].Value + ")", connect).ExecuteReader();
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

                        reader = new MySqlCommand("call getWindowsillExt(" + dgwr.Cells[0].Value + ")", connect).ExecuteReader();
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

                        reader = new MySqlCommand("select * from mosquito_net where mosquito_net.codeOfItem = " + dgwr.Cells[0].Value, connect).ExecuteReader();
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

                        reader = new MySqlCommand("select * from reflux where reflux.codeOfItem = " + dgwr.Cells[0].Value, connect).ExecuteReader();
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

            showIncTb1.Text = "";
            showIncTb2.Text = "";
            showIncTb3.Text = "";
            showIncTb4.Text = "";
            showIncTb5.Text = "";
            showIncType.Text = "";
        }

        private void btn_manager_chose_accept_Click(object sender, EventArgs e)
        {
            if (cb_managersList.SelectedIndex != -1)
            {
                managerID = mngrArr[cb_managersList.SelectedIndex];
                MessageBox.Show("Вітаю, " + cb_managersList.Text);
                pnl_choose_mngr.Hide();
                pnl_mainMenu.Show();
            }
        }

        private void AddChange_addctrls()
        {

            // 
            // lbl_adch_slot1lbl
            // 
            this.lbl_adch_slot1lbl.AutoSize = true;
            this.lbl_adch_slot1lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.lbl_adch_slot1lbl.Location = new Point(310, 180);
            this.lbl_adch_slot1lbl.Name = "lbl_adch_slot1lbl";
            this.lbl_adch_slot1lbl.Size = new Size(51, 20);
            this.lbl_adch_slot1lbl.TabIndex = 2;
            this.lbl_adch_slot1lbl.Text = "lbl_adch_slot1lbl";
            // 
            // tb_adch_slot1tb
            // 
            this.tb_adch_slot1tb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tb_adch_slot1tb.Location = new Point(408, 173);
            this.tb_adch_slot1tb.Name = "tb_adch_slot1tb";
            this.tb_adch_slot1tb.Size = new Size(171, 26);
            this.tb_adch_slot1tb.TabIndex = 3;
            // 
            // lbl_adch_slot2lbl
            // 
            this.lbl_adch_slot2lbl.AutoSize = true;
            this.lbl_adch_slot2lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.lbl_adch_slot2lbl.Location = new Point(310, 210);
            this.lbl_adch_slot2lbl.Name = "lbl_adch_slot2lbl";
            this.lbl_adch_slot2lbl.Size = new Size(51, 20);
            this.lbl_adch_slot2lbl.TabIndex = 2;
            this.lbl_adch_slot2lbl.Text = "lbl_adch_slot1lbl";
            // 
            // tb_adch_slot2tb
            // 
            this.tb_adch_slot2tb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tb_adch_slot2tb.Location = new Point(408, 203);
            this.tb_adch_slot2tb.Name = "tb_adch_slot2tb";
            this.tb_adch_slot2tb.Size = new Size(171, 26);
            this.tb_adch_slot2tb.TabIndex = 3;
            // 
            // lbl_adch_slot3lbl
            // 
            this.lbl_adch_slot3lbl.AutoSize = true;
            this.lbl_adch_slot3lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.lbl_adch_slot3lbl.Location = new Point(310, 241);
            this.lbl_adch_slot3lbl.Name = "lbl_adch_slot3lbl";
            this.lbl_adch_slot3lbl.Size = new Size(51, 20);
            this.lbl_adch_slot3lbl.TabIndex = 2;
            this.lbl_adch_slot3lbl.Text = "lbl_adch_slot1lbl";
            // 
            // tb_adch_slot3tb
            // 
            this.tb_adch_slot3tb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tb_adch_slot3tb.Location = new Point(408, 234);
            this.tb_adch_slot3tb.Name = "tb_adch_slot3tb";
            this.tb_adch_slot3tb.Size = new Size(171, 26);
            this.tb_adch_slot3tb.TabIndex = 3;
            // 
            // lbl_adch_slot4lbl
            // 
            this.lbl_adch_slot4lbl.AutoSize = true;
            this.lbl_adch_slot4lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.lbl_adch_slot4lbl.Location = new Point(310, 275);
            this.lbl_adch_slot4lbl.Name = "lbl_adch_slot4lbl";
            this.lbl_adch_slot4lbl.Size = new Size(51, 20);
            this.lbl_adch_slot4lbl.TabIndex = 2;
            this.lbl_adch_slot4lbl.Text = "lbl_adch_slot1lbl";
            // 
            // tb_adch_slot4tb
            // 
            this.tb_adch_slot4tb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tb_adch_slot4tb.Location = new Point(408, 268);
            this.tb_adch_slot4tb.Name = "tb_adch_slot4tb";
            this.tb_adch_slot4tb.Size = new Size(171, 26);
            this.tb_adch_slot4tb.TabIndex = 3;
            // 
            // lbl_adch_slot5lbl
            // 
            this.lbl_adch_slot5lbl.AutoSize = true;
            this.lbl_adch_slot5lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.lbl_adch_slot5lbl.Location = new Point(310, 309);
            this.lbl_adch_slot5lbl.Name = "lbl_adch_slot4lbl";
            this.lbl_adch_slot5lbl.Size = new Size(51, 20);
            this.lbl_adch_slot5lbl.TabIndex = 2;
            this.lbl_adch_slot5lbl.Text = "lbl_adch_slot1lbl";
            // 
            // tb_adch_slot5tb
            // 
            this.tb_adch_slot5tb.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tb_adch_slot5tb.Location = new Point(408, 302);
            this.tb_adch_slot5tb.Name = "tb_adch_slot4tb";
            this.tb_adch_slot5tb.Size = new Size(171, 26);
            this.tb_adch_slot5tb.TabIndex = 3;
            // 
            // btn_addch_confirm
            // 
            this.btn_addch_confirm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.btn_addch_confirm.Location = new Point(376, 339);
            this.btn_addch_confirm.Name = "btn_addch_confirm";
            this.btn_addch_confirm.Size = new Size(126, 32);
            this.btn_addch_confirm.TabIndex = 4;
            this.btn_addch_confirm.Text = "btn_addch_confirm";
            this.btn_addch_confirm.UseVisualStyleBackColor = true;
            // 
            // cb_addch_itemType
            // 
            this.cb_addch_itemType.FormattingEnabled = true;
            this.cb_addch_itemType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.cb_addch_itemType.Location = new Point(429, 79);
            this.cb_addch_itemType.Name = "cb_addch_itemType";
            this.cb_addch_itemType.Size = new Size(135, 21);
            this.cb_addch_itemType.TabIndex = 5;
            // 
            // lbl_addch_cblbl
            // 
            this.lbl_addch_cblbl.AutoSize = true;
            this.lbl_addch_cblbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.lbl_addch_cblbl.Location = new Point(260, 80);
            this.lbl_addch_cblbl.Name = "lbl_addch_cblbl";
            this.lbl_addch_cblbl.Size = new Size(60, 20);
            this.lbl_addch_cblbl.TabIndex = 6;
            this.lbl_addch_cblbl.Text = "lbl_addch_cblbl";

            pnl_add_change.Controls.Add(lbl_adch_slot1lbl);
            pnl_add_change.Controls.Add(tb_adch_slot1tb);
            pnl_add_change.Controls.Add(lbl_adch_slot2lbl);
            pnl_add_change.Controls.Add(tb_adch_slot2tb);
            pnl_add_change.Controls.Add(lbl_adch_slot3lbl);
            pnl_add_change.Controls.Add(tb_adch_slot3tb);
            pnl_add_change.Controls.Add(lbl_adch_slot4lbl);
            pnl_add_change.Controls.Add(tb_adch_slot4tb);
            pnl_add_change.Controls.Add(lbl_adch_slot5lbl);
            pnl_add_change.Controls.Add(tb_adch_slot5tb);
            pnl_add_change.Controls.Add(btn_addch_confirm);
            pnl_add_change.Controls.Add(cb_addch_itemType);
            pnl_add_change.Controls.Add(lbl_addch_cblbl);

            lbl_adch_slot1lbl.Visible = false;
            tb_adch_slot1tb.Visible = false;
            lbl_adch_slot2lbl.Visible = false;
            tb_adch_slot2tb.Visible = false;
            lbl_adch_slot3lbl.Visible = false;
            tb_adch_slot3tb.Visible = false;
            lbl_adch_slot4lbl.Visible = false;
            tb_adch_slot4tb.Visible = false;
            lbl_adch_slot5lbl.Visible = false;
            tb_adch_slot5tb.Visible = false;
            btn_addch_confirm.Visible = false;
            cb_addch_itemType.Visible = false;
            lbl_addch_cblbl.Visible = false;
        }

        //
        //root
        //

        private void HideRootCTRLS()
        {
            lbl_root1.Hide();
            lbl_root2.Hide();
            lbl_root3.Hide();
            lbl_root4.Hide();

            tb_root1.Hide();
            tb_root2.Hide();
            tb_root3.Hide();
            tb_root4.Hide();

            btn_root_accept.Hide();

            tb_root1.PasswordChar = '\0';
            tb_root2.PasswordChar = '\0';

            tb_root1.Text = "";
            tb_root2.Text = "";
            tb_root3.Text = "";
            tb_root4.Text = "";

            btn_root_accept.Click -= Btn_root_accept_user_Click;
            btn_root_accept.Click -= Btn_root_accept_root_Click;
            btn_root_accept.Click -= Btn_root_accept_AddManager_Click;
        }

        private void btn_root_changerootpass_Click(object sender, EventArgs e)
        {
            HideRootCTRLS();

            lbl_root1.Text = "Новий пароль:";
            lbl_root2.Text = "Повторіть новий\n       пароль";
            lbl_root3.Text = "Старий пароль";
            btn_root_accept.Text = "Змінити";

            tb_root1.PasswordChar = '•';
            tb_root2.PasswordChar = '•';

            lbl_root1.Show();
            lbl_root2.Show();
            lbl_root3.Show();
            tb_root1.Show();
            tb_root2.Show();
            tb_root3.Show();
            btn_root_accept.Show();
            btn_root_accept.Click += Btn_root_accept_root_Click;
        }

        private void btn_root_changeusrpass_Click(object sender, EventArgs e)
        {
            HideRootCTRLS();

            lbl_root1.Text = "Новий пароль:";
            lbl_root2.Text = "Повторіть новий\n       пароль";
            lbl_root3.Text = "Старий пароль";
            btn_root_accept.Text = "Змінити";

            tb_root1.PasswordChar = '•';
            tb_root2.PasswordChar = '•';

            lbl_root1.Show();
            lbl_root2.Show();
            lbl_root3.Show();
            tb_root1.Show();
            tb_root2.Show();
            tb_root3.Show();
            btn_root_accept.Show();
            btn_root_accept.Click += Btn_root_accept_user_Click;
        }

        private void Btn_root_accept_user_Click(object sender, EventArgs e)
        {
            if (tb_root1.Text != "" && tb_root2.Text != "" && tb_root3.Text != "")
            {
                MySqlDataReader reader = new MySqlCommand("select login, pass from loginData where id = 1", connect).ExecuteReader();
                reader.Read();
                string oldPass = reader[1].ToString();
                reader.Close();

                if (tb_root1.Text == tb_root2.Text && tb_root3.Text == oldPass)
                {
                    new MySqlCommand($"update loginData set pass='{tb_root1.Text}' where id='1'", connect).ExecuteNonQuery();

                    MessageBox.Show("Пароль змінено!");

                    tb_root1.Text = "";
                    tb_root2.Text = "";
                    tb_root3.Text = "";
                }


            }

        }

        private void Btn_root_accept_root_Click(object sender, EventArgs e)
        {
            if (tb_root1.Text != "" && tb_root2.Text != "" && tb_root3.Text != "")
            {
                MySqlDataReader reader = new MySqlCommand("select login, pass from loginData where id = 2", connect).ExecuteReader();
                reader.Read();
                string oldPass = reader[1].ToString();
                reader.Close();

                if (tb_root1.Text == tb_root2.Text && tb_root3.Text == oldPass)
                {
                    new MySqlCommand($"update loginData set pass='{tb_root1.Text}' where id='2'", connect).ExecuteNonQuery();

                    MessageBox.Show("Пароль змінено!");

                    tb_root1.Text = "";
                    tb_root2.Text = "";
                    tb_root3.Text = "";
                }


            }
        }

        private void btn_root_addmngr_Click(object sender, EventArgs e)
        {
            HideRootCTRLS();

            lbl_root1.Text = "Ім'я";
            lbl_root2.Text = "Прізвище";
            lbl_root3.Text = "Дата народження\n      рррр-мм-дд";
            lbl_root4.Text = "Телефон";
            btn_root_accept.Text = "Додати";

            lbl_root1.Show();
            lbl_root2.Show();
            lbl_root3.Show();
            lbl_root4.Show();

            tb_root1.Show();
            tb_root2.Show();
            tb_root3.Show();
            tb_root4.Show();

            btn_root_accept.Show();
            btn_root_accept.Click += Btn_root_accept_AddManager_Click;
        }

        private void Btn_root_accept_AddManager_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_root1.Text != "" && tb_root2.Text != "" && tb_root3.Text != "" && tb_root4.Text != "")
                {
                    string[] date = tb_root3.Text.Split('.', '-', '/');
                    int ph = 0;
                    DateTime dt = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));
                    bool fl1 = int.TryParse(tb_root4.Text, out ph);

                    if (fl1)
                    {
                        string datemysql = $"{dt.Year}-{dt.Month}-{dt.Day}";
                        new MySqlCommand($"insert into managers(nameOfManager, lastNameOfManager, dateOfBirth, phoneNumber) " +
                            $"values ('{tb_root1.Text}', '{tb_root2.Text}', '{datemysql}', '{tb_root4.Text}')", connect).ExecuteNonQuery();

                        MessageBox.Show("Дані внесено успішно!");

                        tb_root1.Text = "";
                        tb_root2.Text = "";
                        tb_root3.Text = "";
                        tb_root4.Text = "";
                    }

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Не праивльний формат дати!");
            }


        }

        private void btn_factory_Click(object sender, EventArgs e)
        {
            HideAllBtns();

            btn_mainMenu_slot3.Text = "Відправити на завод";
            btn_mainMenu_slot4.Text = "Переглянути процес на заводі";
            btn_mainMenu_slot5.Text = "Змінити статус замовлення";
            btn_mainMenu_slot6.Text = "Додати виробника";


            btn_mainMenu_slot5.Show();
            btn_mainMenu_slot6.Show();
            btn_mainMenu_slot3.Show();
            btn_mainMenu_slot4.Show();

            btn_mainMenu_slot3.Click += sendToFactory;
            btn_mainMenu_slot4.Click += checkFactoryStatus;
            btn_mainMenu_slot5.Click += changeFactoryStatus;
            btn_mainMenu_slot6.Click += addFactory;

        }

        private void addFactory(object sender, EventArgs e)
        {
        }

        private void changeFactoryStatus(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_changeFstatus.Show();

            MySqlDataReader reader = new MySqlCommand("select * from statuses", connect).ExecuteReader();

            while (reader.Read())
            {
                cb_fStatus.Items.Add(reader[1]);
            }


            reader.Close();
        }

        private void checkFactoryStatus(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_showfactoryProces.Show();

            dgw_showfactoryProcess.Columns.Add("id", "код");
            dgw_showfactoryProcess.Columns.Add("name", "назва фабрики");
            dgw_showfactoryProcess.Columns.Add("code", "код замовлення");
            dgw_showfactoryProcess.Columns.Add("type", "тип замовлення");
            dgw_showfactoryProcess.Columns.Add("status", "статус");

            MySqlDataReader reader = new MySqlCommand("call getfactoryorders", connect).ExecuteReader();

            while (reader.Read())
            {
                dgw_showfactoryProcess.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
            }

            reader.Close();
        }

        private void sendToFactory(object sender, EventArgs e)
        {
            pnl_mainMenu.Hide();
            pnl_send2factory.Show();
        }

        private void tb_send2fac_codeoforder_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "outcomes", this);
            form2.ShowDialog();
        }

        private void tb_send2fac_codeoffactory_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "factories", this);
            form2.ShowDialog();
        }

        private void btn_send2factory_Click(object sender, EventArgs e)
        {
            if (tb_send2fac_codeoffactory.Text != "" && tb_send2fac_codeoforder.Text != "")
            {
                try
                {
                    string q = $"insert into factory_orders (codeoffactory, codeoforder, statusoforder) " +
                    $"values ('{tb_send2fac_codeoffactory.Text}', '{tb_send2fac_codeoforder.Text}', '1')";

                    new MySqlCommand(q, connect).ExecuteNonQuery();

                    MessageBox.Show("Дані внесено успішно!");

                    tb_send2fac_codeoffactory.Text = "";
                    tb_send2fac_codeoforder.Text = "";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Пусті поля не допускаються!");
            }
        }

        private void tb_changeFstatus_code_Click(object sender, EventArgs e)
        {
            form2 = new GetCodes2IncomeOutcome(connect, "factory_status", this);
            form2.ShowDialog();
        }

        private void btn_changeFstatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_changeFstatus_code.Text != "" && cb_fStatus.SelectedIndex != -1)
                {
                    MySqlDataReader reader = new MySqlCommand("select * from statuses", connect).ExecuteReader();
                    string code = "";
                    while (reader.Read())
                    {
                        if(cb_fStatus.Text == reader[1].ToString())
                        {
                            code = reader[0].ToString();
                            break;
                        }
                    }
                    reader.Close();

                    new MySqlCommand($"update factory_orders set statusoforder = {code} where id = {tb_changeFstatus_code.Text}", connect).ExecuteNonQuery();
                    MessageBox.Show("Статус оновлено успішно!");
                    tb_changeFstatus_code.Text = "";
                    cb_fStatus.Text = "";
                }
                else
                {
                    MessageBox.Show("Пусті поля не допускаються!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
