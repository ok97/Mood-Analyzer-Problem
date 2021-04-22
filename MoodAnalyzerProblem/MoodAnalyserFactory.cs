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
    {/* UC4:- create default Constructor Use Reflection to Create MoodAnalyser with default Constructor
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
                    var res = Activator.CreateInstance(moodAnalyzerType);
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
        public object CreateMoodAnalyzerParameterObject(string className, string constructor, string message)
        {
            Type type = typeof(MoodAnalyzer);

            if (type.Name.Equals(className) || type.FullName.Equals(className))  //check class naem same or not
            {
                if (type.Name.Equals(constructor))
                {
                    //MoodAnalyzerProblem.MoodAnalyzer
                    //string pattern = @"." + constructor + "$";
                    // Match result = Regex.Match(className, pattern); //regex predefine class .pattern matching store result suppose pattern matching then create object than an constructor

                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) }); //get constructor fetching one construct bsae on the  he feth string parameter constructor fetching 
                    var obj = constructorInfo.Invoke(new object[] { message }); //create object that Parameter Constructor by passing message
                    return obj;
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");//Constructor name not maching that time we run
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, "class not found");//Constructor name not maching that time we run
            }
        }

        /* UC6:- Use Reflection to invoke Method –analyseMood 
                 - Use Reflector to Invoke Method
        */
        public string InvokeAnalyzerMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzer);
               
                
                MethodInfo analyzerMoodInfo = type.GetMethod(methodName);
                MoodAnalyzerFactory Factory = new MoodAnalyzerFactory();
               object moodAnalyzerObject = Factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                object mood = analyzerMoodInfo.Invoke(moodAnalyzerObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }


        /* UC7:- Use Reflection to change mood dynamicall
                 - User Reflector to Modify mood dynamically
        */

        public static string SetField(string message, string fieldName)
        {         

                MoodAnalyzerFactory Fact = new MoodAnalyzerFactory();
                MoodAnalyzer obj = (MoodAnalyzer)Fact.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
                Type type = typeof(MoodAnalyzer);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (field!= null)
                {
                    if (message==null)
                    {
                        throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_MESSAGE, "Message should not be null");
                    }
                    field.SetValue(obj, message);
                    return obj.message;
                }
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.FIELD_NULL, "FieldName should not be null");
                  
                
            
        }
    }
}
