using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YogaMaster.Shared
{
    public interface IAnalytics
    {
        void TrackEvent(string eventName, Dictionary<string, string> properties = null);
        void TrackError(Exception ex, Dictionary<string, string> properties = null);
        Task IsEnabledAsync();
        Task SetEnabledAsync(bool enabled);
    }
}
