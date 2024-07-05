using System.Runtime.InteropServices;

namespace Walterlv.Issues.TraceBreakpointTrap.Native;

public static class Linux
{
    public delegate void pa_context_notify_cb_t(nint c, nint userdata);

    [DllImport("libpulse.so.0")]
    public static extern nint pa_threaded_mainloop_new();

    [DllImport("libpulse.so.0")]
    public static extern nint pa_threaded_mainloop_get_api(nint m);

    [DllImport("libpulse.so.0")]
    public static extern nint pa_context_new(nint mainloop, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport("libpulse.so.0")]
    public static extern void pa_context_set_state_callback(nint c, pa_context_notify_cb_t cb, nint userdata);

    [DllImport("libpulse.so.0")]
    public static extern int pa_context_connect(nint c, nint server, uint flags, nint api);

    [DllImport("libpulse.so.0")]
    public static extern int pa_threaded_mainloop_start(nint m);
}
