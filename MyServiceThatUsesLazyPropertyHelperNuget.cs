using System;
using LazyPropertyHelper;

namespace ThreadSafeEfficientLazyProperty
{
  public class MyServiceThatUsesLazyPropertyHelperNuget
  {
    private readonly Func<ExpensiveObject> _expensiveLoadReader = LazyProperty.Create(() => new ExpensiveObject());
    public ExpensiveObject ExpensiveLoad => _expensiveLoadReader();
    
    public void DoWork()
    {
      Console.WriteLine("MyServiceThatUsesLazyPropertyHelperNuget: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MyServiceThatUsesLazyPropertyHelperNuget: work completed");
    }    
  }
}