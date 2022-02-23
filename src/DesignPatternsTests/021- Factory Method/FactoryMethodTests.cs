using DesignPatterns._021__Factory_Method;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsTests._021__Factory_Method;
[TestClass]
public class FactoryMethodTests
{
    [TestMethod]
    public void RealWordTest()
    {
        var hourly = new HourlyContract();
        var monthly = new MonthlyContract();

        var p1 = new Personnel(hourly);
        var p2 = new Personnel(monthly);

        Assert.AreEqual(p1.Contract.CalcSalary(), 1000);
        Assert.AreEqual(p2.Contract.CalcSalary(), 2000);
    }
}