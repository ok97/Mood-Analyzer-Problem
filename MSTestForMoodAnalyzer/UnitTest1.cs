﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    }
}
