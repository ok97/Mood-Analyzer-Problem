using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem;

namespace MSTestForMoodAnalyzer
{
    [TestClass]
    public class UnitTest1  //Class
    {
        [TestMethod]
        public void Given_Happymood_Expecting_Happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert


        }

        public void Given_Happymood_Expecting_Sad_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in sad mood"); //Create object and arrange 
            string expected = "sad";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert


        }
    }
}
