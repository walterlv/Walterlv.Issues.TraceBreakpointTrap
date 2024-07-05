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

        Console.WriteLine("Issue is not reproduced. Exit.");
    }
}
