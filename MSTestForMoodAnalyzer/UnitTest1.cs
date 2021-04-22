using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem;

namespace MSTestForMoodAnalyzer
{
    [TestClass]
    public class UnitTest1  //Class
    {/* UC1*/
        [TestMethod]
        public void Given_Happymood_Expecting_Happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert


        }
        /* UC2:- Handle Exception if User Provides Invalid Mood
                 - Like NULL
        */
        [TestMethod]
        public void Given_Nullmood_Expecting_Exception_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            string expected = "Object Refrence not set to an instance of an object.";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert


        }
        /*UC2.1:- Given Null Mood Should Return Happy To make this Test Case pass Handle NULL Scenario using try catch and 
                    return Happ
        */
        [TestMethod]
        public void Given_Nullmood_Expecting_happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert


        }
        /* UC3.1:- NULL*/
        [TestMethod]
        public void Given_Nullmood_Using_CustomExpection_Return_Null()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            //string actual = "";
            string expected = "Mood should not be null";

            try
            {
                string actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyzerException exception)
            {
                Assert.AreEqual(expected, exception.message);  //Assert
            }
        }

        /* UC3.1:- Empty*/
        [TestMethod]
        public void Given_Emptymood_Using_CustomExpection_Return_Empty()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(""); //Create object and arrange 
            //string actual = "";
            string expected = "Mood should not be empty";

            try
            {
                string actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyzerException exception)
            {
                Assert.AreEqual(expected, exception.message);  //Assert
            }

        }
        /* UC4.1:- create default Constructor using reflection 
                  Use Reflection to Create MoodAnalyser with default Constructor
                  - Create MoodAnalyserFactory and specify static method to create MoodAnalyser Objec
                  MoodAnalyserObject to create MoodAnalyser objecty*/
        [TestMethod]
        public void Given_MoodAnalyzer_Using_Reflection_Return_DefaultConstructor()  //Method
        {
            MoodAnalyzer expected = new MoodAnalyzer(""); //Create object and arrange 
            object obj = null;
            //string actual = "";
           // string expected = "Mood should not be empty";

            try
            {
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
             obj=   factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
                
                // string actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyzerException exception)
            {
                //Assert.Equals(actual, expected);  //Assert
               
            }
            obj.Equals(expected);

        }
        /* UC5.1:- create Parameter Constructor Use Reflection to Create MoodAnalyser with Parameter Constructor.
                 - Use MoodAnalyserFactory to create MoodAnalyser Object with Message Parameneter.
         */

        [TestMethod]
        public void Given_MoodAnalyzer_Using_Reflection_Return_ParameterConstructor()  //Method
        {
            string message = "I am in happy mood";
            MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            object obj = null;
            //string actual = "";
           // string expected = "Mood should not be empty";

            try
            {
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                               

            }
            catch (MoodAnalyzerException exception)
            {
                              
            }
            obj.Equals(expected);

        }
        /* TC 6.1:- Given Happy Message Using Reflection When Proper Should Return HAPPY Mood
        */
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string message = "I am in happy mood";
            MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood");
            object obj = null;
            try
            {
                MoodAnalyzerFactory Factory = new MoodAnalyzerFactory();
                obj = Factory.InvokeAnalyzerMethod(message, "Analyzer");
            }
            catch (MoodAnalyzerException exception)
            {

                throw new Exception(exception.Message);
            }
            obj.Equals(expected);       
        }


        /* UC7.1:- Given happy Should Return Happy
         */

        [TestMethod]
        public void GivenHappyMessageWithReflectorShouldReturnHappy()
        {
            var expected = "happy";
            string mood = MoodAnalyzerFactory.SetField("HAPPY", "message");
            Assert.AreEqual(expected.ToUpper(), mood);
        }
    }
}