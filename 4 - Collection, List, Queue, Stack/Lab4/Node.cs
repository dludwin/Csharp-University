namespace Lab4
{
    public class Node<T>          // Container for other types, can have any type
    {
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
