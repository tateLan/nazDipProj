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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_auth_login = new System.Windows.Forms.TextBox();
            this.btn_auth_enter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_auth_pass = new System.Windows.Forms.TextBox();
            this.pnl_auth.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_auth
            // 
            this.pnl_auth.Controls.Add(this.btn_auth_enter);
            this.pnl_auth.Controls.Add(this.tb_auth_pass);
            this.pnl_auth.Controls.Add(this.label2);
            this.pnl_auth.Controls.Add(this.tb_auth_login);
            this.pnl_auth.Controls.Add(this.label1);
            this.pnl_auth.Location = new System.Drawing.Point(12, 12);
            this.pnl_auth.Name = "pnl_auth";
            this.pnl_auth.Size = new System.Drawing.Size(880, 527);
            this.pnl_auth.TabIndex = 0;
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
            // tb_auth_login
            // 
            this.tb_auth_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_auth_login.Location = new System.Drawing.Point(408, 171);
            this.tb_auth_login.Name = "tb_auth_login";
            this.tb_auth_login.Size = new System.Drawing.Size(142, 26);
            this.tb_auth_login.TabIndex = 1;
            // 
            // btn_auth_enter
            // 
            this.btn_auth_enter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_auth_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_auth_enter.Location = new System.Drawing.Point(358, 285);
            this.btn_auth_enter.Name = "btn_auth_enter";
            this.btn_auth_enter.Size = new System.Drawing.Size(115, 31);
            this.btn_auth_enter.TabIndex = 2;
            this.btn_auth_enter.Text = "Увійти";
            this.btn_auth_enter.UseVisualStyleBackColor = true;
            this.btn_auth_enter.Click += new System.EventHandler(this.btn_auth_enter_Click);
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
            // tb_auth_pass
            // 
            this.tb_auth_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_auth_pass.Location = new System.Drawing.Point(408, 227);
            this.tb_auth_pass.Name = "tb_auth_pass";
            this.tb_auth_pass.PasswordChar = '•';
            this.tb_auth_pass.Size = new System.Drawing.Size(142, 26);
            this.tb_auth_pass.TabIndex = 1;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_auth_enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 551);
            this.Controls.Add(this.pnl_auth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Еталон-Луцьк";
            this.pnl_auth.ResumeLayout(false);
            this.pnl_auth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_auth;
        private System.Windows.Forms.Button btn_auth_enter;
        private System.Windows.Forms.TextBox tb_auth_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_auth_login;
        private System.Windows.Forms.Label label1;
    }
}

