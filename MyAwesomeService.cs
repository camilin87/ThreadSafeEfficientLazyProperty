using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MyAwesomeService
  {
    private object criticalSection = new object();
    private Func<ExpensiveObject> expensiveLoadReader;

    public MyAwesomeService() => expensiveLoadReader = createAndCacheExpensiveLoad;

    public ExpensiveObject ExpensiveLoad => expensiveLoadReader();

    private class ExpensiveObjectFactory
    {
      private readonly ExpensiveObject result = new ExpensiveObject();

      public ExpensiveObject Build() => result;
    }
    
    private ExpensiveObject createAndCacheExpensiveLoad()
    {
      lock (criticalSection)
      {
        if (expensiveLoadReader == createAndCacheExpensiveLoad)
        {
          expensiveLoadReader = new ExpensiveObjectFactory().Build;
        }
      }
      
      return expensiveLoadReader();
    }
    
    public void DoWork()
    {
      Console.WriteLine("MyAwesomeService: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MyAwesomeService: work completed");
    }
  }
}