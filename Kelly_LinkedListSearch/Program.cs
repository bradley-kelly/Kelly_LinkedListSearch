using System;
using System.IO;
using System.Linq;

namespace Kelly_LinkedListSearch
{
    class Program
    {
        public static LinkedList llist = new LinkedList();
        static void Main(string[] args)
        {
            var nData = File.ReadAllLines(Environment.CurrentDirectory + @"\yob2019.txt");
            var nList = from name in nData
                           let data = name.Split(',')
                           select new
                           {
                               Name = data[0],
                               Gender = data[1],
                               Rank = data[2]
                           };
            foreach (var name in nList)
            {
                llist.Add(new MetaData(name.Name, name.Gender.ToCharArray()[0], int.Parse(name.Rank)));
            }
            int result = 0;
            while (result != 8)
            {
                Console.WriteLine("1. Search by name");
                Console.WriteLine("2. Count of all list items");
                Console.WriteLine("3. Count of all male name list items");
                Console.WriteLine("4. Count of all female name list items");
                Console.WriteLine("5. Add a name");
                Console.WriteLine("6. Find the most popular male name");
                Console.WriteLine("7. Find the most popular female name");
                Console.WriteLine("8. Exit");
                result = Convert.ToInt32(Console.ReadLine());
                switch (result)
                {
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                    case 1:
                        Console.Write("Enter a name to search for: ");
                        string term = Console.ReadLine();
                        Node target = llist.Search(term);
                        if (target != null)
                        {
                            Console.WriteLine("Found a name entry: {0}, Gender: {1}, Rank: {2}",
                                target.Metadata.GetName(), target.Metadata.GetGender(), target.Metadata.GetRank());
                        }
                        else
                        {
                            Console.WriteLine("Name not found.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("There are currently {0} names.", llist.GetAllNames());
                        break;
                    case 3:
                        Console.WriteLine("There are currently {0} male names in the list.", llist.GetMaleNames());
                        break;
                    case 4:
                        Console.WriteLine("There are currently {0} female names in the list.", llist.GetFemaleNames());
                        break;
                    case 5:
                        Console.Write("Enter name you want to add: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter person's gender: ");
                        string gender = Console.ReadLine();
                        Console.Write("Enter name rank: ");
                        string rank = Console.ReadLine();
                        if (llist.Search(name) != null)
                        {
                            Console.Write("Name already exists. Rename to {0}_1? (y/n): ", name);
                            char c = Console.ReadLine().ToLower().ToCharArray()[0];
                            if (c == 'y' && llist.Search(name).Metadata.GetGender().ToString().ToUpper() == gender.ToUpper())
                            {
                                name += "_1";
                                MetaData data = new MetaData(name, gender.ToUpper().ToCharArray()[0], int.Parse(rank));
                                llist.Add(data);
                                Console.WriteLine("Inserted {0}.", name);
                            }
                            else
                            {
                                Console.WriteLine("Cancelled.");
                                break;
                            }
                        }
                        else if (llist.Search(name) == null)
                        {
                            MetaData data = new MetaData(name, gender.ToUpper().ToCharArray()[0], int.Parse(rank));
                            llist.Add(data);
                            Console.WriteLine("Inserted {0}.", name);
                        }
                        else
                        {
                            Console.WriteLine("Name not able to be inserted.");
                        }
                        break;
                    case 6:
                        MetaData male = llist.Popular('m');
                        Console.WriteLine("The most popular male name is {0}.", male.GetName());
                        break;
                    case 7:
                        MetaData female = llist.Popular('f');
                        Console.WriteLine("The most popular female name is {0}.", female.GetName());
                        break;
                    case 8:
                        break;
                }
            }
        }
    }
}
