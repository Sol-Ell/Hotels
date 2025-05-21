// Interface/ISerializer.cs

using System.Runtime.CompilerServices;

namespace L4_14._Hotels.Interfaces
{
    /// <summary>
    /// Defines methods for serializing various data types to a specific format.
    /// Implementations of this interface determine how data is serialized.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes the provided string.
        /// </summary>
        /// <param name="str">The string to serialize.</param>
        abstract void SerializeString(string str);

        /// <summary>
        /// Serializes the provided decimal value.
        /// </summary>
        /// <param name="num">The decimal number to serialize.</param>
        abstract void SerializeDecimal(decimal num);

        /// <summary>
        /// Serializes the provided unsigned integer.
        /// </summary>
        /// <param name="num">The unsigned integer to serialize.</param>
        abstract void SerializeUint(uint num);

        /// <summary>
        /// Serializes each element of the provided tuple by calling <see cref="SerializeAny{T}(T)"/> for each element.
        /// </summary>
        /// <param name="tuple">The tuple containing elements to be serialized.</param>
        void SerializeTuple(ITuple tuple)
        {
            for (int i = 0; i < tuple.Length; i++)
            {
                SerializeAny(tuple[i]);
            }
        }

        /// <summary>
        /// Serializes a value of any supported type.
        /// <para>
        /// Depending on the type of <paramref name="val"/>, serialization is delegated to the corresponding method:
        /// <list type="bullet">
        /// <item><description>If the value implements <see cref="ISerializable"/>, its <see cref="ISerializable.Serialize{S}(S)"/> method is called.</description></item>
        /// <item><description>If the value is a string, <see cref="SerializeString"/> is called.</description></item>
        /// <item><description>If the value is a decimal, <see cref="SerializeDecimal"/> is called.</description></item>
        /// <item><description>If the value is a uint, <see cref="SerializeUint"/> is called.</description></item>
        /// <item><description>If the value is an <see cref="ITuple"/>, <see cref="SerializeTuple"/> is used to serialize each element.</description></item>
        /// </list>
        /// If the value is null, an <see cref="ArgumentNullException"/> is thrown, and if the value’s type is not supported,
        /// an <see cref="InvalidDataException"/> is thrown.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="val">The value to serialize.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void SerializeAny<T>(T val)
        {
            switch (val)
            {
                case ISerializable ser:
                    ser.Serialize(this);
                    break;
                case string str:
                    SerializeString(str);
                    break;
                case decimal num:
                    SerializeDecimal(num);
                    break;
                case uint num:
                    SerializeUint(num);
                    break;
                case ITuple tuple:
                    SerializeTuple(tuple);
                    break;
                case null:
                    throw new ArgumentNullException("Null cannot be serialized.");
                default:
                    throw new InvalidDataException($"Type {val.GetType().Name} cannot be serialized.");
            }
        }
    }
}
