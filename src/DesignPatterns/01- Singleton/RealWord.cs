using System.Reflection;
using System.Runtime.Versioning;

namespace DesignPatterns._01__Singleton;

/// <summary>
///     Generic Singleton Interface
/// </summary>
/// <typeparam name="TSingleton">The type of the singleton.</typeparam>
[RequiresPreviewFeatures]
public interface ISingleton<TSingleton>
{
    public static abstract TSingleton Instance { get; }
}

/// <summary>
///     A Singleton using an StaticAllocator used just to simplify the inheritance syntax.
/// </summary>
[RequiresPreviewFeatures]
public class Singleton<T> : ISingleton<T>
    where T : class, ISingleton<T>
{
    private static readonly Lazy<T> _instance = new(GenerateInstance());

    protected Singleton()
    {

    }

    /// <summary>
    ///     Gets the instance.
    /// </summary>
    /// <value>
    ///     The instance.
    /// </value>
    public static T Instance => _instance.Value;

    /// <summary>
    /// Generates the singleton instance.
    /// </summary>
    /// <typeparam name="TObject">The type of the singleton.</typeparam>
    /// <param name="createInstance">The create instance.</param>
    /// <param name="initializeInstance">The initialize instance.</param>
    /// <returns></returns>
    /// <exception cref="SingletonException">The class must have a static method: \"{typeof(TSingleton)} New()\" or a private/protected parameter-less constructor.</exception>
    private static T GenerateInstance()
    {
        T result = null;
        var ctor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Array.Empty<Type>());
        if (ctor is not null)
        {
            result = ctor.Invoke(null) as T;
        }
        else
        {
            var methodInfo = typeof(T).GetMethod("New", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (methodInfo is not null)
            {
                var instantiator = Delegate.CreateDelegate(typeof(Func<T>), null, methodInfo) as Func<T>;
                result = instantiator?.Invoke();
            }
        }
        if (result is null)
        {
            throw new InvalidOperationException("Neither a private ctor nor a method named New() was found.");
        }
        return result;
    }
}