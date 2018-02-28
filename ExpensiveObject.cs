using System;
using System.Security.Cryptography;
using System.Threading;

namespace ThreadSafeEfficientLazyProperty
{
  public class ExpensiveObject
  {
    public ExpensiveObject()
    {
      Console.WriteLine("ExpensiveObject: Starting creation");

      Thread.Sleep(500);
      
      Console.WriteLine("ExpensiveObject: Completed creation");
    }

    public void Move(int from, int to)
    {
      Console.WriteLine($"ExpensiveObject: Moving from: {from} to: {to}");
    }
  }
}