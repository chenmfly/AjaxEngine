﻿#if (NETFX_CORE || SILVERLIGHT || PORTABLE40 || PORTABLE)
using AjaxEngine.Json.Serialization;

namespace AjaxEngine.Json
{
  /// <summary>
  /// Specifies what messages to output for the <see cref="ITraceWriter"/> class.
  /// </summary>
  public enum TraceLevel
  {
    /// <summary>
    /// Output no tracing and debugging messages.
    /// </summary>
    Off,
    /// <summary>
    /// Output error-handling messages.
    /// </summary>
    Error,
    /// <summary>
    /// Output warnings and error-handling messages.
    /// </summary>
    Warning,
    /// <summary>
    /// Output informational messages, warnings, and error-handling messages.
    /// </summary>
    Info,
    /// <summary>
    /// Output all debugging and tracing messages.
    /// </summary>
    Verbose
  }
}
#endif