﻿namespace PersonalPlanner.GUI
{
    partial class MemoUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMemo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)MainMemo.Properties).BeginInit();
            SuspendLayout();
            // 
            // MainMemo
            // 
            MainMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            MainMemo.Name = "MainMemo";
            MainMemo.Properties.AcceptsTab = true;
            MainMemo.Size = new System.Drawing.Size(100, 96);
            MainMemo.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)MainMemo.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit MainMemo;
    }
}
