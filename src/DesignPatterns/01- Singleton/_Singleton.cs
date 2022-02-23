namespace DesignPatterns._01__Singleton;
public class Singleton1
{
    private static Singleton1 _instance;
    private Singleton1() { }
    public static Singleton1 Instance => _instance ??= new();
}