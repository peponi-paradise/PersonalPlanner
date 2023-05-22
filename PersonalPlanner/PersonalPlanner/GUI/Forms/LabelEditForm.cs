using DevExpress.XtraEditors.Repository;
using System;
using System.Drawing;

namespace PersonalPlanner.GUI.Forms
{
    public partial class LabelEditForm : System.Windows.Forms.Form
    {
        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/
        private RepositoryItemColorPickEdit ColorPickEdit;

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public LabelEditForm()
        {
            InitializeComponent();
            ColorPickEdit = new RepositoryItemColorPickEdit();
            ColorPickEdit.StoreColorAsInteger = true;
            MainGridControl.DataSourceChanged += MainGridControl_DataSourceChanged;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void MainGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (!MainGridControl.RepositoryItems.Contains(ColorPickEdit))
            {
                MainGridControl.RepositoryItems.Add(ColorPickEdit);
                ColorPickEdit.AutoHeight = false;
                ColorPickEdit.AutomaticColor = Color.Black;
                ColorPickEdit.Name = "Color Picker";
            }
            if (MainGridView.Columns.ColumnByFieldName("Color") != null) MainGridView.Columns["Color"].ColumnEdit = ColorPickEdit;
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void SetDataSources(object source) => MainGridControl.DataSource = source;
    }
}