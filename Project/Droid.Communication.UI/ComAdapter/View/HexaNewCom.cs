using Tools4Libraries;

namespace Droid.Communication.ComAdapter.View
{
    public partial class HexaNewCom : UserControlCustom
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public HexaNewCom()
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
            //_currentColor = Color.DARKORANGE;
            label.Text = GetText.Text("NewCom");
        }
        #endregion

        #region Event
        private void buttonGoAction_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
