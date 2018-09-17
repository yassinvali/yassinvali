using System;
using log4net;

namespace Attitude.Shared.Extensions
{
    public static class LogHelper
    {
        public static void Error(object className, Exception exception)
        {
            ILog Logger = LogManager.GetLogger(Environment.MachineName);
            Logger.Error(className, exception);
        }
        public static void Info(object className, Exception exception)
        {
            ILog Logger = LogManager.GetLogger(Environment.MachineName);
            Logger.Info(className, exception);
        }
    }
}
