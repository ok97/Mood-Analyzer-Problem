using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerFactory
    {

        public static Object CreateMoodAnalyse(string className, string constructorName)
        {
            String pattern = @"." + constructorName + "$";
            //Regex regex = new Regex(pattern);
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {

                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);

                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class not found");

                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");

            }


        }


    }
}
