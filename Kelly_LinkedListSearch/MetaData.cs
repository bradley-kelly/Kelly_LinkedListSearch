namespace Kelly_LinkedListSearch
{
    class MetaData
    {
        private readonly int Rank;
        private readonly char Gender;
        private readonly string Name;
        public MetaData(string name, char gender, int rank)
        {
            Name = name;
            Gender = gender;
            Rank = rank;
        }
        public string GetName()
        {
            return Name;
        }
        public char GetGender()
        {
            return Gender;
        }

        public int GetRank()
        {
            return Rank;
        }
    }
}
