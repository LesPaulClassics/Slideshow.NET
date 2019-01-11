using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ScreenSaverForm : System.Windows.Forms.Form
	{

		#region Windows Form Designer generated code

		private System.Windows.Forms.Timer _slideTimer;
		private System.ComponentModel.IContainer components;
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this._slideTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _slideTimer
            // 
            this._slideTimer.Interval = 5000;
            this._slideTimer.Tick += new System.EventHandler(this._slideTimer_Tick);
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenSaverForm";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TopMost = true;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenSaverForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseEvent);
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

		#region Members

		private Graphics _formGraphics;

		private Point _mouseXY;

		private SlideShowProcessor _processor;

		private ImageItem _currentImage;

		private Region _pauseLabel;

        private int _monitorIndex;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		public ScreenSaverForm(bool loadFromRegistry, int monitorIndex)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            _monitorIndex = monitorIndex;

			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

			_processor = new SlideShowProcessor();

            if (loadFromRegistry)
            {
                if (!_processor.LoadConfigFromRegistry())
                {
                    _processor = null;
                }
            }
            else
                _processor = null;


			if (_processor.ImageArray.GetLength(0) > 0)
				_currentImage = _processor.ImageArray[0];
			else
				_currentImage = null;

		}

		#endregion

		#region Destructors

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Methods

        private void DrawErrorMessage(Graphics g, string message)
        {
            int x, y;
            Random rdm = new Random(DateTime.Now.Millisecond);
            x = rdm.Next(5, 300);
            y = rdm.Next(5, 700);
            g.DrawString(message, new Font("Arial", 14), new SolidBrush(Color.Red), new PointF(x, y));
         }

		private void ClearScreen()
		{
			ClearScreen(_formGraphics);
		}

		private void ClearScreen(Graphics g)
		{
			g.FillRectangle(new SolidBrush(Color.Black), Screen.PrimaryScreen.Bounds);
		}

		private void Pause()
		{

			if (_slideTimer.Enabled)
			{

				_slideTimer.Enabled = false;
				Invalidate(_pauseLabel);

			}
			else
			{

				_slideTimer.Enabled = true;
				Invalidate(_pauseLabel);
				Refresh();

			}

		}

        private void CleanupImageMemory()
        {
            if (_currentImage != null)
                _currentImage.UnloadImageObject();
        }

		#endregion

		#region Events

		private void _slideTimer_Tick(object sender, System.EventArgs e)
		{
			int i = DateTime.Now.Second % 4;

			try
			{
                if (_processor != null)
                {
                    CleanupImageMemory();
                    _currentImage = _processor.GetNextImage();
                }
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				TSOP.AppLog appLog = new TSOP.AppLog();
				appLog.LogError("failed to get next image", ex, "ScreenSaverForm", "_slideTimer_Tick");
			}
			Refresh();

		}

		private void ScreenSaverForm_Load(object sender, System.EventArgs e)
		{
            if (_monitorIndex == 0)
                this.Bounds = Screen.PrimaryScreen.Bounds;
            else
                this.Bounds = Screen.AllScreens[0].Bounds;
			_formGraphics = this.CreateGraphics();
			_pauseLabel = new Region(new Rectangle(Screen.PrimaryScreen.Bounds.Width - 90, 0, 90, 24));
			//			Cursor.Hide();
			//			TopMost = true;
		
			this._slideTimer.Start();
		}

		private void ScreenSaverForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (_processor == null)
                return;

			switch (e.KeyData)
			{
				case Keys.Down:
                    CleanupImageMemory();
					_currentImage = _processor.GetNextImage();
					Refresh();
					break;
				case Keys.Up:
                    CleanupImageMemory();
					_currentImage = _processor.GetPreviousImage();
					Refresh();
					break;
				case Keys.Escape:
					Close();
					break;
				case Keys.Space:
					Pause();
					break;
				default:
					break;
			}

		}

		private void ScreenSaverForm_MouseEvent(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!_mouseXY.IsEmpty)
			{
		    // always wakeup after a load error
                if (_mouseXY != new Point(e.X, e.Y) && _processor == null)
                {
                    Close();
                    return;
                }
			// only close form (wake up) on mouse movement if flag is set in config
                if (_mouseXY != new Point(e.X, e.Y) && _processor.SlideShowConfig.MouseWakeup)
                {
                    Close();
                    return;
                }
			// always wake up on right mouse click
                if (e.Clicks > 0 && e.Button == MouseButtons.Right)
                {
                    Close();
                    return;
                }
			}

			_mouseXY = new Point(e.X, e.Y);

		}

		protected override void OnPaint(PaintEventArgs e)
		{
 			ClearScreen(e.Graphics);

            if (_processor != null && _currentImage != null)
            {
 			
 			    // apply default stretch if necessary
			    if (_currentImage.StretchType == StretchTypes.UseDefault)
				    _currentImage.StretchType = _processor.SlideShowConfig.StretchDefault;

			    // draw the image
			    _currentImage.Draw(e.Graphics);

			    // paint the fileName label
			    if (_processor.SlideShowConfig.DisplayFileInfoDefault)
			    {
				    int width = Screen.PrimaryScreen.Bounds.Width - (int) _pauseLabel.GetBounds(e.Graphics).Width - 80;
				    SizeF textSize = e.Graphics.MeasureString(_processor.CurrentImage.PathAndFileName, new Font("Times New Roman", 10), width);
				    e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, (int) textSize.Width, (int) textSize.Height);
				    e.Graphics.DrawString(_processor.CurrentImage.PathAndFileName, new Font("Times New Roman", 10f), new SolidBrush(Color.BlanchedAlmond), new RectangleF(0, 0, textSize.Width, textSize.Height));
			    }
    			
			    // paint the pause label
			    if (!_slideTimer.Enabled)
			    {
				    e.Graphics.FillRegion(new SolidBrush(Color.Black), _pauseLabel);
				    e.Graphics.DrawString("PAUSED", new Font("Arial", 14f), new SolidBrush(Color.BlanchedAlmond), _pauseLabel.GetBounds(e.Graphics));
			    }

			    // paint the textfile text
			    if (Utilities.EvaluateFlags(_processor.SlideShowConfig.DisplayTextDefault, _currentImage.TextDisplayFlag))
			    {
				    string textStr = _processor.CurrentImage.GetTextFileString();
				    SizeF textSize = e.Graphics.MeasureString(textStr, new Font("Times New Roman", 10), Screen.PrimaryScreen.Bounds.Width);
				    int y = Screen.PrimaryScreen.Bounds.Height - (int) textSize.Height;
				    e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, y, Screen.PrimaryScreen.Bounds.Width, (int) textSize.Height);
				    e.Graphics.DrawString(textStr, new Font("Times New Roman", 10f), new SolidBrush(Color.BlanchedAlmond), new RectangleF(0, y, Screen.PrimaryScreen.Bounds.Width, (int) textSize.Height));
			    }
            }
            else
            {
                if (_currentImage == null)
                    DrawErrorMessage(e.Graphics, StringConstants.GetString(StringNames.SCRIPT_EMPTY));
                 else
                    DrawErrorMessage(e.Graphics, StringConstants.GetString(StringNames.LOAD_SLIDESHOW_FAILED));
            }

			base.OnPaint (e);
		}

		#endregion

	}
}
