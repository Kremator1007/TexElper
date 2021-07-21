public class MaybeWithError<ValueT, ErrorT>
{
    public MaybeWithError<ValueT2, ErrorT> Bind<ValueT2>(
        System.Func<ValueT,
        MaybeWithError<ValueT2, ErrorT>> func)
    {
        if (this is ValueWrapper<ValueT, ErrorT> valueWrapper)
            return func(valueWrapper.Value);
        else if (this is ErrorWrapper<ValueT, ErrorT> errorWrapper)
            return new ErrorWrapper<ValueT2, ErrorT>(errorWrapper.Error);
        else
            throw new System.Exception("Unreachable");
    }
}

public class ValueWrapper<ValueT, ErrorT> : MaybeWithError<ValueT, ErrorT>
{
    public ValueWrapper(ValueT value) => Value = value;
    public ValueT Value { get; }
}

public class ErrorWrapper<ValueT, ErrorT> : MaybeWithError<ValueT, ErrorT>
{
    public ErrorWrapper(ErrorT error) => Error = error;
    public ErrorT Error { get; }
}