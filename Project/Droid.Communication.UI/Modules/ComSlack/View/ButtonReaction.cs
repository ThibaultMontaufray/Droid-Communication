using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid.Communication
{
    public partial class ButtonReaction : UserControl
    {
        #region Attributes
        private Reaction _currentReaction;
        #endregion

        #region Properties
        public Reaction CurrentReaction
        {
            get { return _currentReaction; }
            set { _currentReaction = value; }
        }
        #endregion

        #region Constructor
        public ButtonReaction()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public void LoadReaction(Reaction reaction)
        {
            _currentReaction = reaction;
            if (_currentReaction != null)
            { 
                labelCount.Text = _currentReaction.Count.ToString();
            }
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(_currentReaction.Name.Replace('+', '_'));
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
