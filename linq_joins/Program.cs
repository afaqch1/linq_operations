using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_joins
{
    public class Shelf
    {
        public int no { get; set; }
        public string s_name { get; set; }
        public int b_id { get; set; }

    }
    public class book
    {
        public int b_id { get; set; }
        public string b_name { get; set; }
    }

    public class student
    {
        public int age { get; set; }
        public string name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<Shelf> shelfs = new List<Shelf>()
            {
                new Shelf(){no=3,s_name="Islamic collection",b_id=87},
                new Shelf(){no=2,s_name="Geography",b_id=32},
                new Shelf(){no=4,s_name="Science",b_id=44},
                new Shelf(){no=8,s_name="Geography",b_id=2},
                new Shelf(){no=1,s_name="History",b_id=33},
                new Shelf(){no=7,s_name="Mathematics",b_id=45}

            };

            IList<book> books = new List<book>()
            {
                new book(){b_id=87,b_name="Life of Prophet"},
                new book(){b_id=45,b_name="Linear Algebra"},
                new book(){b_id=33,b_name="Ancient China"},
                new book(){b_id=2,b_name="Rock Repulsion"},
                new book(){b_id=44,b_name="Chemical Bonding"},
                new book(){b_id=32,b_name="Layers of atmosphere"}
            };

            var result = shelfs.Join(
                books,
                s => s.b_id,
                b => b.b_id,
                (s, b) => new
                {
                    s_name = s.s_name,
                    b_name=b.b_name
                });

            foreach (var r in result)
                Console.WriteLine("{0}=={1}", r.s_name, r.b_name);

            IList<student> std = new List<student>()
            {
                new student(){age=19,name="Rahim" },
                new student(){age=17,name="Mehmat" },
                new student(){age=22,name="Musa" },
                new student(){age=20,name="Ibrahim" },
                new student(){age=15,name="Esa" },
                new student(){age=19,name="Yusuf" },

            };

            foreach (var o in std)
                Console.WriteLine("Name: " + o.name + "\tAge:" + o.age);

            bool t1 = std.All(s => s.age >= 18);
            Console.WriteLine("All students are adult: " + t1);

            bool t2 = std.Any(std => std.age >= 18);
            Console.WriteLine("Any student is adult: " + t2);


            Console.WriteLine("Enter any name to check the student is present or not:");
            string n = Console.ReadLine();
            Console.WriteLine("Enter the age of mention students:");
            int a = Convert.ToInt32(Console.ReadLine());
            student std1 = new student() { age = a, name = n };
            bool res = std.Contains(std1);

            if (res)
            {
                Console.WriteLine("Yes it is present ..");
            }
            else
                Console.WriteLine("No it is not present..");
            Console.WriteLine("================Average marks of students======================");
            List<int> marks = new List<int>() { 50, 60, 74, 99, 22, 36, 76, 69 };

            var avg = marks.Average();
            System.Console.WriteLine("Average Marks:" + avg);

            Console.WriteLine("================Count of students======================");
            Console.WriteLine("No of students=" + marks.Count());

            Console.WriteLine("================Count of students who pass the exam======================");
            Console.WriteLine("No of students who pass the exam: " + marks.Count(i=>i>35));
            Console.WriteLine("Students whose age is greater than 18=" + std.Count(s => s.age > 18));

            Console.WriteLine("=================count using query on books===================");
            int cnt = (from c in books
                       select c).Count();
            Console.WriteLine("No of books:"+cnt);

            Console.WriteLine("=================Max marks scored===================");
            Console.WriteLine("MAx marks: " + marks.Max());

            Console.WriteLine("=================sum of marks===================");
            Console.WriteLine("Total of marks: " + marks.Sum());
            Console.WriteLine("Total of marks whose marks are in even num: " + marks.Sum(s =>
            {
                if (s % 2 == 0)
                    return s;
                return 0;
            }));




        }
    }
}
