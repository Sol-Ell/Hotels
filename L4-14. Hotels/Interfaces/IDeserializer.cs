namespace L4_14._Hotels.Interfaces
{
    public interface IDeserializer
    {
        abstract string DeserializeString();

        abstract decimal DeserializeDecimal();
        abstract uint DeserializeUint();
    }
}
