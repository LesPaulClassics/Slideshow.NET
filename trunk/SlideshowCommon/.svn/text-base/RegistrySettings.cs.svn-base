using Microsoft.Win32;

using System;
using System.Collections;
using System.Drawing;

using TSOP;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for RegistrySettings.
	/// </summary>
	public class RegistrySettings
	{
		private const string CONFIG_FILE = "CONFIG_FILE";
		private const string COPY_TO_DIR = "COPYTODIR";
		private const string OPEN_DIR = "OPENDIR";
		private const string WINDOW_POSITION_X = "X-POS";
		private const string WINDOW_POSITION_Y = "Y-POS";
		private const string WINDOW_SIZE_HEIGHT = "HEIGHT";
		private const string WINDOW_SIZE_WIDTH = "WIDTH";
		private const string MRU_LIST_1 = "MRU1";
		private const string MRU_LIST_2 = "MRU2";
		private const string MRU_LIST_3 = "MRU3";
		private const string MRU_LIST_4 = "MRU4";

		#region Members

		private ArrayList _mruList;

		private RegistryKey _regKey;

		private AppLog _appLog;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		public RegistrySettings()
		{
			RegistryKey regSoft = Registry.Users.OpenSubKey(".DEFAULT").OpenSubKey("Software", true);
			RegistryKey regTSOP;

			regTSOP = regSoft.CreateSubKey("TSOP");

			_regKey = regTSOP.CreateSubKey("SlideShow.Net");

			_appLog = new AppLog();
		
		}	

		#endregion

		#region Destructors

		#endregion

		#region Methods

		public bool AddMRUFile(string fileName)
		{
			try
			{

				// get an updated list of what's currently in there
				GetMRUList();

				string[] nameArray = {MRU_LIST_1, MRU_LIST_2, MRU_LIST_3, MRU_LIST_4};

				string[] newArray;
				// if its already in the list, reorder things
				if (_mruList.Contains(fileName) && _mruList.Count > 1)
				{
					newArray = new string[_mruList.Count + 1];
					newArray[0] = fileName;
					int i;
					for (i = 0; i < _mruList.Count - 1; i++)
					{
						if ((string)_mruList[i] == fileName)
							break;
						newArray[i+1] = (string) _mruList[i];
					}
					// after breaking, copy the rest of the array
					for (int j = i + 1; j < _mruList.Count; j++)
					{
						newArray[j] = (string) _mruList[j];
					}
				}
				else
				{
					// otherwise index everything down a notch
					newArray = new string[_mruList.Count + 1];
					newArray[0] = fileName;
					_mruList.CopyTo(newArray, 1);
				}

				// now set the registry keys for the first 4
				for (int index = 0; (index < newArray.GetLength(0) && index < nameArray.GetLength(0)); index++)
				{
                    if (newArray[index] != null)
					    _regKey.SetValue(nameArray[index], newArray[index]);
				}
			
				return true;
			
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to add mru file", ex, "RegistrySettings", "AddMRUFile");
				return false;
			}

		}

		public ConfigFile GetConfigSettings()
		{
            ConfigFile cf = new ConfigFile();
            if (PopulateConfigFile(cf))
                return cf;
            else
                return null;
		}

        public bool PopulateConfigFile(ConfigFile cf)
        {
            System.IO.MemoryStream ms = null;
            System.IO.BinaryReader br = null;
            try
            {

                byte[] cfBytes = (byte[])_regKey.GetValue(CONFIG_FILE);
                if (cfBytes == null)
                    return false;
                ms = new System.IO.MemoryStream(cfBytes);
                br = new System.IO.BinaryReader(ms);
                cf.Deserialize(br, null);

                return true;
            }
            catch (Exception ex)
            {
                _appLog.LogError("failed to get config file from registry", ex, "RegistrySettings", "GetConfigSettings");
                return false;
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (ms != null)
                ms.Close();
            }
        }

		public string GetCopyToDir()
		{
			return (string) _regKey.GetValue(COPY_TO_DIR, "");
		}

		public string GetOpenDir()
		{
			return (string) _regKey.GetValue(OPEN_DIR, "");
		}

		public ArrayList GetMRUList()
		{
			_mruList = new ArrayList(4);

			string[] nameArray = {MRU_LIST_1, MRU_LIST_2, MRU_LIST_3, MRU_LIST_4};

			foreach (string nameStr in nameArray)
			{
				string mruStr = (string) _regKey.GetValue(nameStr, "");
				if (mruStr != "") 
					_mruList.Add(mruStr);
			}

			return _mruList;
		}

		public Size GetWindowSize()
		{
			int h = (int) _regKey.GetValue(WINDOW_SIZE_HEIGHT, 600);
			int w = (int) _regKey.GetValue(WINDOW_SIZE_WIDTH, 800);
			return new Size(w, h);
		}

		public Point GetWindowPosition()
		{
			int x = (int) _regKey.GetValue(WINDOW_POSITION_X, 0);
			int y = (int) _regKey.GetValue(WINDOW_POSITION_Y, 0);
			return new Point(x, y);
		}

		public bool SetConfigSettings(ConfigFile cf)
		{

			try
			{
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ms);
				cf.Serialize(bw);
				_regKey.SetValue(CONFIG_FILE, ms.ToArray());
				return true;
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to set config file to registry", ex, "RegistrySettings", "SetConfigSettings");
				return false;
			}

		}

		public bool SetCopyToDir(string dirPath)
		{
			try
			{
				_regKey.SetValue(COPY_TO_DIR, dirPath);
				return true;
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to set copy to directory to registry", ex, "RegistrySettings", "SetCopyToDir");
				return false;
			}
		}

		public bool SetOpenDir(string dirPath)
		{
			try
			{
				_regKey.SetValue(OPEN_DIR, dirPath);
				return true;
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to set open directory to registry", ex, "RegistrySettings", "SetOpenDir");
				return false;
			}
		}

		public bool SetWindowSize(Size winSize)
		{
			try
			{
				_regKey.SetValue(WINDOW_SIZE_HEIGHT, winSize.Height);
				_regKey.SetValue(WINDOW_SIZE_WIDTH, winSize.Width);
				return true;
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to set window size to registry", ex, "RegistrySettings", "SetWindowSize");
				return false;
			}
		}

		public bool SetWindowPosition(Point winPos)
		{
			try
			{
				_regKey.SetValue(WINDOW_POSITION_X, winPos.X);
				_regKey.SetValue(WINDOW_POSITION_Y, winPos.Y);
				return true;
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to set window position to registry", ex, "RegistrySettings", "SetWindowPosition");
				return false;
			}
		}

		#endregion

	}
}
