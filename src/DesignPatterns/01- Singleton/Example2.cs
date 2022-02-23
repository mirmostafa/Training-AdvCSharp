using System.Runtime.Versioning;

namespace DesignPatterns._01__Singleton;

[RequiresPreviewFeatures]
public interface ISingleton3<out TClass>
{
    static abstract TClass New();
}

[RequiresPreviewFeatures]
public abstract class Singleton3<TClass>
    where TClass : ISingleton3<TClass>
{
    private static TClass _instance;

    //! private to protected
    protected Singleton3() { }
    public static TClass Instance => _instance ??= TClass.New();
}

[RequiresPreviewFeatures]
public class Example2 : Singleton3<Example2>, ISingleton3<Example2>
{
    //! Explicit implementation
    static Example2 ISingleton3<Example2>.New() => new();
}