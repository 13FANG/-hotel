namespace ШахГостинница
{
    partial class BookingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.fullnameTB = new System.Windows.Forms.TextBox();
            this.passportDataTB = new System.Windows.Forms.TextBox();
            this.phoneTB = new System.Windows.Forms.TextBox();
            this.roomIDTB = new System.Windows.Forms.TextBox();
            this.inTB = new System.Windows.Forms.TextBox();
            this.outTB = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(296, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Бронирование";
            // 
            // emailTB
            // 
            this.emailTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.emailTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailTB.Location = new System.Drawing.Point(402, 233);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(200, 29);
            this.emailTB.TabIndex = 7;
            this.emailTB.Text = "email";
            // 
            // fullnameTB
            // 
            this.fullnameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.fullnameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fullnameTB.Location = new System.Drawing.Point(196, 163);
            this.fullnameTB.Name = "fullnameTB";
            this.fullnameTB.Size = new System.Drawing.Size(200, 29);
            this.fullnameTB.TabIndex = 6;
            this.fullnameTB.Text = "фамилия имя";
            // 
            // passportDataTB
            // 
            this.passportDataTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.passportDataTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passportDataTB.Location = new System.Drawing.Point(402, 163);
            this.passportDataTB.Name = "passportDataTB";
            this.passportDataTB.Size = new System.Drawing.Size(200, 29);
            this.passportDataTB.TabIndex = 6;
            this.passportDataTB.Text = "паспорт";
            // 
            // phoneTB
            // 
            this.phoneTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.phoneTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.phoneTB.Location = new System.Drawing.Point(196, 198);
            this.phoneTB.Name = "phoneTB";
            this.phoneTB.Size = new System.Drawing.Size(200, 29);
            this.phoneTB.TabIndex = 6;
            this.phoneTB.Text = "телефон";
            // 
            // roomIDTB
            // 
            this.roomIDTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.roomIDTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roomIDTB.Location = new System.Drawing.Point(402, 198);
            this.roomIDTB.Name = "roomIDTB";
            this.roomIDTB.Size = new System.Drawing.Size(200, 29);
            this.roomIDTB.TabIndex = 6;
            this.roomIDTB.Text = "комната";
            // 
            // inTB
            // 
            this.inTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inTB.Location = new System.Drawing.Point(196, 233);
            this.inTB.Name = "inTB";
            this.inTB.Size = new System.Drawing.Size(200, 29);
            this.inTB.TabIndex = 7;
            this.inTB.Text = "заселение";
            // 
            // outTB
            // 
            this.outTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.outTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.outTB.Location = new System.Drawing.Point(196, 268);
            this.outTB.Name = "outTB";
            this.outTB.Size = new System.Drawing.Size(200, 29);
            this.outTB.TabIndex = 7;
            this.outTB.Text = "выселение";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.BlueViolet;
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.loginBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginBtn.Location = new System.Drawing.Point(402, 267);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(200, 32);
            this.loginBtn.TabIndex = 8;
            this.loginBtn.Text = "забронировать";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.inTB);
            this.Controls.Add(this.outTB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.roomIDTB);
            this.Controls.Add(this.phoneTB);
            this.Controls.Add(this.passportDataTB);
            this.Controls.Add(this.fullnameTB);
            this.Controls.Add(this.label1);
            this.Name = "BookingForm";
            this.Text = "BookingForm";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox fullnameTB;
        private System.Windows.Forms.TextBox passportDataTB;
        private System.Windows.Forms.TextBox phoneTB;
        private System.Windows.Forms.TextBox roomIDTB;
        private System.Windows.Forms.TextBox inTB;
        private System.Windows.Forms.TextBox outTB;
        private System.Windows.Forms.Button loginBtn;
    }
}