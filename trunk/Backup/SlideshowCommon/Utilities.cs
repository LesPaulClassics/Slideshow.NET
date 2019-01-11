using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class Utilities
	{
		private Utilities()
		{

        }

        #region Constants

        private const string _noString = "No";
        private const string _yesString = "Yes";
        private const string _includeStr = "+";
        public const string _includeStrUI = "Include (+) File";
        private const string _excludeStr = "-";
        public const string _excludeStrUI = "Exclude (-) File";
        private const string _clearIncludeStr = "";
        public const string _clearIncludeStrUI = "Clear Flag";
        private const string _noStretchString = "None";
        private const string _scaleFactorString = "Scale Factor";
        private const string _KARString = "Keep A/R";
        private const string _toFitString = "Stretch To Fit";
        private const string _defaultString = "Default";

        public const int MaxOffset = 2000;
        public const float MaxScaleFactor = 10.0f;
        public const float MinScaleFactor = 0.1f;

        public const string DateTimeFormatString = "MM/dd/yy hh:mm:ss";

        #endregion

		public static bool EvaluateFlags(bool defaultFlag, ThreeWayFlags imageFlag)
		{

			switch (imageFlag)
			{
				case ThreeWayFlags.UseDefault:
					return defaultFlag;
				case ThreeWayFlags.False:
					return false;
				case ThreeWayFlags.True:
					return true;
				default:
					return false;
			}

		}

		public static string GetIncludeFlagString(IncludeFlags flagValue)
		{

			switch (flagValue)
			{

				case IncludeFlags.UseDefault:
					return _clearIncludeStr;
				case IncludeFlags.Exclude:
					return _excludeStr;
				case IncludeFlags.Include:
					return _includeStr;
				default:
					return _clearIncludeStr;

			}

		}

		public static string GetIncludeFlagStringUI(IncludeFlags flagValue)
		{

			switch (flagValue)
			{

				case IncludeFlags.UseDefault:
					return _clearIncludeStrUI;
				case IncludeFlags.Exclude:
					return _excludeStrUI;
				case IncludeFlags.Include:
					return _includeStrUI;
				default:
					return _clearIncludeStrUI;

			}

		}

		public static string GetThreeWayFlagString(ThreeWayFlags flagValue)
		{

			switch (flagValue)
			{

				case ThreeWayFlags.UseDefault:
					return _defaultString;
				case ThreeWayFlags.False:
					return _noString;
				case ThreeWayFlags.True:
					return _yesString;
				default:
					return _defaultString;

			}

		}

		public static ThreeWayFlags ParseThreeWayFlag(string threeWayString)
		{

			switch (threeWayString)
			{

				case _noString:
					return ThreeWayFlags.False;
				case _yesString:
					return ThreeWayFlags.True;
				case _defaultString:
					return ThreeWayFlags.UseDefault;
				default:
					return ThreeWayFlags.UseDefault;

			}

		}

		public static IncludeFlags ParseIncludeFlag(string includeFlagString)
		{

			switch (includeFlagString)
			{

				case _includeStr:
				case _includeStrUI:
					return IncludeFlags.Include;
				case _excludeStr:
				case _excludeStrUI:
					return IncludeFlags.Exclude;
				case _clearIncludeStr:
				case _clearIncludeStrUI:
					return IncludeFlags.UseDefault;
				default:
					return IncludeFlags.UseDefault;

			}

		}

		public static ArrayList BuildDistinctKeywords(ref List<ImageItem> imageItemList)
		{

			ArrayList keywordList = new ArrayList(13);

			foreach (ImageItem ii in imageItemList)
			{
				foreach (string keyword in ii.KeywordList)
				{
					if (!keywordList.Contains(keyword))
						keywordList.Add(keyword);
				}
			}

			keywordList.Sort();

			return keywordList;

		}

		public static string GetStretchTypeString(StretchTypes stretch)
		{

			switch (stretch)
			{

				case StretchTypes.NoStretch:
					return _noStretchString;
				case StretchTypes.ScaleFactor:
					return _scaleFactorString;
				case StretchTypes.StretchKeepAspectRatio:
					return _KARString;
				case StretchTypes.StretchToFit:
					return _toFitString;
				case StretchTypes.UseDefault:
					return _defaultString;
				default:
					return _defaultString;

			}

		}

		public static StretchTypes ParseStretchType(string stretchString)
		{

			switch (stretchString)
			{

				case _noStretchString:
					return StretchTypes.NoStretch;
				case _scaleFactorString:
					return StretchTypes.ScaleFactor;
				case _KARString:
					return StretchTypes.StretchKeepAspectRatio;
				case _toFitString:
					return StretchTypes.StretchToFit;
				case _defaultString:
					return StretchTypes.UseDefault;
				default:
					return StretchTypes.UseDefault;

			}

		}

        private delegate void CopyDel(string srcPath, string destPath);

        private static bool TryCopy(string srcPath, string destPath, string verb, CopyDel copyDel)
        {
            if (!System.IO.File.Exists(srcPath))
                return false;
            try
            {
                string destThn = ImageItem.GetThumbnailPathAndFileName(destPath);
                string srcThn = ImageItem.GetThumbnailPathAndFileName(srcPath);
                string destTxt = ImageItem.GetTextFilePathAndFileName(destPath);
                string srcTxt = ImageItem.GetTextFilePathAndFileName(srcPath);
                copyDel(srcPath, destPath);
                if (System.IO.File.Exists(srcThn))
                    copyDel(srcThn, destThn);
                if (System.IO.File.Exists(srcTxt))
                    copyDel(srcTxt, destTxt);
                return true;
            }
            catch (Exception ex)
            {
                AppLog appLog = new AppLog();
                appLog.LogError(String.Format("Failed to {0} file {1}", verb, srcPath), ex, "SlideShowCommon.Utilities", "Try" + verb);
                return false;
            }
        }

        public static bool TryCopy(string srcPath, string destPath)
        {
            return Utilities.TryCopy(srcPath, destPath, "Copy", new CopyDel(System.IO.File.Copy));
        }

        public static bool TryMove(string srcPath, string destPath)
        {
            return Utilities.TryCopy(srcPath, destPath, "Move", new CopyDel(System.IO.File.Move));
        }


        //public static bool TryCopy(string srcPath, string destPath)
        //{
        //    if (!System.IO.File.Exists(srcPath))
        //        return false;
        //    try
        //    {
        //        string destThn = ImageItem.GetThumbnailPathAndFileName(destPath);
        //        string srcThn = ImageItem.GetThumbnailPathAndFileName(srcPath);
        //        string destTxt = ImageItem.GetTextFilePathAndFileName(destPath);
        //        string srcTxt = ImageItem.GetTextFilePathAndFileName(srcPath);
        //        System.IO.File.Copy(srcPath, destPath);
        //        if (System.IO.File.Exists(srcThn))
        //            System.IO.File.Copy(srcThn, destThn);
        //        if (System.IO.File.Exists(srcTxt))
        //            System.IO.File.Copy(srcTxt, destTxt);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _appLog.LogError(String.Format("Failed to copy file {0}", srcPath), ex, "SlideShowSetupForm", "TryCopy");
        //        return false;
        //    }
        //}

        //public static bool TryMove(string srcPath, string destPath)
        //{
        //    if (!System.IO.File.Exists(srcPath))
        //        return false;
        //    try
        //    {
        //        string destThn = ImageItem.GetThumbnailPathAndFileName(destPath);
        //        string srcThn = ImageItem.GetThumbnailPathAndFileName(srcPath);
        //        string destTxt = ImageItem.GetTextFilePathAndFileName(destPath);
        //        string srcTxt = ImageItem.GetTextFilePathAndFileName(srcPath);
        //        System.IO.File.Move(srcPath, destPath);
        //        if (System.IO.File.Exists(srcThn))
        //            System.IO.File.Move(srcThn, destThn);
        //        if (System.IO.File.Exists(srcTxt))
        //            System.IO.File.Move(srcTxt, destTxt);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _appLog.LogError(String.Format("Failed to move file {0}", srcPath), ex, "SlideShowSetupForm", "TryMove");
        //        return false;
        //    }
        //}

        public static bool TryDelete(string srcPath)
        {
            if (!System.IO.File.Exists(srcPath))
                return false;
            try
            {
                string srcThn = ImageItem.GetThumbnailPathAndFileName(srcPath);
                string srcTxt = ImageItem.GetTextFilePathAndFileName(srcPath);
                System.IO.File.Delete(srcPath);
                if (System.IO.File.Exists(srcThn))
                    System.IO.File.Delete(srcThn);
                if (System.IO.File.Exists(srcTxt))
                    System.IO.File.Delete(srcTxt);
                return true;
            }
            catch (Exception ex)
            {
                AppLog appLog = new AppLog();
                appLog.LogError(String.Format("Failed to delete file {0}", srcPath), ex, "SlideShowSetupForm", "TryDelete");
                return false;
            }
        }

	}

}
