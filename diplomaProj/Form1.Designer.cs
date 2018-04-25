namespace diplomaProj
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_auth = new System.Windows.Forms.Panel();
            this.lbl_auth_invalidData = new System.Windows.Forms.Label();
            this.btn_auth_enter = new System.Windows.Forms.Button();
            this.tb_auth_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_auth_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_mainMenu = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_mainMenu_checkInfo = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot8 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot7 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot6 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot2 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot5 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot1 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot4 = new System.Windows.Forms.Button();
            this.btn_mainMenu_slot3 = new System.Windows.Forms.Button();
            this.btn_mainMenu_addChangeInfo = new System.Windows.Forms.Button();
            this.btn_mainMenu_registerSell = new System.Windows.Forms.Button();
            this.btn_mainMenu_registerIncome = new System.Windows.Forms.Button();
            this.pnl_auth.SuspendLayout();
            this.pnl_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_auth
            // 
            this.pnl_auth.Controls.Add(this.lbl_auth_invalidData);
            this.pnl_auth.Controls.Add(this.btn_auth_enter);
            this.pnl_auth.Controls.Add(this.tb_auth_pass);
            this.pnl_auth.Controls.Add(this.label2);
            this.pnl_auth.Controls.Add(this.tb_auth_login);
            this.pnl_auth.Controls.Add(this.label1);
            this.pnl_auth.Location = new System.Drawing.Point(12, 12);
            this.pnl_auth.Name = "pnl_auth";
            this.pnl_auth.Size = new System.Drawing.Size(43, 27);
            this.pnl_auth.TabIndex = 0;
            // 
            // lbl_auth_invalidData
            // 
            this.lbl_auth_invalidData.AutoSize = true;
            this.lbl_auth_invalidData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_auth_invalidData.ForeColor = System.Drawing.Color.Red;
            this.lbl_auth_invalidData.Location = new System.Drawing.Point(297, 335);
            this.lbl_auth_invalidData.Name = "lbl_auth_invalidData";
            this.lbl_auth_invalidData.Size = new System.Drawing.Size(253, 20);
            this.lbl_auth_invalidData.TabIndex = 3;
            this.lbl_auth_invalidData.Text = "Непраивльний логін або пароль";
            this.lbl_auth_invalidData.Visible = false;
            // 
            // btn_auth_enter
            // 
            this.btn_auth_enter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_auth_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_auth_enter.Location = new System.Drawing.Point(358, 285);
            this.btn_auth_enter.Name = "btn_auth_enter";
            this.btn_auth_enter.Size = new System.Drawing.Size(115, 31);
            this.btn_auth_enter.TabIndex = 3;
            this.btn_auth_enter.Text = "Увійти";
            this.btn_auth_enter.UseVisualStyleBackColor = true;
            this.btn_auth_enter.Click += new System.EventHandler(this.btn_auth_enter_Click);
            // 
            // tb_auth_pass
            // 
            this.tb_auth_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_auth_pass.Location = new System.Drawing.Point(408, 227);
            this.tb_auth_pass.Name = "tb_auth_pass";
            this.tb_auth_pass.PasswordChar = '•';
            this.tb_auth_pass.Size = new System.Drawing.Size(142, 26);
            this.tb_auth_pass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(306, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Пароль";
            // 
            // tb_auth_login
            // 
            this.tb_auth_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_auth_login.Location = new System.Drawing.Point(408, 171);
            this.tb_auth_login.Name = "tb_auth_login";
            this.tb_auth_login.Size = new System.Drawing.Size(142, 26);
            this.tb_auth_login.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(306, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логін";
            // 
            // pnl_mainMenu
            // 
            this.pnl_mainMenu.Controls.Add(this.label3);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_checkInfo);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot8);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot7);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot6);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot2);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot5);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot1);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot4);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_slot3);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_addChangeInfo);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_registerSell);
            this.pnl_mainMenu.Controls.Add(this.btn_mainMenu_registerIncome);
            this.pnl_mainMenu.Location = new System.Drawing.Point(12, 12);
            this.pnl_mainMenu.Name = "pnl_mainMenu";
            this.pnl_mainMenu.Size = new System.Drawing.Size(880, 527);
            this.pnl_mainMenu.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 300F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(220, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 455);
            this.label3.TabIndex = 1;
            // 
            // btn_mainMenu_checkInfo
            // 
            this.btn_mainMenu_checkInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_checkInfo.Location = new System.Drawing.Point(31, 404);
            this.btn_mainMenu_checkInfo.Name = "btn_mainMenu_checkInfo";
            this.btn_mainMenu_checkInfo.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_checkInfo.TabIndex = 0;
            this.btn_mainMenu_checkInfo.Text = "Переглянути інформацію";
            this.btn_mainMenu_checkInfo.UseVisualStyleBackColor = true;
            this.btn_mainMenu_checkInfo.Click += new System.EventHandler(this.btn_mainMenu_checkInfo_Click);
            // 
            // btn_mainMenu_slot8
            // 
            this.btn_mainMenu_slot8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot8.Location = new System.Drawing.Point(593, 408);
            this.btn_mainMenu_slot8.Name = "btn_mainMenu_slot8";
            this.btn_mainMenu_slot8.Size = new System.Drawing.Size(197, 61);
            this.btn_mainMenu_slot8.TabIndex = 0;
            this.btn_mainMenu_slot8.Text = "Змінити інформацію про клієнта";
            this.btn_mainMenu_slot8.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot7
            // 
            this.btn_mainMenu_slot7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot7.Location = new System.Drawing.Point(369, 408);
            this.btn_mainMenu_slot7.Name = "btn_mainMenu_slot7";
            this.btn_mainMenu_slot7.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_slot7.TabIndex = 0;
            this.btn_mainMenu_slot7.Text = "Додати нового клієнта";
            this.btn_mainMenu_slot7.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot6
            // 
            this.btn_mainMenu_slot6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot6.Location = new System.Drawing.Point(593, 294);
            this.btn_mainMenu_slot6.Name = "btn_mainMenu_slot6";
            this.btn_mainMenu_slot6.Size = new System.Drawing.Size(197, 61);
            this.btn_mainMenu_slot6.TabIndex = 0;
            this.btn_mainMenu_slot6.Text = "Змінити інформацію про клієнта";
            this.btn_mainMenu_slot6.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot2
            // 
            this.btn_mainMenu_slot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot2.Location = new System.Drawing.Point(593, 76);
            this.btn_mainMenu_slot2.Name = "btn_mainMenu_slot2";
            this.btn_mainMenu_slot2.Size = new System.Drawing.Size(197, 61);
            this.btn_mainMenu_slot2.TabIndex = 0;
            this.btn_mainMenu_slot2.Text = "Змінити інформацію про товар";
            this.btn_mainMenu_slot2.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot5
            // 
            this.btn_mainMenu_slot5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot5.Location = new System.Drawing.Point(369, 294);
            this.btn_mainMenu_slot5.Name = "btn_mainMenu_slot5";
            this.btn_mainMenu_slot5.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_slot5.TabIndex = 0;
            this.btn_mainMenu_slot5.Text = "Додати нового клієнта";
            this.btn_mainMenu_slot5.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot1
            // 
            this.btn_mainMenu_slot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot1.Location = new System.Drawing.Point(369, 76);
            this.btn_mainMenu_slot1.Name = "btn_mainMenu_slot1";
            this.btn_mainMenu_slot1.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_slot1.TabIndex = 0;
            this.btn_mainMenu_slot1.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot4
            // 
            this.btn_mainMenu_slot4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot4.Location = new System.Drawing.Point(593, 172);
            this.btn_mainMenu_slot4.Name = "btn_mainMenu_slot4";
            this.btn_mainMenu_slot4.Size = new System.Drawing.Size(197, 61);
            this.btn_mainMenu_slot4.TabIndex = 0;
            this.btn_mainMenu_slot4.Text = "Змінити інформацію про товар";
            this.btn_mainMenu_slot4.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_slot3
            // 
            this.btn_mainMenu_slot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_slot3.Location = new System.Drawing.Point(369, 172);
            this.btn_mainMenu_slot3.Name = "btn_mainMenu_slot3";
            this.btn_mainMenu_slot3.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_slot3.TabIndex = 0;
            this.btn_mainMenu_slot3.Text = "Додати нову одиницю товару";
            this.btn_mainMenu_slot3.UseVisualStyleBackColor = true;
            // 
            // btn_mainMenu_addChangeInfo
            // 
            this.btn_mainMenu_addChangeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_addChangeInfo.Location = new System.Drawing.Point(31, 294);
            this.btn_mainMenu_addChangeInfo.Name = "btn_mainMenu_addChangeInfo";
            this.btn_mainMenu_addChangeInfo.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_addChangeInfo.TabIndex = 0;
            this.btn_mainMenu_addChangeInfo.Text = "Додати/Змінити інформацію";
            this.btn_mainMenu_addChangeInfo.UseVisualStyleBackColor = true;
            this.btn_mainMenu_addChangeInfo.Click += new System.EventHandler(this.btn_mainMenu_addChangeInfo_Click);
            // 
            // btn_mainMenu_registerSell
            // 
            this.btn_mainMenu_registerSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_registerSell.Location = new System.Drawing.Point(31, 189);
            this.btn_mainMenu_registerSell.Name = "btn_mainMenu_registerSell";
            this.btn_mainMenu_registerSell.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_registerSell.TabIndex = 0;
            this.btn_mainMenu_registerSell.Text = "Зареєструвати продажу товару";
            this.btn_mainMenu_registerSell.UseVisualStyleBackColor = true;
            this.btn_mainMenu_registerSell.Click += new System.EventHandler(this.btn_mainMenu_registerSell_Click);
            // 
            // btn_mainMenu_registerIncome
            // 
            this.btn_mainMenu_registerIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_mainMenu_registerIncome.Location = new System.Drawing.Point(31, 86);
            this.btn_mainMenu_registerIncome.Name = "btn_mainMenu_registerIncome";
            this.btn_mainMenu_registerIncome.Size = new System.Drawing.Size(164, 61);
            this.btn_mainMenu_registerIncome.TabIndex = 0;
            this.btn_mainMenu_registerIncome.Text = "Зареєструвати нову поставку";
            this.btn_mainMenu_registerIncome.UseVisualStyleBackColor = true;
            this.btn_mainMenu_registerIncome.Click += new System.EventHandler(this.btn_mainMenu_registerIncome_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_auth_enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 551);
            this.Controls.Add(this.pnl_mainMenu);
            this.Controls.Add(this.pnl_auth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Еталон-Луцьк";
            this.pnl_auth.ResumeLayout(false);
            this.pnl_auth.PerformLayout();
            this.pnl_mainMenu.ResumeLayout(false);
            this.pnl_mainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_auth;
        private System.Windows.Forms.Button btn_auth_enter;
        private System.Windows.Forms.TextBox tb_auth_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_auth_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_auth_invalidData;
        private System.Windows.Forms.Panel pnl_mainMenu;
        private System.Windows.Forms.Button btn_mainMenu_addChangeInfo;
        private System.Windows.Forms.Button btn_mainMenu_registerSell;
        private System.Windows.Forms.Button btn_mainMenu_registerIncome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_mainMenu_checkInfo;
        private System.Windows.Forms.Button btn_mainMenu_slot6;
        private System.Windows.Forms.Button btn_mainMenu_slot5;
        private System.Windows.Forms.Button btn_mainMenu_slot4;
        private System.Windows.Forms.Button btn_mainMenu_slot3;
        private System.Windows.Forms.Button btn_mainMenu_slot8;
        private System.Windows.Forms.Button btn_mainMenu_slot7;
        private System.Windows.Forms.Button btn_mainMenu_slot2;
        private System.Windows.Forms.Button btn_mainMenu_slot1;
    }
}

