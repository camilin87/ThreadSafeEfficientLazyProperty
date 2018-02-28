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
}