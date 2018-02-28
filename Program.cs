using System;

namespace ThreadSafeEfficientLazyProperty
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Program: starting");

      new MyServiceNaive().DoWork();
      
      Console.WriteLine("Program: completed");
    }
  }
}