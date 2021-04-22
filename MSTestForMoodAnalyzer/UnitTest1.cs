﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem;

namespace MSTestForMoodAnalyzer
{
    [TestClass]
    public class UnitTest1  //Class
    {/* TC 1.1:- Given “I am in Sad Mood” message Should Return SAD
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
    }
}
