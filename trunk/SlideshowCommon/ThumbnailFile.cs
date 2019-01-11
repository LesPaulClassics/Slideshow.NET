using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ThumbnailFile.
	/// </summary>
	public class ThumbnailFile
	{
	
		#region Members

		private string _fileName;

		private bool _stretchFlag;

		private bool _karFlag;

		private bool _textFlag;

		private bool _noStretchFlag;

		private bool _noKARFlag;

		private bool _noTextFlag;

		private string _keywordString;

		private short _offsetX;

		private short _offsetY;

		private float _scaleFactor;

		private byte[] _type;

		private byte[] _blank;

		private TSOP.AppLog _appLog;

		#endregion

		#region Properties

		public string FileName
		{
			get
			{
				return _fileName;
			}
			set
			{
				_fileName = value;
			}
		}

		public bool StretchFlag
		{
			get
			{
				return _stretchFlag;
			}
			set
			{
				_stretchFlag = value;
			}
		}
		public bool KARFlag
		{
			get
			{
				return _karFlag;
			}
			set
			{
				_karFlag = value;
			}
		}
		public bool TextFlag
		{
			get
			{
				return _textFlag;
			}
			set
			{
				_textFlag = value;
			}
		}
		public bool NoStretchFlag
		{
			get
			{
				return _noStretchFlag;
			}
			set
			{
				_noStretchFlag = value;
			}
		}
		public bool NoKARFlag
		{
			get
			{
				return _noKARFlag;
			}
			set
			{
				_noKARFlag = value;
			}
		}
		public bool NoTextFlag
		{
			get
			{
				return _noTextFlag;
			}
			set
			{
				_noTextFlag = value;
			}
		}

		public string KeywordString
		{
			get
			{
				return _keywordString;
			}
			set
			{
				if (value.Length > 127) 
					value = value.Substring(0, 127);
				_keywordString = value;
			}
		}

		// to preserve legacy data, create this mapping between the flags in the thumbnail file and the object enumeration
		public ThreeWayFlags TextDisplayEnum
		{
			get
			{
				int bitmask = Convert.ToInt16(_noTextFlag) * 1 + Convert.ToInt16(_textFlag) * 2;

				switch (bitmask)
				{
					case 1:
						return ThreeWayFlags.False;
					case 2:
						return ThreeWayFlags.True;
					default:
					return ThreeWayFlags.UseDefault;
					}
			}
			set
			{
				switch (value)
				{
					case ThreeWayFlags.False:
						_noTextFlag = true;
						_textFlag = false;
						break;
					case ThreeWayFlags.True:
						_noTextFlag = false;
						_textFlag = true;
						break;
					case ThreeWayFlags.UseDefault:
					default:
						_noTextFlag = false;
						_textFlag = false;
						break;
				}
			}
		}

		// to preserve legacy data, create this mapping between the flags in the thumbnail file and the object enumeration
		public StretchTypes StretchType
		{
			get
			{
				int bitmask = Convert.ToInt16(_noStretchFlag) * 1 
								+ Convert.ToInt16(_noKARFlag) * 2 
								+ Convert.ToInt16(_stretchFlag) * 4 
								+ Convert.ToInt16(_karFlag) * 8;

				switch (bitmask)
				{

					case 1:
						return StretchTypes.NoStretch;
					case 15:
						return StretchTypes.ScaleFactor;
					case 12:
						return StretchTypes.StretchKeepAspectRatio;
					case 6:
						return StretchTypes.StretchToFit;
					default:
						return StretchTypes.UseDefault;

				}

			}
			set
			{

				/*					NoStretchFlag	NoKARFlag	StretchFlag	KARFlag
				 * NoStretch		1				0			0			0
				 * ScaleFactor		1				1			1			1
				 * KAR				0				0			1			1
				 * ToFit			0				1			1			0
				 * UseDefault		0				0			0			0
				 */
			
				switch (value)
				{
					case StretchTypes.NoStretch:
						_noStretchFlag = true;
						_noKARFlag = false;
						_stretchFlag = false;
						_karFlag = false;
						break;
					case StretchTypes.ScaleFactor:
						_noStretchFlag = true;
						_noKARFlag = true;
						_stretchFlag = true;
						_karFlag = true;
						break;
					case StretchTypes.StretchKeepAspectRatio:
						_noStretchFlag = false;
						_noKARFlag = false;
						_stretchFlag = true;
						_karFlag = true;
						break;
					case StretchTypes.StretchToFit:
						_noStretchFlag = false;
						_noKARFlag = true;
						_stretchFlag = true;
						_karFlag = false;
						break;
					case StretchTypes.UseDefault:
					default:
						_noStretchFlag = false;
						_noKARFlag = false;
						_stretchFlag = false;
						_karFlag = false;
						break;
				}
			}
		}

		public System.Drawing.Point Offset 
		{
			get
			{
				return new System.Drawing.Point(_offsetX, _offsetY);
			}
			set
			{
               if (value.X < (0 - Utilities.MaxOffset))
                    _offsetX = (short) (0 - Utilities.MaxOffset);
                else if (value.X > Utilities.MaxOffset)
                    _offsetX = (short)Utilities.MaxOffset;
                else
                    _offsetX = (short)value.X;

                if (value.Y < (0 - Utilities.MaxOffset))
                    _offsetY = (short) (0 - Utilities.MaxOffset);
                else if (value.Y > Utilities.MaxOffset)
                    _offsetY = Utilities.MaxOffset;
                else
                    _offsetY = (short) value.Y;

			}
		}

		public float ScaleFactor
		{
			get
			{
				return _scaleFactor;
			}
			set
			{
                if (value < Utilities.MinScaleFactor)
                    _scaleFactor = Utilities.MinScaleFactor;
                else if (value > Utilities.MaxScaleFactor)
                    _scaleFactor = Utilities.MaxScaleFactor;
                else
                    _scaleFactor = value;
            }
		}

		#endregion

		#region Constructors

		public ThumbnailFile(string fileName)
		{
			_fileName = fileName;

			_type = new Byte[4] {84, 72, 78, 76};

			_blank = new Byte[131];
			_blank[0] = 1;
			_blank[1] = 1;

			_appLog = new TSOP.AppLog();
		}

		#endregion

		#region Destructors

		#endregion

		#region Methods

		public bool Load()
		{

			StreamReader sr = null;

            if (!File.Exists(_fileName))
                return false;

			try
			{
  				sr = new StreamReader(_fileName);

				using(sr)
				{
					BinaryReader br = new BinaryReader(sr.BaseStream);
	
					// read the file
					_type = br.ReadBytes(4);
					_blank = br.ReadBytes(131);
					byte[] keywordBytes = br.ReadBytes(127);
					byte flags = br.ReadByte();
					short offX = br.ReadInt16();
                    if (Math.Abs(offX) < Utilities.MaxOffset)
                        _offsetX = offX;
                    else
                        _offsetX = 0;
					short offY = br.ReadInt16();
                    if (Math.Abs(offY) < Utilities.MaxOffset)
                        _offsetY = offY;
                    else
                        _offsetY = 0;
                    float sf = br.ReadSingle();			// note: this may be read as 0.0
                    if (sf > 0.0f && sf <= Utilities.MaxScaleFactor)
                        _scaleFactor = sf;
                    else
                        _scaleFactor = 1.0f;
                    //_theRest = br.ReadBytes((int)(br.BaseStream.Length - (long) br.BaseStream.Position));
					
					// convert the keyword string
					ASCIIEncoding ascii = new ASCIIEncoding();
					_keywordString = ascii.GetString(keywordBytes);
					_keywordString = _keywordString.TrimEnd(new char[] {'\0'});

					// set the flags
					if ((flags & (int) FlagConstants.Stretch) != 0)
						_stretchFlag = true;
					if ((flags & (int) FlagConstants.KAR) != 0)
						_karFlag = true;
					if ((flags & (int) FlagConstants.Text) != 0)
						_textFlag = true;
					if ((flags & (int) FlagConstants.NoStretch) != 0)
						_noStretchFlag = true;
					if ((flags & (int) FlagConstants.NoKAR) != 0)
						_noKARFlag = true;
					if ((flags & (int) FlagConstants.NoText) != 0)
						_noTextFlag = true;
				}


			}

			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to load thumbnail file", ex, "ThumbnailFile", "Load");
				return false;
			}
			finally
			{
				if (sr != null)
					sr.Close();
			}

			return true;
		}

		public bool Save(string keywordString, StretchTypes stretchType, ThreeWayFlags textFlag, System.Drawing.Point offset, float scaleFactor)
		{
			_keywordString = keywordString;

			StretchType = stretchType;

			TextDisplayEnum = textFlag;

			Offset = offset;

			ScaleFactor = scaleFactor;

			return Save();
		}

		public bool Save()
		{
			FileStream fs = null;

			try
			{
                // todo: check if file exists first so an exception doesn't get thrown
				// open the file
				fs = new FileStream(_fileName, FileMode.Open);
				BinaryWriter bw = new BinaryWriter(fs);

				// write the generic stuff
				fs.Write(_type, 0, _type.Length);
				fs.Write(_blank, 0, _blank.Length);

				//write the keyword string
				_keywordString = _keywordString.PadRight(127,'\0');
				ASCIIEncoding ascii = new ASCIIEncoding();
				fs.Write(ascii.GetBytes(_keywordString), 0, 127);

				// write the flags byte
				byte flags = 0;
				if (_stretchFlag)
					flags ^= (byte) FlagConstants.Stretch;
				if (_karFlag)
					flags ^= (byte) FlagConstants.KAR;
				if (_textFlag)
					flags ^= (byte) FlagConstants.Text;
				if (_noStretchFlag)
					flags ^= (byte) FlagConstants.NoStretch;
				if (_noKARFlag)
					flags ^= (byte) FlagConstants.NoKAR;
				if (_noTextFlag)
					flags ^= (byte) FlagConstants.NoText;
				fs.WriteByte(flags);
				fs.Write(BitConverter.GetBytes(_offsetX), 0, 2);
				fs.Write(BitConverter.GetBytes(_offsetY), 0, 2);
				fs.Write(BitConverter.GetBytes(_scaleFactor), 0, 4);
			}

			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to save thumbnail file", ex, "ThumbnailFile", "Save");
				return false;
			}
			finally
			{
				if (fs != null)
					fs.Close();
			}

			return true;
		}

		#endregion

		private enum FlagConstants
		{
			Stretch = 1,
			KAR = 2,
			Text = 8,
			NoStretch = 16,
			NoKAR = 32,
			NoText = 64
		}

	}
}
