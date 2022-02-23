namespace DesignPatterns._02__Abstract_Factory;

internal interface ISandwich { }

internal interface IDessert { }

internal interface IChild { }

internal interface IAdult { }

internal interface IKitchen
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

internal interface IRecipeFactory
{
    (ISandwich, IDessert) CreateRecipe();
}

internal class AdultRecipeFactory : IRecipeFactory
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

internal class ChildRecipeFactory : IRecipeFactory
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

internal class Woker
{
    private readonly IRecipeFactory _adult;
    private readonly IRecipeFactory _child;

    public Woker(IRecipeFactory adult, IRecipeFactory child)
    {
        this._adult = adult;
        this._child = child;
    }
    public void Do(bool forAdult)
    {
        (ISandwich sandwich, IDessert dessert) result = forAdult == true ? this._adult.CreateRecipe() : this._child.CreateRecipe();
    }
}