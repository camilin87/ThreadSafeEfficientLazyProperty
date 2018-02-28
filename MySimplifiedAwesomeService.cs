using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MySimplifiedAwesomeService
  {
    private readonly Func<ExpensiveObject> _expensiveLoadReader = LazyPropertyHelper.Create(() => new ExpensiveObject());
    public ExpensiveObject ExpensiveLoad => _expensiveLoadReader();
    
    public void DoWork()
    {
      Console.WriteLine("MySimplifiedAwesomeService: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MySimplifiedAwesomeService: work completed");
    }
  }

  public static class LazyPropertyHelper
  {
    public static Func<T> Create<T>(Func<T> initializer) => new LazyPropertyHelperInternal<T>(initializer).Read;

    private class LazyPropertyHelperInternal<T>
    {
      private readonly Func<T> _initializer;
    
      public LazyPropertyHelperInternal(Func<T> initializer) => _initializer = initializer;

      public T Read()
      {
        return _initializer();
      }
    }
  }
}