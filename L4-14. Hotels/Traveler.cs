// Traveler.cs

using L4_14._Hotels.Interfaces;

namespace L4_14._Hotels
{
    /// <summary>
    /// Represents a traveler with personal information and travel-related details.
    /// Implements deserialization, serialization, and supports comparisons.
    /// </summary>
    public sealed class Traveler : IDeserializable<Traveler>, ISerializable, IComparable<Traveler>, IEquatable<Traveler>
    {
        /// <summary>
        /// Gets or sets the traveler's surname.
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the traveler's first name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the hotel the traveler has chosen.
        /// </summary>
        public string HotelName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of room the traveler selected.
        /// </summary>
        public string RoomType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number of nights the traveler plans to stay.
        /// </summary>
        public uint Nights { get; set; }

        /// <summary>
        /// Deserializes an instance of <see cref="Traveler"/> from the provided deserializer.
        /// </summary>
        /// <typeparam name="D">The type of the deserializer, which must implement <see cref="IDeserializer"/>.</typeparam>
        /// <param name="des">The deserializer used to read the traveler data.</param>
        /// <returns>A new instance of <see cref="Traveler"/> deserialized from the data source.</returns>
        /// <exception cref="InvalidDataException">
        /// Thrown when any required traveler data is missing or invalid.
        /// </exception>
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

        /// <summary>
        /// Compares this instance with another <see cref="Traveler"/> based on surname and then name.
        /// </summary>
        /// <param name="other">The traveler to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the travelers.
        /// Less than zero if this instance precedes <paramref name="other"/>, zero if they are equal,
        /// and greater than zero if it follows <paramref name="other"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        public int CompareTo(Traveler? other)
        {
            ArgumentNullException.ThrowIfNull(other);

            var cmp = Surname.CompareTo(other.Surname);
            return cmp == 0 ? Name.CompareTo(other.Name) : cmp;
        }

        /// <summary>
        /// Determines whether the current traveler is equal to another traveler.
        /// </summary>
        /// <param name="other">The traveler to compare with the current traveler.</param>
        /// <returns><c>true</c> if the travelers are considered equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Traveler? other)
        {
            return CompareTo(other) == 0;
        }

        /// <summary>
        /// Serializes the current instance of <see cref="Traveler"/> using the provided serializer.
        /// </summary>
        /// <typeparam name="S">The type of the serializer, which must implement <see cref="ISerializer"/>.</typeparam>
        /// <param name="ser">The serializer used to write the traveler's data.</param>
        public void Serialize<S>(S ser) where S : ISerializer
        {
            ser.SerializeString(Surname);
            ser.SerializeString(Name);
            ser.SerializeString(HotelName);
            ser.SerializeString(RoomType);
            ser.SerializeUint(Nights);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current traveler.
        /// </summary>
        /// <param name="obj">The object to compare with the current traveler.</param>
        /// <returns>
        /// <c>true</c> if the specified object is a <see cref="Traveler"/> and is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="obj"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when <paramref name="obj"/> is not of type <see cref="Traveler"/>.
        /// </exception>
        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is Traveler other)
                return Equals(other);

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a string that represents the current traveler.
        /// </summary>
        /// <returns>
        /// A string containing the traveler's surname, name, hotel name, room type, and number of nights.
        /// </returns>
        public override string ToString()
        {
            return $"{Surname} {Name} {HotelName} {RoomType} {Nights}";
        }

        /// <summary>
        /// Returns a hash code for the current traveler.
        /// </summary>
        /// <returns>A hash code based on the traveler's surname and name.</returns>
        public override int GetHashCode()
        {
            return Surname.GetHashCode() ^ Name.GetHashCode();
        }
    }
}
