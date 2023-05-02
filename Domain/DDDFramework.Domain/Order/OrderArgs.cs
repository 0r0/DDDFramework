using System.Reflection;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public interface ISingleObjectBuilder< T,TProperty> where T : class, new()
{
    void With(Func<T, TProperty> func, TProperty value);
    T Build();
}



public class SingleObjectBuilder<T,TProperty> : ISingleObjectBuilder<T,TProperty> where T : class, new()
{
    public void With(Func<T, TProperty> func, TProperty value)
    {
        // Func<OrderArgs,Guid> m = M;
        // var ty2 = typeof(OrderArgs).GetProperty("Id").SetValue(ty2,Guid.NewGuid());
        // ty2.SetValue();
        // Type ty = typeof(T);
        // FieldInfo[] fieldInfos = ty.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        // fieldInfos.Select()
        var instance = Activator.CreateInstance<T>();
        var a=  func(instance);
        


    }

    private Guid M(OrderArgs arg)
    {
        Guid a = default;
        arg.GetType().
            GetField("Id",BindingFlags.Instance| BindingFlags.Public | BindingFlags.Static |BindingFlags.CreateInstance)
            ?.SetValue(arg,a=Guid.NewGuid());
        return a;

    }

    public T Build()
    {
        throw new NotImplementedException();
    }
}

public class OrderArgs
{
    public OrderArgs()
    {
    }

    public OrderId Id { get; set; }
    private string Title { get; set; }
    private long OrderNumber { get; set; }
    private bool IsActive { get; set; }

    public void With(OrderId id)
    {
        Id = id;
    }

    public void With(string title)
    {
        Title = title;
    }

    public void With(long orderNumber)
    {
        OrderNumber = orderNumber;
    }

    public void With(bool isActive)
    {
        IsActive = isActive;
    }

    public OrderArgs Build()
    {
        return this;
    }

    //todo! make a builder here
    // var order = new OrderArgs.With 
}