using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  /* UC1:- Given a Message, ability to analyse and respond Happy or Sad Mood 
      - Create MoodAnalyser Object - Call analyseMood function with message as parameter and return Happy or Sad Mood
    TC1.1:- Given “I am in Sad Mood” message Should Return SAD analyseMood method can just return 
             SAD to pass this Test Case (TC)
    TC1.2:- Given “I am in Any Mood” message Should Return HAPPY To make the Test case pass analyseMood method need to check 
            for Sad else return HAPPY
    Refactor the code to take the mood message in Constructor 
           - Note: - MoodAnalyser will have a message Field - MoodAnalyser will have 2 Constructors 
           – Default - MoodAnalyser() and with Parameters – MoodAnalyser(message) 
           - analyseMood method will change to support no parameters and use message Field defined for the Class
    Repeat TC1.1:- Given “I am in Sad Mood” message in Constructor Should Return SAD 
            To pass this Test Case when calling analyseMood method with no params should return SAD
          - analyseMood method will change to support no parameters and use message Field defined for the Class
    Repeat TC1.2:- Given “I am in Happy Mood” message in Constructor Should Return SAD 
            To pass this Test Case when calling analyseMood method with no params should return HAPPY


   */
    public class MoodAnalyzer
    {
        string message;  //instance variable

        /* 
         */
        public MoodAnalyzer() //Constructors
        {

        }
        public MoodAnalyzer(string message) //parameterized constructor for intilizing instance member
        {
            this.message = message;
        }
        public string Analyzer()  //Analyzer method find mood
        {
            if(this.message.ToLower().Contains("happy"))
            {
                return "happy";
            }
            else
            {
                return "sad";
            }

        }
        

        
    }
}
