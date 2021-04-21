using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  /* 
   UC2:- Handle Exception if User Provides Invalid Mood
         - Like NULL
   TC2.1:- Given Null Mood Should Return Happy To make this Test Case pass Handle NULL Scenario using try catch and 
           return Happy
   */
    public class MoodAnalyzer
    {
        string message;  //instance variable

        public MoodAnalyzer() //Constructors
        {

        }
        public MoodAnalyzer(string message) //parameterized constructor for intilizing instance member
        {
            this.message = message;
        }
        public string Analyzer()  //Analyzer method find mood
        {//Handling Exception
            try
            {
                if (this.message.Equals(string.Empty))
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");
                if (this.message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            catch (MoodAnalyzerException ex)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be null");
            }
        }
    }
}