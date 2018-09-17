using System;
using log4net;
using log4net.Core;

namespace Attitude.Shared.Extensions
{
    public static class LogHelper
    {
        public static void Error(object className, Exception exception)
        {
            ILog Logger = LogManager.GetLogger(className.GetType());
            Logger.Error(className, exception);
        }
        public static void Info(object className, Exception exception)
        {
            ILog Logger = LogManager.GetLogger(className.GetType());
            Logger.Info(className, exception);
        }
    }
}
