using L4_14._Hotels.Interfaces;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace L4_14._Hotels
{
    public sealed class FixedTableBuilder : IEnumerable<string>
    {
        private const char _delimeter = '|';
        private const char _hBarSymbol = '-';

        private  class FixedRowSerializer(IEnumerable<int> colsWidth) : ISerializer
        {
            private readonly IEnumerator<int> _colsWidth = colsWidth.GetEnumerator();
            public StringBuilder Sb = new(_delimeter);

            public void FillRemainingCells()
            {
                while (_colsWidth.MoveNext())
                {
                    Sb.Append(' ', _colsWidth.Current);
                    Sb.Append(_delimeter);
                }
            }

            public override string ToString()
            {
                FillRemainingCells();
                return Sb.ToString();
            }

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

            public void SerializeDecimal(decimal num)
            {
                SerializeString(num.ToString());
            }

            public void SerializeUint(uint num)
            {
                SerializeString(num.ToString());
            }
        }

        private readonly IEnumerable<int> _colsWidth;
        private string HBar { get; init; } = string.Empty;
        private string _title = string.Empty;
        private string _header = string.Empty;
        private readonly DoublyLinkedList<string> rows = [];

        public FixedTableBuilder(IEnumerable<(string, uint)> colsWidth)
        {
            _colsWidth = colsWidth.Select(t => (int)t.Item2);
            HBar = new string(_hBarSymbol, (int)colsWidth.Aggregate((uint)0, (acc, val) => acc + val.Item2 + 1));
            WithHeader(colsWidth.Select(t => t.Item1));
        }

        public void WithTitle(string title)
        {
            _title = title;
        }

        private void WithHeader<I>(I items) where I : IEnumerable<string>
        {
            var row = new FixedRowSerializer(_colsWidth);
            
            foreach (var item in items)
                row.SerializeString(item);

            _header = row.ToString();
        }

        public void InsertAnySeq<T>(IEnumerable<T> items) 
        {
            foreach (var item in items)
            {
                InsertAny(item);
            }
        }

        public void InsertAny<T>(T item)
        {
            var row = new FixedRowSerializer(_colsWidth);

            (row as ISerializer).SerializeAny(item);

            rows.Add(row.ToString());
        }

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
