using System;

namespace ThreadSafeEfficientLazyProperty
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Program: starting");

      new MyServiceNaive().DoWork();
      Console.WriteLine("--");
      Console.WriteLine();
      
      new MyLockedService().DoWork();
      Console.WriteLine("--");
      Console.WriteLine();
      
      new MyAwesomeService().DoWork();
      Console.WriteLine("--");
      Console.WriteLine();

      new MySimplifiedAwesomeService().DoWork();
      Console.WriteLine("--");
      Console.WriteLine();
      
      new MyServiceThatUsesLazyPropertyHelperNuget().DoWork();
      Console.WriteLine("--");
      Console.WriteLine();

      Console.WriteLine("Program: completed");
    }
  }
}