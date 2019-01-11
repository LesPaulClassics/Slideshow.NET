namespace TSOP.SlideShow
{
    partial class ListBoxResultsForm
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
            this._lblMessage = new System.Windows.Forms.Label();
            this._lstResults = new System.Windows.Forms.ListBox();
            this._btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblMessage
            // 
            this._lblMessage.AutoSize = true;
            this._lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblMessage.Location = new System.Drawing.Point(12, 9);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(59, 15);
            this._lblMessage.TabIndex = 0;
            this._lblMessage.Text = "Results:";
            // 
            // _lstResults
            // 
            this._lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lstResults.FormattingEnabled = true;
            this._lstResults.Location = new System.Drawing.Point(15, 27);
            this._lstResults.Name = "_lstResults";
            this._lstResults.Size = new System.Drawing.Size(765, 160);
            this._lstResults.TabIndex = 1;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnOK.Location = new System.Drawing.Point(370, 190);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(60, 23);
            this._btnOK.TabIndex = 2;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // ListBoxResultsForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnOK;
            this.ClientSize = new System.Drawing.Size(792, 216);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._lstResults);
            this.Controls.Add(this._lblMessage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListBoxResultsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblMessage;
        private System.Windows.Forms.ListBox _lstResults;
        private System.Windows.Forms.Button _btnOK;
    }
}