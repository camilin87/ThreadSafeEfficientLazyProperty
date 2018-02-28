using System;
using System.Threading;

namespace ThreadSafeEfficientLazyProperty
{
  public class ExpensiveObject
  {
    public ExpensiveObject()
    {
      Console.WriteLine("Starting Expensive object creation");

      Thread.Sleep(2000);
      
      Console.WriteLine("Completed Expensive object creation");
    }
  }
}