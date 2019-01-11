using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for OffsetEntryForm.
	/// </summary>
	public class OffsetEntryForm : EntryFormBase
	{
		protected Point _offset;

		public Point Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
			}
		}

		public OffsetEntryForm()
		{
			this.Text = "Enter Offset";
		}

		protected override void InitForm()
		{
			_txtValue.Text = TSOP.Utilities.GetPointString(_offset);
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
				input = input.Trim();
				//				input = input.Replace(" ", "");
				input = input.Replace("(", "");
				input = input.Replace(")", "");
				input = input.Trim();

				string[] parts = input.Split(new char[] {' ', ',', ';'});

				if (parts.GetLength(0) != 2)
					throw new Exception();

				_offset = new Point(Int32.Parse(parts[0]), Int32.Parse(parts[1]));

                if (_offset.X < (0 - Utilities.MaxOffset) || _offset.X > Utilities.MaxOffset ||
                    _offset.Y < (0 - Utilities.MaxOffset) || _offset.Y > Utilities.MaxOffset)
                {
                    MessageBoxes.ShowError(StringConstants.GetString(StringNames.POINT_OUT_OF_RANGE));
                    return;
                }

				//				MessageBox.Show(String.Format("({0}, {1})", _offset.X, _offset.Y));

                DialogResult = DialogResult.OK;
				Close();
			}
			catch
			{
                MessageBoxes.ShowError(StringConstants.GetString(StringNames.INVALID_POINT_SYNTAX));
			}
		}

	}
}
