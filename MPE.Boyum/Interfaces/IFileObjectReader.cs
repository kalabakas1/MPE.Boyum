using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Functional.Maybe;

namespace MPE.Boyum.Interfaces
{
    public interface IFileObjectReader
    {
        Maybe<T> Read<T>(string filePath);
    }
}
