using System.Runtime.CompilerServices;

namespace L4_14._Hotels.Interfaces
{
    public interface ISerializer
    {
        abstract void SerializeString(string str);
        abstract void SerializeDecimal(decimal num);
        abstract void SerializeUint(uint num);

        void SerializeTuple(ITuple tuple)
        {
            for (int i = 0; i < tuple.Length; i++)
            {
                SerializeAny(tuple[i]);
            }
        }

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
