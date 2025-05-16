namespace L4_14._Hotels.Interfaces
{
    public interface IDeserializable<T> where T : IDeserializable<T>
    {
        static abstract T Deserialize<D>(D des) where D : IDeserializer;
    }
}