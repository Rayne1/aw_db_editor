using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aw_db_editor
{
    public static class Logger
    {
        private static ILog current = LogManager.GetLogger("LOGGER");


        public static ILog Current
        {
            get { return current; }
        }

        public static void InitLogger()
        {
            //XmlConfigurator.Configure(ConfigFile = "log4net.config");
        }
    }
}