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

        Label whLessThanAll_lbl = new Label();

        Form1 form1;
        MySqlConnection connect;
        string table;
        string q;

        public GetCodes2IncomeOutcome(MySqlConnection con, string table, Form1 f1)
        {
            InitializeComponent();

            form1 = f1;
            connect = con;
            this.table = table;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;

            Setup();
        }

        private void Setup()
        {
            MySqlDataReader reader;

            switch (table)
            {
                case "provider":
                    {
                        label1.Text = "Код";
                        label2.Text = "Назва";
                        label3.Text = "Номер";

                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;

                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("name", "Назва");
                        dgw_info.Columns.Add("ph", "Телефон");
                        dgw_info.Columns.Add("adress", "Адреса");

                        reader = new MySqlCommand("select * from " + table, connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                        }
                        reader.Close();


                    }
                    break;
                case "ch-clients":
                case "clients":
                    {
                        label1.Text = "Код";
                        label2.Text = "Ім'я";
                        label3.Text = "Прізвище";

                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;

                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("fname", "Ім'я");
                        dgw_info.Columns.Add("sname", "Прізвище");
                        dgw_info.Columns.Add("ph", "Телефон");
                        dgw_info.Columns.Add("adress", "Адреса");
                        dgw_info.Columns.Add("spent", "Витрачено");

                        reader = new MySqlCommand("select * from clients", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        }
                        reader.Close();


                    }

                    break;
                case "items-inc":
                    {
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;

                        label1.Text = "Код";
                        label2.Text = "Тип";
                        label3.Text = "Виробник";

                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("type", "Тип");
                        dgw_info.Columns.Add("manufacturer", "Виробник");

                        reader = new MySqlCommand("call getitems4inc", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2]);
                        }
                        reader.Close();

                        this.Width = 1160;
                        ItemsAdditionCtrlsAdd();
                        HideAdditionalCtrls();

                        dgw_info.CellClick += Dgw_info_CellClick;
                    }
                    break;
                case "items":
                    {
                        int availCount = 0;
                        int allCount = 0;

                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;

                        label1.Text = "Код";
                        label2.Text = "Тип";
                        label3.Text = "Виробник";

                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("type", "Тип");
                        dgw_info.Columns.Add("manufacturer", "Виробник");


                        reader = new MySqlCommand("select items.id, assortment.nameOfItem from warehouse left join (items left join assortment" +
                            " on items.typeOfProduct = assortment.codeOfItem) on items.id = warehouse.codeOfItem where quantity > 0 ", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1]);
                        }
                        reader.Close();

                        for (int i = 0; i < dgw_info.Rows.Count; i++)
                        {
                            string q = null;

                            switch (dgw_info.Rows[i].Cells[1].Value)
                            {
                                case "Вікна":
                                    {
                                        q = "select manufacturer from windows where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Двері":
                                    {
                                        q = "select manufacturer from doors where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Відлив":
                                    {
                                        q = "select manufacturer from reflux where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Підвіконня":
                                    {
                                        q = "select manufacturer from windowsill where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Москітна сітка":
                                    {
                                        q = "select manufacturer from mosquito_net where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                            }

                            reader = new MySqlCommand(q, connect).ExecuteReader();

                            while (reader.Read())
                            {
                                dgw_info.Rows[i].Cells[2].Value = reader[0];
                            }

                            reader.Close();
                        }

                        reader = new MySqlCommand("select count(warehouse.codeOfItem) from warehouse left join (items left join assortment" +
                            " on items.typeOfProduct = assortment.codeOfItem) on items.id = warehouse.codeOfItem where quantity > 0", connect).ExecuteReader();
                        reader.Read();
                        availCount = Convert.ToInt32(reader[0]);
                        reader.Close();

                        reader = new MySqlCommand("select count(items.id) from items", connect).ExecuteReader();
                        reader.Read();
                        allCount = Convert.ToInt32(reader[0]);
                        reader.Close();

                        if (availCount < allCount)
                        {
                            whLessThanAll_lbl.AutoSize = true;
                            whLessThanAll_lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                            whLessThanAll_lbl.Location = new Point(760, 21);
                            whLessThanAll_lbl.Name = "whLessThanAll_lbl";
                            whLessThanAll_lbl.Size = new Size(51, 20);
                            whLessThanAll_lbl.TabIndex = 3;
                            whLessThanAll_lbl.Text = "На складі доступний не повний перелік товарів";
                            whLessThanAll_lbl.ForeColor = Color.Red;

                            this.Controls.Add(whLessThanAll_lbl);
                        }

                        this.Width = 1160;
                        ItemsAdditionCtrlsAdd();
                        HideAdditionalCtrls();

                        dgw_info.CellClick += Dgw_info_CellClick;
                    }
                    break;
                case "ch-doors":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("manuf", "Виробник");
                        dgw_info.Columns.Add("type", "Тип");
                        dgw_info.Columns.Add("mater", "Матеріал");
                        dgw_info.Columns.Add("color", "Колір");

                        reader = new MySqlCommand("select doors.codeOfItem, doors.manufacturer, typeOfProducts.typeOfProducts, doors.material, colors.color " +
                            "from (doors left join typeOfProducts on doors.typeOfDoors = typeOfProducts.codeOfItem) left join colors " +
                            "on doors.colour = colors.codeOfColor", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                        }
                        reader.Close();
                    }
                    break;
                case "types":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("matytypenuf", "Тип");

                        reader = new MySqlCommand("select * from typeOfProducts", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1]);
                        }
                        reader.Close();
                    }
                    break;
                case "ch-colors":
                case "colors":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("color", "Колір");

                        reader = new MySqlCommand("select * from colors", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1]);
                        }
                        reader.Close();
                    }
                    break;
                case "ch-reflux":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("name", "Назва");

                        reader = new MySqlCommand("select * from reflux", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1]);
                        }
                        reader.Close();
                    }
                    break;
                case "ch-windows":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("man", "Виробник");
                        dgw_info.Columns.Add("name", "Назва");

                        reader = new MySqlCommand("select * from windows", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2]);
                        }
                        reader.Close();
                    }
                    break;
                case "ch-windowsill":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("man", "Виробник");
                        dgw_info.Columns.Add("mat", "Матеріал");
                        dgw_info.Columns.Add("colo", "Колір");

                        reader = new MySqlCommand("select windowsill.codeOfItem, windowsill.manufacturer, windowsill.material, colors.color " +
                            "from windowsill left join colors on windowsill.colour = colors.codeOfColor", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                        }
                        reader.Close();
                    }
                    break;
                case "ch-mosquito":
                    {
                        dgw_info.Columns.Add("code", "Код");
                        dgw_info.Columns.Add("name", "Назва");

                        reader = new MySqlCommand("select * from mosquito_net", connect).ExecuteReader();

                        while (reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1]);
                        }
                        reader.Close();
                    }
                    break;
                case "outcomes":
                    {
                        dgw_info.Columns.Add("id", "код замовлення");
                        dgw_info.Columns.Add("date", "дата");
                        dgw_info.Columns.Add("name", "ім'я клієнта");
                        dgw_info.Columns.Add("lname", "прізвище клієнта");
                        dgw_info.Columns.Add("coofitem", "код товару");
                        dgw_info.Columns.Add("q", "кількість");
                        dgw_info.Columns.Add("mname", "ім'я менеджера");
                        dgw_info.Columns.Add("mlname", "прізвище менеджера");

                        reader = new MySqlCommand("select outcome.id, outcome.dateofoutcome, clients.firstname, clients.lastname, outcome.codeofitem, outcome.quantity, " +
                            "managers.nameofmanager, managers.lastnameofmanager from (outcome left join clients on outcome.codeofclient = clients.codeofclient) " +
                            "left join managers on outcome.manager = managers.codeofmanager", connect).ExecuteReader();

                        while(reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                        }

                        reader.Close();
                    }
                    break;
                case "factories":
                    {
                        dgw_info.Columns.Add("id", "код");
                        dgw_info.Columns.Add("name", "назва");
                        dgw_info.Columns.Add("adress", "адреса");
                        dgw_info.Columns.Add("pn", "телефон");

                        reader = new MySqlCommand("select * from factories", connect).ExecuteReader();

                        while(reader.Read())
                        {
                            dgw_info.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                        }

                        reader.Close();
                    }
                    break;
            }
        }

        private void Dgw_info_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HideAdditionalCtrls();
            if (e.RowIndex > dgw_info.RowCount || e.RowIndex < 0)
                return;
            DataGridViewRow dgwr = dgw_info.Rows[e.RowIndex];
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

                        showIncType.Visible = true;
                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Назва";

                        reader = new MySqlCommand("select * from windows where windows.codeOfItem = " + dgwr.Cells[0].Value, connect).ExecuteReader();
                        while (reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[2].ToString();
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

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Тип";
                        showIncLbl3.Text = "Матеріал";
                        showIncLbl4.Text = "Колір";

                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncTb3.Visible = true;
                        showIncTb4.Visible = true;
                        showIncType.Visible = true;

                        reader = new MySqlCommand("call getDoorsExt(" + dgwr.Cells[0].Value + ")", connect).ExecuteReader();
                        while (reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[2].ToString();
                            showIncTb3.Text = reader[3].ToString();
                            showIncTb4.Text = reader[4].ToString();
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

                        showIncLbl1.Text = "Код";
                        showIncLbl2.Text = "Матеріал";
                        showIncLbl3.Text = "Колір";

                        showIncTb1.Visible = true;
                        showIncTb2.Visible = true;
                        showIncTb3.Visible = true;
                        showIncType.Visible = true;

                        reader = new MySqlCommand("call getWindowsillExt(" + dgwr.Cells[0].Value + ")", connect).ExecuteReader();
                        while (reader.Read())
                        {
                            showIncTb1.Text = reader[0].ToString();
                            showIncTb2.Text = reader[2].ToString();
                            showIncTb3.Text = reader[3].ToString();
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

        private void ItemsAdditionCtrlsAdd()
        {
            // 
            // showIncLblType
            // 
            showIncLblType.AutoSize = true;
            showIncLblType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLblType.Location = new Point(800, 78);
            showIncLblType.Name = "showIncLbl1";
            showIncLblType.Size = new Size(51, 20);
            showIncLblType.TabIndex = 3;
            showIncLblType.Text = "Вид продукту";
            // 
            // showIncType
            // 
            showIncType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncType.Location = new Point(930, 75);
            showIncType.Name = "showIncTb1";
            showIncType.Size = new Size(133, 26);
            showIncType.TabIndex = 4;
            // 
            // showIncLbl1
            // 
            showIncLbl1.AutoSize = true;
            showIncLbl1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl1.Location = new Point(800, 118);
            showIncLbl1.Name = "showIncLbl1";
            showIncLbl1.Size = new Size(51, 20);
            showIncLbl1.TabIndex = 3;
            showIncLbl1.Text = "showIncLbl1";
            // 
            // showIncTb1
            // 
            showIncTb1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb1.Location = new Point(930, 115);
            showIncTb1.Name = "showIncTb1";
            showIncTb1.Size = new Size(200, 26);
            showIncTb1.TabIndex = 4;
            // 
            // showIncLbl2
            // 
            showIncLbl2.AutoSize = true;
            showIncLbl2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl2.Location = new Point(800, 158);
            showIncLbl2.Name = "showIncLbl2";
            showIncLbl2.Size = new Size(51, 20);
            showIncLbl2.TabIndex = 3;
            showIncLbl2.Text = "showIncLbl1";
            // 
            // showIncTb2
            // 
            showIncTb2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb2.Location = new Point(930, 155);
            showIncTb2.Name = "showIncTb2";
            showIncTb2.Size = new Size(200, 26);
            showIncTb2.TabIndex = 4;
            // 
            // showIncLbl3
            // 
            showIncLbl3.AutoSize = true;
            showIncLbl3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl3.Location = new Point(800, 198);
            showIncLbl3.Name = "showIncLbl3";
            showIncLbl3.Size = new Size(51, 20);
            showIncLbl3.TabIndex = 3;
            showIncLbl3.Text = "showIncLbl1";
            // 
            // showIncTb3
            // 
            showIncTb3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb3.Location = new Point(930, 195);
            showIncTb3.Name = "showIncTb3";
            showIncTb3.Size = new Size(200, 26);
            showIncTb3.TabIndex = 4;
            // 
            // showIncLbl4
            // 
            showIncLbl4.AutoSize = true;
            showIncLbl4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl4.Location = new Point(800, 238);
            showIncLbl4.Name = "showIncLbl4";
            showIncLbl4.Size = new Size(51, 20);
            showIncLbl4.TabIndex = 3;
            showIncLbl4.Text = "showIncLbl1";
            // 
            // showIncTb4
            // 
            showIncTb4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb4.Location = new Point(930, 235);
            showIncTb4.Name = "showIncTb4";
            showIncTb4.Size = new Size(200, 26);
            showIncTb4.TabIndex = 4;
            // 
            // showIncLbl5
            // 
            showIncLbl5.AutoSize = true;
            showIncLbl5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncLbl5.Location = new Point(800, 278);
            showIncLbl5.Name = "showIncLbl5";
            showIncLbl5.Size = new Size(51, 20);
            showIncLbl5.TabIndex = 3;
            showIncLbl5.Text = "showIncLbl1";
            // 
            // showIncTb5
            // 
            showIncTb5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            showIncTb5.Location = new Point(930, 275);
            showIncTb5.Name = "showIncTb5";
            showIncTb5.Size = new Size(200, 26);
            showIncTb5.TabIndex = 4;

            Controls.Add(showIncLbl1);
            Controls.Add(showIncLbl2);
            Controls.Add(showIncLbl3);
            Controls.Add(showIncLbl4);
            Controls.Add(showIncLbl5);
            Controls.Add(showIncLblType);

            Controls.Add(showIncType);
            Controls.Add(showIncTb1);
            Controls.Add(showIncTb2);
            Controls.Add(showIncTb3);
            Controls.Add(showIncTb4);
            Controls.Add(showIncTb5);
        }

        private void HideAdditionalCtrls()
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

        private void Changed(object sender, EventArgs e)
        {
            MySqlDataReader reader;

            switch (table)
            {
                case "provider":
                    {
                        q = "select * from provider where provider.codeOfProvider like '" + textBox1.Text.ToLower() + "%' and provider.nameOfProvider like '" +
                            textBox2.Text.ToLower() + "%' and provider.phoneNumber like '" + textBox3.Text.ToLower() + "%'";
                    }
                    break;
                case "ch-clients":
                case "clients":
                    {
                        q = "select * from clients where clients.codeOfclient like '" + textBox1.Text.ToLower() + "%' and clients.firstName like '" +
                            textBox2.Text.ToLower() + "%' and clients.lastName like '" + textBox3.Text.ToLower() + "%'";
                    }
                    break;
                case "items":
                    {

                        q = "select items.id, assortment.nameOfItem from warehouse left join(items left join assortment" +
                            " on items.typeOfProduct = assortment.codeOfItem) on items.id = warehouse.codeOfItem where quantity > 0 and items.id like '" + textBox1.Text.ToLower() + "%' " +
                            "and assortment.nameOfItem like '" + textBox2.Text.ToLower() + "%'";
                    }
                    break;
                case "items-inc":
                    {
                        q = $"call searchitems4inc('{textBox1.Text}%', '{textBox2.Text}%', '{textBox3.Text}%')";
                    }
                    break;
            }

            reader = new MySqlCommand(q, connect).ExecuteReader();

            switch (table)
            {
                case "provider":
                    {
                        FillDGW(reader, 4);
                    }
                    break;
                case "ch-clients":
                case "clients":
                    {
                        FillDGW(reader, 6);
                    }
                    break;
                case "items":
                    {
                        FillDGW(reader, 2);
                        reader.Close();

                        for (int i = 0; i < dgw_info.Rows.Count; i++)
                        {
                            string q = null;

                            switch (dgw_info.Rows[i].Cells[1].Value)
                            {
                                case "Вікна":
                                    {
                                        q = "select manufacturer from windows where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Двері":
                                    {
                                        q = "select manufacturer from doors where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Відлив":
                                    {
                                        q = "select manufacturer from reflux where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Підвіконня":
                                    {
                                        q = "select manufacturer from windowsill where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                                case "Москітна сітка":
                                    {
                                        q = "select manufacturer from mosquito_net where codeOfItem = " + dgw_info.Rows[i].Cells[0].Value;
                                    }
                                    break;
                            }

                            reader = new MySqlCommand(q, connect).ExecuteReader();

                            while (reader.Read())
                            {
                                dgw_info.Rows[i].Cells[2].Value = reader[0];
                            }

                            reader.Close();
                        }
                        for (int i = 0; i < dgw_info.Rows.Count; i++)
                        {
                            char[] req = textBox3.Text.ToCharArray();
                            char[] avail = dgw_info.Rows[i].Cells[2].Value.ToString().ToCharArray();
                            int count = 0;

                            for (int j = 0; j < req.Length; j++)
                            {
                                if (req.Length <= avail.Length)
                                {
                                    if (req[j].ToString().ToLower() == avail[j].ToString().ToLower())
                                        count++;
                                }
                            }

                            if (count != req.Length)
                            {
                                dgw_info.Rows.Remove(dgw_info.Rows[i]);
                                i = -1;
                            }
                            count = 0;
                        }
                    }
                    break;
                case "items-inc":
                    {
                        FillDGW(reader, 3);
                    }
                    break;
            }

            reader.Close();

            if (table == "items")
            {

            }
        }

        private void FillDGW(MySqlDataReader reader, int count)
        {
            dgw_info.Rows.Clear();

            object[] arr = new object[count];

            while (reader.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    arr[i] = reader[i];
                }
                dgw_info.Rows.Add(arr);
            }
        }

        private void dgw_info_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlDataReader reader;
            if (e.RowIndex != -1)
            {
                switch (table)
                {
                    case "provider":
                        {
                            form1.regNew_tb1.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            this.Close();
                        }
                        break;
                    case "clients":
                        {
                            form1.regNew_tb1.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            this.Close();
                        }
                        break;
                    case "ch-clients":
                        {
                            form1.tb_adch_slot1tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            form1.tb_adch_slot2tb.Text = dgw_info.Rows[e.RowIndex].Cells[1].Value.ToString();
                            form1.tb_adch_slot3tb.Text = dgw_info.Rows[e.RowIndex].Cells[2].Value.ToString();
                            form1.tb_adch_slot4tb.Text = dgw_info.Rows[e.RowIndex].Cells[3].Value.ToString();
                            form1.tb_adch_slot5tb.Text = dgw_info.Rows[e.RowIndex].Cells[4].Value.ToString();
                            this.Close();
                        }
                        break;
                    case "items-inc":
                        {
                            form1.regNew_tbCodeOfItem.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            this.Close();
                        }
                        break;
                    case "items":
                        {
                            form1.regNew_tbCodeOfItem.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            this.Close();
                        }
                        break;
                    case "ch-doors":
                        {
                            reader = new MySqlCommand("select * from doors where codeOfItem = " + dgw_info.Rows[e.RowIndex].Cells[0].Value, connect).ExecuteReader();
                            reader.Read();

                            form1.tb_adch_slot1tb.Text = reader[0].ToString();
                            form1.tb_adch_slot2tb.Text = reader[1].ToString();
                            form1.tb_adch_slot3tb.Text = reader[2].ToString();
                            form1.tb_adch_slot4tb.Text = reader[3].ToString();
                            form1.tb_adch_slot5tb.Text = reader[4].ToString();

                            reader.Close();

                            this.Close();
                        }
                        break;
                    case "types":
                        {
                            form1.tb_adch_slot3tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "colors":
                        {
                            form1.tb_adch_slot5tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "ch-reflux":
                        {
                            form1.tb_adch_slot1tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            form1.tb_adch_slot2tb.Text = dgw_info.Rows[e.RowIndex].Cells[1].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "ch-windows":
                        {
                            form1.tb_adch_slot1tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            form1.tb_adch_slot2tb.Text = dgw_info.Rows[e.RowIndex].Cells[1].Value.ToString();
                            form1.tb_adch_slot3tb.Text = dgw_info.Rows[e.RowIndex].Cells[2].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "ch-colors":
                        {
                            form1.tb_adch_slot4tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "ch-windowsill":
                        {
                            reader = new MySqlCommand("select * from windowsill where codeOfItem = " + dgw_info.Rows[e.RowIndex].Cells[0].Value, connect).ExecuteReader();
                            reader.Read();

                            form1.tb_adch_slot1tb.Text = reader[0].ToString();
                            form1.tb_adch_slot2tb.Text = reader[1].ToString();
                            form1.tb_adch_slot3tb.Text = reader[2].ToString();
                            form1.tb_adch_slot4tb.Text = reader[3].ToString();

                            reader.Close();
                            this.Close();
                        }
                        break;
                    case "ch-mosquito":
                        {
                            form1.tb_adch_slot1tb.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            form1.tb_adch_slot2tb.Text = dgw_info.Rows[e.RowIndex].Cells[1].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "outcomes":
                        {
                            form1.tb_send2fac_codeoforder.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();

                            this.Close();
                        }
                        break;
                    case "factories":
                        {
                            form1.tb_send2fac_codeoffactory.Text = dgw_info.Rows[e.RowIndex].Cells[0].Value.ToString();
                            this.Close();
                        }
                        break;
                }
            }

        }
    }
}
