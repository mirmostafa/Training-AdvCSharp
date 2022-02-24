namespace DesignPatterns._05__Mediator;

public class Mediator
{
    public ConcreteColleague1 Colleague1 { get; set; }
    public ConcreteColleague2 Colleague2 { get; set; }

    internal void Send(string message, Colleague colleague)
    {
        if (colleague == Colleague1)
        {
            Colleague2.Notify(message);
        }
        else
        {
            Colleague1.Notify(message);
        }
    }
}

public abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }

    internal virtual void Notify(string message)
    {
        Console.WriteLine("Colleague1 gets message: " + message);
    }
}

public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator)
        : base(mediator)
    {
    }
}

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator)
        : base(mediator)
    {
    }
}

internal class Worker
{
    private void Do()
    {
        var m = new Mediator();
        var c1 = new ConcreteColleague1(m);
        var c2 = new ConcreteColleague2(m);
        m.Colleague1 = c1;
        m.Colleague2 = c2;
        c1.Send("How are you?");
        c2.Send("Fine, thanks");
    }
}