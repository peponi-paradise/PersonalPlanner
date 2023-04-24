using DevExpress.XtraTreeList;
using PersonalPlanner.Define;
using System;

namespace PersonalPlanner.Dev.Test
{
    public partial class GanttEditLayout : EditFormUserControl
    {
        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public GanttEditLayout()
        {
            InitializeComponent();

            SetBoundFieldName(NameEdit, nameof(Task.Name));
            SetBoundFieldName(StartDateEdit, nameof(Task.StartDate));
            SetBoundFieldName(FinishDateEdit, nameof(Task.FinishDate));
            SetBoundFieldName(ProgressEdit, nameof(Task.Progress));
            SetBoundFieldName(ResponsibilityEdit, nameof(Task.Responsibility));

            StartDateEdit.EditValueChanging += StartDateEdit_EditValueChanging;
            FinishDateEdit.EditValueChanging += FinishDateEdit_EditValueChanging;
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void FinishDateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue < StartDateEdit.DateTime) e.NewValue = StartDateEdit.DateTime;
        }

        private void StartDateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue > FinishDateEdit.DateTime) e.NewValue = FinishDateEdit.DateTime;
        }
    }
}