using System;
using System.IO;
using System.Runtime.Serialization;

using TSOP;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ConfigFile.
	/// </summary>
	public class ConfigFile
	{

		#region Members

		private StretchTypes _stretchDefault;

		private uint _intervalTime;

		private ScriptFileCollection _scriptFileList;

		private bool _randomize;

		private bool _mouseWakeup;

		private bool _displayTextDefault;

		private bool _displayFileInfoDefault;

		private string _fileName;

		private string _filePath;

		private const string _fileHeader = "Slideshow.Net Config File v1.0          ";

		private bool _fromRegistry;

		private bool _readKeywords;

		private AppLog _appLog;

        private int _startProgress;         // used for progress bar updating within a script file load operation

        private int _endProgress;           // used for progress bar updating within a script file load operation

        private ProgressChangedEventHandler _updateProgress;    // delegate that calls back to the form for progress updates

		#endregion

		#region Properties

		public StretchTypes StretchDefault
		{
			get
			{
				return _stretchDefault;
			}
			set
			{
				// don't allow "UseDefault" as a default setting
				if (value == StretchTypes.UseDefault)
					_stretchDefault = StretchTypes.NoStretch;
				else
					_stretchDefault = value;
			}
		}

		public uint IntervalTime
		{
			get
			{
				return _intervalTime;
			}
			set
			{
				_intervalTime = value;
			}
		}

		public ScriptFileCollection ScriptFileList
		{
			get
			{
				return _scriptFileList;
			}
			set
			{
				_scriptFileList = value;
			}
		}

		public bool Randomize
		{
			get
			{
				return _randomize;
			}
			set
			{
				_randomize = value;
			}
		}

		public bool MouseWakeup
		{
			get
			{
				return _mouseWakeup;
			}
			set
			{
				_mouseWakeup = value;
			}
		}

		public bool DisplayTextDefault
		{
			get
			{
				return _displayTextDefault;
			}
			set
			{
				_displayTextDefault = value;
			}
		}

		public bool DisplayFileInfoDefault
		{
			get
			{
				return _displayFileInfoDefault;
			}
			set
			{
				_displayFileInfoDefault = value;
			}
		}

		public string FileName
		{
			get
			{
				return _fileName;
			}
		}

		public string FilePath
		{
			get
			{
				return _filePath;
			}
		}

		public string PathAndFileName
		{
			get
			{
				return _filePath + _fileName;
			}
		}

		public bool ReadKeywordsOnLoad
		{
			get
			{
				return _readKeywords;
			}
			set
			{
				_readKeywords = value;
			}
		}

		#endregion

		#region Constructors

		public ConfigFile()
		{
			_fromRegistry = false;
			Init();

		}

		public ConfigFile(string fileName)
		{
	
			_fromRegistry = false;
			SetPathAndFilename(fileName);
			Init();

		}

		public ConfigFile(bool fromRegistry)
		{

			_fromRegistry = fromRegistry;
			Init();
 		
		}

		public void Init()
		{

			_stretchDefault = StretchTypes.NoStretch;
			_intervalTime = 5;
			_scriptFileList = new ScriptFileCollection();
			_randomize = false;
			_mouseWakeup = false;
			_displayTextDefault = false;
			_displayFileInfoDefault = false;
			_appLog = new AppLog();
		}

		#endregion

		#region Destructors

		#endregion

		#region Methods

		public void SetPathAndFilename(string filename)
		{
			
			string[] parts = filename.Split("\\".ToCharArray(), 30);
			_fileName = parts[parts.GetUpperBound(0)];
			_filePath = filename.Remove(filename.LastIndexOf("\\") + 1, _fileName.Length);
			
		}

		public bool Save(string fileName)
		{

 			FileStream fs = new FileStream(fileName, FileMode.Create);

			try
			{
				using (fs)
				{
				
					BinaryWriter bw = new BinaryWriter(fs);

					using(bw)
					{
						if (!Serialize(bw))
							throw new Exception("failed to serialize Config Data");
					}

					fs.Close();

				}
			}
			catch (Exception ex)
			{
				
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to save config file", ex, "ConfigFile", "Save");
				return false;

			}

			return true;

		}

		public bool Save()
		{
			
			return Save(PathAndFileName);
		}

        public bool Load(string fileName)
        {
            return Load(fileName, null);
        }

 		public bool Load(string fileName, ProgressChangedEventHandler updateProgress)
		{

			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

			try
			{
				using (fs)
				{
			
					BinaryReader br = new BinaryReader(fs);

					using(br)
					{

						if (!Deserialize(br, updateProgress))
							throw (new Exception("Could not deserialize config file"));

						br.Close();

					}

					fs.Close();

				}
			}
			catch (Exception ex)
			{
			
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to load config file", ex, "ConfigFile", "Load");
				return false;

			}

			return true;

		}

        public bool LoadFromRegistry()
		{

            RegistrySettings reg = new RegistrySettings();
            return reg.PopulateConfigFile(this);

		}

        public bool Load()
        {
            if (_fromRegistry)
                return LoadFromRegistry();
            else
                return Load(PathAndFileName, null);
        }

        public bool Load(ProgressChangedEventHandler updateProgress)
		{
			if (_fromRegistry)
				return LoadFromRegistry();
			else
				return Load(PathAndFileName, updateProgress);
		}

		public bool Serialize(BinaryWriter bw)
		{
			try
			{

				bw.Write(_fileHeader);
				bw.Write((int) _stretchDefault);
				bw.Write(_intervalTime);
				bw.Write(_scriptFileList.ToString());
				bw.Write(_randomize);
				bw.Write(_mouseWakeup);
				bw.Write(_displayTextDefault);
				bw.Write(_displayFileInfoDefault);
				bw.Write(_readKeywords);

				foreach (ScriptFile sf in _scriptFileList)
				{
					if (!sf.Save())
						throw new Exception("Failed to save Script File " + sf.PathAndFileName);
				}
				
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to serialize Config File", ex, "ConfigFile", "Serialize");
				return false;
			}
			
			return true;
			
		}

		public bool Deserialize(BinaryReader br, ProgressChangedEventHandler updateProgress)
		{

			try
			{
                _updateProgress = updateProgress;

				// read the file
				string header = br.ReadString();	// (file header)
				if (header != _fileHeader)	// for now, force the file header to be the same.  in the future, implement versioning.
					 return false;
				_stretchDefault = (StretchTypes) br.ReadInt32();
				_intervalTime = br.ReadUInt32();
				string scriptFileListString = br.ReadString();
				_randomize = br.ReadBoolean();
				_mouseWakeup = br.ReadBoolean();
				_displayTextDefault = br.ReadBoolean();
				_displayFileInfoDefault = br.ReadBoolean();
				_readKeywords = br.ReadBoolean();

                if (_updateProgress != null)
                    _updateProgress(5);

				// parse the script file string and load each script file
				string[] scriptFileNames = scriptFileListString.Split('|');
                ProgressChangedEventHandler updateImageProgress = new ProgressChangedEventHandler(UpdateImageLevelProgress);
                for (int i = 0; i < scriptFileNames.GetLength(0); i++)
                {
                    ScriptFile sf = new ScriptFile(scriptFileNames[i]);
                    _startProgress = (int)((float) i / (float)scriptFileNames.GetLength(0) * 90) + 5;
                    _endProgress = (int)((float)(i + 1) / (float)scriptFileNames.GetLength(0) * 90) + 5;
                    sf.Load(_readKeywords, updateImageProgress);
                    _scriptFileList.Add(sf);
                }

			}
			catch (Exception ex)
			{

				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to deserialize config file", ex, "ConfigFile", "Deserialize");
				return false;
			}

			return true;

		}

        private void UpdateImageLevelProgress(int currProgress)
        {
            if (_updateProgress != null)
            {
                int progressRange = _endProgress - _startProgress;
                _updateProgress((int)((float)currProgress / 100f * progressRange) + _startProgress);
            }
        }

		#endregion		
		

	}

}
