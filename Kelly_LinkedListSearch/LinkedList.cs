namespace Kelly_LinkedListSearch
{
    class LinkedList
    {
        private static int MaleNames = 0;
        private static int FemaleNames = 0;
        private static MetaData MostPopularMale;
        private static MetaData MostPopularFemale;
        private Node Head;
        private Node Tail;

        public int GetAllNames()
        {
            int AllNames = MaleNames + FemaleNames;
            return AllNames;
        }
        public int GetMaleNames()
        {
            return MaleNames;
        }
        public int GetFemaleNames()
        {
            return FemaleNames;
        }
        public Node Search(string data)
        {
            Node front = Head;
            while (front != null)
            {
                string current = front.Metadata.GetName();
                if (front == null)
                {
                    return null;
                }
                if (current.ToLower().CompareTo(data.ToLower()) == 0)
                {

                    return front;
                }
                front = front.Next;
            }
            return null;
        }
        public Node Add(MetaData data)
        {
            if (data.GetGender().ToString().ToLower() == "m")
            {
                if (MaleNames == 0 || MostPopularMale.GetRank() < data.GetRank())
                {
                    MostPopularMale = data;
                }
                MaleNames++;
            }
            else
            {
                if (FemaleNames == 0 || MostPopularFemale.GetRank() < data.GetRank())
                {
                    MostPopularFemale = data;
                }
                FemaleNames++;
            }
            if (Head == null)
            {
                Head = new Node(data);
                Tail = Head;
                return Head;
            }
            Node current = Head;
            while (current != null)
            {
                Node next = current.Next;
                if (next == null)
                {
                    if (current.Metadata.GetName().CompareTo(data.GetName()) > 0)
                    {
                        Node temp = new Node(data);
                        temp.Next = Head;
                        Head = temp;
                        return temp;
                    }
                    else
                    {
                        Tail.Next = new Node(data);
                        Tail.Next.Previous = Tail;
                        Tail = Tail.Next;
                        return Tail;
                    }
                }
                if (current.Metadata.GetName().CompareTo(data.GetName()) > 0)
                {
                    Node temp = new Node(data);
                    temp.Next = Head;
                    Head = temp;
                    return temp;
                }
                if (current.Metadata.GetName().CompareTo(data.GetName()) < 0 && next.Metadata.GetName().CompareTo(data.GetName()) >= 0)
                {
                    current.Next = new Node(data);
                    current.Next.Previous = current;
                    current.Next.Next = next;
                    next.Previous = current.Next;
                    return current.Next;
                }
                current = current.Next;
            }
            return null;
        }
        public MetaData Popular(char g)
        {
            if (g == 'm')
            {
                return MostPopularMale;
            }
            else if (g == 'f')
            {
                return MostPopularFemale;
            }
            else
            {
                return null;
            }
        }
    }
}
