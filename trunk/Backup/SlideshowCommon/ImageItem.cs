using System;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for ImageItem.
	/// </summary>
	[Serializable]
	public class ImageItem : ISerializable
	{
		#region Members

		private Image _imageObj; 

		private IncludeFlags _includeFlag;

		private string _fileName;

		private string _filePath;

		private StretchTypes _stretchType;

		private ThreeWayFlags _textDisplayFlag;

		private bool _recursiveDirFlag;

		private Point _offset;

		private float _scaleFactor;

		private ArrayList _keywordList;
		
		private float _previewScaleFactor;

		private ThumbnailFile tf;

		private int _index;

		private bool _changesMade;

		private TSOP.AppLog _appLog;

		#endregion

		#region Properties

		public string CreateDateStr
		{
			get
			{
				try
				{
                    DateTime createDT, modDT;
                    if (File.Exists(PathAndFileName))
                    {
                        createDT = File.GetCreationTime(PathAndFileName);
                        modDT = File.GetLastWriteTime(PathAndFileName);
                        if (DateTime.Compare(createDT, modDT) < 0)
                            return createDT.ToString(Utilities.DateTimeFormatString);
                        else
                            return modDT.ToString(Utilities.DateTimeFormatString);
                    }
                    else
                        return "";
				}
				catch
				{
					return "";
				}
			}
		}

		public string ModifyDateStr
		{
			get
			{
				try
				{
                    DateTime imageDT = new DateTime();
                    DateTime thumbDT = new DateTime();
                    if (File.Exists(PathAndFileName))
					    imageDT = File.GetLastWriteTime(PathAndFileName);
                    if (File.Exists(tf.FileName))
					    thumbDT = File.GetLastWriteTime(tf.FileName);
					if (DateTime.Compare(imageDT, thumbDT) > 0)
                        return imageDT.ToString(Utilities.DateTimeFormatString);
					else
                        return thumbDT.ToString(Utilities.DateTimeFormatString);
				}
				catch
				{
					return "";
				}
			}
		}

		public IncludeFlags IncludeFlag
		{
			get
			{
				return _includeFlag;
			}
			set
			{
				_includeFlag = value;
			}
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

		public string PathAndFileName
		{
			get
			{
				return _filePath + _fileName;
			}
		}

		public StretchTypes StretchType
		{
			get
			{
				return _stretchType;
			}
			set
			{
				_stretchType = value;
			}
		}

		public ThreeWayFlags TextDisplayFlag
		{
			get
			{
				return _textDisplayFlag;
			}
			set
			{
				_textDisplayFlag = value;
			}
		}

		public bool RecursiveDirFlag
		{
			get
			{
				return _recursiveDirFlag;
			}
			set
			{
				_recursiveDirFlag = value;
			}
		}

		public Point Offset
		{
			get
			{
				return _offset;
			}
			set
			{
                if (value.X < (0 - Utilities.MaxOffset))
                    _offset.X = 0 - Utilities.MaxOffset;
                else if (value.X > Utilities.MaxOffset)
                    _offset.X = Utilities.MaxOffset;
                else
                    _offset.X = value.X;

                if (value.Y < (0 - Utilities.MaxOffset))
                    _offset.Y = 0 - Utilities.MaxOffset;
                else if (value.Y > Utilities.MaxOffset)
                    _offset.Y = Utilities.MaxOffset;
                else
                    _offset.Y = value.Y;

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

		public ArrayList KeywordList
		{
			get
			{
				return _keywordList;
			}
			set
			{
				_keywordList = value;
			}
		}

		public string KeywordString
		{
			get
			{
				string kwString = "";
				foreach (string kw in KeywordList)
				{
					kwString += kw;
					kwString += ",";
				}
				if (kwString != "")
					return kwString.Remove(kwString.Length - 1, 1);
				else
					return kwString;
			}
			set
			{
                // check if value is null so exception isn't thrown
                if (value != null)
                {
                    //_keywordList = new ArrayList(value.Split(",".ToCharArray()));
                    //for (int i = 0; i < _keywordList.Count; i++)
                    //{
                    //    _keywordList[i] = ((string) _keywordList[i]).Trim();
                    //}
                    string[] keywordArray = value.Split(",".ToCharArray());
                    // don't add empty strings as keywords
                    foreach (string keyword in keywordArray)
                    {
                        string keywordTrim = keyword.Trim();
                        if (keywordTrim != "" && !_keywordList.Contains(keywordTrim))
                            _keywordList.Add(keywordTrim);
                    }
                }
			}
		}

		public int Index
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;
			}
		}

		public bool ChangesMade
		{
			get
			{
				return _changesMade;
			}
			set
			{
				_changesMade = value;
			}
		}

        protected Image ImageObj
        {
            get
            {
                if (_imageObj == null)
                    try
                    {
                        if (File.Exists(PathAndFileName))
                            _imageObj = Image.FromFile(PathAndFileName);
                        else 
                            _imageObj = CreateDefaultBitmap();
                    }
                    catch (Exception ex)
                    {
                        _appLog.LogWarning("Could not load file " + PathAndFileName, ex, "ImageItem", "get_ImageObj()");
                        _imageObj = CreateDefaultBitmap();
                    }
                 return _imageObj;
            }
        }

		#endregion

		#region Constructors

		public ImageItem()
		{
			Init();
		}

		protected ImageItem(SerializationInfo info, StreamingContext context)
		{
			_includeFlag = (IncludeFlags) info.GetInt32("IncludeFlag");
			_fileName = info.GetString("FileName");
			_filePath = info.GetString("FilePath");
			_stretchType = (StretchTypes) info.GetInt32("StretchType");
			_textDisplayFlag = (ThreeWayFlags) info.GetInt32("TextDisplayFlag");
			_recursiveDirFlag = info.GetBoolean("RecursiveDirFlag");
			_offset = (Point) info.GetValue("Offset", typeof(Point));
			_scaleFactor = (float) info.GetDouble("ScaleFactor");
			_keywordList = (ArrayList) info.GetValue("KeywordList", typeof(ArrayList));
// ??		_previewScaleFactor = (float) info.GetDouble("PreviewScaleFactor");

			SetPathAndFilename(_filePath + _fileName);
			_appLog = new TSOP.AppLog();
			try
			{
				tf = new ThumbnailFile(this.GetThumbnailPathAndFileName());
				//_imageObj = Image.FromFile(PathAndFileName);
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to deserialize image item", ex, "ImageItem", "Constructor");
			}
		}

		public ImageItem(String fileName)
		{
			Init();
			SetPathAndFilename(fileName);
			try
			{
				tf = new ThumbnailFile(this.GetThumbnailPathAndFileName());
				//_imageObj = Image.FromFile(fileName);
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to get thumbnail file or image file", ex, "ImageItem", "Constructor");
			}

		}

		private void Init()
		{
		
			this._keywordList = new ArrayList();
			this._includeFlag = IncludeFlags.UseDefault;
			this._offset = new Point(0, 0);
			this._recursiveDirFlag = false;
			this._scaleFactor = 1.0f;
			this._stretchType = StretchTypes.UseDefault;
			this._textDisplayFlag = ThreeWayFlags.UseDefault;
			this._previewScaleFactor = 1.0f;
            this._imageObj = null;       
			this._index = -1;
			this._appLog = new TSOP.AppLog();
		}

		#endregion

		#region Destructors

        public void UnloadImageObject()
        {
            _imageObj = null;
            System.GC.Collect();
        }

		#endregion

		#region Public Methods

		public void Draw(Graphics g)
		{
			Rectangle drawRect = new Rectangle();
			if (ImageObj != null)
				//g.DrawImage(_imageObj, new Point(0,0));
				drawRect = GetDrawRect((int) g.VisibleClipBounds.Width, (int) g.VisibleClipBounds.Height);
				g.DrawImage(ImageObj, drawRect);
//				_appLog.LogInfo(String.Format("001 {0} - Image W:{1} H:{2}\nBounds W:{3} H:{4}\nDrawRect W:{5} H:{6}", this.FileName, _imageObj.Width, _imageObj.Height, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height, drawRect.Width, drawRect.Height), null, "", "");
		}

		public void Draw(Graphics g, RectangleF screenRect)
		{
			// calculate an additional scale factor if the graphics obj is not the screen
			if (g.VisibleClipBounds != screenRect)
			{
				float widthFactor, heightFactor;
				
				widthFactor = (g.VisibleClipBounds.Width / screenRect.Width);
				heightFactor = (g.VisibleClipBounds.Height / screenRect.Height);
				_previewScaleFactor = Math.Min(widthFactor, heightFactor);
			}
			Rectangle drawRect = GetDrawRect((int) g.VisibleClipBounds.Width, (int) g.VisibleClipBounds.Height);
			g.DrawImage(ImageObj, drawRect);
//			_appLog.LogInfo(String.Format("002 {0} - Image W:{1} H:{2}\nBounds W:{3} H:{4}\nDrawRect W:{5} H:{6}\nScale Factor: {7}", this.FileName, _imageObj.Width, _imageObj.Height, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height, drawRect.Width, drawRect.Height, _previewScaleFactor), null, "", "");
			_previewScaleFactor = 1.0f;
		}

		public void ReadThumbnailDataFromFile()
		{
			if (tf.Load())
			{
				this.KeywordString = tf.KeywordString;
				this.StretchType = tf.StretchType;
				this.TextDisplayFlag = tf.TextDisplayEnum;
				this.Offset = tf.Offset;
				this.ScaleFactor = tf.ScaleFactor;
			}

		}

		public bool WriteThumbnailData()
		{
			return tf.Save(KeywordString, _stretchType, _textDisplayFlag, _offset, _scaleFactor);
		}

		public void AddKeywords(ArrayList keywords)
		{
			foreach (string keyword in keywords)
			{
				if (!KeywordList.Contains(keyword))
					KeywordList.Add(keyword);
			}
			KeywordList.Sort();
		}

		public void RemoveKeywords(ArrayList keywords)
		{
			foreach (string keyword in keywords)
			{
				if (KeywordList.Contains(keyword))
					KeywordList.Remove(keyword);
			}
		}

		public void Promote()
		{
			int rank = GetRank();

			if (rank != 0)
				SetRank(rank - 1);

		}

		private int GetRank()
		{
            WriteDiagnostics();
			int rank = -1;

			if (KeywordList.Contains("1") && KeywordList.Contains("best"))
				rank = 0;
			else if (KeywordList.Contains("1"))
				rank = 1;
			else if (KeywordList.Contains("2"))
				rank = 2;
			else if (KeywordList.Contains("3"))
				rank = 3;
			else
				rank = 2;

			return rank;
		}

		private void SetRank(int rank)
		{

			ArrayList rankWords = new ArrayList(4);
			rankWords.AddRange(new string[] {"best", "1", "2", "3"});

			RemoveKeywords(rankWords);

			switch (rank)
			{
				case 0:
					KeywordList.AddRange(new string[] {"1", "best"});
					break;
				case 1:
					KeywordList.Add("1");
					break;
				case 2:
					KeywordList.Add("2");
					break;
				case 3:
					KeywordList.Add("3");
					break;
			}

			KeywordList.Sort();

		}

		public void Demote()
		{

			int rank = GetRank();

			if (rank != 3)
				SetRank(rank + 1);

		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("IncludeFlag", (int) _includeFlag);
			info.AddValue("FileName", _fileName);
			info.AddValue("FilePath", _filePath);
			info.AddValue("StretchType", (int) _stretchType);
			info.AddValue("TextDisplayFlag", (int) _textDisplayFlag);
			info.AddValue("RecursiveDirFlag", _recursiveDirFlag);
			info.AddValue("OffSet", _offset, typeof(System.Drawing.Point));
			info.AddValue("ScaleFactor", _scaleFactor);
			info.AddValue("KeywordList", _keywordList, typeof(ArrayList));

		}

		public bool Serialize(BinaryWriter bw)
		{
			try
			{
				bw.Write((int) _includeFlag);
				bw.Write(_fileName);
				bw.Write(_filePath);
				bw.Write((int) _stretchType);
				bw.Write((int) _textDisplayFlag);
				bw.Write(_recursiveDirFlag);
				bw.Write(_offset.X);
				bw.Write(_offset.Y);
				bw.Write(_scaleFactor);
				bw.Write(this.KeywordString);
				
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to serialize ImageItem", ex, "ImageItem", "Serialize");
				return false;
			}
			
			return true;
			
		}

		public bool Deserialize(BinaryReader br, bool readKeywords)
		{

			try
			{
                //_appLog.LogInfo("Starting deserialize", null, "ImageItem", "Deserialize()");
				_includeFlag = (IncludeFlags) br.ReadInt32();
				_fileName = br.ReadString();
				_filePath = br.ReadString();
				_stretchType = (StretchTypes) br.ReadInt32();
				_textDisplayFlag = (ThreeWayFlags) br.ReadInt32();
				_recursiveDirFlag =  br.ReadBoolean();
				int x = br.ReadInt32();
				int y = br.ReadInt32();
				_offset = new Point(x, y);
				float sf = br.ReadSingle();
				if (sf != 0.0f)
					_scaleFactor = sf;
				else
					_scaleFactor = 1.0f;
                //_appLog.LogInfo("Reading Keyword String", null, "ImageItem", "Deserialize()");
                KeywordString = br.ReadString();

				SetPathAndFilename(_filePath + _fileName);
                //_appLog.LogInfo("Constructing Thumbnail", null, "ImageItem", "Deserialize()");
                tf = new ThumbnailFile(this.GetThumbnailPathAndFileName());
				if (readKeywords)
				{
                    //_appLog.LogInfo("Loading Keywords", null, "ImageItem", "Deserialize()");
                    tf.Load();
					_stretchType = tf.StretchType;
					_textDisplayFlag = tf.TextDisplayEnum;
                    //_appLog.LogInfo("Getting keyword string", null, "ImageItem", "Deserialize()");
                    _keywordList.Clear();
                    KeywordString = tf.KeywordString;
					_offset = tf.Offset;
					if (tf.ScaleFactor != 0.0f)
						_scaleFactor = tf.ScaleFactor;		
					else
						_scaleFactor = 1.0f;
				}
                //_appLog.LogInfo("Getting Image Object", null, "ImageItem", "Deserialize()");
 
			}
			catch (Exception ex)
			{

				System.Diagnostics.Debug.WriteLine(ex.Message);
				_appLog.LogError("failed to deserialize ImageItem", ex, "ImageItem", "Deserialize");
				return false;
			}

			return true;

		}

		public string GetTextFileString()
		{

			string output = "";

			try
			{
				if (!File.Exists(this.GetTextFilePathAndFileName()))
					return output;

				using(FileStream fs = new FileStream(this.GetTextFilePathAndFileName(), FileMode.Open))
				{
					
					using(StreamReader sr = new StreamReader(fs))
					{

						output += sr.ReadToEnd();

					}

				}			
			
			}
			catch (Exception ex)
			{
				_appLog.LogError("failed to get text file string", ex, "ImageItem", "GetTextFileString");
			}

			return output;

		}

		#endregion

		#region Utility Functions

		private string GetThumbnailPathAndFileName()
		{
            return GetThumbnailPathAndFileName(PathAndFileName);
		}

        public static string GetThumbnailPathAndFileName(string pathAndFileName)
        {
            return SubstituteExtension(pathAndFileName, "THN");
        }

		private string GetTextFilePathAndFileName()
		{
            return GetTextFilePathAndFileName(PathAndFileName);
		}

        public static string GetTextFilePathAndFileName(string pathAndFileName)
        {
            return SubstituteExtension(pathAndFileName, "TXT");
        }

		private string SubstituteExtension(string newExt)
		{

			string imageName = PathAndFileName;
            return SubstituteExtension(imageName, newExt);

		}

        public static string SubstituteExtension(string pathAndFileName, string newExt)
        {
            string thnName = pathAndFileName.Remove(pathAndFileName.LastIndexOf("."), (pathAndFileName.Length - pathAndFileName.LastIndexOf(".")));
            thnName += "." + newExt;

            return thnName;
        }

		private Rectangle GetDrawRect(int graphicsWidth, int graphicsHeight)
		{
			Size outSize = new Size();

			Point offset = new Point(0, 0);

			switch (_stretchType)
			{
				case StretchTypes.StretchToFit:
					outSize.Height = graphicsHeight;
					outSize.Width = graphicsWidth;
					break;
				case StretchTypes.StretchKeepAspectRatio:
					outSize = GetKARSize(graphicsWidth, graphicsHeight);
					break;
				case StretchTypes.ScaleFactor:
					outSize.Height = (int) (ImageObj.Size.Height * _scaleFactor * _previewScaleFactor);
					outSize.Width = (int) (ImageObj.Size.Width * _scaleFactor * _previewScaleFactor);
					break;
				case StretchTypes.NoStretch:
				case StretchTypes.UseDefault:
					outSize.Height = (int) (ImageObj.Size.Height * _previewScaleFactor);
					outSize.Width = (int) (ImageObj.Size.Width * _previewScaleFactor);
					break;
			}

			// determine the offset that would center the image
			offset.X = (graphicsWidth - outSize.Width) / 2;
			offset.Y = (graphicsHeight - outSize.Height) / 2;

			// adjust by the amount of additional offset needed
			offset.Offset((int) (_offset.X * _previewScaleFactor), (int) (_offset.Y * _previewScaleFactor));
            //_appLog.LogInfo(String.Format("Offset.X = {0}, Offset.Y = {1}, outSize.Height = {2}, outSize.Width = {3}", _offset.X, _offset.Y, outSize.Height, outSize.Width), null, "", "");
			return (new Rectangle(offset, outSize));
		}

		private Size GetKARSize(int screenWidth, int screenHeight)
		{
			Size outSize = new Size(screenWidth, screenHeight);

			// calculate the screens aspect ratio
			float sar = ((float) screenHeight) / ((float) screenWidth);

			// calculate the images aspect ratio
			float iar = ((float) ImageObj.Height) / ((float) ImageObj.Width);

			// determine whether the height or width will be the constraint
			if (iar < sar)	// width is constraint
			{
				outSize.Height = (int) (screenWidth * iar);
			}
			else if (iar > sar) // height is constraint
			{
				outSize.Width = (int) (screenHeight / iar);
			}

			return outSize;
		}

		private Bitmap CreateDefaultBitmap()
		{
            Bitmap bm = null;

            try
            {
                bm = new Bitmap(GetType(), "Image Unavailable.bmp");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                bm = new Bitmap(400, 300);
            }

            return bm;

            //Bitmap bm = new Bitmap(256, 256);
            //for (int x = 0; x < 256; x++)
            //{
            //    for (int y = 0; y < 256; y++)
            //    {
            //        bm.SetPixel(x, y, Color.FromArgb(x, y, (x * y) % 256));
            //    }
            //}
            //Graphics g = Graphics.FromImage(bm);
            //SizeF textSize = g.MeasureString("Image", new Font("Arial", 30, FontStyle.Bold));
            //g.DrawString("Image", new Font("Arial", 30, FontStyle.Bold), new SolidBrush(Color.Navy), new Rectangle((int)((255 -  textSize.Width) / 2) + 2, (int)((255 - 2.2 * textSize.Height) / 2) + 2, (int) textSize.Width + 2, (int) textSize.Height));
            //textSize = g.MeasureString("Unavailable", new Font("Arial", 30, FontStyle.Bold));
            //g.DrawString("Unavailable", new Font("Arial", 30, FontStyle.Bold), new SolidBrush(Color.Navy), new Rectangle((int)((255 -  textSize.Width) / 2) + 2, (int)((255 + 0.2 * textSize.Height) / 2) + 2, (int) textSize.Width + 2, (int) textSize.Height));
            //return bm;
		}

		private void SetPathAndFilename(string filename)
		{
			
			string[] parts = filename.Split("\\".ToCharArray(), 30);
			_fileName = parts[parts.GetUpperBound(0)];
			_filePath = filename.Remove(filename.LastIndexOf("\\") + 1, _fileName.Length);
			
		}

		#endregion

        private void WriteDiagnostics()
        {

            System.Diagnostics.StackFrame frame = (new System.Diagnostics.StackTrace()).GetFrame(1);
            System.Reflection.MethodBase method = frame.GetMethod();
            System.Diagnostics.Debug.WriteLine("*** " + method.DeclaringType.Name + " - " + method.Name + " ***");

            System.Text.StringBuilder sBldr = new System.Text.StringBuilder("Selected[0]: ");
            sBldr.Append("_imageIndex = " + "N/A");
            sBldr.Append(": ImageID = " + "N/A");
            sBldr.Append(": LV Index = " + "N/A");
            sBldr.Append(": FileName = " + this.FileName);
            sBldr.Append(": KW = " + this.KeywordString);
            System.Diagnostics.Debug.WriteLine(sBldr.ToString());

        }



	}

}
