using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
    class MessageBoxes
    {
        private MessageBoxes()
        {
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, 
                StringConstants.GetString(StringNames.MESSAGE_BOX_TITLE_ERROR), 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        public static DialogResult ShowConfirm(string message)
        {
            return MessageBox.Show(message,
                        StringConstants.GetString(StringNames.MESSAGE_BOX_TITLE_CONFIRM),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message,
                StringConstants.GetString(StringNames.MESSAGE_BOX_TITLE_INFO),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message,
                StringConstants.GetString(StringNames.MESSAGE_BOX_TITLE_WARNING),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public static void ShowInfo(string message, string[] items)
        {
            ListBoxResultsForm.Show(message,
                StringConstants.GetString(StringNames.MESSAGE_BOX_TITLE_INFO),
                items);
        }
    }
}
