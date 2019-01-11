using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for KeywordEditForm.
	/// </summary>
	public class KeywordEditForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox _txtNewKeyword;
		private System.Windows.Forms.ListBox _lstKeywords;
		private System.Windows.Forms.Button _btnClear;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.Button _btnCancel;
        private RadioButton _rdoAND;
        private RadioButton _rdoOR;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public KeywordEditForm(bool showAndOr)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_selectedKeywords = new List<string>(1);

            if (showAndOr)
            {
                _rdoAND.Visible = true;
                _rdoOR.Visible = true;
            }

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
            this._txtNewKeyword = new System.Windows.Forms.TextBox();
            this._lstKeywords = new System.Windows.Forms.ListBox();
            this._btnClear = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._rdoAND = new System.Windows.Forms.RadioButton();
            this._rdoOR = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // _txtNewKeyword
            // 
            this._txtNewKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNewKeyword.Location = new System.Drawing.Point(8, 8);
            this._txtNewKeyword.Name = "_txtNewKeyword";
            this._txtNewKeyword.Size = new System.Drawing.Size(136, 20);
            this._txtNewKeyword.TabIndex = 0;
            this._txtNewKeyword.Leave += new System.EventHandler(this._txtNewKeyword_Leave);
            this._txtNewKeyword.KeyUp += new System.Windows.Forms.KeyEventHandler(this._txtNewKeyword_KeyUp);
            // 
            // _lstKeywords
            // 
            this._lstKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lstKeywords.Location = new System.Drawing.Point(8, 32);
            this._lstKeywords.Name = "_lstKeywords";
            this._lstKeywords.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._lstKeywords.Size = new System.Drawing.Size(136, 134);
            this._lstKeywords.TabIndex = 1;
            // 
            // _btnClear
            // 
            this._btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClear.Location = new System.Drawing.Point(152, 144);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(75, 23);
            this._btnClear.TabIndex = 2;
            this._btnClear.Text = "Clear Select";
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(152, 8);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(152, 32);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _rdoAND
            // 
            this._rdoAND.AutoSize = true;
            this._rdoAND.Checked = true;
            this._rdoAND.Location = new System.Drawing.Point(152, 81);
            this._rdoAND.Name = "_rdoAND";
            this._rdoAND.Size = new System.Drawing.Size(48, 17);
            this._rdoAND.TabIndex = 5;
            this._rdoAND.TabStop = true;
            this._rdoAND.Text = "AND";
            this._rdoAND.UseVisualStyleBackColor = true;
            this._rdoAND.Visible = false;
            // 
            // _rdoOR
            // 
            this._rdoOR.AutoSize = true;
            this._rdoOR.Location = new System.Drawing.Point(151, 105);
            this._rdoOR.Name = "_rdoOR";
            this._rdoOR.Size = new System.Drawing.Size(41, 17);
            this._rdoOR.TabIndex = 6;
            this._rdoOR.Text = "OR";
            this._rdoOR.UseVisualStyleBackColor = true;
            this._rdoOR.Visible = false;
            // 
            // KeywordEditForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(234, 176);
            this.ControlBox = false;
            this.Controls.Add(this._rdoOR);
            this.Controls.Add(this._rdoAND);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._lstKeywords);
            this.Controls.Add(this._txtNewKeyword);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.MinimizeBox = false;
            this.Name = "KeywordEditForm";
            this.ShowInTaskbar = false;
            this.Text = "Edit Keywords";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void _btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();

			DialogResult = DialogResult.Cancel;
		}

		public List<string> Keywords
		{
			get
			{
				return _keywords;
			}
			set
			{
				_keywords = value;
			}
		}

		private List<string> _keywords;

		private void DisplayKeywords()
		{
			_lstKeywords.Items.Clear();

			foreach (string keyword in _keywords)
			{
				_lstKeywords.Items.Add(keyword);
				if (_selectedKeywords.Contains(keyword))
					_lstKeywords.SelectedItem = keyword;
			}
			
		}
	
		protected override void OnLoad(EventArgs e)
		{
			
			DisplayKeywords();

			base.OnLoad (e);
		}

		private void _btnClear_Click(object sender, System.EventArgs e)
		{
            this._lstKeywords.SelectedItems.Clear();
		}

		private void _btnOK_Click(object sender, System.EventArgs e)
		{
			GetSelectedKeywords();
			DialogResult = DialogResult.OK;
		}

		private void GetSelectedKeywords()
		{

			_selectedKeywords = new List<string>(_lstKeywords.SelectedIndices.Count);

			foreach (object obj in _lstKeywords.SelectedItems)
			{
				_selectedKeywords.Add(obj.ToString());
			}

		}

		private List<string> _selectedKeywords;

		private void _txtNewKeyword_Leave(object sender, System.EventArgs e)
		{
			AddKeyword();
		}

		private void AddKeyword()
		{
			string newKW = _txtNewKeyword.Text;

			if (newKW.Trim() != "")
			{
				GetSelectedKeywords();
				if (!_keywords.Contains(newKW))
				{
					_keywords.Add(newKW);
					_keywords.Sort();
				}
				_selectedKeywords.Add(newKW);
				DisplayKeywords();
			}

			_txtNewKeyword.Text = "";

		}

		public bool ShowTextBox
		{
			set
			{
				_txtNewKeyword.Visible = value;
			}
		}

		private void _txtNewKeyword_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				AddKeyword();
		}

		public List<string> SelectedKeywords
		{
			get
			{
				return _selectedKeywords;
			}
			set
			{
				_selectedKeywords = value;
			}
		}

        public bool AndChecked
        {
            get
            {
                return _rdoAND.Checked;
            }
        }

	}
}
