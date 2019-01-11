using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using TSOP;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ScriptFile.
	/// </summary>
	public class ScriptFile
	{
		#region Members

		private ImageItemList _imageItemCollection;

		private string _fileName;

		private string _filePath;

		private AppLog _appLog;

		private Guid _id;

		private string _name;

		private const string _fileHeader = "Slideshow.Net Script File v1.0          ";

		#endregion

		#region Properties

		public ImageItemList ImageItemCollection
		{
			get
			{
				return _imageItemCollection;
			}
//			set
//			{
//				_imageItemCollection = value;
//			}
		}

		public string FileName
		{
			get
			{
				return _fileName;
			}
//			set
//			{
//				_fileName = value;
//			}
		}

		public string FilePath
		{
			get
			{
				return _filePath;
			}
//			set
//			{
//				if (!value.EndsWith("\\"))
//					value += "\\";
//				_filePath = value;
//			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public string PathAndFileName
		{
			get
			{
				return _filePath + _fileName;
			}
//			set
//			{
//				string[] parts = value.Split("\\".ToCharArray(), 30);
//				_fileName = parts[parts.GetUpperBound(0)];
//				_filePath = value.Remove(value.LastIndexOf("\\") + 1, _fileName.Length);
//			}
		}

		public Guid ID
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		#endregion

		#region Constructors

		public ScriptFile(string fileName)
		{
			string name = fileName.Remove(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
			string[] nameparts = name.Split("\\".ToCharArray());
			Init(fileName, nameparts[nameparts.GetUpperBound(0)]);
		}	
	
		public ScriptFile(string fileName, string name)
		{
			Init(fileName, name);
		}

        public ScriptFile(ScriptFile origSF, string newFileName)
        {
            // create a new filename
            string name = newFileName.Remove(newFileName.LastIndexOf("."), newFileName.Length - newFileName.LastIndexOf("."));
            string[] nameparts = name.Split("\\".ToCharArray());
            Init(newFileName, nameparts[nameparts.GetUpperBound(0)]);

            // copy the original members
            _imageItemCollection = origSF.ImageItemCollection.Copy();
         
        }

		private void Init(string fileName, string name)
		{
			_imageItemCollection = new ImageItemList(13);
			SetPathAndFilename(fileName);
			_name = name;
			_id = Guid.NewGuid();
			_appLog = new AppLog();
		}
		
		#endregion

		#region Destructors

		#endregion

		#region Methods

        public bool Load(bool readKeywords)
        {
            return Load(readKeywords, null);
        }

		public bool Load(bool readKeywords, ProgressChangedEventHandler updateProgress)
		{

			FileStream fs = new FileStream(PathAndFileName, FileMode.Open, FileAccess.Read);

			try
			{
				using (fs)
				{
				
					BinaryReader br = new BinaryReader(fs);

					using(br)
					{
						string header = br.ReadString();
						_name = br.ReadString();

						_imageItemCollection = new ImageItemList();

						while (br.BaseStream.Position < br.BaseStream.Length)
						{
 						    ImageItem ii = new ImageItem();
                            //_appLog.LogWarning("loading new image", null, "ScriptFile", "Load()");
                            ii.Deserialize(br, readKeywords);
                            _imageItemCollection.AddImageItem(ref ii);
                            if (updateProgress != null)
                                updateProgress((int)((float)br.BaseStream.Position / (float) br.BaseStream.Length * 100));
						}
	
						br.Close();
					}

					fs.Close();

				}
			}
			catch (Exception ex)
			{
				
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to load script file", ex, "ScriptFile", "Load");
				return false;

			}

			return true;

		}

		public bool Save()
		{
			FileStream fs = new FileStream(PathAndFileName, FileMode.Create);

			try
			{
				using (fs)
				{
				
					BinaryWriter bw = new BinaryWriter(fs);

					using(bw)
					{
						bw.Write(_fileHeader);
						bw.Write(_name);

						foreach (ImageItem i in this._imageItemCollection)
						{
							i.Serialize(bw);
						}
	
						bw.Close();
					}

					fs.Close();

				}
			}
			catch (Exception ex)
			{
				
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to save script file", ex, "ScriptFile", "Save");
				return false;

			}

			return true;
		}

		private void SetPathAndFilename(string filename)
		{
			
			string[] parts = filename.Split("\\".ToCharArray(), 30);
			_fileName = parts[parts.GetUpperBound(0)];
			_filePath = filename.Remove(filename.LastIndexOf("\\") + 1, _fileName.Length);
			
		}

		#endregion

	}
}
