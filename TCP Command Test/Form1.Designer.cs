namespace TCP_Command_Test
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Command_list = new System.Windows.Forms.ListBox();
            this.CommandList_Clear = new System.Windows.Forms.Button();
            this.ReceiveData_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(12, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(399, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // tb_ip
            // 
            this.tb_ip.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_ip.Location = new System.Drawing.Point(584, 36);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(158, 29);
            this.tb_ip.TabIndex = 1;
            // 
            // tb_port
            // 
            this.tb_port.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_port.Location = new System.Drawing.Point(584, 71);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(158, 29);
            this.tb_port.TabIndex = 1;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(748, 71);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(79, 29);
            this.btn_connect.TabIndex = 2;
            this.btn_connect.Text = "연결";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(500, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(500, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "전송";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.Location = new System.Drawing.Point(12, 77);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(479, 328);
            this.textBox4.TabIndex = 5;
            this.textBox4.TabStop = false;
            // 
            // Command_list
            // 
            this.Command_list.FormattingEnabled = true;
            this.Command_list.ItemHeight = 12;
            this.Command_list.Location = new System.Drawing.Point(511, 113);
            this.Command_list.Name = "Command_list";
            this.Command_list.Size = new System.Drawing.Size(316, 292);
            this.Command_list.TabIndex = 6;
            this.Command_list.SelectedIndexChanged += new System.EventHandler(this.Command_list_SelectedIndexChanged);
            // 
            // CommandList_Clear
            // 
            this.CommandList_Clear.Location = new System.Drawing.Point(735, 414);
            this.CommandList_Clear.Name = "CommandList_Clear";
            this.CommandList_Clear.Size = new System.Drawing.Size(91, 24);
            this.CommandList_Clear.TabIndex = 7;
            this.CommandList_Clear.Text = "Clear";
            this.CommandList_Clear.UseVisualStyleBackColor = true;
            this.CommandList_Clear.Click += new System.EventHandler(this.CommandList_Clear_Click);
            // 
            // ReceiveData_Clear
            // 
            this.ReceiveData_Clear.Location = new System.Drawing.Point(400, 411);
            this.ReceiveData_Clear.Name = "ReceiveData_Clear";
            this.ReceiveData_Clear.Size = new System.Drawing.Size(91, 24);
            this.ReceiveData_Clear.TabIndex = 7;
            this.ReceiveData_Clear.Text = "Clear";
            this.ReceiveData_Clear.UseVisualStyleBackColor = true;
            this.ReceiveData_Clear.Click += new System.EventHandler(this.ReceiveData_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 453);
            this.Controls.Add(this.ReceiveData_Clear);
            this.Controls.Add(this.CommandList_Clear);
            this.Controls.Add(this.Command_list);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "TCP TEST";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button CommandList_Clear;
        private System.Windows.Forms.Button ReceiveData_Clear;

        private System.Windows.Forms.ListBox Command_list;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button btn_connect;

        private System.Windows.Forms.TextBox tb_ip;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}