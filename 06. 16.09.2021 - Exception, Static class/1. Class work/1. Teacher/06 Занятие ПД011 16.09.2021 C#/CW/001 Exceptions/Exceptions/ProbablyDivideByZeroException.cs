using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    // Пример создания собствы=енного класса исключения
    // сниппет Excepton -- напечатать Exception и нажать Tab
    [Serializable]
    public class ProbablyDivideByZeroException : Exception
    {
        public ProbablyDivideByZeroException() { }
        public ProbablyDivideByZeroException(string message) : base(message) { }
        public ProbablyDivideByZeroException(string message, Exception inner) : base(message, inner) { }
        protected ProbablyDivideByZeroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
