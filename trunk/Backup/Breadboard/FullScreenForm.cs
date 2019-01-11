using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TSOP.SlideShow;

namespace Breadboard
{
	/// <summary>
	/// Summary description for FullScreenForm.
	/// </summary>
	public class FullScreenForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ISlideShowForm _parentForm;

		private Graphics _graphicsObj;

		public FullScreenForm(ISlideShowForm parentForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_parentForm = parentForm;

			_graphicsObj = this.CreateGraphics();

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
			// 
			// FullScreenForm
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FullScreenForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "Full Screen Image Preview";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullScreenForm_KeyDown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FullScreenForm_Paint);

		}
		#endregion


		private void FullScreenForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Down:
					_parentForm.NextImage();
					this.Refresh();
					break;
				case Keys.Up:
					_parentForm.PreviousImage();
					this.Refresh();
					break;
				case Keys.Escape:
					this.Visible = false;
					break;
				
					
			}
		
		}

		private void FullScreenForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
//			_graphicsObj.FillRectangle(new SolidBrush(Color.Black), _graphicsObj.VisibleClipBounds);
//
//			ImageItem i = _parentForm.GetCurrentImageItem();
//			i.Draw(_graphicsObj);
				
		}


	}
}
