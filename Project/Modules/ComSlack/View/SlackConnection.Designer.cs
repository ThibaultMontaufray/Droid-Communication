namespace Droid.Communication.Modules.ComSlack.View
{
    partial class SlackConnection
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelConnection = new System.Windows.Forms.Label();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.labelToken = new System.Windows.Forms.Label();
            this._dataGridViewToken = new System.Windows.Forms.DataGridView();
            this.ColumnActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewToken)).BeginInit();
            this.SuspendLayout();
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.BackColor = System.Drawing.Color.Transparent;
            this.labelConnection.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnection.Location = new System.Drawing.Point(12, 13);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(165, 23);
            this.labelConnection.TabIndex = 3;
            this.labelConnection.Text = "Connection settings";
            // 
            // textBoxToken
            // 
            this.textBoxToken.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxToken.Location = new System.Drawing.Point(97, 44);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(208, 23);
            this.textBoxToken.TabIndex = 5;
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.BackColor = System.Drawing.Color.Transparent;
            this.labelToken.Location = new System.Drawing.Point(13, 47);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(38, 15);
            this.labelToken.TabIndex = 4;
            this.labelToken.Text = "Token";
            // 
            // _dataGridViewToken
            // 
            this._dataGridViewToken.AllowUserToAddRows = false;
            this._dataGridViewToken.AllowUserToDeleteRows = false;
            this._dataGridViewToken.AllowUserToResizeColumns = false;
            this._dataGridViewToken.AllowUserToResizeRows = false;
            this._dataGridViewToken.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this._dataGridViewToken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewToken.ColumnHeadersVisible = false;
            this._dataGridViewToken.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnActive,
            this.ColumnKey,
            this.ColumnDelete});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewToken.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewToken.Location = new System.Drawing.Point(16, 73);
            this._dataGridViewToken.Name = "_dataGridViewToken";
            this._dataGridViewToken.RowHeadersVisible = false;
            this._dataGridViewToken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewToken.Size = new System.Drawing.Size(370, 23);
            this._dataGridViewToken.TabIndex = 8;
            this._dataGridViewToken.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridViewToken_CellClick);
            // 
            // ColumnActive
            // 
            this.ColumnActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnActive.HeaderText = "Active";
            this.ColumnActive.Name = "ColumnActive";
            this.ColumnActive.Width = 5;
            // 
            // ColumnKey
            // 
            this.ColumnKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnKey.HeaderText = "Key";
            this.ColumnKey.Name = "ColumnKey";
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnDelete.HeaderText = "Delete";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Width = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(311, 44);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // SlackConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this._dataGridViewToken);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.labelConnection);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "SlackConnection";
            this.Size = new System.Drawing.Size(400, 118);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewToken)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.DataGridView _dataGridViewToken;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKey;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.Button buttonAdd;
    }
}
