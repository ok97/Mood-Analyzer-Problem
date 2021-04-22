using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalysisException : Exception
    {

        public enum ExceptionType { EMPTY, NULL, NO_SUCH_METHOD, NO_SUCH_CLASS }

        public readonly ExceptionType type;
        public MoodAnalysisException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
