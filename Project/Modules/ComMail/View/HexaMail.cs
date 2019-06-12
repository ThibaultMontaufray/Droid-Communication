using Tools4Libraries;

namespace Droid.Communication
{
    public partial class HexaMail : Hexagon
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public HexaMail()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void Init()
        {
            _currentColor = Color.DARKORANGE;
            label.Text = "no connection";
        }
        #endregion

        #region Event
        private void buttonGoAction_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
