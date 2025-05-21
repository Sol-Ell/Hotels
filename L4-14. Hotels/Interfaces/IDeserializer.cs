// Interfaces/IDeserializer.cs

namespace L4_14._Hotels.Interfaces
{
    /// <summary>
    /// Defines methods for deserializing primitive data types from a data source.
    /// Implementations of this interface provide logic to read and convert serialized data into .NET types.
    /// </summary>
    public interface IDeserializer
    {
        /// <summary>
        /// Deserializes and returns a string value from the data source.
        /// </summary>
        /// <returns>
        /// The deserialized string value.
        /// </returns>
        abstract string DeserializeString();

        /// <summary>
        /// Deserializes and returns a decimal value from the data source.
        /// </summary>
        /// <returns>
        /// The deserialized decimal value.
        /// </returns>
        abstract decimal DeserializeDecimal();

        /// <summary>
        /// Deserializes and returns an unsigned integer (uint) value from the data source.
        /// </summary>
        /// <returns>
        /// The deserialized unsigned integer value.
        /// </returns>
        abstract uint DeserializeUint();
    }
}
