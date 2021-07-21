using System;
using System.Collections.Generic;
using System.Text;

namespace YogaMaster.Core
{
    public class Constants
    {

        public static class Analytics
        {
            public static class Events
            {
                public const string PageOpened = "Page Opened";
            }

            public static class Properties
            {
                public const string PageName = "Page Name";
                public const string FileName = "Edition File";
                public const string EditionId = "Edition Id";
                public const string ShowSaved = "Show Saved";
            }

        }

        public static class Navigation
        {
            public static class Paths
            {
                public const string TimerExecutes = "timeExecutes";
            }
        }
        public static class Preferences
        {
            public const string Analytics = "Analytics";
            public const string Theme = "Theme";
        }
    }
}
