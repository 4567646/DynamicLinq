using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Xunit;

namespace TestDynamicLinq.Test
{
    public class CompilerTest
    {
        [Fact]
        public void Comiler_Success()
        {
            var str = @"using System;
                        namespace TestDynamicLinq {
                            public class Test
                                {
                                    public string Function(string str)
                                    {
                                        return str;
                                    }
                                }
                            }";
            var compiler = new Compiler().Compile(str,
                Assembly.Load(new AssemblyName("TestDynamicLinq")),
                typeof(object).Assembly);
            var typeName = "TestDynamicLinq.Test";

            Type type = compiler.GetType(typeName);
            object obj = Activator.CreateInstance(type);
            var result = type.InvokeMember("Function",
             BindingFlags.Default | BindingFlags.InvokeMethod,
             null,
             obj,
             new object[] { "Hello World" });
            Assert.True(result.Equals("Hello World"));

        }
        [Fact]
        public void Linq_String_Equal_GetStudents()
        {
            var str = @"using System;
                        using System.Collections.Generic;
                        using System.Linq;
                        namespace TestDynamicLinq {
                            public class StudentReporsitory
                                {
                                    public List<Student> GetStudents(List<Student> students)
                                    {
                                       return (from std in students
                                               where std.Name.Contains('уе')
                                               select std).ToList(); 
                                    }
                                }
                            }";
            var compiler = new Compiler().Compile(str,
                 Assembly.Load(new AssemblyName("TestDynamicLinq")),
                 typeof(object).Assembly,
                 Assembly.Load(new AssemblyName("System.Linq")),
                 Assembly.Load(new AssemblyName("System.Runtime")),
                 Assembly.Load(new AssemblyName("System.Collections")));
            Type type = compiler.GetType("TestDynamicLinq.StudentReporsitory");
            object obj = Activator.CreateInstance(type);
            var result = (List<Student>)type.InvokeMember("GetStudents", BindingFlags.Default | BindingFlags.InvokeMethod,
             null, obj, new object[] { Student.Init() });
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
            Assert.Equal(4, result[2].Id);

        }

    }

}
