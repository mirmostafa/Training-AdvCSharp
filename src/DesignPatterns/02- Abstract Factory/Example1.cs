namespace DesignPatterns._02__Abstract_Factory;

public interface ISandwich { }

public interface IDessert { }

public interface IChild { }

public interface IAdult { }

public interface IKitchen
{
    void CreateMenuForAdult<TSandwich, TDessert>(TSandwich sandwich, TDessert dessert)
        where TSandwich : ISandwich, IAdult
        where TDessert : IDessert, IAdult;
    void CreateMenuForChild<TSandwich, TDessert>(TSandwich sandwich, TDessert dessert)
        where TSandwich : ISandwich, IChild
        where TDessert : IDessert, IChild;

    (ISandwich, IDessert) GetFoodForAdult();
    (ISandwich, IDessert) GetFoodForChild();
}

public interface IRecipeFactory
{
    (ISandwich, IDessert) CreateRecipe();
}

public class AdultRecipeFactory : IRecipeFactory
{
    private readonly IKitchen _kitchen;

    public AdultRecipeFactory(IKitchen kitchen)
    {
        this._kitchen = kitchen;
    }
    public (ISandwich, IDessert) CreateRecipe()
    {
        return _kitchen.GetFoodForAdult();
    }
}

public class ChildRecipeFactory : IRecipeFactory
{
    private readonly IKitchen _kitchen;

    public ChildRecipeFactory(IKitchen kitchen)
    {
        this._kitchen = kitchen;
    }
    public (ISandwich, IDessert) CreateRecipe()
    {
        return _kitchen.GetFoodForChild();
    }
}
