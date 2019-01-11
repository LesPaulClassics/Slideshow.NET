using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for PreviewForm.
	/// </summary>
	public class PreviewForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ISlideShowForm _parentForm;

		private Graphics _graphicsObj;

		private Rectangle _restoreRect;

		public PreviewForm(ISlideShowForm parentForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_aspectRatio = (decimal) (Screen.PrimaryScreen.Bounds.Width) / (decimal) (Screen.PrimaryScreen.Bounds.Height);

            // accomodate for window border width
            Height = 400 + 26;
            //Width = (int) (Height * _aspectRatio);



			_parentForm = parentForm;

			this.ContextMenu = this._parentForm.CtxtMenu;

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
            this.SuspendLayout();
            // 
            // PreviewForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(320, 246);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewForm";
            this.Text = "Preview";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PreviewForm_Paint);
            this.Resize += new System.EventHandler(this.PreviewForm_Resize);
            this.DoubleClick += new System.EventHandler(this.PreviewForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PreviewForm_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

		private decimal _aspectRatio;

		private void PreviewForm_Resize(object sender, System.EventArgs e)
		{
            // accomodate for window border width
            if (this.ClientSize != Screen.PrimaryScreen.Bounds.Size)
			    Width = (int) ((Height - 26) * _aspectRatio) + 8;

			_graphicsObj = this.CreateGraphics();

			Invalidate();

		}

		private void PreviewForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Down:
					if (e.Control)
						_parentForm.UpdateOffset(0, 10);
					else
						_parentForm.NextImage();
					this.Refresh();
					break;
				case Keys.Up:
					if (e.Control)
						_parentForm.UpdateOffset(0, -10);
					else
						_parentForm.PreviousImage();
					this.Refresh();
					break;
				case Keys.OemMinus:
					if (e.Shift)
					{
						_parentForm.UpdateScaleFactor(false);
						this.Refresh();
					}
					break;
				case Keys.Oemplus:
					if (e.Shift)
					{
						_parentForm.UpdateScaleFactor(true);
						this.Refresh();
					}
					break;
				case Keys.Escape:
					this.Visible = false;
					this._parentForm.ClosePreview();
					break;
				case Keys.Right:
					//Make these with the CTRL key and program up and down that way.
					if (e.Control)
					{
						_parentForm.UpdateOffset(10, 0);
						this.Refresh();
					}
					break;
				case Keys.Left:
					if (e.Control) 
					{
						_parentForm.UpdateOffset(-10, 0);
						this.Refresh();
					}
					break;
				
			}

		}

		private void PreviewForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			_graphicsObj.FillRectangle(new SolidBrush(Color.Black), _graphicsObj.VisibleClipBounds);

			ImageItem i = _parentForm.GetCurrentImageItem();
			if (i != null)
				i.Draw(_graphicsObj, Screen.PrimaryScreen.Bounds);
				
	
		}

		private void PreviewForm_DoubleClick(object sender, System.EventArgs e)
		{
			if (ClientSize == Screen.PrimaryScreen.Bounds.Size)
			{
				this.FormBorderStyle = FormBorderStyle.SizableToolWindow;

				this.DesktopBounds = _restoreRect;
			}
			else
			{
				_restoreRect = this.DesktopBounds;

				this.FormBorderStyle = FormBorderStyle.None;

				this.ClientSize = Screen.PrimaryScreen.Bounds.Size;
				this.DesktopLocation = new Point(0,0);
			}
		
		}


	}
}
