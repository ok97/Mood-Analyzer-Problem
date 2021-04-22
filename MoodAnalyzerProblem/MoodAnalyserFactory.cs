using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lucene.Net.Analysis;
using System.Reflection;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerFactory
    {/* UC4:- create default Constructor - Use Reflection to Create MoodAnalyser with default Constructor
              - Create MoodAnalyserFactory and specify static method to create MoodAnalyser Objec
              MoodAnalyserObject to create MoodAnalyser object 
        */
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            //MoodAnalyzerProblem.MoodAnalyzer
            string pattern = @"." + constructor + "$";
            Match result = Regex.Match(className, pattern); //regex predefine class .pattern matching store result suppose pattern matching then create object than an constructor

            if (result.Success) //success boolen property sucess hold true value other wise false //classma,e and patytern both are matching
            {
                try
                {    //constructor and classname both are matching

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyzerType); //Activator class
                    return res;
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, "class not found");//class name not maching that time we run
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");//Constructor name not maching that time we run
            }
        }

        /* UC5:- create Parameter Constructor Use Reflection to Create MoodAnalyser with Parameter Constructor.
                 - Use MoodAnalyserFactory to create MoodAnalyser Object with Message Parameneter.
         */
        public Object CreateMoodAnalyzerParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {

                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorObject = type.GetConstructor(new[] { typeof(string) });
                    Object instance = constructorObject.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, "Class not found");

            }
        }
        
    }
}
