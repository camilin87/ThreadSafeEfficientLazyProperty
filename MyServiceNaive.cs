using System;

namespace ThreadSafeEfficientLazyProperty
{
  public class MyServiceNaive
  {
    private ExpensiveObject expensiveLoad;

    public ExpensiveObject ExpensiveLoad
    {
      get
      {
        if (expensiveLoad == null)
        {
          expensiveLoad = new ExpensiveObject();
        }

        return expensiveLoad;
      }
    }

    public void DoWork()
    {
      Console.WriteLine("MyServiceNaive: Starting work");
      
      ExpensiveLoad.Move(10, 2000);
      ExpensiveLoad.Move(2000, 15);
      
      Console.WriteLine("MyServiceNaive: work completed");
    }
  }
}