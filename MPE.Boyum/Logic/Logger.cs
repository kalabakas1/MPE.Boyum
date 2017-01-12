using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MPE.Boyum.Enums;
using NLog;
using ILogger = MPE.Boyum.Interfaces.ILogger;

namespace MPE.Boyum.Logic
{
    internal class Logger : ILogger
    {
        public void Log(LogLevels lvl, Exception exception)
        {
            LogManager.GetCurrentClassLogger().Log(GetLevel(lvl), exception);
        }

        private LogLevel GetLevel(LogLevels lvl)
        {
            switch (lvl)
            {
                case LogLevels.Debug:
                    return LogLevel.Debug;
            }
            return LogLevel.Debug;
        }
    }
}
