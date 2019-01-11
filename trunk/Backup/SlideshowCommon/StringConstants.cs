using System;
using System.Collections.Generic;
using System.Text;

namespace TSOP.SlideShow
{
    public class StringConstants
    {
        private StringConstants()
        {
        }

        //public const string SCRIPT_NOT_SELECTED = "SCRIPT_NOT_SELECTED";
        //public const string SCRIPT_EMPTY = "SCRIPT_EMPTY";
        //public const string MESSAGE_BOX_TITLE_ERROR = "MESSAGE_BOX_TITLE_ERROR";
        //public const string MESSAGE_BOX_TITLE_WARNING = "MESSAGE_BOX_TITLE_WARNING";
        //public const string MESSAGE_BOX_TITLE_INFO = "MESSAGE_BOX_TITLE_INFO";
        //public const string DUPLICATE_IMAGES_NOT_ADDED = "DUPLICATE_IMAGES_NOT_ADDED";
        //public const string INVALID_SCALE_FACTOR = "INVALID_SCALE_FACTOR";
        //public const string INVALID_POINT_SYNTAX = "INVALID_POINT_SYNTAX";
        //public const string SCALE_FACTOR_OUT_OF_RANGE = "SCALE_FACTOR_OUT_OF_RANGE";
        //public const string POINT_OUT_OF_RANGE = "POINT_OUT_OF_RANGE";
        //public const string LOAD_SLIDESHOW_FAILED = "LOAD_SLIDESHOW_FAILED";

        public const string REGISTRY_FILENAME = "REGISTRY";

        public static string GetString(StringNames stringName)
        {
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("TSOP.SlideShow.Strings", System.Reflection.Assembly.GetExecutingAssembly());
            return rm.GetString(stringName.ToString());
        }
    }

    public enum StringNames
    {
        SCRIPT_NOT_SELECTED,
        SCRIPT_EMPTY,
        SCRIPT_MULTI_SELECTED,
        SCRIPT_SAVE_FAILED,
        SCRIPT_SAVE_SUCCEEDED,
        SCRIPT_LOAD_FAILED,
        SCRIPT_LOAD_SUCCEEDED,
        SCRIPT_DELETE_FAILED,
        SCRIPT_DELETE_SUCCEEDED,
        MESSAGE_BOX_TITLE_ERROR,
        MESSAGE_BOX_TITLE_WARNING,
        MESSAGE_BOX_TITLE_INFO,
        MESSAGE_BOX_TITLE_CONFIRM,
        DUPLICATE_IMAGES_NOT_ADDED,
        INVALID_SCALE_FACTOR,
        INVALID_POINT_SYNTAX,
        SCALE_FACTOR_OUT_OF_RANGE,
        POINT_OUT_OF_RANGE,
        LOAD_SLIDESHOW_FAILED,
        IMAGES_NONE_SELECTED
    }
}
