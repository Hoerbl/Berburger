namespace Berburger
{
    partial class EditDatabaseForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.buttonDelete = new System.Windows.Forms.Button();
			this.change_button = new System.Windows.Forms.Button();
			this.comboBoxTables = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.labelColumns = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.Location = new System.Drawing.Point(684, 449);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(115, 24);
			this.buttonDelete.TabIndex = 0;
			this.buttonDelete.Text = "Löschen";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// change_button
			// 
			this.change_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.change_button.Location = new System.Drawing.Point(803, 449);
			this.change_button.Margin = new System.Windows.Forms.Padding(2);
			this.change_button.Name = "change_button";
			this.change_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.change_button.Size = new System.Drawing.Size(108, 24);
			this.change_button.TabIndex = 1;
			this.change_button.Text = "Ändern";
			this.change_button.UseVisualStyleBackColor = true;
			// 
			// comboBoxTables
			// 
			this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTables.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxTables.FormattingEnabled = true;
			this.comboBoxTables.Location = new System.Drawing.Point(11, 11);
			this.comboBoxTables.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxTables.Name = "comboBoxTables";
			this.comboBoxTables.Size = new System.Drawing.Size(183, 25);
			this.comboBoxTables.TabIndex = 2;
			this.comboBoxTables.SelectedValueChanged += new System.EventHandler(this.comboBoxTables_SelectedValueChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Location = new System.Drawing.Point(11, 44);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(902, 401);
			this.dataGridView1.TabIndex = 3;
			// 
			// labelColumns
			// 
			this.labelColumns.AutoSize = true;
			this.labelColumns.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelColumns.Location = new System.Drawing.Point(199, 12);
			this.labelColumns.Name = "labelColumns";
			this.labelColumns.Size = new System.Drawing.Size(81, 20);
			this.labelColumns.TabIndex = 4;
			this.labelColumns.Text = "Columns: 0";
			// 
			// EditDatabaseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(920, 483);
			this.Controls.Add(this.labelColumns);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBoxTables);
			this.Controls.Add(this.change_button);
			this.Controls.Add(this.buttonDelete);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "EditDatabaseForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Berburger";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button change_button;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label labelColumns;
	}
}

