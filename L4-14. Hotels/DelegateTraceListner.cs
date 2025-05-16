// DelegateTraceListner.cs
using System;
using System.Diagnostics;

namespace L4_14._Hotels
{
    internal class DelegateTraceListner(Action<string> eventHandler) : TraceListener
    {
        readonly Action<string> eventHandler = eventHandler;

        public override void Write(string? message)
        {
            HandleEvent(message ?? string.Empty);
        }

        public override void WriteLine(string? message)
        {
            HandleEvent(message ?? string.Empty);
        }

        public override void Write(string? message, string? category)
        {
            HandleEvent(message ?? string.Empty);
        }

        public override void WriteLine(string? message, string? category)
        {
            HandleEvent(message ?? string.Empty);
        }

        public override void TraceEvent(TraceEventCache? eventCache, string? source, TraceEventType eventType, int id, string? message)
        {
            HandleEvent(message ?? string.Empty);
        }

        void HandleEvent(string? message)
        {
            eventHandler(message ?? string.Empty);
        }
    }
}
