using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MySimplifiedAwesomeService
  {
    private readonly Func<ExpensiveObject> expensiveLoadReader =
      new LazyPropertyHelper<ExpensiveObject>(() => new ExpensiveObject()).read;
    public ExpensiveObject ExpensiveLoad => expensiveLoadReader();
    
    public void DoWork()
    {
      Console.WriteLine("MySimplifiedAwesomeService: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MySimplifiedAwesomeService: work completed");
    }
  }

  public class LazyPropertyHelper<T>
  {
    private readonly Func<T> _initializer;

    public LazyPropertyHelper(Func<T> initializer)
    {
      _initializer = initializer;
    }
    
    public T read()
    {
      return _initializer();
    }
  }
}