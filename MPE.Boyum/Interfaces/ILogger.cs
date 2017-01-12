using System;
using MPE.Boyum.Enums;

namespace MPE.Boyum.Interfaces
{
    internal interface ILogger
    {
        void Log(LogLevels lvl, Exception exception);
    }
}
