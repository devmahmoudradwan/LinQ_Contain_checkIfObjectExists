using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Comparer_if_newObject_alreadyExists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
             {
                 new Student() { Id=1 , Name = "Ahmed"},
                 new Student() { Id=2 , Name = "Mahmoud"}
             };

            Student temp = new Student() { Id = 2, Name = "Mahmoud" };
            
            var compare = new StudentComparer();

            //check if there is an object like this
            var IsExist = students.Contains(temp , compare);

            Console.ReadLine();
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            return x.Id == y.Id && x.Name == y.Name;
        }

         public int GetHashCode(Student obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return 0;
            }
            int idHashCode = obj.Id.GetHashCode();
            int NameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();

            return idHashCode ^ NameHashCode;
        }
    }
}
