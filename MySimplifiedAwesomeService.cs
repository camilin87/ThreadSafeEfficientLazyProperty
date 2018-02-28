using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MySimplifiedAwesomeService
  {
    public ExpensiveObject ExpensiveLoad => LazyPropertyHelper<ExpensiveObject>.read(() => new ExpensiveObject());
    
    public void DoWork()
    {
      Console.WriteLine("MySimplifiedAwesomeService: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MySimplifiedAwesomeService: work completed");
    }
  }

  public static class LazyPropertyHelper<T>
  {
    public static T read(Func<T> initializer)
    {
      return initializer();
    }
  }
}