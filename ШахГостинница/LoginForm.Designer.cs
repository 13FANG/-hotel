namespace ШахГостинница
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toBookingBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.paswordTB = new System.Windows.Forms.TextBox();
            this.FullNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toBookingBtn
            // 
            this.toBookingBtn.BackColor = System.Drawing.Color.BlueViolet;
            this.toBookingBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toBookingBtn.FlatAppearance.BorderSize = 0;
            this.toBookingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toBookingBtn.Font = new System.Drawing.Font("Microsoft YaHei", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toBookingBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toBookingBtn.Location = new System.Drawing.Point(195, 76);
            this.toBookingBtn.Name = "toBookingBtn";
            this.toBookingBtn.Size = new System.Drawing.Size(420, 100);
            this.toBookingBtn.TabIndex = 0;
            this.toBookingBtn.Text = "БРОНИРОВАНИЕ";
            this.toBookingBtn.UseVisualStyleBackColor = false;
            this.toBookingBtn.Click += new System.EventHandler(this.toBookingBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.BlueViolet;
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.loginBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginBtn.Location = new System.Drawing.Point(301, 292);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(200, 32);
            this.loginBtn.TabIndex = 1;
            this.loginBtn.Text = "Войти";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // paswordTB
            // 
            this.paswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.paswordTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paswordTB.Location = new System.Drawing.Point(301, 257);
            this.paswordTB.Name = "paswordTB";
            this.paswordTB.Size = new System.Drawing.Size(200, 29);
            this.paswordTB.TabIndex = 2;
            this.paswordTB.Text = "пароль";
            // 
            // FullNameTB
            // 
            this.FullNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FullNameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FullNameTB.Location = new System.Drawing.Point(301, 222);
            this.FullNameTB.Name = "FullNameTB";
            this.FullNameTB.Size = new System.Drawing.Size(200, 29);
            this.FullNameTB.TabIndex = 3;
            this.FullNameTB.Text = "Имя фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(626, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Поддержка +79280397736";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FullNameTB);
            this.Controls.Add(this.paswordTB);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.toBookingBtn);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toBookingBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox paswordTB;
        private System.Windows.Forms.TextBox FullNameTB;
        private System.Windows.Forms.Label label1;
    }
}