using L4_14._Hotels.Interfaces;

namespace L4_14._Hotels
{
    public sealed class Hotel : IDeserializable<Hotel>, ISerializable, IComparable<Hotel>, IEquatable<Hotel>
    {
        public string Name { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }

        public static Hotel Deserialize<D>(D des) where D : IDeserializer
        {
            var name = des.DeserializeString().Trim();
            var roomType = des.DeserializeString().Trim();
            var pricePerNight = des.DeserializeDecimal();

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(roomType) ||
                pricePerNight <= 0)
                throw new InvalidDataException("Invalid hotel data.");

            return new Hotel
            {
                Name = name,
                RoomType = roomType,
                PricePerNight = pricePerNight,
            };
        }

        public void Serialize<S>(S ser) where S : ISerializer
        {
            ser.SerializeString(Name);
            ser.SerializeString(RoomType);
            ser.SerializeDecimal(PricePerNight);
        }

        public bool Equals(Hotel? other)
        {
            return CompareTo(other) == 0;
        }

        public int CompareTo(Hotel? other)
        {
            ArgumentNullException.ThrowIfNull(other);
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is Hotel other)
                return Equals(other);

            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return $"{Name} {RoomType} {PricePerNight}";
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
