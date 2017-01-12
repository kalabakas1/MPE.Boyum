namespace MPE.Boyum.Interfaces
{
    public interface IConverter<TIn, TOut>
    {
        TOut Build(TIn input);
    }
}
