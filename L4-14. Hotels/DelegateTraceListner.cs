// DelegateTraceListner.cs

using System.Diagnostics;

namespace L4_14._Hotels
{
    /// <summary>
    /// A custom TraceListener that delegates trace events to a specified event handler.
    /// </summary>
    /// <param name="eventHandler">The delegate used to process trace messages.</param>
    internal class DelegateTraceListner(Action<string> eventHandler) : TraceListener
    {
        /// <summary>
        /// The delegate that handles incoming trace messages.
        /// </summary>
        readonly Action<string> eventHandler = eventHandler;

        /// <summary>
        /// Writes a message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void Write(string? message)
        {
            HandleEvent(message ?? string.Empty);
        }

        /// <summary>
        /// Writes a message followed by a line terminator.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void WriteLine(string? message)
        {
            HandleEvent(message ?? string.Empty);
        }

        /// <summary>
        /// Writes a categorized message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The category of the message.</param>
        public override void Write(string? message, string? category)
        {
            HandleEvent(message ?? string.Empty);
        }

        /// <summary>
        /// Writes a categorized message followed by a line terminator.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="category">The category of the message.</param>
        public override void WriteLine(string? message, string? category)
        {
            HandleEvent(message ?? string.Empty);
        }

        /// <summary>
        /// Traces an event by writing a trace message.
        /// </summary>
        /// <param name="eventCache">A TraceEventCache object that provides contextual information.</param>
        /// <param name="source">The name of the source.</param>
        /// <param name="eventType">One of the TraceEventType values specifying the type of event that has caused the trace.</param>
        /// <param name="id">A trace identifier number.</param>
        /// <param name="message">The message to write.</param>
        public override void TraceEvent(TraceEventCache? eventCache, string? source, TraceEventType eventType, int id, string? message)
        {
            HandleEvent(message ?? string.Empty);
        }

        /// <summary>
        /// Invokes the delegate to handle the trace event.
        /// </summary>
        /// <param name="message">The message associated with the trace event.</param>
        void HandleEvent(string? message)
        {
            eventHandler(message ?? string.Empty);
        }
    }
}
