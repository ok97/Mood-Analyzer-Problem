using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  /* UC3:- Inform user if entered Invalid Mood - In case of NULL or Empty Mood throw 
             Custom Exception MoodAnalysisException. 
             - Use Enum to differentiate the Mood Analysis Errors. 
     */
    public class MoodAnalyzer
    {
        public string message;  //instance variable
       

        public MoodAnalyzer() //Constructors
        {

        }
        public MoodAnalyzer(string message ) //parameterized constructor for intilizing instance member
        {
            this.message = message;
            //this.methodName = methodName;
        }
        public string Analyzer()  //Analyzer method find mood
        {
            try  // Handling Exception
            {
                if (this.message.Equals(string.Empty))
                {

                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");
                }
                else
                {
                    if (this.message.ToLower().Contains("happy"))
                    {
                        return "happy";
                    }
                    else
                    {
                        return "sad";
                    }
                }
            }
           catch(NullReferenceException ex)
            {
                //UC2 use -->// return ex.Message;
               // return "happy";
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_EXCEPTION, "Mood should not be null");
            }
        }
    }
}
