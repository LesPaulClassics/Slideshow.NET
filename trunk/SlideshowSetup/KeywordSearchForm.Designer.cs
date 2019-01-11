namespace TSOP.SlideShow
{
    partial class KeywordSearchForm
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
            this.rdoAND = new System.Windows.Forms.RadioButton();
            this.rdoOR = new System.Windows.Forms.RadioButton();
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
            // rdoAND
            // 
            this.rdoAND.AutoSize = true;
            this.rdoAND.Checked = true;
            this.rdoAND.Location = new System.Drawing.Point(152, 78);
            this.rdoAND.Name = "rdoAND";
            this.rdoAND.Size = new System.Drawing.Size(48, 17);
            this.rdoAND.TabIndex = 5;
            this.rdoAND.TabStop = true;
            this.rdoAND.Text = "AND";
            this.rdoAND.UseVisualStyleBackColor = true;
            // 
            // rdoOR
            // 
            this.rdoOR.AutoSize = true;
            this.rdoOR.Location = new System.Drawing.Point(152, 101);
            this.rdoOR.Name = "rdoOR";
            this.rdoOR.Size = new System.Drawing.Size(41, 17);
            this.rdoOR.TabIndex = 6;
            this.rdoOR.Text = "OR";
            this.rdoOR.UseVisualStyleBackColor = true;
            // 
            // KeywordSearchForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(234, 176);
            this.ControlBox = false;
            this.Controls.Add(this.rdoOR);
            this.Controls.Add(this.rdoAND);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._lstKeywords);
            this.Controls.Add(this._txtNewKeyword);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.MinimizeBox = false;
            this.Name = "KeywordSearchForm";
            this.ShowInTaskbar = false;
            this.Text = "Search Keywords";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.RadioButton rdoAND;
        private System.Windows.Forms.RadioButton rdoOR;
    }
}


