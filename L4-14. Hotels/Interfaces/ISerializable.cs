namespace L4_14._Hotels.Interfaces
{
    public interface ISerializable
    {
        void Serialize<S>(S ser) where S : ISerializer;
    }
}
