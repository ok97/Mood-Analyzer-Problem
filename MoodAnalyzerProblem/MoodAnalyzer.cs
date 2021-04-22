using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{  /* UC2:- Given Null Mood Should Return Happy To make this Test Case pass Handle. 
             - NULL Scenario using try catch and return Happy
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
            try  // Handling Exception
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
            catch 
            {
                return "happy";                
            }
        }
    }
}
