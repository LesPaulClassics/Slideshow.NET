using System;
using System.Drawing;

namespace TSOP.SlideShow
{
	/// <summary>
	/// Summary description for Interfaces.
	/// </summary>
    public interface ISlideShowForm
    {

        ImageItem GetCurrentImageItem();

        void NextImage();

        void PreviousImage();

        void ClosePreview();

        void UpdateOffset(int X, int Y);

        void UpdateScaleFactor(bool increase);

        System.Windows.Forms.ContextMenu CtxtMenu
        {
            get;
        }

    }

    public delegate void ProgressChangedEventHandler(int percent);

}
