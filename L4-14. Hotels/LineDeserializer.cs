// LineDeserializer.cs

using L4_14._Hotels.Interfaces;

namespace L4_14._Hotels
{
    /// <summary>
    /// Provides functionality to deserialize primitive data types (string, decimal, and uint)
    /// from a comma-delimited line.
    /// </summary>
    public sealed class LineDeserializer : IDeserializer
    {
        /// <summary>
        /// The remaining unprocessed portion of the input string.
        /// </summary>
        private string _remaining;

        /// <summary>
        /// Gets the current cursor position within the input string.
        /// This value represents the total number of characters consumed.
        /// </summary>
        public int CursorPosition { get; private set; }

        /// <summary>
        /// The delimiter character used to separate values.
        /// </summary>
        private static readonly char delimeter = ',';

        /// <summary>
        /// Initializes a new instance of the <see cref="LineDeserializer"/> class with the specified input line.
        /// </summary>
        /// <param name="line">The comma-separated line from which data will be deserialized.</param>
        public LineDeserializer(string line)
        {
            _remaining = line;
        }

        /// <summary>
        /// Gets the remaining unprocessed portion of the input line.
        /// </summary>
        /// <returns>A string containing the portion of the line that has not yet been deserialized.</returns>
        public string Remaining()
        {
            return _remaining;
        }

        /// <summary>
        /// Creates a new instance of <see cref="LineDeserializer"/> from the specified string.
        /// </summary>
        /// <param name="line">The comma-separated line to deserialize.</param>
        /// <returns>A new instance of <see cref="LineDeserializer"/> initialized with the provided line.</returns>
        public static LineDeserializer FromString(string line)
        {
            return new LineDeserializer(line);
        }

        /// <summary>
        /// Deserializes a decimal value from the input line.
        /// This method parses a substring representing a decimal number,
        /// trimming any leading or trailing whitespace.
        /// </summary>
        /// <returns>The deserialized decimal value.</returns>
        public decimal DeserializeDecimal()
        {
            return decimal.Parse(DeserializeString().Trim());
        }

        /// <summary>
        /// Deserializes a string value from the input line.
        /// The method reads up to the next occurrence of the delimiter.
        /// If no delimiter is found and the line is non-empty, the remainder is returned.
        /// If the line is empty, an <see cref="EndOfStreamException"/> is thrown.
        /// </summary>
        /// <returns>The deserialized string value.</returns>
        /// <exception cref="EndOfStreamException">Thrown if the end of the line is reached without any remaining data.</exception>
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
                    CursorPosition += last.Length + 1; // Update with the length of the remaining data plus delimiter
                    return last;
                }
            }

            var part = _remaining[..at];
            _remaining = _remaining[(at + 1)..];
            CursorPosition += at + 1;
            return part;
        }

        /// <summary>
        /// Deserializes an unsigned integer (uint) value from the input line.
        /// The method retrieves a string value and then parses it as a uint.
        /// </summary>
        /// <returns>The deserialized unsigned integer value.</returns>
        public uint DeserializeUint()
        {
            return uint.Parse(DeserializeString().Trim());
        }
    }
}
