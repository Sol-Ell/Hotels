// Interface/ISerializable.cs

namespace L4_14._Hotels.Interfaces
{
    /// <summary>
    /// Defines a contract for objects that can be serialized using a specified serializer.
    /// </summary>
    public interface ISerializable
    {
        /// <summary>
        /// Serializes the current instance using the provided serializer.
        /// </summary>
        /// <typeparam name="S">
        /// The type of the serializer, which must implement <see cref="ISerializer"/>.
        /// </typeparam>
        /// <param name="ser">
        /// An instance of the serializer used to write the current object's state.
        /// </param>
        void Serialize<S>(S ser) where S : ISerializer;
    }
}
