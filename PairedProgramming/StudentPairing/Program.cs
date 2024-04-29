namespace StudentPairing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> studentNames = new List<string>();

            bool finishedEnteringNames = false;

            while (!finishedEnteringNames)
            {
                Console.WriteLine("Type 'pair' to pair students, or type a student name: ");
                string userEntry = Console.ReadLine();
                switch (userEntry)
                {
                    case "pair":
                        finishedEnteringNames = true;
                        break;
                    default:
                        studentNames.Add(userEntry);
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Pairing students...\n\n");

            //next bit is optional but awesome - randomize the order!
            Random rng = new Random();
            studentNames = studentNames.OrderBy(x => rng.Next()).ToList();

            Console.WriteLine("Student Groups\n----------------\n");
            //Even number of students
            if (studentNames.Count % 2 == 0)
            {
                for (int i = 0; i < studentNames.Count; i++)
                {
                    Console.WriteLine(studentNames[i]);
                    if (i == 1 || i % 2 != 0)
                    {
                        Console.WriteLine("\n----------------\n");
                    }
                }
            }
            //odd number of students
            else
            {
                for (int i = 0; i < studentNames.Count; i++)
                {
                    Console.WriteLine(studentNames[i]);
                    if ((i == 1 || i % 2 != 0) && i != studentNames.Count - 2)
                    {
                        Console.WriteLine("\n----------------\n");
                    }
                }
            }
        }
    }
}
