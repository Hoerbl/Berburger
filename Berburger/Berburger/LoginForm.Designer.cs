namespace Berburger
{
	partial class LoginForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxServer = new System.Windows.Forms.TextBox();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.checkBoxSavePass = new System.Windows.Forms.CheckBox();
			this.checkBoxAutoConnect = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.label2.Location = new System.Drawing.Point(13, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "User:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.label3.Location = new System.Drawing.Point(13, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 21);
			this.label3.TabIndex = 2;
			this.label3.Text = "Password:";
			// 
			// textBoxServer
			// 
			this.textBoxServer.Location = new System.Drawing.Point(138, 12);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(147, 20);
			this.textBoxServer.TabIndex = 2;
			// 
			// textBoxUser
			// 
			this.textBoxUser.Location = new System.Drawing.Point(138, 38);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(147, 20);
			this.textBoxUser.TabIndex = 3;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(138, 65);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(147, 20);
			this.textBoxPassword.TabIndex = 4;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonConnect.Location = new System.Drawing.Point(203, 101);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(81, 33);
			this.buttonConnect.TabIndex = 1;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// checkBoxSavePass
			// 
			this.checkBoxSavePass.AutoSize = true;
			this.checkBoxSavePass.Checked = true;
			this.checkBoxSavePass.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSavePass.Location = new System.Drawing.Point(12, 97);
			this.checkBoxSavePass.Name = "checkBoxSavePass";
			this.checkBoxSavePass.Size = new System.Drawing.Size(97, 17);
			this.checkBoxSavePass.TabIndex = 5;
			this.checkBoxSavePass.Text = "save password";
			this.checkBoxSavePass.UseVisualStyleBackColor = true;
			// 
			// checkBoxAutoConnect
			// 
			this.checkBoxAutoConnect.AutoSize = true;
			this.checkBoxAutoConnect.Checked = true;
			this.checkBoxAutoConnect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAutoConnect.Location = new System.Drawing.Point(12, 120);
			this.checkBoxAutoConnect.Name = "checkBoxAutoConnect";
			this.checkBoxAutoConnect.Size = new System.Drawing.Size(153, 17);
			this.checkBoxAutoConnect.TabIndex = 6;
			this.checkBoxAutoConnect.Text = "Auto connect to this server";
			this.checkBoxAutoConnect.UseVisualStyleBackColor = true;
			// 
			// LoginForm
			// 
			this.AcceptButton = this.buttonConnect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 146);
			this.Controls.Add(this.checkBoxAutoConnect);
			this.Controls.Add(this.checkBoxSavePass);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxUser);
			this.Controls.Add(this.textBoxServer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(312, 178);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LoginForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxServer;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.CheckBox checkBoxSavePass;
		private System.Windows.Forms.CheckBox checkBoxAutoConnect;
	}
}