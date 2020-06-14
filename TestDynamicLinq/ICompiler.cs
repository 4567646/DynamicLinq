using System;
using System.Reflection;

namespace TestDynamicLinq
{
    public interface ICompiler
    {
        Assembly Compile(string text, params Assembly[] referencedAssemblies);
    }
}
