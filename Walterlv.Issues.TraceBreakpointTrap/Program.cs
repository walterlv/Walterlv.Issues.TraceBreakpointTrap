using static Walterlv.Issues.TraceBreakpointTrap.DebuggingHelper;

namespace Walterlv.Issues.TraceBreakpointTrap;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("### Trace/Breakpoint Trap issue on .NET debugger ###");
        Console.WriteLine();

        if (!OperatingSystem.IsLinux())
        {
            Console.WriteLine("This issue is only reproducible on Linux. Exit.");
            return;
        }

        AttachDebugger(args);

        var manager = new VolumeManager();
        manager.Init();

        Thread.Sleep(1000);
        Console.WriteLine("Issue may not be reproduced. Exit.");
    }
}
