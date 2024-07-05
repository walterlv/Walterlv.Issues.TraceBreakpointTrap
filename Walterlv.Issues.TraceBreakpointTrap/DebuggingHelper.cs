using System.Diagnostics;

namespace Walterlv.Issues.TraceBreakpointTrap;

public static class DebuggingHelper
{
    public static void AttachDebugger(string[] args)
    {
        if (Debugger.IsAttached)
        {
            return;
        }

        if (args.Length > 0 && args[0] == "--skip-attach")
        {
            return;
        }

        if (args.Length > 1 && args[0] == "--sleep" && double.TryParse(args[1], out var seconds))
        {
            Console.WriteLine($"Sleep for {seconds} seconds before attaching debugger.");
            Thread.Sleep((int)seconds * 1000);
            return;
        }

        Console.WriteLine("""
If you want to debug this demo using other debuggers (e.g. GDB, LLDB), you can use the following options:

  --sleep <seconds>  Sleep for a while before attaching debugger.
  --skip-attach      Skip attaching debugger and run directly.

""");

        Console.WriteLine("Please attach a dotnet debugger and use 'Set next statement'.");

        while (true)
        {
            Thread.Sleep(100);

            if (Debugger.IsAttached)
            {
                break;
            }
        }
    }
}
