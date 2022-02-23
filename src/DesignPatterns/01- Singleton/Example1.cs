#nullable disable
namespace DesignPatterns._01__Singleton;

//!? Not fancy, bcuz needs public ctor
public abstract class Singleton2<TClass>
    where TClass : new()
{
    private static TClass _instance;

    //! private to protected
    protected Singleton2() { }
    public static TClass Instance => _instance ??= new();
}

public class Example1 : Singleton2<Example1>
{

}