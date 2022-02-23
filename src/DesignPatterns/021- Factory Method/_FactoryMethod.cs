namespace DesignPatterns._021__Factory_Method;

public abstract class Product
{

}

public class ConcreteProductA : Product
{

}

public class ConcreteProductB : Product
{

}

public abstract class Creator
{
    public abstract Product FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

public class Worker
{
    private void Do()
    {

        Display(new ConcreteCreatorA(), new ConcreteCreatorB());
    }

    private void Display(params Creator[] creators)
    {
        foreach (var creator in creators)
        {
            var product = creator.FactoryMethod();
        }
    }
}