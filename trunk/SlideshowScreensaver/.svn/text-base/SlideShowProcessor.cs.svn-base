using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for SlideShowScreenSaver.
	/// </summary>
	public class SlideShowProcessor
	{
		[STAThread]
		static void Main(string[] args) 
		{
			if (args.Length > 0)
			{
				if (args[0].ToLower().Trim().Substring(0,2) == "/c")
				{
					System.Diagnostics.Process p = new System.Diagnostics.Process();
					p.StartInfo.FileName = "TSOP.SlideShowSetup.NET.exe";
                    p.StartInfo.Arguments = "/r";
					p.Start();
				}
				else if (args[0].ToLower() == "/s")
				{
                    // todo: need to figure out which is primary and secondary screen
                    // when esc is hit on one screen, close all screens
                    //if (Screen.AllScreens.GetLength(0) > 1)
                    //{
                        //System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(thread2));
                        //t2.Start();
                        System.Windows.Forms.Application.Run(new ScreenSaverForm(true, 0));
                    //}
                }
			}
			else
			{
                //if (Screen.AllScreens.GetLength(0) > 1)
                //{
                //    System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(thread2));
                //    t2.Start();
                //}
				System.Windows.Forms.Application.Run(new ScreenSaverForm(true, 0));
            }
		}

        static void thread2()
        {
            System.Windows.Forms.Application.Run(new ScreenSaverForm(true, 1));

        }

		#region Members

		private ConfigFile _configFile;

		private Random _rand;

		private ArrayList _imageList;

		private int _currentImageIndex;

		#endregion

		#region Properties

		public ImageItem[] ImageArray
		{
			get
			{
				ImageItem[] imageArray = new ImageItem[_imageList.Count];
				_imageList.CopyTo(imageArray);
				return imageArray;
			}
		}

		public ConfigFile SlideShowConfig
		{
			get
			{
				return _configFile;
			}
		}

		public ImageItem CurrentImage
		{
			get
			{
                return (ImageItem)_imageList[_currentImageIndex];
  			}
		}

		#endregion

		#region Constructors

		public SlideShowProcessor()
		{
			//_configFile = new ConfigFile(true);
			_configFile = new ConfigFile(@"C:\Documents and Settings\Stan Dewan\My Documents\Programming\C#\Programs\Slideshow.NET\Test Files\TestConfig.scr");

			_rand = new Random();

			_currentImageIndex = 0;
		}

		#endregion

		#region Destructors

		#endregion

		#region Methods

		public bool LoadConfig(string fileName)
		{

			if (!_configFile.Load(fileName))
				return false;

			BuildImageList();

			return true;

		}

		public bool LoadConfig()
		{

			if (!_configFile.Load())
				return false;

			BuildImageList();

			return true;
	
		}

		public bool LoadConfigFromRegistry()
		{

			if (!_configFile.LoadFromRegistry())
				return false;

			BuildImageList();

			return true;

		}

		private void BuildImageList()
		{

			int count = 0;
			foreach (ScriptFile sf in _configFile.ScriptFileList)
			{
				count += sf.ImageItemCollection.Count;
			}
			_imageList = new ArrayList(count);
			_currentImageIndex = 0;

			_imageList.AddRange(AppendImageList());

		}

		private ImageItem[] AppendImageList()
		{

			ArrayList imageList;
			int count = 0;
			foreach (ScriptFile sf in _configFile.ScriptFileList)
			{
				count += sf.ImageItemCollection.Count;
			}
			imageList = new ArrayList(count);

			// build an unshuffled arraylist
			foreach (ScriptFile sf in _configFile.ScriptFileList)
			{

				foreach (ImageItem ii in sf.ImageItemCollection)
				{
					imageList.Add(ii);
				}

			}

			if (_configFile.Randomize)
			{
//				imageList.Sort(new Randomizer());
                Shuffle(imageList);
			}

			ImageItem[] imageArray = new ImageItem[imageList.Count];
			imageList.CopyTo(imageArray);

			return imageArray;

		}

        private void Shuffle(ArrayList imageList)
        {
            Random rand = new Random();
            
            for (int i = 0; i < imageList.Count; i++)
            {
                int j = (int)(rand.Next(imageList.Count));
                object temp = imageList[i];          // swap
                imageList[i] = imageList[j];        // the
                imageList[j] = temp;               // images
            }
        }

		public ImageItem GetNextImage()
		{

			// get the highest index in the current image list
			int upperIndex = _imageList.Count - 1;

			// increment the current image index
			_currentImageIndex++;

			// see if more images are needed
			if (_currentImageIndex > upperIndex)
			{
				_imageList.AddRange(AppendImageList());
			}

			return (ImageItem) _imageList[_currentImageIndex];
		
		}

		public ImageItem GetPreviousImage()
		{
			_currentImageIndex--;

			if (_currentImageIndex < 0)
				_currentImageIndex = 0;

			return (ImageItem) _imageList[_currentImageIndex];

		}

		#endregion


	}
}
