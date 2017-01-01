using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assistant.ComOutlook
{
    public delegate void ActionsEventHandler(string name, object obj);
    public partial class Actions : UserControl
    {
        #region Attribute
        public event ActionsEventHandler Request;

        private System.ComponentModel.IContainer components = null;
        private Button buttonDelete;
        private Button buttonSearch;
        private System.Windows.Forms.Button buttonNew;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public Actions()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Mehtods protected
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods private
        private void InitializeComponent()
        {
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNew
            // 
            this.buttonNew.FlatAppearance.BorderSize = 0;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Location = new System.Drawing.Point(1, 1);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(16, 16);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(23, 1);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(16, 16);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(45, 1);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(16, 16);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonNew);
            this.Name = "Actions";
            this.Size = new System.Drawing.Size(200, 18);
            this.ResumeLayout(false);

        }
        private void Init()
        {
            this.buttonNew.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.email_edit));
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.email_delete));
            this.buttonSearch.BackgroundImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.client_account_template));
        }
        #endregion

        #region Event
        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (Request != null) { Request("newmail", null);  }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Request != null) { Request("delete", null); }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (Request != null) { Request("search", null); }
        }
        #endregion
    }
}
