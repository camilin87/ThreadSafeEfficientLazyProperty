using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MyLockedService
  {
    private object criticalSection = new object();
    
    private ExpensiveObject expensiveLoad;

    public ExpensiveObject ExpensiveLoad
    {
      get
      {
        lock (criticalSection)
        {
          if (expensiveLoad == null)
          {
            expensiveLoad = new ExpensiveObject();
          }  
        }

        return expensiveLoad;
      }
    }

    public void DoWork()
    {
      Console.WriteLine("MyLockedService: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MyLockedService: work completed");
    }
  }
}