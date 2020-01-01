using System;

namespace BinaryTree
{
    class Program
    {
        static bool FindNodeMenu(BinaryTree<Student> tree)
        {
            Console.WriteLine("Enter value of node to search");
            int valueToSearch = Int32.Parse(Console.ReadLine());
            bool IsNodeFound = tree.Find(new Student("firstName", "lastName",
                "parrentName", "testName", valueToSearch, new System.DateTime(2019, 10, 10)));
            return IsNodeFound;
        }

        static bool WantToExit()
        {
            Console.WriteLine("To Exit press E, if you don`t want to exet - press any other key");
            string exit = Console.ReadLine();
            if (exit[0] == 'E')
                return true;
            return false;
        }
        static void AddElementMenu(BinaryTree<Student> tree)
        {
            while (true)
            {
                Console.WriteLine("Please enter First Name");
                string fName = Console.ReadLine();
                Console.WriteLine("Please enter Last Name");
                string lName = Console.ReadLine();
                Console.WriteLine("Please enter Parrent Name");
                string pName = Console.ReadLine();
                Console.WriteLine("Enter Test value of node");
                int value = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please enter Test Name");
                string testName = Console.ReadLine();
                tree.Add(new Student(fName, lName, pName, testName, value, System.DateTime.Now));
                if (WantToExit())
                {
                    break;
                }
            }
        }

        static void RemoveElementMenu(BinaryTree<Student> tree)
        {
            while (true)
            {
                Console.WriteLine("Please enter test value to Remove element");
                int value = Int32.Parse(Console.ReadLine());
                tree.Remove(new Student("firstName", "lastName",
                "parrentName", "testName", value, new System.DateTime(2019, 10, 10)));
                if (WantToExit())
                {
                    break;
                }

            }
        }
        public static void MainMenu()
        {
            BinaryTree<Student> tree = new BinaryTree<Student>();
            tree.AddNodeEvent += TreeEventsHandler<Student>.AddElement;
            tree.RemoveNodeEvent += TreeEventsHandler<Student>.RemoveElement;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter \n A to Add element to the tree \n F to Find element in the tree\n" +
                        " R to Remove element from tree\n");
                    string choice = Console.ReadLine();
                    switch (choice[0])
                    {
                        case 'A':
                            try
                            {
                                AddElementMenu(tree);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERROR: \n Message: {ex.Message}");
                                Console.WriteLine("Please enter valid value to Add Node");
                                AddElementMenu(tree);
                                continue;
                            }
                            break;
                        case 'F':
                            while (true)
                            {
                                bool found = FindNodeMenu(tree);
                                if (found)
                                {
                                    Console.WriteLine($"Node is Found");
                                }
                                else
                                {
                                    Console.WriteLine("tree does not contain this node");
                                }
                                if (WantToExit())
                                    break;
                            }
                            break;
                        case 'R':
                            try
                            {
                                RemoveElementMenu(tree);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERROR: \n Message: {ex.Message}");
                                Console.WriteLine("Please enter valid value to Remove Node");
                                RemoveElementMenu(tree);
                                continue;
                            }
                            break;
                    }
                    if (WantToExit())
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: \n Message: {ex.Message}");
                    Console.WriteLine("Please, try to do one more try");
                    continue;
                }
            }
        }

        static void UsageWithoutMenu()
        {
            BinaryTree<Student> students = new BinaryTree<Student>();
            students.AddNodeEvent += TreeEventsHandler<Student>.AddElement;
            students.RemoveNodeEvent += TreeEventsHandler<Student>.RemoveElement;
            Student oleh = new Student("Oleh", "Horban", "Hennadiovich", "English test", 11, new DateTime(2019, 10, 10));
            students.Add(new Student("Olesya", "Pashko", "Vitaliivna", "English test", 10, new DateTime(2019, 10, 10)));
            students.Add(new Student("Olha", "Pupenko", "Vivtorivna", "English test", 8, new DateTime(2019, 10, 10)));
            students.Add(new Student("Olana", "Cklarenko", "Olehivna", "English test", 3, new DateTime(2019, 10, 10)));
            students.Add(new Student("Katya", "Smit", "Hlebiva", "English test", 5.5, new DateTime(2019, 10, 10)));
            students.Add(oleh);
            students.Add(new Student("Victor", "Lish", "Myshailovich", "English test", 2, new DateTime(2019, 10, 10)));
            students.Remove(oleh);
            Console.WriteLine("In Descending Order");
            Console.WriteLine(students.ToStringDescending());
        }
        static void Main(string[] args)
        {
            //MainMenu();
            UsageWithoutMenu();
        }
    }
}
