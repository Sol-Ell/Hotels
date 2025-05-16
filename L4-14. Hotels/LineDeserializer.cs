using L4_14._Hotels.Interfaces;

namespace L4_14._Hotels
{
    public sealed class LineDeserializer : IDeserializer
    {
        private string _remaining;
        public int CursorPosition { get; private set; }
        private static readonly char delimeter = ',';

        public LineDeserializer(string line)
        {
            _remaining = line;
        }

        public string Remaining()
        {
            return _remaining;
        }

        public static LineDeserializer FromString(string line)
        {
            return new LineDeserializer(line);
        }

        public decimal DeserializeDecimal()
        {
            return decimal.Parse(DeserializeString().Trim());
        }

        public string DeserializeString()
        {
            var at = _remaining.IndexOf(delimeter);
            if (at == -1)
            {
                if (_remaining.Length == 0)
                    throw new EndOfStreamException("End of line reached.");
                else
                {
                    var last = _remaining;
                    _remaining = string.Empty;
                    CursorPosition += _remaining.Length + 1;

                    return last;
                }
            }

            var part = _remaining[..at];
            _remaining = _remaining[(at + 1)..];
            
            CursorPosition += at + 1;

            return part;
        }

        public uint DeserializeUint()
        {
            return uint.Parse(DeserializeString().Trim());
        }
    }
}
