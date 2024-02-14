using System;
using System.Collections.Generic;

namespace UINavigationSystem.Core.Modal
{
    [ Serializable ]
    public class Router
    {
        public List< RouterItem > screens = new();
        public string rootPath;
    }

    [ Serializable ]
    public class RouterItem
    {
        public string path;
        public UIViewController viewController;
    }
}