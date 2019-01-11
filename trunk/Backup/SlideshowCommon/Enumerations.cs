using System;

namespace TSOP.SlideShow
{

	public enum IncludeFlags 
	{
		UseDefault = 0,
		Include = 1,
		Exclude = 2
	}

	public enum ThreeWayFlags
	{
		UseDefault = 0,
		True = 1,
		False = 2
	}

	public enum StretchTypes
	{
		UseDefault = 0,
		NoStretch = 1,
		StretchToFit = 2,
		StretchKeepAspectRatio = 3,
		ScaleFactor = 4
	}

}
