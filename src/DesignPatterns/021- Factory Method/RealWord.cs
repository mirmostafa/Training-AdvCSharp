namespace DesignPatterns._021__Factory_Method;

public class Personnel
{
    public Personnel(Contract contract)
    {
        this.Contract = contract;
    }
    public Contract Contract { get; }
}

public abstract class Contract
{
    public abstract int CalcSalary();
}
public sealed class HourlyContract : Contract
{
    public override int CalcSalary()
    {
        return 1000;
    }
}
public sealed class MonthlyContract : Contract
{
    public override int CalcSalary()
    {
        return 2000;
    }
}
