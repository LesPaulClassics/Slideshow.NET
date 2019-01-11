using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
    public partial class ListBoxResultsForm : Form
    {
        public ListBoxResultsForm()
        {
            InitializeComponent();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return this._lblMessage.Text;
            }
            set
            {
                this._lblMessage.Text = value;
            }
        }

        public void AddListItem(string itemText)
        {
            _lstResults.Items.Add(itemText);
        }

        public static DialogResult Show(string message, string title, string[] items)
        {
            ListBoxResultsForm frm = new ListBoxResultsForm();
            frm.Title = title;
            frm.Message = message;
            foreach (string item in items)
                frm.AddListItem(item);
            return frm.ShowDialog();
        }
    }
}