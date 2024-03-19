namespace topic_4_programming_csharp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter total students:");
            string? studentCount = Console.ReadLine();

            int studentCounter = 0;

            bool studentCountIntegerCheck = int.TryParse(studentCount, out studentCounter);

            if (!studentCountIntegerCheck) Console.WriteLine("Please enter a valid number.");

            var studentList = new List<string>();
            var studentGrades = new List<int[]>();

            while (studentCounter != 0)
            {
                Console.WriteLine($@"Welcome to the Student Grades System!
[1]Enroll Students
[2]Enter Student Grades
[3]Show Student Grades
[4]Show Top Student
[5]Exit");

                Console.WriteLine("Enter Choice: ");
                string? userChoice = Console.ReadLine();
                int choices = 0;
                string enterAgain = "Y";

                if (userChoice is not null) choices = Int32.Parse(userChoice);

                int attempts = 1;

                switch (choices) {
                    case 1:
                        while(enterAgain == "Y" || enterAgain == "y")
                        {

                            if (attempts > studentCounter)
                            {
                                Console.WriteLine("Error: Cannot exceed total number of students.");
                                break;
                            }

                            Console.WriteLine("Enroll Student");
                            Console.WriteLine("Enter student name:");
                            string? studentName = Console.ReadLine();
                            if (studentName is not null) studentList.Add(studentName);

                            attempts++;

                            Console.WriteLine("Enter again? [Y/N]:");
                            string? response = Console.ReadLine();

                            Console.WriteLine($"Response: {response}");

                            if (response == "N" || response == "n") enterAgain = "N";
                        }
                        break;
                    case 2:
                        string[] subjects = ["Science", "Math", "English"];

                        foreach (var student in studentList)
                        {
                            int[] grades = new int[3];
                            Console.WriteLine($"Enter student Grades");
                            Console.WriteLine($"Student: {student}");

                            for(int i = 0; i < subjects.Length; i++) {
                                Console.WriteLine($"Enter grade for {subjects[i]}:");
                                string? answer = Console.ReadLine();
                                int grade = 0;
                                if (answer is not null) grade = Int32.Parse(answer);
                                grades[i] = grade;
                            }

                            studentGrades.Add(grades);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Name\t\tScience\t\tMath\t\tEnglish\t\tAve.");
                        for(int i = 0; i < studentList.Count; i++)
                        {
                            int sum = 0;
                            foreach(int grade in studentGrades[i])
                            {
                                sum += grade;
                            }

                            Console.WriteLine($"{studentList[i]}\t\t  {studentGrades[i][0]}\t\t {studentGrades[i][1]}\t\t  {studentGrades[i][2]}\t\t {sum/3}");
                        }
                        break;
                    case 4:
                        int highestAve = 0, studentAve = 0, s = 0;
                        string topStudent = "";

                        for (int i = 0; i < studentList.Count; i++)
                        {
                            foreach (int g in studentGrades[i])
                            {
                                s += g;
                            }

                            if (s > highestAve)
                            {
                                highestAve = s;
                                topStudent = studentList[i];
                            }
                        }
                        Console.WriteLine($"Top student: {topStudent}");
                        break;
                }
            }

        }
    }
}
