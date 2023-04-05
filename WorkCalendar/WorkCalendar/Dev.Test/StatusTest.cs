using DevExpress.Utils.Drawing;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.CustomEditor;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCalendar.Dev.Test
{
    public partial class StatusTest : Form
    {
        public StatusTest()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
            gridView1.OptionsEditForm.CustomEditFormLayout = new StatusEditTest();
        }

        public void SetDataSources(object source) => gridControl1.DataSource = source;
    }
}