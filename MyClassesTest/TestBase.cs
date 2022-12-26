using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    public class TestBase
    {
        protected string _GoodFileName;

        public TestContext TestContext { get; set; }

        protected void WriteDescription(Type typ)
        {
            string testName = TestContext.TestName;

            //find the test method currently execuiting
            MemberInfo method = typ.GetMethod(testName);
            if(method != null)
            {
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if(attr != null)
                {
                    //cast the attribute to a descriptionAttribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;
                    // Display the test description
                    TestContext.WriteLine("Test deciption: " + dattr.Description);
                }
            }

        }
        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment
                    .GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
