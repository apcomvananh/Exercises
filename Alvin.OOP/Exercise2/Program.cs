using System;
using System.Linq;

namespace Exercise2
{
    internal class Program
    {
        private static void Main()
        {
            var students = GetStudents();
            var workers = GetWorkers();
            SortStudentsByGrade(students);
            Console.WriteLine("------------------------------------------------------");
            SortWorkersByMoneyPerHour(workers);
            Console.ReadLine();
        }

        private static void SortStudentsByGrade(Student[] students)
        {
            var sortedStudents = students.OrderBy(x => x.Grade);
            Console.WriteLine("List of Students sorted by grade in ascending");
            Console.WriteLine("First name \t Last name \t Grade");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} \t {1} \t {2}", student.FirstName, student.LastName, student.Grade);
            }
        }

        private static void SortWorkersByMoneyPerHour(Worker[] workers)
        {
            var sortedWorkers = from w in workers select new { firstName = w.FirstName, lastName = w.LastName, moneyPerHour = w.MoneyPerHour() };
            sortedWorkers = sortedWorkers.OrderByDescending(x => x.moneyPerHour);
            Console.WriteLine("List of Workers sorted by money per hour in descending");
            Console.WriteLine("First name \t Last name \t Money per hour");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} \t {1} \t {2}", worker.firstName, worker.lastName, worker.moneyPerHour);
            }
        }

        private static Student[] GetStudents()
        {
            var students = new Student[10];
            students[0] = new Student("Student 1", "Student 1", 10);
            students[1] = new Student("Student 2", "Student 2", 9);
            students[2] = new Student("Student 3", "Student 3", 8);
            students[3] = new Student("Student 4", "Student 4", 7);
            students[4] = new Student("Student 5", "Student 5", 6);
            students[5] = new Student("Student 6", "Student 6", 5);
            students[6] = new Student("Student 7", "Student 7", 4);
            students[7] = new Student("Student 8", "Student 8", 3);
            students[8] = new Student("Student 9", "Student 9", 2);
            students[9] = new Student("Student 10", "Student 10", 1);
            return students;
        }

        private static Worker[] GetWorkers()
        {
            var workers = new Worker[10];
            workers[0] = new Worker("Worker 1", "Worker 1", 400, 8);
            workers[1] = new Worker("Worker 2", "Worker 2", 500, 10);
            workers[2] = new Worker("Worker 3", "Worker 3", 600, 10);
            workers[3] = new Worker("Worker 4", "Worker 4", 700, 12);
            workers[4] = new Worker("Worker 5", "Worker 5", 1000, 8);
            workers[5] = new Worker("Worker 6", "Worker 6", 1200, 12);
            workers[6] = new Worker("Worker 7", "Worker 7", 400, 4);
            workers[7] = new Worker("Worker 8", "Worker 8", 600, 4);
            workers[8] = new Worker("Worker 9", "Worker 9", 700, 5);
            workers[9] = new Worker("Worker 10", "Worker 10", 900, 8);
            return workers;
        }
    }
}