using Tools4Libraries;

namespace Droid.Communication
{
    public partial class HexaFacebook : Hexagon
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public HexaFacebook()
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
