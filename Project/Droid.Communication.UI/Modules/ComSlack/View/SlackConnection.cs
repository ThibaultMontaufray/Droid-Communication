using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.Communication.Modules.ComSlack.View
{
    public partial class SlackConnection : UserControlCustom
    {
        #region Attributes
        private SlackAdapter _adapter;
        #endregion

        #region Properties
        public SlackAdapter Adapter
        {
            get { return _adapter; }
            set { _adapter = value; }
        }
        #endregion

        #region Constructor
        public SlackConnection()
        {
            InitializeComponent();
        }
        public SlackConnection(SlackAdapter adapter)
        {
            _adapter = adapter;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            RefreshDgv();
        }
        #endregion

        #region Methods private
        private void RefreshDgv()
        {
            DataGridViewRow row;
            _dataGridViewToken.Rows.Clear();

            if (_adapter != null && _adapter.Token != null)
            {
                foreach (Token item in _adapter.Tokens)
                {
                    _dataGridViewToken.Rows.Add();

                    row = _dataGridViewToken.Rows[_dataGridViewToken.Rows.Count - 1];
                    row.Tag = item;
                    row.Cells[ColumnKey.Index].Value = item.Key;
                    row.Cells[ColumnActive.Index].Value = item.IsUsed;
                    row.Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.bin_empty;
                }
            }
            _dataGridViewToken.Height = (_dataGridViewToken.Rows.Count > 0 ? _dataGridViewToken.Rows.Count * 24 : 24) - 1;
            this.Height = 135 + (_dataGridViewToken.Rows.Count > 0 ? ((_dataGridViewToken.Rows.Count - 1) * 24) : 0);
        }
        #endregion

        #region Event
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Token t = new Token() { Key = textBoxToken.Text };
            textBoxToken.Clear();
            _adapter.Tokens.Add(t);
            RefreshData();
        }
        private void _dataGridViewToken_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDelete.Index)
            {
                if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _adapter.Tokens.Remove(_adapter.Tokens.Where(t => t.Key == ((Token)_dataGridViewToken.Rows[e.RowIndex].Tag).Key).FirstOrDefault());
                    RefreshData();
                }
            }
            else if (e.ColumnIndex == ColumnActive.Index)
            {
                foreach (DataGridViewRow item in _dataGridViewToken.Rows)
                {
                    ((Token)item.Tag).IsUsed = false;
                }
                ((Token)_dataGridViewToken.Rows[e.RowIndex].Tag).IsUsed = true;
                RefreshData();
            }
        }
        #endregion
    }
}
