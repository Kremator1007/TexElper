public abstract class MaybeWithError<ValueT, ErrorT> where ValueT : class
{
    public abstract MaybeWithError<ValueT2, ErrorT> Bind<ValueT2>(
        System.Func<ValueT, MaybeWithError<ValueT2, ErrorT>> func) where ValueT2 : class;
    public abstract void CallIfHasValue(System.Action<ValueT> action);
    public abstract ValueT? Extract();
}

public class ValueWrapper<ValueT, ErrorT> : MaybeWithError<ValueT, ErrorT> where ValueT : class
{
    public ValueWrapper(ValueT value) => Value = value;

    public override MaybeWithError<ValueT2, ErrorT> Bind<ValueT2>(
        System.Func<ValueT,
        MaybeWithError<ValueT2, ErrorT>> func)
    {
        return func(Value);
    }

    public ValueT Value { get; }

    public override void CallIfHasValue(System.Action<ValueT> action) =>
        action(Value);

    public override ValueT? Extract() => Value;
}

public class ErrorWrapper<ValueT, ErrorT> : MaybeWithError<ValueT, ErrorT> where ValueT : class
{
    public ErrorWrapper(ErrorT error) => Error = error;

    public override MaybeWithError<ValueT2, ErrorT> Bind<ValueT2>(
        System.Func<ValueT,
        MaybeWithError<ValueT2, ErrorT>> func)
    {
        return new ErrorWrapper<ValueT2, ErrorT>(Error);
    }

    public ErrorT Error { get; }

    public override void CallIfHasValue(System.Action<ValueT> action) { }

    public override ValueT? Extract() => null;
}

