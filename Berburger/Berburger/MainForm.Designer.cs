﻿namespace Berburger
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.button1 = new System.Windows.Forms.Button();
			this.buttonExecuteCommand = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.textBoxCommand = new System.Windows.Forms.TextBox();
			this.comboBoxDatabases = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonExecuteCommand
			// 
			resources.ApplyResources(this.buttonExecuteCommand, "buttonExecuteCommand");
			this.buttonExecuteCommand.Name = "buttonExecuteCommand";
			this.buttonExecuteCommand.UseVisualStyleBackColor = true;
			this.buttonExecuteCommand.Click += new System.EventHandler(this.buttonExecuteCommand_Click);
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.textBoxResult);
			this.groupBox1.Controls.Add(this.textBoxCommand);
			this.groupBox1.Controls.Add(this.buttonExecuteCommand);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// textBoxResult
			// 
			resources.ApplyResources(this.textBoxResult, "textBoxResult");
			this.textBoxResult.Name = "textBoxResult";
			// 
			// textBoxCommand
			// 
			resources.ApplyResources(this.textBoxCommand, "textBoxCommand");
			this.textBoxCommand.Name = "textBoxCommand";
			// 
			// comboBoxDatabases
			// 
			this.comboBoxDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDatabases.FormattingEnabled = true;
			resources.ApplyResources(this.comboBoxDatabases, "comboBoxDatabases");
			this.comboBoxDatabases.Name = "comboBoxDatabases";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBoxDatabases);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonExecuteCommand;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxCommand;
		private System.Windows.Forms.TextBox textBoxResult;
		private System.Windows.Forms.ComboBox comboBoxDatabases;
	}
}