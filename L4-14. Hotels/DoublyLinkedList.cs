using System.Collections;

namespace L4_14._Hotels
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private sealed class Node<U>
        {
            public Node<U> Prev { get; set; }
            public U Value { get; set; }
            public Node<U> Next { get; set; }

            public Node(U value)
            {
                Value = value;
            }

            public Node(Node<U> prev, U value)
            {
                Prev = prev;
                Value = value;
            }

            public Node(U value, Node<U> next)
            {
                Value = value;
                Next = next;
            }

            public Node(Node<U> prev, U value, Node<U> next)
            {
                Prev = prev;
                Value = value;
                Next = next;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(T value)
        {
            PushBack(value);
        }

        public bool IsEmpty()
        {
            return _head == null || _tail == null;
        }

        public void PushBack(T value)
        {
            if (IsEmpty())
            {
                _head = new Node<T>(value);
                _tail = _head;
                return;
            }
            _tail.Next = new Node<T>(_tail, value);
            _tail = _tail.Next;
        }

        public void PushFront(T val)
        {
            if (IsEmpty())
            {
                _head = new Node<T>(val);
                _tail = _head;
                return;
            }
            _head.Prev = new Node<T>(val, _head);
            _head = _head.Prev;
        }

        public void Add(T value)
        {
            PushBack(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cursor = _head;
            while (cursor != null)
            {
                yield return cursor.Value;
                cursor = cursor.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class DoublyLinkedListExt
    {
        public static DoublyLinkedList<T> ToDoublyLinkedList<T>(this IEnumerable<T> self)
        {
            var list = new DoublyLinkedList<T>();
            foreach (var item in self)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
