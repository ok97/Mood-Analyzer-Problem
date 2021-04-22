using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem;

namespace MSTestForMoodAnalyzer
{
     [TestClass]
    public class UnitTest1  //Class
    {
        /* TC 1.1:- Given “I am in Sad Mood” message Should Return SAD
                    - analyseMood method can just return SAD to pass this Test Case (TC)
        */
        [TestMethod]
        public void AnalyseMood_ShouldReturn_Sad()       
        {
            //Arraneg
            string expected = "sad";
            MoodAnalyzer obj = new MoodAnalyzer("I am in sad Mood");
            //Act
            string actual = obj.Analyzer();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /* TC 1.2:- Given “I am in Any Mood” message Should Return HAPPY.
                    - To make the Test case pass analyseMood method need to check for Sad else return HAPPY
       */
        [TestMethod]
        public void Given_Happymood_Expecting_Happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert
        }

        /* UC2:- Handle Exception if User Provides Invalid Mood
         */
        [TestMethod]
        public void Given_Nullmood_Expecting_Exception_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            string expected = "Object reference not set to an instance of an object.";

            string actual = mood.Analyzer();    //act

           Assert.AreEqual(expected, actual);  //Assert
        }

        /* TC 2.1:- Given Null Mood Should Return Happy.
                   - To make this Test Case pass Handle NULL Scenario using try catch and return Happy.
        */
        [TestMethod]
        public void Given_Nullmood_Expecting_happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act

            Assert.AreEqual(expected, actual);  //Assert
        }

        /* TC 3.1:- NULL Given NULL Mood Should Throw MoodAnalysisException
                    To pass this Test Case in try catch block throw MoodAnalysisException
         */
        [TestMethod]
        public void Given_Nullmood_Using_CustomExpection_Return_Null()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            //string actual = "";
            string actual = "";

            try
            {
                 actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyzerException exception)
            {
                Assert.AreEqual("Mood should not be null", exception.Message);  //Assert
            }
        }

        /* TC 3.2:- Empty Given Empty Mood Should Throw MoodAnalysisException indicating Empty Mood 
                   - Handle Empty Mood Scenario throw MoodAnalysisException and inform user of the EmptyMood
                   HINT: Use Enum to EMPTY or NULL
        */
        [TestMethod]
        public void Given_Emptymood_Using_CustomExpection_Return_Empty()  //Method
        {           
            
            string actual = "";

            try
            {
                string message = string.Empty;
                MoodAnalyzer mood = new MoodAnalyzer(message); //Create object and arrange 
                actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyzerException exception)
            {
                Assert.AreEqual("Mood should not be empty", exception.Message);  //Assert
            }

        }
        /* TC 4.1:- Given MoodAnalyser Class Name Should Return MoodAnalyser Object
                    - Create MoodAnalyser Factory to create a MoodAnalyser Object with default constructor
                    - Use Equals method in MoodAnalyser to check if the two objects are equal.
                    - Test passes if they are equal.
        */

        [TestMethod]
        public void GivenMoodAnalyseClass_ShouldReturn_MoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
            object obj = factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }

        /* TC 4.2:- Given Class Name When Improper Should Throw MoodAnalysisException
                    - To pass this test case pass wrong class name catch Exception and throw 
                    Exception indicating No Such Class Error.
         */
        [TestMethod]
        public void MoodAnalyseClass_GivenWrongClassName_ShouldReturn_NOClassException()
        {
            string expected = "Class not found";
            try
            {
                string message = null;              
                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                object obj = factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        /*TC 4.3:- Given Class When Constructor Not Proper Should Throw MoodAnalysisException.
                  - To pass this Test Case pass wrong Constructor parameter, catch the Exception and throw indicating No 
                   Such Method Error. 
        */
        [TestMethod]
        public void MoodAnalyseClass_GivenWrongConstructorName_ShouldReturn_NoConstructorException()
        {
            string expected = "Constructor not found";
            try
            {
                string message = null;                
                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                object obj = factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }

        //[TestMethod]
        //public void Given_MoodAnalyzer_Using_Reflection_Return_DefaultConstructor()  //Method
        //{
        //    string message = "I am in happy mood";
        //    MoodAnalyzer expected = new MoodAnalyzer(""); //Create object and arrange 
        //    object obj = null;
        //    //string actual = "";
        //   // string expected = "Mood should not be empty";

        //    try
        //    {

        //        MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
        //        obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
        //        // obj =   factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");

        //        // string actual = mood.Analyzer();    //act

        //    }
        //    catch (MoodAnalyzerException exception)
        //    {
        //        //Assert.Equals(actual, expected);  //Assert

        //    }
        //    obj.Equals(expected);

        //}

        /* TC 5.1:- Given MoodAnalyser When Proper Return MoodAnalyser Object.
                    - Use MoodAnalyser Factory to create a MoodAnalyser Object with Parameter constructor.
                    - Use Equals method in MoodAnalyser to check if the two objects are equal.
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

        /* TC 5.2:- Given Class Name When Improper Should Throw MoodAnalysisException.
                    - To pass this test case pass wrong class name catch Exception and throw 
                      Exception indicating No Such Class Error.
         */
        [TestMethod]
        public void MoodAnalyseClass_GivenWrongClassName_ShouldReturn_NoClassException_UsingParameterizedConstrucor()
        {
            string expected = "Class not found";
            object obj = null;
            try
            {
                string message = "Happy";
                
                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }

        /* TC 5.3:- Given Class When Constructor Not Proper Should Throw MoodAnalysisException.
                    - To pass this Test Case pass wrong Constructor parameter, catch the 
                    Exception and throw indicating No Such Method Error.
         */
        [TestMethod]
        public void MoodAnalyseClass_GivenWrongConstructorName_ShouldReturn_NoConstructorException_UsingParameterizedConstrucor()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                string message = "Happy";
                
                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }

    }
}
