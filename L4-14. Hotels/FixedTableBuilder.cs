// FixedTableBuilder.cs

using L4_14._Hotels.Interfaces;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace L4_14._Hotels
{
    /// <summary>
    /// Builds a table with fixed-width columns and provides methods for adding rows to it.
    /// </summary>
    public sealed class FixedTableBuilder : IEnumerable<string>
    {
        private const char _delimeter = '|';
        private const char _hBarSymbol = '-';

        /// <summary>
        /// A helper class that serializes a table row according to fixed column widths.
        /// </summary>
        /// <remarks>
        /// This class implements <see cref="ISerializer"/> to format a row and fill missing cells.
        /// </remarks>
        private class FixedRowSerializer(IEnumerable<int> colsWidth) : ISerializer
        {
            private readonly IEnumerator<int> _colsWidth = colsWidth.GetEnumerator();

            /// <summary>
            /// Gets the underlying string builder used for constructing the serialized row.
            /// </summary>
            public StringBuilder Sb = new(_delimeter);

            /// <summary>
            /// Fills any remaining cells with spaces according to the column widths.
            /// </summary>
            public void FillRemainingCells()
            {
                while (_colsWidth.MoveNext())
                {
                    Sb.Append(' ', _colsWidth.Current);
                    Sb.Append(_delimeter);
                }
            }

            /// <summary>
            /// Returns the formatted row as a string.
            /// </summary>
            /// <returns>A string representing the serialized row.</returns>
            public override string ToString()
            {
                FillRemainingCells();
                return Sb.ToString();
            }

            /// <summary>
            /// Serializes a string into a cell with fixed width.
            /// </summary>
            /// <param name="str">The string to serialize.</param>
            public void SerializeString(string str)
            {
                if (!_colsWidth.MoveNext())
                    throw new EndOfStreamException("End of table row reached.");

                if (str.Length > _colsWidth.Current)
                    Sb.Append(str.AsSpan(0, _colsWidth.Current));
                else
                {
                    Sb.Append(str);
                    if (str.Length < _colsWidth.Current)
                        Sb.Append(' ', _colsWidth.Current - str.Length);
                }

                Sb.Append(_delimeter);
            }

            /// <summary>
            /// Serializes a decimal number into a cell.
            /// </summary>
            /// <param name="num">The decimal number to serialize.</param>
            public void SerializeDecimal(decimal num)
            {
                SerializeString(num.ToString());
            }

            /// <summary>
            /// Serializes an unsigned integer into a cell.
            /// </summary>
            /// <param name="num">The unsigned integer to serialize.</param>
            public void SerializeUint(uint num)
            {
                SerializeString(num.ToString());
            }
        }
        private readonly IEnumerable<int> _colsWidth;
        private string HBar { get; init; } = string.Empty;
        private string _title = string.Empty;
        private string _header = string.Empty;
        private readonly DoublyLinkedList<string> rows = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedTableBuilder"/> class with the specified column configuration.
        /// </summary>
        /// <param name="colsWidth">A collection of tuples where Item1 is the column header and Item2 is the width of the column.</param>
        public FixedTableBuilder(IEnumerable<(string, uint)> colsWidth)
        {
            _colsWidth = colsWidth.Select(t => (int)t.Item2);
            HBar = new string(_hBarSymbol, (int)colsWidth.Aggregate((uint)0, (acc, val) => acc + val.Item2 + 1));
            WithHeader(colsWidth.Select(t => t.Item1));
        }

        /// <summary>
        /// Sets the title of the table.
        /// </summary>
        /// <param name="title">The title of the table.</param>
        public void WithTitle(string title)
        {
            _title = title;
        }

        /// <summary>
        /// Sets the header row using the provided column headers.
        /// </summary>
        /// <typeparam name="I">The type that implements <see cref="IEnumerable{T}"/> of strings.</typeparam>
        /// <param name="items">The collection of column headers.</param>
        private void WithHeader<I>(I items) where I : IEnumerable<string>
        {
            var row = new FixedRowSerializer(_colsWidth);

            foreach (var item in items)
                row.SerializeString(item);

            _header = row.ToString();
        }

        /// <summary>
        /// Inserts a sequence of items into the table as separate rows.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="items">The collection of items to insert.</param>
        public void InsertAnySeq<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                InsertAny(item);
            }
        }

        /// <summary>
        /// Inserts a single item into the table.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="item">The item to insert.</param>
        public void InsertAny<T>(T item)
        {
            var row = new FixedRowSerializer(_colsWidth);

            // Call SerializeAny on the row using the ISerializer interface implementation.
            (row as ISerializer).SerializeAny(item);

            rows.Add(row.ToString());
        }

        /// <summary>
        /// Returns an enumerator that iterates through the table rows, including the title and header.
        /// </summary>
        /// <returns>An enumerator of strings, each representing a row in the table.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            if (!string.IsNullOrEmpty(_title))
                yield return _title;

            if (!string.IsNullOrEmpty(_header))
            {
                yield return HBar;
                yield return _header;
                yield return HBar;
            }

            foreach (var item in rows)
            {
                yield return item;
            }
            if (!rows.IsEmpty())
            {
                yield return HBar;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the table rows.
        /// </summary>
        /// <returns>An enumerator for the table rows.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
