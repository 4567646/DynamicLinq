using System;
using System.Collections.Generic;
using System.Text;

namespace TestDynamicLinq
{
    public class Student
    {
        public Student(int id, string name, int sex, DateTime birthday)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Birthday = birthday;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreateDate { get; set; }
        public static List<Student> Init() => new List<Student> {
            new Student(1,"张三",1,DateTime.Parse("2020-06-14")),
            new Student(2,"张四",1,DateTime.Parse("2020-06-12")),
            new Student(3,"李四",1,DateTime.Parse("2020-06-13")),
            new Student(4,"张一三",1,DateTime.Parse("2020-06-14")),
            new Student(5,"里一",1,DateTime.Parse("2020-05-14")),
            new Student(6,"速度",1,DateTime.Parse("2020-01-14")),

        };
    }
}
