using static Walterlv.Issues.TraceBreakpointTrap.Native.Linux;

namespace Walterlv.Issues.TraceBreakpointTrap;

public class VolumeManager
{
    private IntPtr _mainloop;
    private readonly pa_context_notify_cb_t _contextStateCallback;

    public VolumeManager()
    {
        _contextStateCallback = ContextStateCallback;
    }

    public void Init()
    {
        _mainloop = pa_threaded_mainloop_new();
        if (_mainloop == 0)
        {
            return;
        }

        var mainloopApi = pa_threaded_mainloop_get_api(_mainloop);
        if (mainloopApi == 0)
        {
            return;
        }

        var context = pa_context_new(mainloopApi, "IssueDemo");
        if (context == 0)
        {
            return;
        }

        pa_context_set_state_callback(context, _contextStateCallback, 0);

        var result = pa_context_connect(context, 0, 0, 0);
        if (result < 0)
        {
            return;
        }

        result = pa_threaded_mainloop_start(_mainloop);
        if (result < 0)
        {
            return;
        }
    }

    private void ContextStateCallback(IntPtr c, IntPtr userdata)
    {
    }
}
