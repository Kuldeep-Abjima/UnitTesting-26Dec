using class_Library;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In ClassInitializa() method");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
           

        }
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() method");

            WriteDescription(this.GetType());
            if (TestContext.TestName.StartsWith("FileNameDoseExist"))
            {
                SetGoodFileName();
                if(!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("creating file: " + _GoodFileName);
                    //create the 'good' file.
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }
        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In Cleanup() method");
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file: "+ _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        [TestMethod]
        [Description("Check to see if a file exists")]
         public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            SetGoodFileName();
            if (!string.IsNullOrEmpty(_GoodFileName))
            {
                //create the 'Good' file.
                File.AppendAllText(_GoodFileName, "Some text");
            }

            TestContext.WriteLine(@"Checking -: " + _GoodFileName);

            fromCall = fp.FileExits(_GoodFileName);
            //delete file
            //if (File.Exists(_GoodFileName))
            //{
            //    File.Delete(_GoodFileName);
            //}
            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        [Description("Check to see if a file doesn't exists")]

        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            TestContext.WriteLine(@"Checking -:" + BAD_FILE_NAME);
            fromCall = fp.FileExits(BAD_FILE_NAME);
            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [Description("Check for a thrown ArguementNullException using")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            TestContext.WriteLine(@"Checking For a null file using attributes");

            FileProcess fp = new FileProcess();
            fp.FileExits("");

        }
        [TestMethod]
        [Description("Check for a thrown ArguementNullException using try...catch.")]

        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                TestContext.WriteLine(@"Checking For a null file ");

                fp.FileExits("");
            }
            catch (ArgumentNullException ex)
            {
                return;
            }
            Assert.Fail("Call ro FileExists() dod NOT throw an ArguementNullExpection.");
        }
    }
}