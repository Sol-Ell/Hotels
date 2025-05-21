// Hotel.cs

using L4_14._Hotels.Interfaces;

namespace L4_14._Hotels
{
    /// <summary>
    /// Represents a hotel with a name, a room type, and a price per night.
    /// Implements deserialization and serialization, and supports comparisons.
    /// </summary>
    public sealed class Hotel : IDeserializable<Hotel>, ISerializable, IComparable<Hotel>, IEquatable<Hotel>
    {
        /// <summary>
        /// Gets or sets the name of the hotel.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of room offered by the hotel.
        /// </summary>
        public string RoomType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price per night for a room at the hotel.
        /// </summary>
        public decimal PricePerNight { get; set; }

        /// <summary>
        /// Deserializes an instance of <see cref="Hotel"/> from the provided deserializer.
        /// </summary>
        /// <typeparam name="D">The type of the deserializer, which implements <see cref="IDeserializer"/>.</typeparam>
        /// <param name="des">The deserializer used to read the hotel data.</param>
        /// <returns>A new instance of <see cref="Hotel"/> deserialized from the data source.</returns>
        /// <exception cref="InvalidDataException">Thrown when the deserialized data is invalid.</exception>
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

        /// <summary>
        /// Serializes the current instance of <see cref="Hotel"/> using the provided serializer.
        /// </summary>
        /// <typeparam name="S">The type of the serializer, which implements <see cref="ISerializer"/>.</typeparam>
        /// <param name="ser">The serializer used to write the hotel data.</param>
        public void Serialize<S>(S ser) where S : ISerializer
        {
            ser.SerializeString(Name);
            ser.SerializeString(RoomType);
            ser.SerializeDecimal(PricePerNight);
        }

        /// <summary>
        /// Determines whether this hotel is equal to another hotel.
        /// </summary>
        /// <param name="other">The other hotel to compare with.</param>
        /// <returns><c>true</c> if the hotels are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Hotel? other)
        {
            return CompareTo(other) == 0;
        }

        /// <summary>
        /// Compares this hotel with another hotel based on their names.
        /// </summary>
        /// <param name="other">The other hotel to compare with.</param>
        /// <returns>
        /// A value that indicates the relative order of the hotels.
        /// Less than 0 if this hotel precedes <paramref name="other"/>, 0 if they are equal, and greater than 0 if it follows.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        public int CompareTo(Hotel? other)
        {
            ArgumentNullException.ThrowIfNull(other);
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Determines whether this hotel is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with this hotel.</param>
        /// <returns><c>true</c> if the object is a <see cref="Hotel"/> and is equal to this instance; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="obj"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when <paramref name="obj"/> is not of type <see cref="Hotel"/>.</exception>
        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if (obj is Hotel other)
                return Equals(other);

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a string that represents the current hotel.
        /// </summary>
        /// <returns>A string that contains the hotel's name, room type, and price per night.</returns>
        public override string ToString()
        {
            return $"{Name} {RoomType} {PricePerNight}";
        }

        /// <summary>
        /// Returns a hash code for this hotel.
        /// </summary>
        /// <returns>A hash code based on the hotel's name.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
