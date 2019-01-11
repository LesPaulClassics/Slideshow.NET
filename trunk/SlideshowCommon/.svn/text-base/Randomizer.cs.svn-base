using System;
using System.Collections;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for Randomizer.
	/// </summary>
	public class Randomizer : IComparer
	{

		public Randomizer()
		{
			rand = new Random();
		}
	
		private Random rand;

		public int Compare(object x, object y)
		{
            if ((x is ImageItem) && (y is ImageItem))
            {
                if (((ImageItem)x).PathAndFileName == ((ImageItem)y).PathAndFileName) return 0;
            }
            else
		    	if (x == y) return 0;

			int result = rand.Next(2);
			if (result == 0) 
				return -1;
			else
				return 1;
		}
	}
}
