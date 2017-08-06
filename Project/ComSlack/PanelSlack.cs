// log code 42 00
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Tools4Libraries;

namespace Droid_communication
{
    public class PanelSlack : RibbonPanel
    {
        #region Attribute
        public event EventHandlerAction ActionAppened;
        
        private Interface_slack _intSlack;

        private RibbonButton _rb_connection;
        #endregion

        #region Properties
        public Interface_slack InterfaceSlack
        {
            get { return _intSlack; }
            set { _intSlack = value; }
        }
        #endregion

        #region Constructor
        public PanelSlack(Interface_slack interface_slack)
        {
            _intSlack = interface_slack;
            BuildPanel();
        }
        #endregion

        #region Methods public
        public void OnAction(EventArgs e)
        {
            if (ActionAppened != null) ActionAppened(this, e);
        }
        private void DisableMenu()
        {
            this.Enabled = false;
        }
        private void EnableMenu()
        {
            this.Enabled = true;
        }
        #endregion

        #region Methods private
        private void BuildPanel()
        {
            this.Text = "Slack";

            _rb_connection = new RibbonButton("Connection");
            _rb_connection.Image = Tools4Libraries.Resources.ResourceIconSet32Default.connect;
            _rb_connection.SmallImage = Tools4Libraries.Resources.ResourceIconSet32Default.connect;
            _rb_connection.Click += _rb_connection_Click;
            
            this.Items.Add(_rb_connection);
        }
        #endregion

        #region Event
        private void _rb_connection_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("slack_connection");
            OnAction(action);
        }
        #endregion
    }
}
