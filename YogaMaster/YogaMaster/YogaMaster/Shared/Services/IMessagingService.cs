using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace YogaMaster.Shared
{
    public interface IStatusBarService
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
