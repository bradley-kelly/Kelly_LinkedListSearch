namespace Kelly_LinkedListSearch
{
    class Node
    {
        protected Node prev;
        protected Node nxt;
        protected MetaData data;
        public Node Previous { get { return prev; } set { prev = value; } }
        public Node Next { get { return nxt; } set { nxt = value; } }
        public MetaData Metadata { get { return data; } set { data = value; } }

        public Node(MetaData metaData)
        {
            Metadata = metaData;
            Next = null;
            Previous = null;
        }
    }
}
