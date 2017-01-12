using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MPE.Boyum.Enums;

namespace MPE.Boyum.Interfaces
{
    internal interface ILogger
    {
        void Log(LogLevels lvl, Exception exception);
    }
}
