#nullable disable

using DesignPatterns._02__Abstract_Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsTests._02__Abstract_Factory;

[TestClass]
public class AbstractFactoryTests
{
    private static AdultRecipeFactory _adultFactory;
    private static ChildRecipeFactory _childFactory;

    [ClassInitialize]
    public static void ClassInitialize(TestContext _)
    {
        var kitchen = new Kitchen();

        kitchen.CreateMenuForAdult(new Hamburger(), new Caramel());
        kitchen.CreateMenuForChild(new Cheese(), new Biscuits());

        _adultFactory = new AdultRecipeFactory(kitchen);
        _childFactory = new ChildRecipeFactory(kitchen);
    }

    [TestMethod]
    public void AbstractFactoryForAdultTest()
    {
        (var s, var d) = _adultFactory.CreateRecipe();
        Assert.IsInstanceOfType(s, typeof(ISandwich));
        Assert.IsInstanceOfType(s, typeof(IAdult));

        Assert.IsInstanceOfType(d, typeof(IDessert));
        Assert.IsInstanceOfType(d, typeof(IAdult));
    }

    [TestMethod]
    public void AbstractFactoryForChildTest()
    {
        (var s, var d) = _childFactory.CreateRecipe();
        Assert.IsInstanceOfType(s, typeof(ISandwich));
        Assert.IsInstanceOfType(s, typeof(IChild));

        Assert.IsInstanceOfType(d, typeof(IDessert));
        Assert.IsInstanceOfType(d, typeof(IChild));
    }
}

internal class Biscuits : IChild, IDessert { }
internal class Cheese : IChild, ISandwich { }
internal class Caramel : IAdult, IDessert { }
internal class Hamburger : IAdult, ISandwich { }

internal class Kitchen : IKitchen
{
    private (ISandwich, IDessert) _forAdult;
    private (ISandwich, IDessert) _forChild;
    public void CreateMenuForAdult<TSandwich, TDessert>(TSandwich sandwich, TDessert dessert)
        where TSandwich : ISandwich, IAdult
        where TDessert : IDessert, IAdult
    {
        _forAdult = (sandwich, dessert);
    }

    public void CreateMenuForChild<TSandwich, TDessert>(TSandwich sandwich, TDessert dessert)
       where TSandwich : ISandwich, IChild
       where TDessert : IDessert, IChild
    {
        _forChild = (sandwich, dessert);
    }

    public (ISandwich, IDessert) GetFoodForAdult()
    {
        return _forAdult;
    }

    public (ISandwich, IDessert) GetFoodForChild()
    {
        return _forChild;
    }
}