# Trace/breakpoint trap

## To reproduce

Build this project with `dotnet build`.

```powershell
dotnet publish -c debug -r linux-x64 --self-contained
```

Run the generated executable:

```powershell
> ./TraceBreakpointTrapDemo

### Trace/Breakpoint Trap issue on .NET debugger ###

If you want to debug this demo using other debuggers (e.g. GDB, LLDB), you can use the following options:

  --sleep <seconds>  Sleep for a while before attaching debugger.
  --skip-attach      Skip attaching debugger and run directly.

Please attach a dotnet debugger and use 'Set next statement'.
```

Attach a dotnet debugger and then you'll see the following output:

```powershell
Trace/breakpoint trap
```
