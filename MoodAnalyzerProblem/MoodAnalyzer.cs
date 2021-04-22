using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  /* UC1:-  Given a Message, ability to analyse and respond Happy or Sad Mood
             - Create MoodAnalyser Object - Call analyseMood function with message as 
             parameter and return Happy or Sad Mood.
   */
    public class MoodAnalyzer
    {
        public string message;  //instance variable      

        
        public MoodAnalyzer(string message ) //parameterized constructor for intilizing instance member
        {
            this.message = message;
           
        }
        public string Analyzer()  //Analyzer method find mood
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
    }
}
