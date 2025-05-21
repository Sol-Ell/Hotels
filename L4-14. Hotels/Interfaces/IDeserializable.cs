// Interfaces/IDeserializable.cs

namespace L4_14._Hotels.Interfaces
{
    /// <summary>
    /// Defines a contract for types that can be deserialized from a data source using a specified deserializer.
    /// </summary>
    /// <typeparam name="T">
    /// The type that implements <see cref="IDeserializable{T}"/>. 
    /// This constraint ensures that the implementing type provides its own deserialization logic.
    /// </typeparam>
    public interface IDeserializable<T> where T : IDeserializable<T>
    {
        /// <summary>
        /// Deserializes an instance of <typeparamref name="T"/> from the provided deserializer.
        /// </summary>
        /// <typeparam name="D">
        /// The type of the deserializer, which must implement <see cref="IDeserializer"/>.
        /// </typeparam>
        /// <param name="des">
        /// The deserializer instance used to read and construct the object.
        /// </param>
        /// <returns>
        /// A new instance of <typeparamref name="T"/> deserialized from the data source.
        /// </returns>
        static abstract T Deserialize<D>(D des) where D : IDeserializer;
    }
}
