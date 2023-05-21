using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Library.TextParsers
{
    public interface IInputTextParser<T>
    {
        List<T> Parse(string input);
    }
}
