using System;
using System.Collections.Generic;
using System.Text;

namespace YogaMaster.Core.Services
{
    public class Container
    {
        public static Container Instance { get; } = new Container();
        public IServiceProvider ServiceProvider { get; set; }
    }
}
