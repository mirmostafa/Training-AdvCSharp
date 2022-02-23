namespace DesignPatterns._02__Abstract_Factory;

internal class Prodduct1
{

}

internal class Product2
{

}

internal class Product1Creator
{
    internal Prodduct1 Create()
    {
        return new();
    }
}

internal class Product2Creator
{
    internal Product2 Create()
    {
        return new();
    }
}
internal class _AbstractFactory
{
    private readonly Product1Creator _creator1;
    private readonly Product2Creator _creator2;

    public _AbstractFactory(Product1Creator creator1, Product2Creator creator2)
    {
        this._creator1 = creator1;
        this._creator2 = creator2;
    }
    public (Prodduct1 Product1, Product2 Product2) Create()
    {
        var p1 = _creator1.Create();
        var p2 = _creator2.Create();
        return (p1, p2);
    }
}

//====
internal class Worker
{
    public void Do()
    {
        var creator1 = new Product1Creator();
        var creator2 = new Product2Creator();
        var factory = new _AbstractFactory(creator1, creator2);
        var result = factory.Create();
    }
}
