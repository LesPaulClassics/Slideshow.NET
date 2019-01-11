using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ScaleEntryForm.
	/// </summary>
	public class ScaleEntryForm : EntryFormBase
	{
		public ScaleEntryForm()
		{
			this.Text = "Enter Scale Factor";
			_scaleFactor = 1.0f;
		}

		protected float _scaleFactor;

		public float ScaleFactor
		{
			get
			{
				return _scaleFactor;
			}
			set
			{
				_scaleFactor = value;
			}
		}

		protected override void InitForm()
		{
			_txtValue.Text = _scaleFactor.ToString("##0.00");
		}

		protected override void Cancel()
		{
			Close();
		}

		protected override void Save()
		{
			try
			{
				string input = _txtValue.Text;
	
				_scaleFactor = float.Parse(input);

                if (_scaleFactor < Utilities.MinScaleFactor || _scaleFactor > Utilities.MaxScaleFactor)
                {
                    MessageBoxes.ShowError(StringConstants.GetString(StringNames.SCALE_FACTOR_OUT_OF_RANGE));
                    return;
                }

                DialogResult = DialogResult.OK;
				Close();
			}
			catch
			{
                MessageBoxes.ShowError(StringConstants.GetString(StringNames.INVALID_SCALE_FACTOR));
			}
		}

	}
}
