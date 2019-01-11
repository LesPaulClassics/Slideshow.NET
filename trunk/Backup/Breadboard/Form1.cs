using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TSOP;
using TSOP.SlideShow;

namespace Breadboard
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form, ISlideShowForm
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox _checkBoxFullScreen;
		private System.Windows.Forms.PictureBox _pictureBoxPreview;
		private System.Windows.Forms.ComboBox _comboBoxStretchType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox _textBoxScaleFactor;

		private ImageItem[] _images = new ImageItem[15];

		private Graphics _pictureBoxGraphics;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button _buttonPerf;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ListBox _listBoxScripts;
		private System.Windows.Forms.ListView _listViewImages;

		private FullScreenForm _fullScreen;
		private System.Windows.Forms.ColumnHeader FileName;
		private System.Windows.Forms.ColumnHeader FilePath;

		private ConfigFile _cf;
		private System.Windows.Forms.ListView _listViewScripts;
		private System.Windows.Forms.Button buttonReg;
		private System.Windows.Forms.Button setReg;
		private System.Windows.Forms.TextBox _txtAddReg;
		private System.Windows.Forms.Button _buttonAddReg;
		private System.Windows.Forms.TextBox _txtFullPath;
		private System.Windows.Forms.NumericUpDown _cboLength;
		private System.Windows.Forms.Button _btnGo;
        private Button button7;
		private System.Windows.Forms.ColumnHeader ScriptFileName;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_images[0] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image1.jpg");
			_images[1] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image2.jpg");
			_images[2] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image3.jpg");
			_images[3] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image4.jpg");
			_images[4] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image5.jpg");
			_images[5] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image6.jpg");
			_images[6] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image7.jpg");
			_images[7] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image8.jpg");
			_images[8] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image9.jpg");
			_images[9] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image10.jpg");
			_images[10] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image11.jpg");
			_images[11] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image12.jpg");
			_images[12] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image13.jpg");
			_images[13] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image14.jpg");
			_images[14] = new ImageItem(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image15.jpg");

			for (int i = 0; i < 15; i++)
			{
				_images[i].KeywordString = "keyword1, keyword2, some other keywords";
				_images[i].KeywordString += String.Format(", this is image{0}", i);
				this._listViewImages.Items.Add(_images[i].PathAndFileName);
			}

			this._comboBoxStretchType.DataSource = Enum.GetNames(typeof(StretchTypes));

			this._pictureBoxGraphics = _pictureBoxPreview.CreateGraphics();

			_fullScreen = new FullScreenForm(this);
			_fullScreen.Visible = false;
			_fullScreen.Bounds = Screen.PrimaryScreen.Bounds;
//			this._screenGraphics = _fullScreen.CreateGraphics();

		}

		public System.Windows.Forms.ContextMenu CtxtMenu
		{
			get
			{
				throw new NotSupportedException();
			}
		}


		public ImageItem GetCurrentImageItem()
		{
			return null;//_images[this._listViewImages.SelectedIndex];
		}

		public void NextImage()
		{
//			if (this._listViewImages.SelectedIndex < this._listBoxImages.Items.Count - 1)
//				this._listViewImages.SelectedIndex++;
		}

		public void PreviousImage()
		{
//			if (this._listViewImages.SelectedIndex > 0)
//				this._listViewImages.SelectedIndex--;
		}

		public void ClosePreview()
		{

		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this._comboBoxStretchType = new System.Windows.Forms.ComboBox();
            this._pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this._checkBoxFullScreen = new System.Windows.Forms.CheckBox();
            this._textBoxScaleFactor = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this._buttonPerf = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this._listBoxScripts = new System.Windows.Forms.ListBox();
            this._listViewImages = new System.Windows.Forms.ListView();
            this.FileName = new System.Windows.Forms.ColumnHeader();
            this.FilePath = new System.Windows.Forms.ColumnHeader();
            this._listViewScripts = new System.Windows.Forms.ListView();
            this.ScriptFileName = new System.Windows.Forms.ColumnHeader();
            this.buttonReg = new System.Windows.Forms.Button();
            this.setReg = new System.Windows.Forms.Button();
            this._txtAddReg = new System.Windows.Forms.TextBox();
            this._buttonAddReg = new System.Windows.Forms.Button();
            this._txtFullPath = new System.Windows.Forms.TextBox();
            this._cboLength = new System.Windows.Forms.NumericUpDown();
            this._btnGo = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cboLength)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Thumbnail";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _comboBoxStretchType
            // 
            this._comboBoxStretchType.AllowDrop = true;
            this._comboBoxStretchType.Location = new System.Drawing.Point(304, 40);
            this._comboBoxStretchType.Name = "_comboBoxStretchType";
            this._comboBoxStretchType.Size = new System.Drawing.Size(121, 21);
            this._comboBoxStretchType.TabIndex = 3;
            this._comboBoxStretchType.SelectedIndexChanged += new System.EventHandler(this._comboBoxStretchType_SelectedIndexChanged);
            // 
            // _pictureBoxPreview
            // 
            this._pictureBoxPreview.Location = new System.Drawing.Point(352, 160);
            this._pictureBoxPreview.Name = "_pictureBoxPreview";
            this._pictureBoxPreview.Size = new System.Drawing.Size(300, 225);
            this._pictureBoxPreview.TabIndex = 4;
            this._pictureBoxPreview.TabStop = false;
            // 
            // _checkBoxFullScreen
            // 
            this._checkBoxFullScreen.Location = new System.Drawing.Point(312, 72);
            this._checkBoxFullScreen.Name = "_checkBoxFullScreen";
            this._checkBoxFullScreen.Size = new System.Drawing.Size(104, 24);
            this._checkBoxFullScreen.TabIndex = 5;
            this._checkBoxFullScreen.Text = "Full Screen";
            this._checkBoxFullScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._checkBoxFullScreen.CheckedChanged += new System.EventHandler(this._checkBoxFullScreen_CheckedChanged);
            // 
            // _textBoxScaleFactor
            // 
            this._textBoxScaleFactor.Enabled = false;
            this._textBoxScaleFactor.Location = new System.Drawing.Point(432, 40);
            this._textBoxScaleFactor.Name = "_textBoxScaleFactor";
            this._textBoxScaleFactor.Size = new System.Drawing.Size(40, 20);
            this._textBoxScaleFactor.TabIndex = 6;
            this._textBoxScaleFactor.Text = "1.0";
            this._textBoxScaleFactor.TextChanged += new System.EventHandler(this._textBoxScaleFactor_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Save Thumbnail";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _buttonPerf
            // 
            this._buttonPerf.Location = new System.Drawing.Point(216, 8);
            this._buttonPerf.Name = "_buttonPerf";
            this._buttonPerf.Size = new System.Drawing.Size(104, 23);
            this._buttonPerf.TabIndex = 8;
            this._buttonPerf.Text = "Test Performance";
            this._buttonPerf.Click += new System.EventHandler(this._buttonPerf_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(480, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Save Script";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(480, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Load Script";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(576, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Load Config";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(576, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Save Config";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // _listBoxScripts
            // 
            this._listBoxScripts.Location = new System.Drawing.Point(368, 104);
            this._listBoxScripts.Name = "_listBoxScripts";
            this._listBoxScripts.ScrollAlwaysVisible = true;
            this._listBoxScripts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._listBoxScripts.Size = new System.Drawing.Size(288, 43);
            this._listBoxScripts.TabIndex = 13;
            this._listBoxScripts.SelectedIndexChanged += new System.EventHandler(this._listBoxScripts_SelectedIndexChanged);
            // 
            // _listViewImages
            // 
            this._listViewImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FilePath});
            this._listViewImages.FullRowSelect = true;
            this._listViewImages.GridLines = true;
            this._listViewImages.Location = new System.Drawing.Point(8, 96);
            this._listViewImages.Name = "_listViewImages";
            this._listViewImages.Size = new System.Drawing.Size(288, 288);
            this._listViewImages.TabIndex = 14;
            this._listViewImages.UseCompatibleStateImageBehavior = false;
            this._listViewImages.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 104;
            // 
            // FilePath
            // 
            this.FilePath.Text = "Path";
            this.FilePath.Width = 174;
            // 
            // _listViewScripts
            // 
            this._listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScriptFileName});
            this._listViewScripts.FullRowSelect = true;
            this._listViewScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._listViewScripts.Location = new System.Drawing.Point(8, 40);
            this._listViewScripts.Name = "_listViewScripts";
            this._listViewScripts.Size = new System.Drawing.Size(288, 48);
            this._listViewScripts.TabIndex = 15;
            this._listViewScripts.UseCompatibleStateImageBehavior = false;
            this._listViewScripts.View = System.Windows.Forms.View.Details;
            this._listViewScripts.SelectedIndexChanged += new System.EventHandler(this._listViewScripts_SelectedIndexChanged);
            // 
            // ScriptFileName
            // 
            this.ScriptFileName.Text = "ScriptFileName";
            this.ScriptFileName.Width = 260;
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(8, 392);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(75, 23);
            this.buttonReg.TabIndex = 16;
            this.buttonReg.Text = "Load Reg";
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // setReg
            // 
            this.setReg.Location = new System.Drawing.Point(88, 392);
            this.setReg.Name = "setReg";
            this.setReg.Size = new System.Drawing.Size(75, 23);
            this.setReg.TabIndex = 17;
            this.setReg.Text = "Set Reg";
            this.setReg.Click += new System.EventHandler(this.setReg_Click);
            // 
            // _txtAddReg
            // 
            this._txtAddReg.Location = new System.Drawing.Point(176, 392);
            this._txtAddReg.Name = "_txtAddReg";
            this._txtAddReg.Size = new System.Drawing.Size(440, 20);
            this._txtAddReg.TabIndex = 18;
            this._txtAddReg.Text = "filename 1";
            // 
            // _buttonAddReg
            // 
            this._buttonAddReg.Location = new System.Drawing.Point(624, 392);
            this._buttonAddReg.Name = "_buttonAddReg";
            this._buttonAddReg.Size = new System.Drawing.Size(32, 23);
            this._buttonAddReg.TabIndex = 19;
            this._buttonAddReg.Text = "Add";
            this._buttonAddReg.Click += new System.EventHandler(this._buttonAddReg_Click);
            // 
            // _txtFullPath
            // 
            this._txtFullPath.Location = new System.Drawing.Point(8, 424);
            this._txtFullPath.Name = "_txtFullPath";
            this._txtFullPath.Size = new System.Drawing.Size(456, 20);
            this._txtFullPath.TabIndex = 20;
            this._txtFullPath.Text = "d:\\Documents and Settings\\Stan Dewan\\My Documents\\Work\\New Century\\Code\\LIMS_PR\\N" +
                "CEN.LIMS\\NCEN.LIMS.BusinessLayerNew\\NCEN.LIMS.BusinessLayer.Journals\\Something.v" +
                "b";
            // 
            // _cboLength
            // 
            this._cboLength.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._cboLength.Location = new System.Drawing.Point(472, 424);
            this._cboLength.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this._cboLength.Name = "_cboLength";
            this._cboLength.Size = new System.Drawing.Size(48, 20);
            this._cboLength.TabIndex = 21;
            this._cboLength.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // _btnGo
            // 
            this._btnGo.Location = new System.Drawing.Point(528, 424);
            this._btnGo.Name = "_btnGo";
            this._btnGo.Size = new System.Drawing.Size(32, 23);
            this._btnGo.TabIndex = 22;
            this._btnGo.Text = "Go";
            this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(581, 424);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 23;
            this.button7.Text = "String Constants";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 454);
            this.Controls.Add(this.button7);
            this.Controls.Add(this._btnGo);
            this.Controls.Add(this._cboLength);
            this.Controls.Add(this._txtFullPath);
            this.Controls.Add(this._txtAddReg);
            this.Controls.Add(this._textBoxScaleFactor);
            this.Controls.Add(this._buttonAddReg);
            this.Controls.Add(this.setReg);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this._listViewScripts);
            this.Controls.Add(this._listViewImages);
            this.Controls.Add(this._listBoxScripts);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this._buttonPerf);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._checkBoxFullScreen);
            this.Controls.Add(this._pictureBoxPreview);
            this.Controls.Add(this._comboBoxStretchType);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.OnClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cboLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private int _index = 0;

		private void button1_Click(object sender, System.EventArgs e)
		{
		
			_images[0].ReadThumbnailDataFromFile();

//			ImageItem testItem = new ImageItem();
//
//			testItem.FileName = "thefilename.jpg";
//			testItem.FilePath = @"C:\path1\path2\";
//			//			MessageBox.Show(testItem.PathAndFileName);
//
//			testItem.PathAndFileName = @"C:\this is the path\this is the filename.jpg";
//			//			MessageBox.Show(String.Format("FileName: {0}, FilePath: {1}", testItem.FileName, testItem.FilePath));
//
//			testItem.KeywordString = "keyword1, keyword2, another keyword";
//			MessageBox.Show(String.Format("KW1 = {0}; KW2 = {1}; KW3 = {2}", testItem.KeywordList[0], testItem.KeywordList[1], testItem.KeywordList[2]));
//
//			string[] strArray = new string[4];
//			strArray[0] = "the first keyword";
//			strArray[1] = "the 2nd keyword";
//			strArray[2] = "another keyword";
//			strArray[3] = "the last keyword";
//			testItem.KeywordList = new ArrayList(strArray);
//
//			MessageBox.Show("Keyword String = " + testItem.KeywordString);
//
//			testItem.KeywordList = new ArrayList();
//			testItem.KeywordList.Add("the first keyword");
//			testItem.KeywordList.Add("the 2nd keyword");
//			testItem.KeywordList.Add("another keyword");
//			testItem.KeywordList.Add("the last keyword");
//
//			MessageBox.Show("Keyword String = " + testItem.KeywordString);

		}

		private void _checkBoxFullScreen_CheckedChanged(object sender, System.EventArgs e)
		{
		}

		private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			_index++;
			if (_index > 2)
				_index = 0;
		}

		private void SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_pictureBoxGraphics.FillRectangle(new SolidBrush(Color.Black), _pictureBoxGraphics.VisibleClipBounds);
			if (this._checkBoxFullScreen.Checked)
			{
				_fullScreen.Visible = true;
				//_images[this._listBoxImages.SelectedIndex].Draw(_screenGraphics, Screen.PrimaryScreen.Bounds);
			}
			else
				_images[this._listViewImages.SelectedIndices[0]].Draw(_pictureBoxGraphics, Screen.PrimaryScreen.Bounds);
		}

		private void _comboBoxStretchType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			StretchTypes stretchType = (StretchTypes) Enum.Parse(typeof(StretchTypes), _comboBoxStretchType.Text);

			foreach (ImageItem i in _images)
			{
				i.StretchType = stretchType;
			}

			if (stretchType == StretchTypes.ScaleFactor)
				this._textBoxScaleFactor.Enabled = true;
			else
				this._textBoxScaleFactor.Enabled = false;

		}

		private void _textBoxScaleFactor_TextChanged(object sender, System.EventArgs e)
		{
			float scale = 1.0f;
			try
			{
				scale = float.Parse(this._textBoxScaleFactor.Text);
			}
			catch
			{
			}

			foreach (ImageItem i in _images)
			{
				i.ScaleFactor = scale;
			}
		}

		private void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			MessageBox.Show("testing");
		}

		private void OnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			MessageBox.Show("testing");
		
		}

		private void OnKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			MessageBox.Show("testing");
		
		}

		private void OnClick(object sender, System.EventArgs e)
		{
			MessageBox.Show("testing");

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			_images[0].WriteThumbnailData();
		}

		private void _buttonPerf_Click(object sender, System.EventArgs e)
		{
			DateTime dt = DateTime.Now;

			for (int i = 0; i < 1000; i++)
			{
				ThumbnailFile tf = new ThumbnailFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\Image1.jpg");
				tf.Load();
				//System.Diagnostics.Debug.WriteLine(tf.KeywordString);
				//tf = null;
				//System.GC.Collect();
			}

			TimeSpan diff = DateTime.Now.Subtract(dt);
			MessageBox.Show(diff.ToString());
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			ScriptFile sf = new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript1.scr");
			sf.ImageItemCollection.AddImageItem(ref _images[0]);
			sf.ImageItemCollection.AddImageItem(ref _images[1]);
			sf.ImageItemCollection.AddImageItem(ref _images[2]);
			sf.ImageItemCollection.AddImageItem(ref _images[3]);
			sf.ImageItemCollection.AddImageItem(ref _images[4]);

			ScriptFile sf2 = new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript2.scr");
			sf2.ImageItemCollection.AddImageItem(ref _images[5]);
			sf2.ImageItemCollection.AddImageItem(ref _images[6]);
			sf2.ImageItemCollection.AddImageItem(ref _images[7]);
			sf2.ImageItemCollection.AddImageItem(ref _images[8]);
			sf2.ImageItemCollection.AddImageItem(ref _images[9]);

			ScriptFile sf3 = new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript3.scr");
			sf3.ImageItemCollection.AddImageItem(ref _images[10]);
			sf3.ImageItemCollection.AddImageItem(ref _images[11]);
			sf3.ImageItemCollection.AddImageItem(ref _images[12]);
			sf3.ImageItemCollection.AddImageItem(ref _images[13]);
			sf3.ImageItemCollection.AddImageItem(ref _images[14]);
			
			if (sf.Save() & sf2.Save() & sf3.Save())
				MessageBox.Show("okeydokey");
			else
				MessageBox.Show("damn it");
		}

		private void button4_Click(object sender, System.EventArgs e)
		{

			ScriptFile sf = new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript.scr");
			sf.Load(true);

		}

		private void button6_Click(object sender, System.EventArgs e)
		{

			ConfigFile cf = new ConfigFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestConfig.scr");

			cf.IntervalTime = 13;
			cf.MouseWakeup = true;
			cf.Randomize = true;
			cf.StretchDefault = StretchTypes.StretchKeepAspectRatio;
			cf.ScriptFileList.Add(new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript1.scr"));
			cf.ScriptFileList.Add(new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript2.scr"));
			cf.ScriptFileList.Add(new ScriptFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestScript3.scr"));

			if (cf.Save())
				MessageBox.Show("okeydokey");
			else
				MessageBox.Show("damn it");

		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			_images = null;
			_listBoxScripts.Items.Clear();

			_cf = new ConfigFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestConfig.scr");

			if (_cf.Load())
				MessageBox.Show("okeydokey");
			else
				MessageBox.Show("damn it");

//			foreach (ScriptFile sf in _cf.ScriptFileList)
//			{
//				this._listBoxScripts.Items.Add(sf.PathAndFileName);
//			}

			for (int i = 0; i < _cf.ScriptFileList.Count; i++)
			{

				//this._listBoxScripts.ForeColor = _colorArray[i];
				ListViewItem item = new ListViewItem(_cf.ScriptFileList[i].PathAndFileName);
				//this._listBoxScripts.Items.Add(_cf.ScriptFileList[i].PathAndFileName);
				item.ForeColor = TSOP.ColorArray.GetAt(i);
				this._listViewScripts.Items.Add(item);
			}
			
		}

		private void _listBoxScripts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this._listViewImages.Items.Clear();

			ScriptFile sf = _cf.ScriptFileList.GetScriptByName(_cf.ScriptFileList[_listBoxScripts.SelectedIndex].PathAndFileName);

			foreach (ImageItem ii in sf.ImageItemCollection)
			{

				//this._listViewImages.Items.Add(ii.PathAndFileName);
				this._listViewImages.Items.Add(new ListViewItem(new String[] {ii.FileName, ii.FilePath}));

			}

			this._listViewImages.Refresh();
		}

		private void _listViewScripts_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			this._listViewImages.Items.Clear();

			for (int i = 0; i < _listViewScripts.SelectedIndices.Count; i++)
			{

				ScriptFile sf = _cf.ScriptFileList.GetScriptByName(_cf.ScriptFileList[_listViewScripts.SelectedIndices[i]].PathAndFileName);

				foreach (ImageItem ii in sf.ImageItemCollection)
				{

					//this._listViewImages.Items.Add(ii.PathAndFileName);
					ListViewItem lvi = new ListViewItem(new String[] {ii.FileName, ii.FilePath});
					lvi.ForeColor = TSOP.ColorArray.GetAt(_listViewScripts.SelectedIndices[i]);
					this._listViewImages.Items.Add(lvi);

				}
			}

			this._listViewImages.Refresh();
		
		}

		private void buttonReg_Click(object sender, System.EventArgs e)
		{
			RegistrySettings rs = new RegistrySettings();

			System.Text.StringBuilder sBldr = new System.Text.StringBuilder();

			sBldr.Append(String.Format("CopyToDir: {0}\n", rs.GetCopyToDir()));
			sBldr.Append(String.Format("Size: {0}, {1}\n", rs.GetWindowSize().Width, rs.GetWindowSize().Height));
			sBldr.Append(String.Format("Position: {0}, {1}\n", rs.GetWindowPosition().X, rs.GetWindowPosition().Y));

			string[] mruArray = {"NOT SET", "NOT SET", "NOT SET", "NOT SET"};
			System.Collections.ArrayList mruList = rs.GetMRUList();
			for (int i=0; i < mruList.Count; i++)
			{
				mruArray[i] = (string) mruList[i];
			}
			sBldr.Append(String.Format("MRU List:\n\t{0}\n\t{1}\n\t{2}\n\t{3}", 
										mruArray[0],mruArray[1],mruArray[2],mruArray[3]));
	
			ConfigFile cf = rs.GetConfigSettings();
			if (cf != null) 
			{
				sBldr.Append(String.Format("\nConfig Data\n\t{0}, {1}, {2}, {3}, {4}", cf.IntervalTime, cf.Randomize, cf.ScriptFileList[0].FileName, cf.ScriptFileList[1].FileName, cf.ScriptFileList[2].FileName));
			}
			string outStr = sBldr.ToString();
			MessageBox.Show(outStr);
		}

		private void setReg_Click(object sender, System.EventArgs e)
		{
			RegistrySettings rs = new RegistrySettings();

			rs.SetCopyToDir(@"D:\temp");
			rs.SetWindowPosition(new Point(10,12));
			rs.SetWindowSize(new Size(850, 675));

			ConfigFile cf = new ConfigFile(@"D:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestConfig.ssc");
			cf.Load();

			rs.SetConfigSettings(cf);

		}

		private void _buttonAddReg_Click(object sender, System.EventArgs e)
		{
			RegistrySettings rs = new RegistrySettings();
			if (!rs.AddMRUFile(_txtAddReg.Text))
				MessageBox.Show("oops");		
		}

		private void _btnGo_Click(object sender, System.EventArgs e)
		{
			_txtAddReg.Text = TSOP.Utilities.ShortenPath(_txtFullPath.Text, (int) _cboLength.Value);
		}
	
		public void UpdateOffset(int X, int Y)
		{
			Point currOff = GetCurrentImageItem().Offset;
			GetCurrentImageItem().Offset.Offset(X, Y);
			
		}

		public void UpdateScaleFactor(bool increase)
		{

		}

        private void button7_Click(object sender, EventArgs e)
        {
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Breadboard.Resource1", System.Reflection.Assembly.GetExecutingAssembly());
            string s1 = rm.GetString( "String1" );
            string s2 = rm.GetString("String2");
            MessageBox.Show(s1 + "\n" + s2);
        }
	}
}
