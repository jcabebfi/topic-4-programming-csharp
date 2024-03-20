namespace topic_4_programming_csharp
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public Dictionary<string, double> Grades = new Dictionary<string, double>();

            public Student (string name)
            {
                this.Name = name;
            }

            public void SetGrade(string subject, double grade)
            {
                Grades.Add(subject, grade);
            }

            public double GetGrade(string subject)
            {
                return Grades[subject];
            }

            public double CalculateAverageGrade()
            {
                double sum = 0;

                foreach(KeyValuePair<string, double> grade in Grades)
                    sum += grade.Value;

                return sum/Grades.Count;
            }
        }

        public enum Subjects { Science, English, Math };
        
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter total students:");
            string? studentCount = Console.ReadLine();
            int studentCounter = 0;
            if (studentCount is not null) studentCounter = Int32.Parse(studentCount);

            var students = new List<Student>();

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
                            if (studentName is not null)
                            {
                                Student student = new Student(studentName);
                                students.Add(student);
                            }

                            attempts++;

                            Console.WriteLine("Enter again? [Y/N]:");
                            string? response = Console.ReadLine();

                            if (response == "N" || response == "n") enterAgain = "N";
                        }
                        break;
                    case 2:
                        foreach (var student in students)
                        {
                            Console.WriteLine($"Enter student Grades");
                            Console.WriteLine($"Student: {student.Name}");

                            foreach(var subject in Enum.GetNames(typeof(Subjects))) {
                                Console.WriteLine($"Enter grade for {subject}:");
                                string? answer = Console.ReadLine();
                                int grade = 0;
                                if (answer is not null) grade = Int32.Parse(answer);

                                student.SetGrade(subject, grade);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Name\t\tScience\t\tMath\t\tEnglish\t\tAve.");
                        foreach(var student in students)
                        {
                            string result = $"{student.Name}\t\t";

                            foreach(var subject in Enum.GetNames<Subjects>())
                            {
                                double grade = student.GetGrade(subject.ToString());
                                result += $"{grade}\t\t";
                            }
                            result += student.CalculateAverageGrade();
                            Console.WriteLine(result);
                        }
                        break;
                    case 4:
                        double highestAverage = 0;
                        string topStudent = "";

                        foreach(var student in students)
                        {
                            if (student.CalculateAverageGrade() > highestAverage)
                            {
                                highestAverage = student.CalculateAverageGrade();
                                topStudent = student.Name;
                            }
                        }

                        Console.WriteLine($"Top student: {topStudent}");
                        break;
                }
            }

        }
    }
}
