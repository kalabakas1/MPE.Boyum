using Functional.Maybe;

namespace MPE.Boyum.Interfaces
{
    public interface IFileObjectReader<T, TK>
    {
        Maybe<TK> Read(string filePath);
    }
}
