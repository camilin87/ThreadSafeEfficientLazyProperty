using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MyAwesomeService
  {
    private object criticalSection = new object();
    private Func<ExpensiveObject> expensiveLoad;

    public MyAwesomeService()
    {
      expensiveLoad = createAndCacheExpensiveLoad;
    }

    public ExpensiveObject ExpensiveLoad
    {
      get { return expensiveLoad(); }
    }

    private class ExpensiveObjectFactory
    {
      private readonly ExpensiveObject result = new ExpensiveObject();

      public ExpensiveObject Build() => result;
    }
    
    private ExpensiveObject createAndCacheExpensiveLoad()
    {
      lock (criticalSection)
      {
        if (expensiveLoad == createAndCacheExpensiveLoad)
        {
          expensiveLoad = new ExpensiveObjectFactory().Build;
        }
      }
      
      return expensiveLoad();
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