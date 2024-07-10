using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Walterlv.Issues.TraceBreakpointTrap;

public class Tester
{
    public static unsafe void Run()
    {
        ExecCallbackInNewThread(&Callback);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void Callback()
    {
    }

    [DllImport("test")]
    private static unsafe extern void ExecCallbackInNewThread(delegate* unmanaged[Cdecl]<void> callback);
}

public delegate void test_callback();
