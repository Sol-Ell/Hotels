using L4_14._Hotels.Interfaces;

namespace L4_14._Hotels
{
    public sealed class Traveler : IDeserializable<Traveler>, ISerializable, IComparable<Traveler>, IEquatable<Traveler>
    {
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public uint Nights { get; set; }

        public static Traveler Deserialize<D>(D des) where D : IDeserializer
        {
            var surname = des.DeserializeString().Trim();
            var name = des.DeserializeString().Trim();
            var hotelName = des.DeserializeString().Trim();
            var roomType = des.DeserializeString().Trim();
            var nights = des.DeserializeUint();

            if (string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(hotelName) ||
                string.IsNullOrEmpty(roomType) ||
                nights == 0)
                throw new InvalidDataException("Invalid traveler data.");

            return new Traveler
            {
                Surname = surname,
                Name = name,
                HotelName = hotelName,
                RoomType = roomType,
                Nights = nights
            };
        }

        public int CompareTo(Traveler? other)
        {
            ArgumentNullException.ThrowIfNull(other);

            var cmp = Surname.CompareTo(other.Surname);
            return cmp == 0 ? Name.CompareTo(other.Name) : cmp;
        }

        public bool Equals(Traveler? other)
        {
            return CompareTo(other) == 0;
        }

        public void Serialize<S>(S ser) where S : ISerializer
        {
            ser.SerializeString(Surname);
            ser.SerializeString(Name);
            ser.SerializeString(HotelName);
            ser.SerializeString(RoomType);
            ser.SerializeUint(Nights);
        }

        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is Traveler other)
                return Equals(other);

            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {HotelName} {RoomType} {Nights}";
        }

        public override int GetHashCode()
        {
            return Surname.GetHashCode() ^ Name.GetHashCode();
        }
    }
}
