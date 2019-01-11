using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for EntryFormBase.
	/// </summary>
	public abstract class EntryFormBase : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button _btnSave;
		private System.Windows.Forms.Button _btnCancel;
		protected System.Windows.Forms.TextBox _txtValue;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public EntryFormBase()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this._txtValue = new System.Windows.Forms.TextBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtValue
            // 
            this._txtValue.Location = new System.Drawing.Point(8, 16);
            this._txtValue.Name = "_txtValue";
            this._txtValue.Size = new System.Drawing.Size(100, 20);
            this._txtValue.TabIndex = 0;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(8, 64);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(48, 23);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(64, 64);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(48, 23);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // OffsetEntryForm
            // 
            this.AcceptButton = this._btnSave;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(120, 94);
            this.ControlBox = false;
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OffsetEntryForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Enter Value";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EntryFormBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void _btnSave_Click(object sender, System.EventArgs e)
		{
			Save();
		}

		private void _btnCancel_Click(object sender, System.EventArgs e)
		{
			Cancel();
		}

		private void EntryFormBase_Load(object sender, System.EventArgs e)
		{
			InitForm();
		}

		protected abstract void InitForm();

		protected abstract void Cancel();

		protected abstract void Save();

	}
}
