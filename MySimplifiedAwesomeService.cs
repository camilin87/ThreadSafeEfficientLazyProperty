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
      private readonly object _criticalSection = new object();
      private Func<T> _expensiveLoadReader;

      private readonly Func<T> _initializer;
    
      public T Read() => ExpensiveLoad;
      private T ExpensiveLoad => _expensiveLoadReader();

      public LazyPropertyHelperInternal(Func<T> initializer)
      {
        _initializer = initializer;
        _expensiveLoadReader = createAndCacheExpensiveLoad;
      }     

      private class ExpensiveLoadFactory<T>
      {
        private readonly T result;

        public ExpensiveLoadFactory(Func<T> initializer) => result = initializer();

        public T Build() => result;
      }
      
      private T createAndCacheExpensiveLoad()
      {
        lock (_criticalSection)
        {
          if (_expensiveLoadReader == createAndCacheExpensiveLoad)
          {
            _expensiveLoadReader = new ExpensiveLoadFactory<T>(_initializer).Build;
          }
        }
      
        return _expensiveLoadReader();
      }
    }
  }
}