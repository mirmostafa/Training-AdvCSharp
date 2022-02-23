using System.Runtime.Versioning;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns._01__Singleton.Tests;

[RequiresPreviewFeatures]
[TestClass()]
public class SingletonTests
{
    [TestMethod()]
    public void ClassWithPrivateCtorTest()
    {
        var p1 = ClassWithPrivateCtor.Instance;
        Assert.IsNotNull(p1);
    }

    [TestMethod()]
    public void ClassWithNewMethodTest()
    {
        var p1 = ClassWithNewMethod.Instance;
        Assert.IsNotNull(p1);
    }
}

[RequiresPreviewFeatures]
internal class ClassWithPrivateCtor : Singleton<ClassWithPrivateCtor>
{
    private ClassWithPrivateCtor()
    {

    }
}
[RequiresPreviewFeatures]
internal class ClassWithNewMethod : Singleton<ClassWithNewMethod>
{
    private ClassWithNewMethod(object? o)
    {

    }
    private static ClassWithNewMethod New()
    {
        return new(null);
    }
}