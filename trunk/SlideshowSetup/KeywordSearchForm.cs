using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
    public partial class KeywordSearchForm : Form
    {
		private System.Windows.Forms.TextBox _txtNewKeyword;
		private System.Windows.Forms.ListBox _lstKeywords;
		private System.Windows.Forms.Button _btnClear;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.Button _btnCancel;

		public KeywordSearchForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_selectedKeywords = new List<string>(1);

		}


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

            base.OnLoad(e);
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

        public bool SearchUsingAnd
        {
            get
            {
                return rdoAND.Checked;
            }
        }

    }
}