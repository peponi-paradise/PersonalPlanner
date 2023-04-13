using DevExpress.XtraEditors.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class LabelEditForm : Form
    {
        private RepositoryItemColorPickEdit ColorPickEdit;

        public LabelEditForm()
        {
            InitializeComponent();
            ColorPickEdit = new RepositoryItemColorPickEdit();
            ColorPickEdit.StoreColorAsInteger = true;
            MainGridControl.DataSourceChanged += MainGridControl_DataSourceChanged;
        }

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

        public void SetDataSources(object source) => MainGridControl.DataSource = source;
    }
}