// DoublyLinkedList.cs

using System.Collections;

namespace L4_14._Hotels
{
    /// <summary>
    /// Represents a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Represents a node in the doubly linked list.
        /// </summary>
        /// <typeparam name="U">The type of the value held by the node.</typeparam>
        private sealed class Node<U>
        {
            /// <summary>
            /// Gets or sets the previous node.
            /// </summary>
            public Node<U> Prev { get; set; }

            /// <summary>
            /// Gets or sets the value stored in this node.
            /// </summary>
            public U Value { get; set; }

            /// <summary>
            /// Gets or sets the next node.
            /// </summary>
            public Node<U> Next { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Node{U}"/> class with the specified value.
            /// </summary>
            /// <param name="value">The value to store in the node.</param>
            public Node(U value)
            {
                Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Node{U}"/> class with a previous node and a value.
            /// </summary>
            /// <param name="prev">The previous node.</param>
            /// <param name="value">The value to store.</param>
            public Node(Node<U> prev, U value)
            {
                Prev = prev;
                Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Node{U}"/> class with a value and a next node.
            /// </summary>
            /// <param name="value">The value to store.</param>
            /// <param name="next">The next node.</param>
            public Node(U value, Node<U> next)
            {
                Value = value;
                Next = next;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Node{U}"/> class with a previous node, a value and a next node.
            /// </summary>
            /// <param name="prev">The previous node.</param>
            /// <param name="value">The value to store.</param>
            /// <param name="next">The next node.</param>
            public Node(Node<U> prev, U value, Node<U> next)
            {
                Prev = prev;
                Value = value;
                Next = next;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class.
        /// </summary>
        public DoublyLinkedList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class and adds the first value.
        /// </summary>
        /// <param name="value">The value to add to the list.</param>
        public DoublyLinkedList(T value)
        {
            PushBack(value);
        }

        /// <summary>
        /// Determines whether the linked list is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the list is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty()
        {
            return _head == null || _tail == null;
        }

        /// <summary>
        /// Adds a value at the end of the list.
        /// </summary>
        /// <param name="value">The value to add.</param>
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

        /// <summary>
        /// Adds a value at the beginning of the list.
        /// </summary>
        /// <param name="val">The value to add.</param>
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

        /// <summary>
        /// Adds a value to the list. This is an alias for <see cref="PushBack(T)"/>.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void Add(T value)
        {
            PushBack(value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator for the list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var cursor = _head;
            while (cursor != null)
            {
                yield return cursor.Value;
                cursor = cursor.Next;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator for the list.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// Provides extension methods for <see cref="DoublyLinkedList{T}"/>.
    /// </summary>
    public static class DoublyLinkedListExt
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> to a <see cref="DoublyLinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="self">The enumerable to convert.</param>
        /// <returns>A new <see cref="DoublyLinkedList{T}"/> containing the elements of the source enumerable.</returns>
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
