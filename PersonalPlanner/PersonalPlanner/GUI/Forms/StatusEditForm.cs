using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PersonalPlanner.GUI.Components;
using System;
using System.Drawing;

namespace PersonalPlanner.GUI.Forms
{
    public partial class StatusEditForm : DevExpress.XtraEditors.XtraForm
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

        public StatusEditForm()
        {
            InitializeComponent();
            this.TopMost = true;
            ColorPickEdit = new RepositoryItemColorPickEdit();
            ColorPickEdit.StoreColorAsInteger = true;
            MainGridControl.DataSourceChanged += MainGridControl_DataSourceChanged;
            MainGridView.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;
            MainGridView.OptionsEditForm.CustomEditFormLayout = new StatusEditLayout();
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
            foreach (GridColumn col in MainGridView.Columns)
            {
                if (col.Name.Contains("Color")) col.ColumnEdit = ColorPickEdit;
            }
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void SetDataSources(object source) => MainGridControl.DataSource = source;
    }
}