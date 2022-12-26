using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{

    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In AssemblyInitialized() method");
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {

        }
    }
}
