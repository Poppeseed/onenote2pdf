using OneNote2PDF.Library.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OneNote2PDF.Library;
using System.IO;

namespace OneNote2PDF.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ONNotebookTest and is intended
    ///to contain all ONNotebookTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ONNotebookTest
    {
        private TestContext testContextInstance;
        private ONNotebookListing notebookListing;
        private static string notebookXML;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Config.Current.TraceLevel = System.Diagnostics.TraceLevel.Off;
            notebookXML = File.ReadAllText("EntireNotebook.xml");
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            notebookListing = new ONNotebookListing(notebookXML);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        //
        #endregion


        /// <summary>
        ///A test for GetSection
        ///</summary>
        [TestMethod()]
        public void GetSectionTest()
        {
            ONNotebook target = notebookListing.GetNotebook("Shared Reference");
            string sectionName = "learning/programming";
            string expected = "Programming";
            ONSection actual;
            actual = target.GetSection(sectionName);
            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod()]
        public void GetSectionTest1()
        {
            ONNotebook target = notebookListing.GetNotebook("Shared Reference");
            string sectionName = "learning/programing";
            ONSection expected = null;
            ONSection actual;
            actual = target.GetSection(sectionName);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetSectionTest2()
        {
            ONNotebook target = notebookListing.GetNotebook("Code Notebook");
            string sectionName = "Cá nhân";
            string expected = "Cá nhân";
            ONSection actual;
            actual = target.GetSection(sectionName);
            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod()]
        public void GetSectionTest3()
        {
            ONNotebook target = notebookListing.GetNotebook("Code Notebook");
            string sectionName = "Cá nhân/Thông tin không được xâm phạm";
            string expected = "{22A89DC3-B809-4FAE-BDF1-B34AF08A0580}{1}{B0}";
            ONSection actual;
            actual = target.GetSection(sectionName);
            Assert.AreEqual(expected, actual.ID);
        }
        
    }
}
