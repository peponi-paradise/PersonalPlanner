namespace PersonalPlanner.GUI.Components
{
    public enum WidgetCloseMode
    {
        WidgetOnly,
        WidgetAndData,
    }

    public partial class WidgetClose : DevExpress.XtraEditors.XtraUserControl
    {
        public WidgetCloseMode WidgetCloseMode
        {
            get
            {
                if (WidgetOnly.Checked) return WidgetCloseMode.WidgetOnly;
                return WidgetCloseMode.WidgetAndData;
            }
        }

        public WidgetClose()
        {
            InitializeComponent();
        }
    }
}